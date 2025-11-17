using System.Data;
using Microsoft.Data.SqlClient;
using VeterinariaGenesisAPI.Data;
using VeterinariaGenesisAPI.DAO.Interfaces;
using VeterinariaGenesisAPI.Models.DTOs;

namespace VeterinariaGenesisAPI.DAO;

public class PropietarioDAO : IPropietarioDAO
{
    private readonly ConexionDB _conexionDB;

    public PropietarioDAO(ConexionDB conexionDB)
    {
        _conexionDB = conexionDB;
    }

    public async Task<int> CrearAsync(PropietarioCreateDto dto)
    {
        await using var connection = _conexionDB.GetConnection();
        await connection.OpenAsync();

        await using var command = new SqlCommand(Procedimientos.Propietario_Crear, connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 100) { Value = dto.Nombre });
        command.Parameters.Add(new SqlParameter("@Apellidos", SqlDbType.VarChar, 120) { Value = dto.Apellidos });
        command.Parameters.Add(new SqlParameter("@Direccion", SqlDbType.VarChar, 200) { Value = (object?)dto.Direccion ?? DBNull.Value });
        command.Parameters.Add(new SqlParameter("@Telefono", SqlDbType.VarChar, 20) { Value = (object?)dto.Telefono ?? DBNull.Value });

        var result = await command.ExecuteScalarAsync();
        return result != null ? Convert.ToInt32(result) : 0;
    }

    public async Task ActualizarAsync(PropietarioUpdateDto dto)
    {
        await using var connection = _conexionDB.GetConnection();
        await connection.OpenAsync();

        await using var command = new SqlCommand(Procedimientos.Propietario_Actualizar, connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add(new SqlParameter("@ID_Propietario", SqlDbType.Int) { Value = dto.ID_Propietario });
        command.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 100) { Value = dto.Nombre });
        command.Parameters.Add(new SqlParameter("@Apellidos", SqlDbType.VarChar, 120) { Value = dto.Apellidos });
        command.Parameters.Add(new SqlParameter("@Direccion", SqlDbType.VarChar, 200) { Value = (object?)dto.Direccion ?? DBNull.Value });
        command.Parameters.Add(new SqlParameter("@Telefono", SqlDbType.VarChar, 20) { Value = (object?)dto.Telefono ?? DBNull.Value });

        await command.ExecuteNonQueryAsync();
    }

    public async Task DesactivarAsync(int id)
    {
        await using var connection = _conexionDB.GetConnection();
        await connection.OpenAsync();

        await using var command = new SqlCommand(Procedimientos.Propietario_Desactivar, connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add(new SqlParameter("@ID_Propietario", SqlDbType.Int) { Value = id });

        await command.ExecuteNonQueryAsync();
    }

    public async Task<List<PropietarioDto>> ListarActivosAsync()
    {
        var resultados = new List<PropietarioDto>();

        await using var connection = _conexionDB.GetConnection();
        await connection.OpenAsync();

        await using var command = new SqlCommand(Procedimientos.Propietario_ListarActivos, connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        await using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            resultados.Add(new PropietarioDto
            {
                ID_Propietario = reader.GetInt32(reader.GetOrdinal("ID_Propietario")),
                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                Apellidos = reader.GetString(reader.GetOrdinal("Apellidos")),
                Direccion = reader.IsDBNull(reader.GetOrdinal("Direccion")) ? null : reader.GetString(reader.GetOrdinal("Direccion")),
                Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? null : reader.GetString(reader.GetOrdinal("Telefono")),
                Activo = true
            });
        }

        return resultados;
    }

    public async Task<PropietarioDto?> BuscarPorIDAsync(int id)
    {
        await using var connection = _conexionDB.GetConnection();
        await connection.OpenAsync();

        await using var command = new SqlCommand(Procedimientos.Propietario_BuscarPorID, connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add(new SqlParameter("@ID_Propietario", SqlDbType.Int) { Value = id });

        await using var reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            return new PropietarioDto
            {
                ID_Propietario = reader.GetInt32(reader.GetOrdinal("ID_Propietario")),
                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                Apellidos = reader.GetString(reader.GetOrdinal("Apellidos")),
                Direccion = reader.IsDBNull(reader.GetOrdinal("Direccion")) ? null : reader.GetString(reader.GetOrdinal("Direccion")),
                Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? null : reader.GetString(reader.GetOrdinal("Telefono")),
                Activo = reader.GetBoolean(reader.GetOrdinal("Activo"))
            };
        }

        return null;
    }
}

