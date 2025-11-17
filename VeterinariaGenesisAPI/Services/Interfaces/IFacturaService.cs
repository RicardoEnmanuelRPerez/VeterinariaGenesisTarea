using VeterinariaGenesisAPI.Models.DTOs;

namespace VeterinariaGenesisAPI.Services.Interfaces;

public interface IFacturaService
{
    Task<int> CrearDesdeCitaAsync(int idCita);
    Task AgregarItemAsync(FacturaItemDto dto);
    Task PagarAsync(FacturaPagoDto dto);
}


