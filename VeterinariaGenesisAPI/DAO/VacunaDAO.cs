using System.Data;
using Microsoft.Data.SqlClient;
using VeterinariaGenesisAPI.Data;
using VeterinariaGenesisAPI.DAO.Interfaces;
using VeterinariaGenesisAPI.Models.DTOs;

namespace VeterinariaGenesisAPI.DAO;

public class VacunaDAO : IVacunaDAO
{
    private readonly ConexionDB _conexionDB;

    public VacunaDAO(ConexionDB conexionDB)
    {
        _conexionDB = conexionDB;
    }

    public async Task<List<RecordatorioVacunacionDto>> ObtenerRecordatoriosAsync(int diasAnticipacion)
    {
        try
        {
            await using var connection = _conexionDB.GetConnection();
            await connection.OpenAsync();

            await using var command = new SqlCommand(Procedimientos.Vacuna_Recordatorios, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add(new SqlParameter("@DiasAnticipacion", SqlDbType.Int) { Value = diasAnticipacion });

            var resultados = new List<RecordatorioVacunacionDto>();

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                resultados.Add(new RecordatorioVacunacionDto
                {
                    ID_Mascota = reader.GetInt32(reader.GetOrdinal("ID_Mascota")),
                    NombreMascota = reader.GetString(reader.GetOrdinal("NombreMascota")),
                    Especie = reader.GetString(reader.GetOrdinal("Especie")),
                    Raza = reader.IsDBNull(reader.GetOrdinal("Raza")) ? null : reader.GetString(reader.GetOrdinal("Raza")),
                    ID_Propietario = reader.GetInt32(reader.GetOrdinal("ID_Propietario")),
                    NombrePropietario = reader.GetString(reader.GetOrdinal("NombrePropietario")),
                    Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? null : reader.GetString(reader.GetOrdinal("Telefono")),
                    Direccion = reader.IsDBNull(reader.GetOrdinal("Direccion")) ? null : reader.GetString(reader.GetOrdinal("Direccion")),
                    NombreVacuna = reader.GetString(reader.GetOrdinal("NombreVacuna")),
                    Dosis = reader.IsDBNull(reader.GetOrdinal("Dosis")) ? null : reader.GetString(reader.GetOrdinal("Dosis")),
                    FechaAplicacion = reader.GetDateTime(reader.GetOrdinal("FechaAplicacion")),
                    FechaProximaDosis = reader.IsDBNull(reader.GetOrdinal("FechaProximaDosis")) ? null : reader.GetDateTime(reader.GetOrdinal("FechaProximaDosis")),
                    Estado = reader.GetString(reader.GetOrdinal("Estado")),
                    DiasRestantes = reader.IsDBNull(reader.GetOrdinal("DiasRestantes")) ? null : reader.GetInt32(reader.GetOrdinal("DiasRestantes"))
                });
            }

            return resultados;
        }
        catch (SqlException sqlEx)
        {
            throw new InvalidOperationException($"Error de base de datos al obtener recordatorios de vacunación: {sqlEx.Message}", sqlEx);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error inesperado al obtener recordatorios de vacunación: {ex.Message}", ex);
        }
    }
}

