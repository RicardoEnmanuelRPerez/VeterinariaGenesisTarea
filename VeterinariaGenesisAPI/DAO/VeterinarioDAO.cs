using System.Data;
using Microsoft.Data.SqlClient;
using VeterinariaGenesisAPI.Data;
using VeterinariaGenesisAPI.DAO.Interfaces;
using VeterinariaGenesisAPI.Models.DTOs;

namespace VeterinariaGenesisAPI.DAO;

public class VeterinarioDAO : IVeterinarioDAO
{
    private readonly ConexionDB _conexionDB;

    public VeterinarioDAO(ConexionDB conexionDB)
    {
        _conexionDB = conexionDB;
    }

    public async Task<List<VeterinarioDto>> ListarActivosAsync()
    {
        var resultados = new List<VeterinarioDto>();

        await using var connection = _conexionDB.GetConnection();
        await connection.OpenAsync();

        await using var command = new SqlCommand(Procedimientos.Veterinario_ListarActivos, connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        await using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            resultados.Add(new VeterinarioDto
            {
                ID_Veterinario = reader.GetInt32(reader.GetOrdinal("ID_Veterinario")),
                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                Especialidad = reader.IsDBNull(reader.GetOrdinal("Especialidad")) ? null : reader.GetString(reader.GetOrdinal("Especialidad")),
                Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? null : reader.GetString(reader.GetOrdinal("Telefono")),
                Correo = reader.IsDBNull(reader.GetOrdinal("Correo")) ? null : reader.GetString(reader.GetOrdinal("Correo")),
                Activo = true
            });
        }

        return resultados;
    }

    public async Task<VeterinarioDto?> BuscarPorIDAsync(int id)
    {
        await using var connection = _conexionDB.GetConnection();
        await connection.OpenAsync();

        await using var command = new SqlCommand(Procedimientos.Veterinario_BuscarPorID, connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add(new SqlParameter("@ID_Veterinario", SqlDbType.Int) { Value = id });

        await using var reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            return new VeterinarioDto
            {
                ID_Veterinario = reader.GetInt32(reader.GetOrdinal("ID_Veterinario")),
                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                Especialidad = reader.IsDBNull(reader.GetOrdinal("Especialidad")) ? null : reader.GetString(reader.GetOrdinal("Especialidad")),
                Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? null : reader.GetString(reader.GetOrdinal("Telefono")),
                Correo = reader.IsDBNull(reader.GetOrdinal("Correo")) ? null : reader.GetString(reader.GetOrdinal("Correo")),
                Activo = reader.GetBoolean(reader.GetOrdinal("Activo"))
            };
        }

        return null;
    }
}

