using VeterinariaGenesisAPI.DAO.Interfaces;
using VeterinariaGenesisAPI.Models.DTOs;
using VeterinariaGenesisAPI.Services.Interfaces;

namespace VeterinariaGenesisAPI.Services;

public class DashboardService : IDashboardService
{
    private readonly IDashboardDAO _dashboardDAO;

    public DashboardService(IDashboardDAO dashboardDAO)
    {
        _dashboardDAO = dashboardDAO;
    }

    public async Task<List<DashboardCirugiasDto>> ObtenerCirugiasPorVeterinarioAsync(DateOnly? fechaInicio, DateOnly? fechaFin)
    {
        try
        {
            return await _dashboardDAO.ObtenerCirugiasPorVeterinarioAsync(fechaInicio, fechaFin);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error en el servicio al obtener cirugías por veterinario: {ex.Message}", ex);
        }
    }

    public async Task<List<DashboardCitasDiaSemanaDto>> ObtenerCitasPorDiaSemanaAsync(DateOnly? fechaInicio, DateOnly? fechaFin)
    {
        try
        {
            return await _dashboardDAO.ObtenerCitasPorDiaSemanaAsync(fechaInicio, fechaFin);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error en el servicio al obtener citas por día de semana: {ex.Message}", ex);
        }
    }

    public async Task<List<DashboardProductividadDto>> ObtenerProductividadVeterinarioAsync(DateOnly? fechaInicio, DateOnly? fechaFin)
    {
        try
        {
            return await _dashboardDAO.ObtenerProductividadVeterinarioAsync(fechaInicio, fechaFin);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error en el servicio al obtener productividad de veterinarios: {ex.Message}", ex);
        }
    }
}

