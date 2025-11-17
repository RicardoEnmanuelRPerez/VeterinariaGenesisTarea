using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeterinariaGenesisAPI.Models.DTOs;
using VeterinariaGenesisAPI.Services.Interfaces;

namespace VeterinariaGenesisAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class MascotaController : ControllerBase
{
    private readonly IMascotaService _mascotaService;
    private readonly ILogger<MascotaController> _logger;

    public MascotaController(IMascotaService mascotaService, ILogger<MascotaController> logger)
    {
        _mascotaService = mascotaService;
        _logger = logger;
    }

    /// <summary>
    /// Obtiene las mascotas de un propietario
    /// </summary>
    [HttpGet("propietario/{idPropietario}")]
    [Authorize(Policy = "AllRoles")]
    [ProducesResponseType(typeof(List<MascotaDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<MascotaDto>>> ListarPorPropietario(int idPropietario)
    {
        try
        {
            var mascotas = await _mascotaService.ListarPorPropietarioAsync(idPropietario);
            return Ok(mascotas);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al listar mascotas del propietario: {Id}", idPropietario);
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }

    /// <summary>
    /// Obtiene una mascota por su ID
    /// </summary>
    [HttpGet("{id}")]
    [Authorize(Policy = "AllRoles")]
    [ProducesResponseType(typeof(MascotaDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MascotaDto>> BuscarPorID(int id)
    {
        try
        {
            var mascota = await _mascotaService.BuscarPorIDAsync(id);

            if (mascota == null)
            {
                return NotFound(new { message = $"Mascota con ID {id} no encontrada" });
            }

            return Ok(mascota);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al buscar mascota por ID: {Id}", id);
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }

    /// <summary>
    /// Crea una nueva mascota
    /// </summary>
    [HttpPost]
    [Authorize(Policy = "AllRoles")]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<int>> Crear([FromBody] MascotaCreateDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nuevoID = await _mascotaService.CrearAsync(dto);
            return CreatedAtAction(nameof(BuscarPorID), new { id = nuevoID }, new { id = nuevoID });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al crear mascota");
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }

    /// <summary>
    /// Actualiza una mascota existente
    /// </summary>
    [HttpPut]
    [Authorize(Policy = "AdministradorOrVeterinario")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Actualizar([FromBody] MascotaUpdateDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mascotaService.ActualizarAsync(dto);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al actualizar mascota: {Id}", dto.ID_Mascota);
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }
}


