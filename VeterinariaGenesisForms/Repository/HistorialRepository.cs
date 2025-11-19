using VeterinariaGenesisForms.Controllers;
using VeterinariaGenesisForms.Models.Dto;
using VeterinariaGenesisForms.Repository.Interfaces;

namespace VeterinariaGenesisForms.Repository;

public class HistorialRepository : IHistorialRepository
{
    private readonly ApiClient _apiClient;

    public HistorialRepository(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<List<HistorialClinicoDto>> ObtenerHistorialPorMascotaAsync(int idMascota)
    {
        var resultado = await _apiClient.GetAsync<List<HistorialClinicoDto>>($"Historial/mascota/{idMascota}");
        return resultado ?? new List<HistorialClinicoDto>();
    }

    public async Task<List<MascotaBusquedaDto>> BuscarMascotasAsync(string? busqueda)
    {
        var queryString = string.IsNullOrWhiteSpace(busqueda) ? "" : $"?busqueda={Uri.EscapeDataString(busqueda)}";
        var resultado = await _apiClient.GetAsync<List<MascotaBusquedaDto>>($"Historial/buscar{queryString}");
        return resultado ?? new List<MascotaBusquedaDto>();
    }
}

