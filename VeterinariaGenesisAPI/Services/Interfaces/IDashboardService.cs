using VeterinariaGenesisAPI.Models.DTOs;

namespace VeterinariaGenesisAPI.Services.Interfaces;

public interface IDashboardService
{
    Task<List<DashboardCirugiasDto>> ObtenerCirugiasPorVeterinarioAsync(DateOnly? fechaInicio, DateOnly? fechaFin);
    Task<List<DashboardCitasDiaSemanaDto>> ObtenerCitasPorDiaSemanaAsync(DateOnly? fechaInicio, DateOnly? fechaFin);
    Task<List<DashboardProductividadDto>> ObtenerProductividadVeterinarioAsync(DateOnly? fechaInicio, DateOnly? fechaFin);
}

