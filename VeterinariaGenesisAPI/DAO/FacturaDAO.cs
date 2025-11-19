using System.Data;
using Microsoft.Data.SqlClient;
using VeterinariaGenesisAPI.Data;
using VeterinariaGenesisAPI.DAO.Interfaces;
using VeterinariaGenesisAPI.Models.DTOs;

namespace VeterinariaGenesisAPI.DAO;

public class FacturaDAO : IFacturaDAO
{
    private readonly ConexionDB _conexionDB;

    public FacturaDAO(ConexionDB conexionDB)
    {
        _conexionDB = conexionDB;
    }

    public async Task<int> CrearDesdeCitaAsync(int idCita)
    {
        await using var connection = _conexionDB.GetConnection();
        await connection.OpenAsync();

        await using var command = new SqlCommand(Procedimientos.Factura_CrearDesdeCita, connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add(new SqlParameter("@ID_Cita", SqlDbType.Int) { Value = idCita });

        try
        {
            var result = await command.ExecuteScalarAsync();
            return result != null ? Convert.ToInt32(result) : 0;
        }
        catch (SqlException ex) when (ex.Number == 50000) // RAISERROR
        {
            throw new InvalidOperationException(ex.Message, ex);
        }
    }

    public async Task AgregarItemAsync(FacturaItemDto dto)
    {
        await using var connection = _conexionDB.GetConnection();
        await connection.OpenAsync();

        await using var command = new SqlCommand(Procedimientos.Factura_AgregarItem, connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add(new SqlParameter("@ID_Factura", SqlDbType.Int) { Value = dto.ID_Factura });
        command.Parameters.Add(new SqlParameter("@ID_Servicio", SqlDbType.Int) { Value = dto.ID_Servicio });
        command.Parameters.Add(new SqlParameter("@Cantidad", SqlDbType.Int) { Value = dto.Cantidad });

        await command.ExecuteNonQueryAsync();
    }

    public async Task PagarAsync(FacturaPagoDto dto)
    {
        await using var connection = _conexionDB.GetConnection();
        await connection.OpenAsync();

        await using var command = new SqlCommand(Procedimientos.Factura_Pagar, connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add(new SqlParameter("@ID_Factura", SqlDbType.Int) { Value = dto.ID_Factura });
        command.Parameters.Add(new SqlParameter("@MontoPagado", SqlDbType.Decimal) { Value = dto.MontoPagado, Precision = 10, Scale = 2 });
        command.Parameters.Add(new SqlParameter("@MetodoPago", SqlDbType.VarChar, 50) { Value = dto.MetodoPago });

        try
        {
            await command.ExecuteNonQueryAsync();
        }
        catch (SqlException ex) when (ex.Number == 50000) // RAISERROR
        {
            throw new InvalidOperationException(ex.Message, ex);
        }
    }

    public async Task<FacturaDto?> BuscarPorIDAsync(int id)
    {
        await using var connection = _conexionDB.GetConnection();
        await connection.OpenAsync();

        await using var command = new SqlCommand(Procedimientos.Factura_BuscarPorID, connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add(new SqlParameter("@ID_Factura", SqlDbType.Int) { Value = id });

        await using var reader = await command.ExecuteReaderAsync();

        // Leer el primer conjunto de resultados: datos de la factura
        if (!await reader.ReadAsync())
            return null;

        var factura = new FacturaDto
        {
            ID_Factura = reader.GetInt32(reader.GetOrdinal("ID_Factura")),
            Fecha = reader.GetDateTime(reader.GetOrdinal("Fecha")),
            Total = reader.GetDecimal(reader.GetOrdinal("Total")),
            ID_Propietario = reader.GetInt32(reader.GetOrdinal("ID_Propietario")),
            ID_Cita = reader.IsDBNull(reader.GetOrdinal("ID_Cita")) ? null : reader.GetInt32(reader.GetOrdinal("ID_Cita")),
            EstadoPago = reader.GetString(reader.GetOrdinal("EstadoPago"))?.Trim() ?? string.Empty,
            Detalles = new List<FacturaDetalleDto>()
        };

        // Avanzar al segundo conjunto de resultados: detalles de la factura
        if (await reader.NextResultAsync())
        {
            while (await reader.ReadAsync())
            {
                factura.Detalles.Add(new FacturaDetalleDto
                {
                    ID_FacturaDetalle = reader.GetInt32(reader.GetOrdinal("ID_FacturaDetalle")),
                    ID_Factura = reader.GetInt32(reader.GetOrdinal("ID_Factura")),
                    ID_Servicio = reader.GetInt32(reader.GetOrdinal("ID_Servicio")),
                    Cantidad = reader.GetInt32(reader.GetOrdinal("Cantidad")),
                    PrecioUnitario = reader.GetDecimal(reader.GetOrdinal("PrecioUnitario")),
                    Subtotal = reader.GetDecimal(reader.GetOrdinal("Subtotal"))
                });
            }
        }

        return factura;
    }

    public async Task<List<FacturaDto>> ListarAsync()
    {
        var resultados = new List<FacturaDto>();

        await using var connection = _conexionDB.GetConnection();
        await connection.OpenAsync();

        await using var command = new SqlCommand(Procedimientos.Factura_Listar, connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        await using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            var factura = new FacturaDto
            {
                ID_Factura = reader.GetInt32(reader.GetOrdinal("ID_Factura")),
                Fecha = reader.GetDateTime(reader.GetOrdinal("Fecha")),
                Total = reader.GetDecimal(reader.GetOrdinal("Total")),
                ID_Propietario = reader.GetInt32(reader.GetOrdinal("ID_Propietario")),
                ID_Cita = reader.IsDBNull(reader.GetOrdinal("ID_Cita")) ? null : reader.GetInt32(reader.GetOrdinal("ID_Cita")),
                EstadoPago = reader.GetString(reader.GetOrdinal("EstadoPago"))?.Trim() ?? string.Empty,
                Detalles = new List<FacturaDetalleDto>()
            };

            resultados.Add(factura);
        }

        await reader.CloseAsync();

        // Cargar detalles para cada factura usando stored procedure
        foreach (var factura in resultados)
        {
            await using var detallesCommand = new SqlCommand(Procedimientos.Factura_DetallesPorID, connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            detallesCommand.Parameters.Add(new SqlParameter("@ID_Factura", SqlDbType.Int) { Value = factura.ID_Factura });

            await using var detallesReader = await detallesCommand.ExecuteReaderAsync();
            while (await detallesReader.ReadAsync())
            {
                factura.Detalles.Add(new FacturaDetalleDto
                {
                    ID_FacturaDetalle = detallesReader.GetInt32(detallesReader.GetOrdinal("ID_FacturaDetalle")),
                    ID_Factura = detallesReader.GetInt32(detallesReader.GetOrdinal("ID_Factura")),
                    ID_Servicio = detallesReader.GetInt32(detallesReader.GetOrdinal("ID_Servicio")),
                    Cantidad = detallesReader.GetInt32(detallesReader.GetOrdinal("Cantidad")),
                    PrecioUnitario = detallesReader.GetDecimal(detallesReader.GetOrdinal("PrecioUnitario")),
                    Subtotal = detallesReader.GetDecimal(detallesReader.GetOrdinal("Subtotal"))
                });
            }
            await detallesReader.CloseAsync();
        }

        return resultados;
    }
}
