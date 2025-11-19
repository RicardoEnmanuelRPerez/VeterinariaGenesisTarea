using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeterinariaGenesisAPI.Models.DTOs;
using VeterinariaGenesisAPI.Services.Interfaces;

namespace VeterinariaGenesisAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class DashboardController : ControllerBase
{
    private readonly IDashboardService _dashboardService;
    private readonly ILogger<DashboardController> _logger;

    public DashboardController(IDashboardService dashboardService, ILogger<DashboardController> logger)
    {
        _dashboardService = dashboardService;
        _logger = logger;
    }

    /// <summary>
    /// Obtiene las cirugías realizadas por cada veterinario
    /// </summary>
    [HttpGet("CirugiasPorVeterinario")]
    [ProducesResponseType(typeof(List<DashboardCirugiasDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<DashboardCirugiasDto>>> ObtenerCirugiasPorVeterinario(
        [FromQuery] DateOnly? fechaInicio,
        [FromQuery] DateOnly? fechaFin)
    {
        try
        {
            var resultado = await _dashboardService.ObtenerCirugiasPorVeterinarioAsync(fechaInicio, fechaFin);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener cirugías por veterinario");
            return StatusCode(500, new { message = "Error al obtener cirugías por veterinario", error = ex.Message });
        }
    }

    /// <summary>
    /// Obtiene las citas agrupadas por día de la semana
    /// </summary>
    [HttpGet("CitasPorDiaSemana")]
    [ProducesResponseType(typeof(List<DashboardCitasDiaSemanaDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<DashboardCitasDiaSemanaDto>>> ObtenerCitasPorDiaSemana(
        [FromQuery] DateOnly? fechaInicio,
        [FromQuery] DateOnly? fechaFin)
    {
        try
        {
            var resultado = await _dashboardService.ObtenerCitasPorDiaSemanaAsync(fechaInicio, fechaFin);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener citas por día de semana");
            return StatusCode(500, new { message = "Error al obtener citas por día de semana", error = ex.Message });
        }
    }

    /// <summary>
    /// Obtiene la productividad general de cada veterinario
    /// </summary>
    [HttpGet("ProductividadVeterinario")]
    [ProducesResponseType(typeof(List<DashboardProductividadDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<DashboardProductividadDto>>> ObtenerProductividadVeterinario(
        [FromQuery] DateOnly? fechaInicio,
        [FromQuery] DateOnly? fechaFin)
    {
        try
        {
            var resultado = await _dashboardService.ObtenerProductividadVeterinarioAsync(fechaInicio, fechaFin);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener productividad de veterinarios");
            return StatusCode(500, new { message = "Error al obtener productividad de veterinarios", error = ex.Message });
        }
    }
}

