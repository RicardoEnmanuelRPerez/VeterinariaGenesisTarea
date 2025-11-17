using System.Data;
using Microsoft.Data.SqlClient;
using VeterinariaGenesisAPI.Data;
using VeterinariaGenesisAPI.DAO.Interfaces;
using VeterinariaGenesisAPI.Models.DTOs;

namespace VeterinariaGenesisAPI.DAO;

public class CitaDAO : ICitaDAO
{
    private readonly ConexionDB _conexionDB;

    public CitaDAO(ConexionDB conexionDB)
    {
        _conexionDB = conexionDB;
    }

    public async Task<int> AgendarAsync(CitaCreateDto dto)
    {
        await using var connection = _conexionDB.GetConnection();
        await connection.OpenAsync();

        await using var command = new SqlCommand(Procedimientos.Cita_Agendar, connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.Date) { Value = dto.Fecha.Date });
        command.Parameters.Add(new SqlParameter("@Hora", SqlDbType.Time) { Value = dto.Hora });
        command.Parameters.Add(new SqlParameter("@ID_Mascota", SqlDbType.Int) { Value = dto.ID_Mascota });
        command.Parameters.Add(new SqlParameter("@ID_Veterinario", SqlDbType.Int) { Value = dto.ID_Veterinario });
        command.Parameters.Add(new SqlParameter("@ID_Servicio", SqlDbType.Int) { Value = dto.ID_Servicio });

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

    public async Task CancelarAsync(int id)
    {
        await using var connection = _conexionDB.GetConnection();
        await connection.OpenAsync();

        await using var command = new SqlCommand(Procedimientos.Cita_Cancelar, connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add(new SqlParameter("@ID_Cita", SqlDbType.Int) { Value = id });

        await command.ExecuteNonQueryAsync();
    }

    public async Task<List<CitaDto>> ListarPorFechaAsync(DateTime fecha)
    {
        var resultados = new List<CitaDto>();

        await using var connection = _conexionDB.GetConnection();
        await connection.OpenAsync();

        await using var command = new SqlCommand(Procedimientos.Cita_ListarPorFecha, connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.Date) { Value = fecha.Date });

        await using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            resultados.Add(new CitaDto
            {
                ID_Cita = reader.GetInt32(reader.GetOrdinal("ID_Cita")),
                Fecha = reader.GetDateTime(reader.GetOrdinal("Fecha")),
                Hora = reader.GetTimeSpan(reader.GetOrdinal("Hora")),
                Estado = reader.GetString(reader.GetOrdinal("Estado")),
                ID_Mascota = reader.GetInt32(reader.GetOrdinal("ID_Mascota")),
                Mascota = reader.IsDBNull(reader.GetOrdinal("Mascota")) ? null : reader.GetString(reader.GetOrdinal("Mascota")),
                ID_Propietario = reader.GetInt32(reader.GetOrdinal("ID_Propietario")),
                Propietario = reader.IsDBNull(reader.GetOrdinal("Propietario")) ? null : reader.GetString(reader.GetOrdinal("Propietario")),
                ID_Veterinario = reader.GetInt32(reader.GetOrdinal("ID_Veterinario")),
                Veterinario = reader.IsDBNull(reader.GetOrdinal("Veterinario")) ? null : reader.GetString(reader.GetOrdinal("Veterinario")),
                ID_Servicio = reader.GetInt32(reader.GetOrdinal("ID_Servicio")),
                Servicio = reader.IsDBNull(reader.GetOrdinal("Servicio")) ? null : reader.GetString(reader.GetOrdinal("Servicio"))
            });
        }

        return resultados;
    }

    public async Task<List<CitaDto>> ListarPorVeterinarioAsync(int idVeterinario)
    {
        var resultados = new List<CitaDto>();

        await using var connection = _conexionDB.GetConnection();
        await connection.OpenAsync();

        await using var command = new SqlCommand(Procedimientos.Cita_ListarPorVeterinario, connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add(new SqlParameter("@ID_Veterinario", SqlDbType.Int) { Value = idVeterinario });

        await using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            resultados.Add(new CitaDto
            {
                ID_Cita = reader.GetInt32(reader.GetOrdinal("ID_Cita")),
                Fecha = reader.GetDateTime(reader.GetOrdinal("Fecha")),
                Hora = reader.GetTimeSpan(reader.GetOrdinal("Hora")),
                Estado = reader.GetString(reader.GetOrdinal("Estado")),
                ID_Mascota = reader.GetInt32(reader.GetOrdinal("ID_Mascota")),
                Mascota = reader.IsDBNull(reader.GetOrdinal("Mascota")) ? null : reader.GetString(reader.GetOrdinal("Mascota")),
                ID_Propietario = reader.GetInt32(reader.GetOrdinal("ID_Propietario")),
                Propietario = reader.IsDBNull(reader.GetOrdinal("Propietario")) ? null : reader.GetString(reader.GetOrdinal("Propietario")),
                ID_Veterinario = reader.GetInt32(reader.GetOrdinal("ID_Veterinario")),
                Veterinario = reader.IsDBNull(reader.GetOrdinal("Veterinario")) ? null : reader.GetString(reader.GetOrdinal("Veterinario")),
                ID_Servicio = reader.GetInt32(reader.GetOrdinal("ID_Servicio")),
                Servicio = reader.IsDBNull(reader.GetOrdinal("Servicio")) ? null : reader.GetString(reader.GetOrdinal("Servicio"))
            });
        }

        return resultados;
    }
}
