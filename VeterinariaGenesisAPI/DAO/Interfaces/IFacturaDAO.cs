using VeterinariaGenesisAPI.Models.DTOs;

namespace VeterinariaGenesisAPI.DAO.Interfaces;

public interface IFacturaDAO
{
    Task<int> CrearDesdeCitaAsync(int idCita);
    Task AgregarItemAsync(FacturaItemDto dto);
    Task PagarAsync(FacturaPagoDto dto);
}

