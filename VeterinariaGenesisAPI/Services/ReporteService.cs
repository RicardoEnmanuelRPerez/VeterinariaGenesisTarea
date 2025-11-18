using VeterinariaGenesisAPI.DAO.Interfaces;
using VeterinariaGenesisAPI.Models.DTOs;
using VeterinariaGenesisAPI.Services.Interfaces;

namespace VeterinariaGenesisAPI.Services;

public class ReporteService : IReporteService
{
    private readonly IReporteDAO _reporteDAO;

    public ReporteService(IReporteDAO reporteDAO)
    {
        _reporteDAO = reporteDAO;
    }

    public async Task<List<ReportePropietarioDto>> ObtenerReportePropietariosAsync(DateOnly? fechaInicio, DateOnly? fechaFin)
    {
        try
        {
            return await _reporteDAO.ObtenerReportePropietariosAsync(fechaInicio, fechaFin);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error en el servicio al obtener reporte de propietarios: {ex.Message}", ex);
        }
    }

    public async Task<List<ReporteServicioVendidoDto>> ObtenerReporteServiciosVendidosAsync(DateOnly? fechaInicio, DateOnly? fechaFin)
    {
        try
        {
            return await _reporteDAO.ObtenerReporteServiciosVendidosAsync(fechaInicio, fechaFin);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error en el servicio al obtener reporte de servicios vendidos: {ex.Message}", ex);
        }
    }

    public async Task<List<ReporteCitaVeterinarioDto>> ObtenerReporteCitasPorVeterinarioAsync(DateOnly? fechaInicio, DateOnly? fechaFin)
    {
        try
        {
            return await _reporteDAO.ObtenerReporteCitasPorVeterinarioAsync(fechaInicio, fechaFin);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error en el servicio al obtener reporte de citas por veterinario: {ex.Message}", ex);
        }
    }

    public async Task<List<ReporteIngresoPeriodoDto>> ObtenerReporteIngresosPorPeriodoAsync(DateOnly? fechaInicio, DateOnly? fechaFin)
    {
        try
        {
            return await _reporteDAO.ObtenerReporteIngresosPorPeriodoAsync(fechaInicio, fechaFin);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error en el servicio al obtener reporte de ingresos por período: {ex.Message}", ex);
        }
    }

    public async Task<List<ReporteMascotaEspecieDto>> ObtenerReporteMascotasPorEspecieAsync(DateOnly? fechaInicio, DateOnly? fechaFin)
    {
        try
        {
            return await _reporteDAO.ObtenerReporteMascotasPorEspecieAsync(fechaInicio, fechaFin);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error en el servicio al obtener reporte de mascotas por especie: {ex.Message}", ex);
        }
    }

    public async Task<List<ReporteTratamientoDto>> ObtenerReporteTratamientosComunesAsync(DateOnly? fechaInicio, DateOnly? fechaFin)
    {
        try
        {
            return await _reporteDAO.ObtenerReporteTratamientosComunesAsync(fechaInicio, fechaFin);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error en el servicio al obtener reporte de tratamientos comunes: {ex.Message}", ex);
        }
    }

    public async Task<List<ReporteMetodoPagoDto>> ObtenerReporteMetodosPagoAsync(DateOnly? fechaInicio, DateOnly? fechaFin)
    {
        try
        {
            return await _reporteDAO.ObtenerReporteMetodosPagoAsync(fechaInicio, fechaFin);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error en el servicio al obtener reporte de métodos de pago: {ex.Message}", ex);
        }
    }

    public async Task<ReporteResumenGeneralDto> ObtenerReporteResumenGeneralAsync(DateOnly? fechaInicio, DateOnly? fechaFin)
    {
        try
        {
            return await _reporteDAO.ObtenerReporteResumenGeneralAsync(fechaInicio, fechaFin);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error en el servicio al obtener reporte resumen general: {ex.Message}", ex);
        }
    }
}

