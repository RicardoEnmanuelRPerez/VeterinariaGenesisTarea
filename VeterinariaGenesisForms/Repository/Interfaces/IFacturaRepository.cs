using VeterinariaGenesisForms.Models.Dto;

namespace VeterinariaGenesisForms.Repository.Interfaces;

public interface IFacturaRepository
{
    Task<int> CrearDesdeCitaAsync(FacturaCreateDto dto);
    Task AgregarItemAsync(FacturaItemDto dto);
    Task PagarAsync(FacturaPagoDto dto);
    Task<FacturaDto?> BuscarPorIDAsync(int id);
    Task<List<FacturaDto>> ListarAsync();
}

