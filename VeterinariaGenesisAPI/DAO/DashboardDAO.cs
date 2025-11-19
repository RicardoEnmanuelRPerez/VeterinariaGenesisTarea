using System.Data;
using Microsoft.Data.SqlClient;
using VeterinariaGenesisAPI.Data;
using VeterinariaGenesisAPI.DAO.Interfaces;
using VeterinariaGenesisAPI.Models.DTOs;

namespace VeterinariaGenesisAPI.DAO;

public class DashboardDAO : IDashboardDAO
{
    private readonly ConexionDB _conexionDB;

    public DashboardDAO(ConexionDB conexionDB)
    {
        _conexionDB = conexionDB;
    }

    public async Task<List<DashboardCirugiasDto>> ObtenerCirugiasPorVeterinarioAsync(DateOnly? fechaInicio, DateOnly? fechaFin)
    {
        try
        {
            await using var connection = _conexionDB.GetConnection();
            await connection.OpenAsync();

            await using var command = new SqlCommand(Procedimientos.Dashboard_CirugiasPorVeterinario, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add(new SqlParameter("@fechaInicio", SqlDbType.Date) 
            { 
                Value = fechaInicio.HasValue ? (object)fechaInicio.Value : DBNull.Value 
            });
            command.Parameters.Add(new SqlParameter("@fechaFin", SqlDbType.Date) 
            { 
                Value = fechaFin.HasValue ? (object)fechaFin.Value : DBNull.Value 
            });

            var resultados = new List<DashboardCirugiasDto>();

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                resultados.Add(new DashboardCirugiasDto
                {
                    ID_Veterinario = reader.GetInt32(reader.GetOrdinal("ID_Veterinario")),
                    NombreVeterinario = reader.GetString(reader.GetOrdinal("NombreVeterinario")),
                    Especialidad = reader.IsDBNull(reader.GetOrdinal("Especialidad")) ? null : reader.GetString(reader.GetOrdinal("Especialidad")),
                    CantidadCirugias = reader.GetInt32(reader.GetOrdinal("CantidadCirugias")),
                    PorcentajeTotal = reader.GetDecimal(reader.GetOrdinal("PorcentajeTotal"))
                });
            }

            return resultados;
        }
        catch (SqlException sqlEx)
        {
            throw new InvalidOperationException($"Error de base de datos al obtener cirugías por veterinario: {sqlEx.Message}", sqlEx);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error inesperado al obtener cirugías por veterinario: {ex.Message}", ex);
        }
    }

    public async Task<List<DashboardCitasDiaSemanaDto>> ObtenerCitasPorDiaSemanaAsync(DateOnly? fechaInicio, DateOnly? fechaFin)
    {
        try
        {
            await using var connection = _conexionDB.GetConnection();
            await connection.OpenAsync();

            await using var command = new SqlCommand(Procedimientos.Dashboard_CitasPorDiaSemana, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add(new SqlParameter("@fechaInicio", SqlDbType.Date) 
            { 
                Value = fechaInicio.HasValue ? (object)fechaInicio.Value : DBNull.Value 
            });
            command.Parameters.Add(new SqlParameter("@fechaFin", SqlDbType.Date) 
            { 
                Value = fechaFin.HasValue ? (object)fechaFin.Value : DBNull.Value 
            });

            var resultados = new List<DashboardCitasDiaSemanaDto>();

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                resultados.Add(new DashboardCitasDiaSemanaDto
                {
                    DiaSemana = reader.GetString(reader.GetOrdinal("DiaSemana")),
                    CantidadCitas = reader.GetInt32(reader.GetOrdinal("CantidadCitas")),
                    CitasCompletadas = reader.GetInt32(reader.GetOrdinal("CitasCompletadas")),
                    CitasCanceladas = reader.GetInt32(reader.GetOrdinal("CitasCanceladas"))
                });
            }

            return resultados;
        }
        catch (SqlException sqlEx)
        {
            throw new InvalidOperationException($"Error de base de datos al obtener citas por día de semana: {sqlEx.Message}", sqlEx);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error inesperado al obtener citas por día de semana: {ex.Message}", ex);
        }
    }

    public async Task<List<DashboardProductividadDto>> ObtenerProductividadVeterinarioAsync(DateOnly? fechaInicio, DateOnly? fechaFin)
    {
        try
        {
            await using var connection = _conexionDB.GetConnection();
            await connection.OpenAsync();

            await using var command = new SqlCommand(Procedimientos.Dashboard_ProductividadVeterinario, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add(new SqlParameter("@fechaInicio", SqlDbType.Date) 
            { 
                Value = fechaInicio.HasValue ? (object)fechaInicio.Value : DBNull.Value 
            });
            command.Parameters.Add(new SqlParameter("@fechaFin", SqlDbType.Date) 
            { 
                Value = fechaFin.HasValue ? (object)fechaFin.Value : DBNull.Value 
            });

            var resultados = new List<DashboardProductividadDto>();

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                resultados.Add(new DashboardProductividadDto
                {
                    ID_Veterinario = reader.GetInt32(reader.GetOrdinal("ID_Veterinario")),
                    NombreVeterinario = reader.GetString(reader.GetOrdinal("NombreVeterinario")),
                    Especialidad = reader.IsDBNull(reader.GetOrdinal("Especialidad")) ? null : reader.GetString(reader.GetOrdinal("Especialidad")),
                    TotalCitas = reader.GetInt32(reader.GetOrdinal("TotalCitas")),
                    TotalCirugias = reader.GetInt32(reader.GetOrdinal("TotalCirugias")),
                    TotalTratamientos = reader.GetInt32(reader.GetOrdinal("TotalTratamientos")),
                    IngresosGenerados = reader.GetDecimal(reader.GetOrdinal("IngresosGenerados"))
                });
            }

            return resultados;
        }
        catch (SqlException sqlEx)
        {
            throw new InvalidOperationException($"Error de base de datos al obtener productividad de veterinarios: {sqlEx.Message}", sqlEx);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error inesperado al obtener productividad de veterinarios: {ex.Message}", ex);
        }
    }
}

