using VeterinariaGenesisAPI.Models.DTOs;

namespace VeterinariaGenesisAPI.Services.Interfaces;

public interface IReporteService
{
    Task<List<ReportePropietarioDto>> ObtenerReportePropietariosAsync(DateOnly? fechaInicio, DateOnly? fechaFin);
    Task<List<ReporteServicioVendidoDto>> ObtenerReporteServiciosVendidosAsync(DateOnly? fechaInicio, DateOnly? fechaFin);
    Task<List<ReporteCitaVeterinarioDto>> ObtenerReporteCitasPorVeterinarioAsync(DateOnly? fechaInicio, DateOnly? fechaFin);
    Task<List<ReporteIngresoPeriodoDto>> ObtenerReporteIngresosPorPeriodoAsync(DateOnly? fechaInicio, DateOnly? fechaFin);
    Task<List<ReporteMascotaEspecieDto>> ObtenerReporteMascotasPorEspecieAsync(DateOnly? fechaInicio, DateOnly? fechaFin);
    Task<List<ReporteTratamientoDto>> ObtenerReporteTratamientosComunesAsync(DateOnly? fechaInicio, DateOnly? fechaFin);
    Task<List<ReporteMetodoPagoDto>> ObtenerReporteMetodosPagoAsync(DateOnly? fechaInicio, DateOnly? fechaFin);
    Task<ReporteResumenGeneralDto> ObtenerReporteResumenGeneralAsync(DateOnly? fechaInicio, DateOnly? fechaFin);
}

