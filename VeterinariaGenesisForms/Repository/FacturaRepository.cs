using VeterinariaGenesisForms.Controllers;
using VeterinariaGenesisForms.Models.Dto;
using VeterinariaGenesisForms.Repository.Interfaces;

namespace VeterinariaGenesisForms.Repository;

public class FacturaRepository : IFacturaRepository
{
    private readonly ApiClient _apiClient;

    public FacturaRepository(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<int> CrearDesdeCitaAsync(FacturaCreateDto dto)
    {
        var response = await _apiClient.PostAsync<dynamic>("Factura/desde-cita", dto);
        if (response != null && response.id != null)
            return (int)response.id;
        throw new Exception("No se pudo crear la factura");
    }

    public async Task AgregarItemAsync(FacturaItemDto dto)
    {
        await _apiClient.PostAsync("Factura/agregar-item", dto);
    }

    public async Task PagarAsync(FacturaPagoDto dto)
    {
        await _apiClient.PostAsync("Factura/pagar", dto);
    }
}

