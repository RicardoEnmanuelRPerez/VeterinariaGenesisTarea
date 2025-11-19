using VeterinariaGenesisForms.Models.Dto;

namespace VeterinariaGenesisForms.Repository.Interfaces;

public interface IDashboardRepository
{
    Task<List<DashboardCirugiasDto>> ObtenerCirugiasPorVeterinarioAsync(DateOnly? fechaInicio, DateOnly? fechaFin);
    Task<List<DashboardCitasDiaSemanaDto>> ObtenerCitasPorDiaSemanaAsync(DateOnly? fechaInicio, DateOnly? fechaFin);
    Task<List<DashboardProductividadDto>> ObtenerProductividadVeterinarioAsync(DateOnly? fechaInicio, DateOnly? fechaFin);
}

