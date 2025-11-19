using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeterinariaGenesisAPI.Models.DTOs;
using VeterinariaGenesisAPI.Services.Interfaces;

namespace VeterinariaGenesisAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class VeterinarioController : ControllerBase
{
    private readonly IVeterinarioService _veterinarioService;
    private readonly ILogger<VeterinarioController> _logger;

    public VeterinarioController(IVeterinarioService veterinarioService, ILogger<VeterinarioController> logger)
    {
        _veterinarioService = veterinarioService;
        _logger = logger;
    }

    /// <summary>
    /// Obtiene la lista de veterinarios activos
    /// </summary>
    [HttpGet]
    [Authorize(Policy = "AllRoles")]
    [ProducesResponseType(typeof(List<VeterinarioDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<VeterinarioDto>>> ListarActivos()
    {
        try
        {
            var veterinarios = await _veterinarioService.ListarActivosAsync();
            return Ok(veterinarios);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al listar veterinarios activos");
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }

    /// <summary>
    /// Obtiene un veterinario por su ID
    /// </summary>
    [HttpGet("{id}")]
    [Authorize(Policy = "AllRoles")]
    [ProducesResponseType(typeof(VeterinarioDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<VeterinarioDto>> BuscarPorID(int id)
    {
        try
        {
            var veterinario = await _veterinarioService.BuscarPorIDAsync(id);

            if (veterinario == null)
            {
                return NotFound(new { message = $"Veterinario con ID {id} no encontrado" });
            }

            return Ok(veterinario);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al buscar veterinario por ID: {Id}", id);
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }
}

