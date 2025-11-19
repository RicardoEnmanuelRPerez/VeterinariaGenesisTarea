using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeterinariaGenesisAPI.Models.DTOs;
using VeterinariaGenesisAPI.Services.Interfaces;

namespace VeterinariaGenesisAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ServicioController : ControllerBase
{
    private readonly IServicioService _servicioService;
    private readonly ILogger<ServicioController> _logger;

    public ServicioController(IServicioService servicioService, ILogger<ServicioController> logger)
    {
        _servicioService = servicioService;
        _logger = logger;
    }

    /// <summary>
    /// Obtiene la lista de todos los servicios
    /// </summary>
    [HttpGet]
    [Authorize(Policy = "AllRoles")]
    [ProducesResponseType(typeof(List<ServicioDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<ServicioDto>>> Listar()
    {
        try
        {
            var servicios = await _servicioService.ListarAsync();
            return Ok(servicios);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al listar servicios");
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }

    /// <summary>
    /// Obtiene un servicio por su ID
    /// </summary>
    [HttpGet("{id}")]
    [Authorize(Policy = "AllRoles")]
    [ProducesResponseType(typeof(ServicioDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ServicioDto>> BuscarPorID(int id)
    {
        try
        {
            var servicio = await _servicioService.BuscarPorIDAsync(id);

            if (servicio == null)
            {
                return NotFound(new { message = $"Servicio con ID {id} no encontrado" });
            }

            return Ok(servicio);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al buscar servicio por ID: {Id}", id);
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }

    /// <summary>
    /// Crea un nuevo servicio (solo Administrador)
    /// </summary>
    [HttpPost]
    [Authorize(Policy = "Administrador")]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<int>> Crear([FromBody] ServicioCreateDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nuevoID = await _servicioService.CrearAsync(dto);
            return CreatedAtAction(nameof(BuscarPorID), new { id = nuevoID }, new { id = nuevoID });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al crear servicio");
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }

    /// <summary>
    /// Actualiza un servicio existente (solo Administrador)
    /// </summary>
    [HttpPut]
    [Authorize(Policy = "Administrador")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Actualizar([FromBody] ServicioUpdateDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _servicioService.ActualizarAsync(dto);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al actualizar servicio: {Id}", dto.ID_Servicio);
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }

    /// <summary>
    /// Elimina un servicio (solo Administrador)
    /// </summary>
    [HttpDelete("{id}")]
    [Authorize(Policy = "Administrador")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Eliminar(int id)
    {
        try
        {
            await _servicioService.EliminarAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al eliminar servicio: {Id}", id);
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }
}

