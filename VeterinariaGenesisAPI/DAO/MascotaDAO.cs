using System.Data;
using Microsoft.Data.SqlClient;
using VeterinariaGenesisAPI.Data;
using VeterinariaGenesisAPI.DAO.Interfaces;
using VeterinariaGenesisAPI.Models.DTOs;

namespace VeterinariaGenesisAPI.DAO;

public class MascotaDAO : IMascotaDAO
{
    private readonly ConexionDB _conexionDB;

    public MascotaDAO(ConexionDB conexionDB)
    {
        _conexionDB = conexionDB;
    }

    public async Task<int> CrearAsync(MascotaCreateDto dto)
    {
        await using var connection = _conexionDB.GetConnection();
        await connection.OpenAsync();

        await using var command = new SqlCommand(Procedimientos.Mascota_Crear, connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 100) { Value = dto.Nombre });
        command.Parameters.Add(new SqlParameter("@Especie", SqlDbType.VarChar, 50) { Value = dto.Especie });
        command.Parameters.Add(new SqlParameter("@Raza", SqlDbType.VarChar, 50) { Value = (object?)dto.Raza ?? DBNull.Value });
        command.Parameters.Add(new SqlParameter("@Edad", SqlDbType.Int) { Value = (object?)dto.Edad ?? DBNull.Value });
        command.Parameters.Add(new SqlParameter("@Sexo", SqlDbType.VarChar, 10) { Value = dto.Sexo });
        command.Parameters.Add(new SqlParameter("@ID_Propietario", SqlDbType.Int) { Value = dto.ID_Propietario });

        var result = await command.ExecuteScalarAsync();
        return result != null ? Convert.ToInt32(result) : 0;
    }

    public async Task ActualizarAsync(MascotaUpdateDto dto)
    {
        await using var connection = _conexionDB.GetConnection();
        await connection.OpenAsync();

        await using var command = new SqlCommand(Procedimientos.Mascota_Actualizar, connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add(new SqlParameter("@ID_Mascota", SqlDbType.Int) { Value = dto.ID_Mascota });
        command.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 100) { Value = dto.Nombre });
        command.Parameters.Add(new SqlParameter("@Especie", SqlDbType.VarChar, 50) { Value = dto.Especie });
        command.Parameters.Add(new SqlParameter("@Raza", SqlDbType.VarChar, 50) { Value = (object?)dto.Raza ?? DBNull.Value });
        command.Parameters.Add(new SqlParameter("@Edad", SqlDbType.Int) { Value = (object?)dto.Edad ?? DBNull.Value });
        command.Parameters.Add(new SqlParameter("@Sexo", SqlDbType.VarChar, 10) { Value = dto.Sexo });
        command.Parameters.Add(new SqlParameter("@ID_Propietario", SqlDbType.Int) { Value = dto.ID_Propietario });

        await command.ExecuteNonQueryAsync();
    }

    public async Task<List<MascotaDto>> ListarPorPropietarioAsync(int idPropietario)
    {
        var resultados = new List<MascotaDto>();

        await using var connection = _conexionDB.GetConnection();
        await connection.OpenAsync();

        await using var command = new SqlCommand(Procedimientos.Mascota_ListarPorPropietario, connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add(new SqlParameter("@ID_Propietario", SqlDbType.Int) { Value = idPropietario });

        await using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            resultados.Add(new MascotaDto
            {
                ID_Mascota = reader.GetInt32(reader.GetOrdinal("ID_Mascota")),
                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                Especie = reader.GetString(reader.GetOrdinal("Especie")),
                Raza = reader.IsDBNull(reader.GetOrdinal("Raza")) ? null : reader.GetString(reader.GetOrdinal("Raza")),
                Edad = reader.IsDBNull(reader.GetOrdinal("Edad")) ? null : reader.GetInt32(reader.GetOrdinal("Edad")),
                Sexo = reader.GetString(reader.GetOrdinal("Sexo")),
                ID_Propietario = reader.GetInt32(reader.GetOrdinal("ID_Propietario")),
                NombrePropietario = reader.IsDBNull(reader.GetOrdinal("NombrePropietario")) ? null : reader.GetString(reader.GetOrdinal("NombrePropietario"))
            });
        }

        return resultados;
    }

    public async Task<MascotaDto?> BuscarPorIDAsync(int id)
    {
        await using var connection = _conexionDB.GetConnection();
        await connection.OpenAsync();

        await using var command = new SqlCommand(Procedimientos.Mascota_BuscarPorID, connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add(new SqlParameter("@ID_Mascota", SqlDbType.Int) { Value = id });

        await using var reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            return new MascotaDto
            {
                ID_Mascota = reader.GetInt32(reader.GetOrdinal("ID_Mascota")),
                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                Especie = reader.GetString(reader.GetOrdinal("Especie")),
                Raza = reader.IsDBNull(reader.GetOrdinal("Raza")) ? null : reader.GetString(reader.GetOrdinal("Raza")),
                Edad = reader.IsDBNull(reader.GetOrdinal("Edad")) ? null : reader.GetInt32(reader.GetOrdinal("Edad")),
                Sexo = reader.GetString(reader.GetOrdinal("Sexo")),
                ID_Propietario = reader.GetInt32(reader.GetOrdinal("ID_Propietario")),
                NombrePropietario = reader.IsDBNull(reader.GetOrdinal("NombrePropietario")) ? null : reader.GetString(reader.GetOrdinal("NombrePropietario"))
            };
        }

        return null;
    }
}
