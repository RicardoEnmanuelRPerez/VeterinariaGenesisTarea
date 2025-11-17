using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeterinariaGenesisAPI.Models.DTOs;
using VeterinariaGenesisAPI.Services.Interfaces;

namespace VeterinariaGenesisAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class FacturaController : ControllerBase
{
    private readonly IFacturaService _facturaService;
    private readonly ILogger<FacturaController> _logger;

    public FacturaController(IFacturaService facturaService, ILogger<FacturaController> logger)
    {
        _facturaService = facturaService;
        _logger = logger;
    }

    /// <summary>
    /// Crea una factura desde una cita (transaccional)
    /// </summary>
    [HttpPost("desde-cita")]
    [Authorize(Policy = "AllRoles")]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<int>> CrearDesdeCita([FromBody] FacturaCreateDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nuevaID = await _facturaService.CrearDesdeCitaAsync(dto.ID_Cita);
            return CreatedAtAction(nameof(CrearDesdeCita), new { id = nuevaID }, new { id = nuevaID });
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogWarning(ex, "Error de negocio al crear factura desde cita");
            return Conflict(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al crear factura desde cita");
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }

    /// <summary>
    /// Agrega un item adicional a una factura existente
    /// </summary>
    [HttpPost("agregar-item")]
    [Authorize(Policy = "AllRoles")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AgregarItem([FromBody] FacturaItemDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _facturaService.AgregarItemAsync(dto);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al agregar item a factura");
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }

    /// <summary>
    /// Procesa el pago de una factura (transaccional)
    /// </summary>
    [HttpPost("pagar")]
    [Authorize(Policy = "AllRoles")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Pagar([FromBody] FacturaPagoDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _facturaService.PagarAsync(dto);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogWarning(ex, "Error de negocio al pagar factura");
            return Conflict(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al pagar factura");
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }
}


