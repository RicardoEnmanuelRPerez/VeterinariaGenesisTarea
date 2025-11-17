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
}
