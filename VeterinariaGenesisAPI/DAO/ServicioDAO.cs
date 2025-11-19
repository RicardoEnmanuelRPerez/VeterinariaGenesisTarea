using System.Data;
using Microsoft.Data.SqlClient;
using VeterinariaGenesisAPI.Data;
using VeterinariaGenesisAPI.DAO.Interfaces;
using VeterinariaGenesisAPI.Models.DTOs;

namespace VeterinariaGenesisAPI.DAO;

public class ServicioDAO : IServicioDAO
{
    private readonly ConexionDB _conexionDB;

    public ServicioDAO(ConexionDB conexionDB)
    {
        _conexionDB = conexionDB;
    }

    public async Task<List<ServicioDto>> ListarAsync()
    {
        var resultados = new List<ServicioDto>();

        await using var connection = _conexionDB.GetConnection();
        await connection.OpenAsync();

        await using var command = new SqlCommand(Procedimientos.Servicio_Listar, connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        await using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            resultados.Add(new ServicioDto
            {
                ID_Servicio = reader.GetInt32(reader.GetOrdinal("ID_Servicio")),
                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion")) ? null : reader.GetString(reader.GetOrdinal("Descripcion")),
                Costo = reader.GetDecimal(reader.GetOrdinal("Costo"))
            });
        }

        return resultados;
    }

    public async Task<ServicioDto?> BuscarPorIDAsync(int id)
    {
        await using var connection = _conexionDB.GetConnection();
        await connection.OpenAsync();

        await using var command = new SqlCommand(Procedimientos.Servicio_BuscarPorID, connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add(new SqlParameter("@ID_Servicio", SqlDbType.Int) { Value = id });

        await using var reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            return new ServicioDto
            {
                ID_Servicio = reader.GetInt32(reader.GetOrdinal("ID_Servicio")),
                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion")) ? null : reader.GetString(reader.GetOrdinal("Descripcion")),
                Costo = reader.GetDecimal(reader.GetOrdinal("Costo"))
            };
        }

        return null;
    }

    public async Task<int> CrearAsync(ServicioCreateDto dto)
    {
        await using var connection = _conexionDB.GetConnection();
        await connection.OpenAsync();

        await using var command = new SqlCommand(Procedimientos.Servicio_Crear, connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 100) { Value = dto.Nombre });
        command.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 250) { Value = (object?)dto.Descripcion ?? DBNull.Value });
        command.Parameters.Add(new SqlParameter("@Costo", SqlDbType.Decimal) { Value = dto.Costo, Precision = 10, Scale = 2 });

        var result = await command.ExecuteScalarAsync();
        return result != null ? Convert.ToInt32(result) : 0;
    }

    public async Task ActualizarAsync(ServicioUpdateDto dto)
    {
        await using var connection = _conexionDB.GetConnection();
        await connection.OpenAsync();

        await using var command = new SqlCommand(Procedimientos.Servicio_Actualizar, connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add(new SqlParameter("@ID_Servicio", SqlDbType.Int) { Value = dto.ID_Servicio });
        command.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 100) { Value = dto.Nombre });
        command.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 250) { Value = (object?)dto.Descripcion ?? DBNull.Value });
        command.Parameters.Add(new SqlParameter("@Costo", SqlDbType.Decimal) { Value = dto.Costo, Precision = 10, Scale = 2 });

        await command.ExecuteNonQueryAsync();
    }

    public async Task EliminarAsync(int id)
    {
        await using var connection = _conexionDB.GetConnection();
        await connection.OpenAsync();

        await using var command = new SqlCommand(Procedimientos.Servicio_Eliminar, connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add(new SqlParameter("@ID_Servicio", SqlDbType.Int) { Value = id });

        await command.ExecuteNonQueryAsync();
    }
}

