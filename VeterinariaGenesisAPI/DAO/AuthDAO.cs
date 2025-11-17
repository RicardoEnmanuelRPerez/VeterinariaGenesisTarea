using System.Data;
using Microsoft.Data.SqlClient;
using VeterinariaGenesisAPI.Data;
using VeterinariaGenesisAPI.DAO.Interfaces;
using VeterinariaGenesisAPI.Models.DTOs;

namespace VeterinariaGenesisAPI.DAO;

public class AuthDAO : IAuthDAO
{
    private readonly ConexionDB _conexionDB;

    public AuthDAO(ConexionDB conexionDB)
    {
        _conexionDB = conexionDB;
    }

    public async Task<UsuarioInfoDto?> LoginAsync(string nombreLogin, string contrasena)
    {
        try
        {
            await using var connection = _conexionDB.GetConnection();
            await connection.OpenAsync();

            await using var command = new SqlCommand(Procedimientos.Usuario_Login, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add(new SqlParameter("@NombreLogin", SqlDbType.VarChar, 50) { Value = nombreLogin });
            command.Parameters.Add(new SqlParameter("@Contrasena", SqlDbType.VarChar, 100) { Value = contrasena });

            await using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new UsuarioInfoDto
                {
                    ID_Usuario = reader.GetInt32(reader.GetOrdinal("ID_Usuario")),
                    NombreLogin = reader.GetString(reader.GetOrdinal("NombreLogin")),
                    NombreCompleto = reader.GetString(reader.GetOrdinal("NombreCompleto")),
                    NombreRol = reader.GetString(reader.GetOrdinal("NombreRol")),
                    ID_Veterinario = reader.IsDBNull(reader.GetOrdinal("ID_Veterinario")) ? null : reader.GetInt32(reader.GetOrdinal("ID_Veterinario"))
                };
            }

            return null;
        }
        catch (SqlException sqlEx)
        {
            throw new InvalidOperationException($"Error de base de datos durante el login: {sqlEx.Message}", sqlEx);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error inesperado durante el login: {ex.Message}", ex);
        }
    }
}

