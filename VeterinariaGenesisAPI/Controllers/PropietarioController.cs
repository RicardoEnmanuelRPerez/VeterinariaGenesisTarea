using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeterinariaGenesisAPI.Models.DTOs;
using VeterinariaGenesisAPI.Services.Interfaces;

namespace VeterinariaGenesisAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PropietarioController : ControllerBase
{
    private readonly IPropietarioService _propietarioService;
    private readonly ILogger<PropietarioController> _logger;

    public PropietarioController(IPropietarioService propietarioService, ILogger<PropietarioController> logger)
    {
        _propietarioService = propietarioService;
        _logger = logger;
    }

    /// <summary>
    /// Obtiene la lista de propietarios activos
    /// </summary>
    [HttpGet]
    [Authorize(Policy = "AllRoles")]
    [ProducesResponseType(typeof(List<PropietarioDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<PropietarioDto>>> ListarActivos()
    {
        try
        {
            var propietarios = await _propietarioService.ListarActivosAsync();
            return Ok(propietarios);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al listar propietarios activos");
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }

    /// <summary>
    /// Obtiene un propietario por su ID
    /// </summary>
    [HttpGet("{id}")]
    [Authorize(Policy = "AllRoles")]
    [ProducesResponseType(typeof(PropietarioDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PropietarioDto>> BuscarPorID(int id)
    {
        try
        {
            var propietario = await _propietarioService.BuscarPorIDAsync(id);

            if (propietario == null)
            {
                return NotFound(new { message = $"Propietario con ID {id} no encontrado" });
            }

            return Ok(propietario);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al buscar propietario por ID: {Id}", id);
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }

    /// <summary>
    /// Crea un nuevo propietario
    /// </summary>
    [HttpPost]
    [Authorize(Policy = "AllRoles")]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<int>> Crear([FromBody] PropietarioCreateDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nuevoID = await _propietarioService.CrearAsync(dto);
            return CreatedAtAction(nameof(BuscarPorID), new { id = nuevoID }, new { id = nuevoID });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al crear propietario");
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }

    /// <summary>
    /// Actualiza un propietario existente
    /// </summary>
    [HttpPut]
    [Authorize(Policy = "AdministradorOrVeterinario")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Actualizar([FromBody] PropietarioUpdateDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _propietarioService.ActualizarAsync(dto);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al actualizar propietario: {Id}", dto.ID_Propietario);
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }

    /// <summary>
    /// Desactiva un propietario (soft delete)
    /// </summary>
    [HttpDelete("{id}")]
    [Authorize(Policy = "Administrador")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Desactivar(int id)
    {
        try
        {
            await _propietarioService.DesactivarAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al desactivar propietario: {Id}", id);
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }
}


