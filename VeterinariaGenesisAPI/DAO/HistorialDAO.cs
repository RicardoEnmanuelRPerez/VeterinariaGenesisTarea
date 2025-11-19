using System.Data;
using Microsoft.Data.SqlClient;
using VeterinariaGenesisAPI.Data;
using VeterinariaGenesisAPI.DAO.Interfaces;
using VeterinariaGenesisAPI.Models.DTOs;

namespace VeterinariaGenesisAPI.DAO;

public class HistorialDAO : IHistorialDAO
{
    private readonly ConexionDB _conexionDB;

    public HistorialDAO(ConexionDB conexionDB)
    {
        _conexionDB = conexionDB;
    }

    public async Task<List<HistorialClinicoDto>> ObtenerHistorialPorMascotaAsync(int idMascota)
    {
        try
        {
            await using var connection = _conexionDB.GetConnection();
            await connection.OpenAsync();

            await using var command = new SqlCommand(Procedimientos.Historial_ObtenerPorMascota, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add(new SqlParameter("@ID_Mascota", SqlDbType.Int) { Value = idMascota });

            var resultados = new List<HistorialClinicoDto>();

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                resultados.Add(new HistorialClinicoDto
                {
                    TipoEvento = reader.GetString(reader.GetOrdinal("TipoEvento")),
                    ID_Evento = reader.GetString(reader.GetOrdinal("ID_Evento")),
                    Fecha = reader.GetDateTime(reader.GetOrdinal("Fecha")),
                    Hora = reader.IsDBNull(reader.GetOrdinal("Hora")) ? null : reader.GetTimeSpan(reader.GetOrdinal("Hora")),
                    Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                    Veterinario = reader.IsDBNull(reader.GetOrdinal("Veterinario")) ? null : reader.GetString(reader.GetOrdinal("Veterinario")),
                    Costo = reader.IsDBNull(reader.GetOrdinal("Costo")) ? null : reader.GetDecimal(reader.GetOrdinal("Costo")),
                    Estado = reader.IsDBNull(reader.GetOrdinal("Estado")) ? null : reader.GetString(reader.GetOrdinal("Estado")),
                    Observaciones = reader.IsDBNull(reader.GetOrdinal("Observaciones")) ? null : reader.GetString(reader.GetOrdinal("Observaciones"))
                });
            }

            return resultados;
        }
        catch (SqlException sqlEx)
        {
            throw new InvalidOperationException($"Error de base de datos al obtener historial clínico: {sqlEx.Message}", sqlEx);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error inesperado al obtener historial clínico: {ex.Message}", ex);
        }
    }

    public async Task<List<MascotaBusquedaDto>> BuscarMascotasAsync(string? busqueda)
    {
        try
        {
            await using var connection = _conexionDB.GetConnection();
            await connection.OpenAsync();

            await using var command = new SqlCommand(Procedimientos.Mascota_BuscarParaHistorial, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add(new SqlParameter("@Busqueda", SqlDbType.VarChar, 200) 
            { 
                Value = string.IsNullOrWhiteSpace(busqueda) ? DBNull.Value : busqueda 
            });

            var resultados = new List<MascotaBusquedaDto>();

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                resultados.Add(new MascotaBusquedaDto
                {
                    ID_Mascota = reader.GetInt32(reader.GetOrdinal("ID_Mascota")),
                    NombreMascota = reader.GetString(reader.GetOrdinal("NombreMascota")),
                    Especie = reader.GetString(reader.GetOrdinal("Especie")),
                    Raza = reader.IsDBNull(reader.GetOrdinal("Raza")) ? null : reader.GetString(reader.GetOrdinal("Raza")),
                    Edad = reader.IsDBNull(reader.GetOrdinal("Edad")) ? null : reader.GetInt32(reader.GetOrdinal("Edad")),
                    ID_Propietario = reader.GetInt32(reader.GetOrdinal("ID_Propietario")),
                    NombrePropietario = reader.GetString(reader.GetOrdinal("NombrePropietario")),
                    Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? null : reader.GetString(reader.GetOrdinal("Telefono")),
                    Direccion = reader.IsDBNull(reader.GetOrdinal("Direccion")) ? null : reader.GetString(reader.GetOrdinal("Direccion"))
                });
            }

            return resultados;
        }
        catch (SqlException sqlEx)
        {
            throw new InvalidOperationException($"Error de base de datos al buscar mascotas: {sqlEx.Message}", sqlEx);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error inesperado al buscar mascotas: {ex.Message}", ex);
        }
    }
}

