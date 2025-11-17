using VeterinariaGenesisAPI.DAO.Interfaces;
using VeterinariaGenesisAPI.Models.DTOs;
using VeterinariaGenesisAPI.Services.Interfaces;

namespace VeterinariaGenesisAPI.Services;

public class FacturaService : IFacturaService
{
    private readonly IFacturaDAO _facturaDAO;

    public FacturaService(IFacturaDAO facturaDAO)
    {
        _facturaDAO = facturaDAO;
    }

    public async Task<int> CrearDesdeCitaAsync(int idCita)
    {
        return await _facturaDAO.CrearDesdeCitaAsync(idCita);
    }

    public async Task AgregarItemAsync(FacturaItemDto dto)
    {
        await _facturaDAO.AgregarItemAsync(dto);
    }

    public async Task PagarAsync(FacturaPagoDto dto)
    {
        await _facturaDAO.PagarAsync(dto);
    }
}


