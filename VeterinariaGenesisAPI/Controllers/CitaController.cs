using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VeterinariaGenesisAPI.Models.DTOs;
using VeterinariaGenesisAPI.Services.Interfaces;

namespace VeterinariaGenesisAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CitaController : ControllerBase
{
    private readonly ICitaService _citaService;
    private readonly ILogger<CitaController> _logger;

    public CitaController(ICitaService citaService, ILogger<CitaController> logger)
    {
        _citaService = citaService;
        _logger = logger;
    }

    /// <summary>
    /// Agendar una nueva cita
    /// </summary>
    [HttpPost("agendar")]
    [Authorize(Policy = "AllRoles")]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<int>> Agendar([FromBody] CitaCreateDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nuevoID = await _citaService.AgendarAsync(dto);
            return CreatedAtAction(nameof(BuscarPorFecha), new { fecha = dto.Fecha }, new { id = nuevoID });
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogWarning(ex, "Error de negocio al agendar cita");
            return Conflict(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al agendar cita");
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }

    /// <summary>
    /// Actualiza una cita existente
    /// </summary>
    [HttpPut]
    [Authorize(Policy = "AdministradorOrVeterinario")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Actualizar([FromBody] CitaUpdateDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _citaService.ActualizarAsync(dto);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogWarning(ex, "Error de negocio al actualizar cita");
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al actualizar cita: {Id}", dto.ID_Cita);
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }

    /// <summary>
    /// Cancela una cita programada
    /// </summary>
    [HttpPost("{id}/cancelar")]
    [Authorize(Policy = "AllRoles")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Cancelar(int id)
    {
        try
        {
            await _citaService.CancelarAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al cancelar cita: {Id}", id);
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }

    /// <summary>
    /// Lista las citas de una fecha específica
    /// </summary>
    [HttpGet("fecha/{fecha}")]
    [Authorize(Policy = "AllRoles")]
    [ProducesResponseType(typeof(List<CitaDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<CitaDto>>> BuscarPorFecha(DateTime fecha)
    {
        try
        {
            var citas = await _citaService.ListarPorFechaAsync(fecha);
            return Ok(citas);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al listar citas por fecha: {Fecha}", fecha);
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }

    /// <summary>
    /// Lista las citas de un veterinario (usando el ID del veterinario del token JWT)
    /// </summary>
    [HttpGet("mis-citas")]
    [Authorize(Policy = "Veterinario")]
    [ProducesResponseType(typeof(List<CitaDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<CitaDto>>> MisCitas()
    {
        try
        {
            var idVeterinarioClaim = User.FindFirst("ID_Veterinario")?.Value;
            
            if (string.IsNullOrEmpty(idVeterinarioClaim) || !int.TryParse(idVeterinarioClaim, out var idVeterinario))
            {
                return BadRequest(new { message = "Usuario no tiene ID_Veterinario asociado" });
            }

            var citas = await _citaService.ListarPorVeterinarioAsync(idVeterinario);
            return Ok(citas);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al listar citas del veterinario");
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }

    /// <summary>
    /// Lista las citas de un veterinario específico (solo Administrador)
    /// </summary>
    [HttpGet("veterinario/{idVeterinario}")]
    [Authorize(Policy = "Administrador")]
    [ProducesResponseType(typeof(List<CitaDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<CitaDto>>> ListarPorVeterinario(int idVeterinario)
    {
        try
        {
            var citas = await _citaService.ListarPorVeterinarioAsync(idVeterinario);
            return Ok(citas);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al listar citas del veterinario: {Id}", idVeterinario);
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }

    /// <summary>
    /// Lista las citas completadas que no tienen factura asociada
    /// </summary>
    [HttpGet("completadas-sin-factura")]
    [Authorize(Policy = "AllRoles")]
    [ProducesResponseType(typeof(List<CitaDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<CitaDto>>> ListarCompletadasSinFactura()
    {
        try
        {
            var citas = await _citaService.ListarCompletadasSinFacturaAsync();
            return Ok(citas);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al listar citas completadas sin factura");
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }
}


