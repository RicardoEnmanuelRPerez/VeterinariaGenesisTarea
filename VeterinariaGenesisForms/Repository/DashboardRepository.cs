using VeterinariaGenesisForms.Controllers;
using VeterinariaGenesisForms.Models.Dto;
using VeterinariaGenesisForms.Repository.Interfaces;

namespace VeterinariaGenesisForms.Repository;

public class DashboardRepository : IDashboardRepository
{
    private readonly ApiClient _apiClient;

    public DashboardRepository(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    private string BuildQueryString(DateOnly? fechaInicio, DateOnly? fechaFin)
    {
        var queryParams = new List<string>();
        if (fechaInicio.HasValue)
            queryParams.Add($"fechaInicio={fechaInicio.Value:yyyy-MM-dd}");
        if (fechaFin.HasValue)
            queryParams.Add($"fechaFin={fechaFin.Value:yyyy-MM-dd}");
        return queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : string.Empty;
    }

    public async Task<List<DashboardCirugiasDto>> ObtenerCirugiasPorVeterinarioAsync(DateOnly? fechaInicio, DateOnly? fechaFin)
    {
        var queryString = BuildQueryString(fechaInicio, fechaFin);
        var resultado = await _apiClient.GetAsync<List<DashboardCirugiasDto>>($"Dashboard/CirugiasPorVeterinario{queryString}");
        return resultado ?? new List<DashboardCirugiasDto>();
    }

    public async Task<List<DashboardCitasDiaSemanaDto>> ObtenerCitasPorDiaSemanaAsync(DateOnly? fechaInicio, DateOnly? fechaFin)
    {
        var queryString = BuildQueryString(fechaInicio, fechaFin);
        var resultado = await _apiClient.GetAsync<List<DashboardCitasDiaSemanaDto>>($"Dashboard/CitasPorDiaSemana{queryString}");
        return resultado ?? new List<DashboardCitasDiaSemanaDto>();
    }

    public async Task<List<DashboardProductividadDto>> ObtenerProductividadVeterinarioAsync(DateOnly? fechaInicio, DateOnly? fechaFin)
    {
        var queryString = BuildQueryString(fechaInicio, fechaFin);
        var resultado = await _apiClient.GetAsync<List<DashboardProductividadDto>>($"Dashboard/ProductividadVeterinario{queryString}");
        return resultado ?? new List<DashboardProductividadDto>();
    }
}

