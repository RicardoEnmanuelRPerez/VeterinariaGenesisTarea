using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeterinariaGenesisAPI.Models.DTOs;
using VeterinariaGenesisAPI.Services.Interfaces;

namespace VeterinariaGenesisAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class VacunaController : ControllerBase
{
    private readonly IVacunaService _vacunaService;
    private readonly ILogger<VacunaController> _logger;

    public VacunaController(IVacunaService vacunaService, ILogger<VacunaController> logger)
    {
        _vacunaService = vacunaService;
        _logger = logger;
    }

    /// <summary>
    /// Obtiene los recordatorios de vacunación (vencidas o por vencer)
    /// </summary>
    [HttpGet("Recordatorios")]
    [ProducesResponseType(typeof(List<RecordatorioVacunacionDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<RecordatorioVacunacionDto>>> ObtenerRecordatorios(
        [FromQuery] int diasAnticipacion = 30)
    {
        try
        {
            var resultado = await _vacunaService.ObtenerRecordatoriosAsync(diasAnticipacion);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener recordatorios de vacunación");
            return StatusCode(500, new { message = "Error al obtener recordatorios de vacunación", error = ex.Message });
        }
    }
}

