using VeterinariaGenesisForms.Controllers;
using VeterinariaGenesisForms.Models.Dto;
using VeterinariaGenesisForms.Repository.Interfaces;

namespace VeterinariaGenesisForms.Repository;

public class MascotaRepository : IMascotaRepository
{
    private readonly ApiClient _apiClient;

    public MascotaRepository(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<List<MascotaDto>> ListarPorPropietarioAsync(int idPropietario)
    {
        var resultado = await _apiClient.GetAsync<List<MascotaDto>>($"Mascota/propietario/{idPropietario}");
        return resultado ?? new List<MascotaDto>();
    }

    public async Task<MascotaDto?> BuscarPorIDAsync(int id)
    {
        return await _apiClient.GetAsync<MascotaDto>($"Mascota/{id}");
    }

    public async Task<int> CrearAsync(MascotaCreateDto dto)
    {
        var response = await _apiClient.PostAsync<dynamic>("Mascota", dto);
        if (response != null && response.id != null)
            return (int)response.id;
        throw new Exception("No se pudo crear la mascota");
    }

    public async Task ActualizarAsync(MascotaUpdateDto dto)
    {
        await _apiClient.PutAsync("Mascota", dto);
    }

    public async Task EliminarAsync(int id)
    {
        await _apiClient.DeleteAsync($"Mascota/{id}");
    }
}

