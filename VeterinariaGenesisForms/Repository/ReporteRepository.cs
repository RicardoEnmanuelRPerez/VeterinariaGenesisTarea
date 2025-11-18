using VeterinariaGenesisForms.Controllers;
using VeterinariaGenesisForms.Models.Dto;
using VeterinariaGenesisForms.Repository.Interfaces;

namespace VeterinariaGenesisForms.Repository;

public class ReporteRepository : IReporteRepository
{
    private readonly ApiClient _apiClient;

    public ReporteRepository(ApiClient apiClient)
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

    public async Task<List<ReportePropietarioDto>> ObtenerReportePropietariosAsync(DateOnly? fechaInicio, DateOnly? fechaFin)
    {
        var queryString = BuildQueryString(fechaInicio, fechaFin);
        var resultado = await _apiClient.GetAsync<List<ReportePropietarioDto>>($"Reporte/Propietarios{queryString}");
        return resultado ?? new List<ReportePropietarioDto>();
    }

    public async Task<List<ReporteServicioVendidoDto>> ObtenerReporteServiciosVendidosAsync(DateOnly? fechaInicio, DateOnly? fechaFin)
    {
        var queryString = BuildQueryString(fechaInicio, fechaFin);
        var resultado = await _apiClient.GetAsync<List<ReporteServicioVendidoDto>>($"Reporte/ServiciosVendidos{queryString}");
        return resultado ?? new List<ReporteServicioVendidoDto>();
    }

    public async Task<List<ReporteCitaVeterinarioDto>> ObtenerReporteCitasPorVeterinarioAsync(DateOnly? fechaInicio, DateOnly? fechaFin)
    {
        var queryString = BuildQueryString(fechaInicio, fechaFin);
        var resultado = await _apiClient.GetAsync<List<ReporteCitaVeterinarioDto>>($"Reporte/CitasPorVeterinario{queryString}");
        return resultado ?? new List<ReporteCitaVeterinarioDto>();
    }

    public async Task<List<ReporteIngresoPeriodoDto>> ObtenerReporteIngresosPorPeriodoAsync(DateOnly? fechaInicio, DateOnly? fechaFin)
    {
        var queryString = BuildQueryString(fechaInicio, fechaFin);
        var resultado = await _apiClient.GetAsync<List<ReporteIngresoPeriodoDto>>($"Reporte/IngresosPorPeriodo{queryString}");
        return resultado ?? new List<ReporteIngresoPeriodoDto>();
    }

    public async Task<List<ReporteMascotaEspecieDto>> ObtenerReporteMascotasPorEspecieAsync(DateOnly? fechaInicio, DateOnly? fechaFin)
    {
        var queryString = BuildQueryString(fechaInicio, fechaFin);
        var resultado = await _apiClient.GetAsync<List<ReporteMascotaEspecieDto>>($"Reporte/MascotasPorEspecie{queryString}");
        return resultado ?? new List<ReporteMascotaEspecieDto>();
    }

    public async Task<List<ReporteTratamientoDto>> ObtenerReporteTratamientosComunesAsync(DateOnly? fechaInicio, DateOnly? fechaFin)
    {
        var queryString = BuildQueryString(fechaInicio, fechaFin);
        var resultado = await _apiClient.GetAsync<List<ReporteTratamientoDto>>($"Reporte/TratamientosComunes{queryString}");
        return resultado ?? new List<ReporteTratamientoDto>();
    }

    public async Task<List<ReporteMetodoPagoDto>> ObtenerReporteMetodosPagoAsync(DateOnly? fechaInicio, DateOnly? fechaFin)
    {
        var queryString = BuildQueryString(fechaInicio, fechaFin);
        var resultado = await _apiClient.GetAsync<List<ReporteMetodoPagoDto>>($"Reporte/MetodosPago{queryString}");
        return resultado ?? new List<ReporteMetodoPagoDto>();
    }

    public async Task<ReporteResumenGeneralDto> ObtenerReporteResumenGeneralAsync(DateOnly? fechaInicio, DateOnly? fechaFin)
    {
        var queryString = BuildQueryString(fechaInicio, fechaFin);
        var resultado = await _apiClient.GetAsync<ReporteResumenGeneralDto>($"Reporte/ResumenGeneral{queryString}");
        return resultado ?? new ReporteResumenGeneralDto();
    }
}

