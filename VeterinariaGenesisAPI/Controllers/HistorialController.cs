using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeterinariaGenesisAPI.Models.DTOs;
using VeterinariaGenesisAPI.Services.Interfaces;

namespace VeterinariaGenesisAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class HistorialController : ControllerBase
{
    private readonly IHistorialService _historialService;
    private readonly ILogger<HistorialController> _logger;

    public HistorialController(IHistorialService historialService, ILogger<HistorialController> logger)
    {
        _historialService = historialService;
        _logger = logger;
    }

    /// <summary>
    /// Obtiene el historial clínico completo de una mascota
    /// </summary>
    [HttpGet("mascota/{id}")]
    [ProducesResponseType(typeof(List<HistorialClinicoDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<HistorialClinicoDto>>> ObtenerHistorialPorMascota(int id)
    {
        try
        {
            var resultado = await _historialService.ObtenerHistorialPorMascotaAsync(id);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener historial clínico para mascota {MascotaId}", id);
            return StatusCode(500, new { message = "Error al obtener el historial clínico", error = ex.Message });
        }
    }

    /// <summary>
    /// Busca mascotas por nombre o propietario para el historial clínico
    /// </summary>
    [HttpGet("buscar")]
    [ProducesResponseType(typeof(List<MascotaBusquedaDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<MascotaBusquedaDto>>> BuscarMascotas([FromQuery] string? busqueda)
    {
        try
        {
            var resultado = await _historialService.BuscarMascotasAsync(busqueda);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al buscar mascotas con criterio: {Busqueda}", busqueda);
            return StatusCode(500, new { message = "Error al buscar mascotas", error = ex.Message });
        }
    }
}

