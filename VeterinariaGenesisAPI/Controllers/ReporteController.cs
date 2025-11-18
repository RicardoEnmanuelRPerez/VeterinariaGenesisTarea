using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeterinariaGenesisAPI.Models.DTOs;
using VeterinariaGenesisAPI.Services.Interfaces;

namespace VeterinariaGenesisAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ReporteController : ControllerBase
{
    private readonly IReporteService _reporteService;
    private readonly ILogger<ReporteController> _logger;

    public ReporteController(IReporteService reporteService, ILogger<ReporteController> logger)
    {
        _reporteService = reporteService;
        _logger = logger;
    }

    /// <summary>
    /// Obtiene el reporte de propietarios con total de facturas
    /// </summary>
    [HttpGet("Propietarios")]
    [Authorize(Policy = "AdministradorOrVeterinario")]
    [ProducesResponseType(typeof(List<ReportePropietarioDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<ReportePropietarioDto>>> ObtenerReportePropietarios(
        [FromQuery] DateOnly? fechaInicio = null,
        [FromQuery] DateOnly? fechaFin = null)
    {
        try
        {
            var resultado = await _reporteService.ObtenerReportePropietariosAsync(fechaInicio, fechaFin);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener reporte de propietarios");
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    /// <summary>
    /// Obtiene el reporte de servicios más vendidos
    /// </summary>
    [HttpGet("ServiciosVendidos")]
    [Authorize(Policy = "AdministradorOrVeterinario")]
    [ProducesResponseType(typeof(List<ReporteServicioVendidoDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<ReporteServicioVendidoDto>>> ObtenerReporteServiciosVendidos(
        [FromQuery] DateOnly? fechaInicio = null,
        [FromQuery] DateOnly? fechaFin = null)
    {
        try
        {
            var resultado = await _reporteService.ObtenerReporteServiciosVendidosAsync(fechaInicio, fechaFin);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener reporte de servicios vendidos");
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    /// <summary>
    /// Obtiene el reporte de citas por veterinario
    /// </summary>
    [HttpGet("CitasPorVeterinario")]
    [Authorize(Policy = "AllRoles")]
    [ProducesResponseType(typeof(List<ReporteCitaVeterinarioDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<ReporteCitaVeterinarioDto>>> ObtenerReporteCitasPorVeterinario(
        [FromQuery] DateOnly? fechaInicio = null,
        [FromQuery] DateOnly? fechaFin = null)
    {
        try
        {
            var resultado = await _reporteService.ObtenerReporteCitasPorVeterinarioAsync(fechaInicio, fechaFin);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener reporte de citas por veterinario");
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    /// <summary>
    /// Obtiene el reporte de ingresos por período
    /// </summary>
    [HttpGet("IngresosPorPeriodo")]
    [Authorize(Policy = "AdministradorOrVeterinario")]
    [ProducesResponseType(typeof(List<ReporteIngresoPeriodoDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<ReporteIngresoPeriodoDto>>> ObtenerReporteIngresosPorPeriodo(
        [FromQuery] DateOnly? fechaInicio = null,
        [FromQuery] DateOnly? fechaFin = null)
    {
        try
        {
            var resultado = await _reporteService.ObtenerReporteIngresosPorPeriodoAsync(fechaInicio, fechaFin);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener reporte de ingresos por período");
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    /// <summary>
    /// Obtiene el reporte de mascotas por especie
    /// </summary>
    [HttpGet("MascotasPorEspecie")]
    [Authorize(Policy = "AllRoles")]
    [ProducesResponseType(typeof(List<ReporteMascotaEspecieDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<ReporteMascotaEspecieDto>>> ObtenerReporteMascotasPorEspecie(
        [FromQuery] DateOnly? fechaInicio = null,
        [FromQuery] DateOnly? fechaFin = null)
    {
        try
        {
            var resultado = await _reporteService.ObtenerReporteMascotasPorEspecieAsync(fechaInicio, fechaFin);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener reporte de mascotas por especie");
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    /// <summary>
    /// Obtiene el reporte de tratamientos más comunes
    /// </summary>
    [HttpGet("TratamientosComunes")]
    [Authorize(Policy = "AllRoles")]
    [ProducesResponseType(typeof(List<ReporteTratamientoDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<ReporteTratamientoDto>>> ObtenerReporteTratamientosComunes(
        [FromQuery] DateOnly? fechaInicio = null,
        [FromQuery] DateOnly? fechaFin = null)
    {
        try
        {
            var resultado = await _reporteService.ObtenerReporteTratamientosComunesAsync(fechaInicio, fechaFin);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener reporte de tratamientos comunes");
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    /// <summary>
    /// Obtiene el reporte de métodos de pago
    /// </summary>
    [HttpGet("MetodosPago")]
    [Authorize(Policy = "AdministradorOrVeterinario")]
    [ProducesResponseType(typeof(List<ReporteMetodoPagoDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<ReporteMetodoPagoDto>>> ObtenerReporteMetodosPago(
        [FromQuery] DateOnly? fechaInicio = null,
        [FromQuery] DateOnly? fechaFin = null)
    {
        try
        {
            var resultado = await _reporteService.ObtenerReporteMetodosPagoAsync(fechaInicio, fechaFin);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener reporte de métodos de pago");
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    /// <summary>
    /// Obtiene el reporte resumen general (Dashboard)
    /// </summary>
    [HttpGet("ResumenGeneral")]
    [Authorize(Policy = "AllRoles")]
    [ProducesResponseType(typeof(ReporteResumenGeneralDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<ReporteResumenGeneralDto>> ObtenerReporteResumenGeneral(
        [FromQuery] DateOnly? fechaInicio = null,
        [FromQuery] DateOnly? fechaFin = null)
    {
        try
        {
            var resultado = await _reporteService.ObtenerReporteResumenGeneralAsync(fechaInicio, fechaFin);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener reporte resumen general");
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }
}

