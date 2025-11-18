using VeterinariaGenesisForms.Controllers;
using VeterinariaGenesisForms.Models.Dto;
using VeterinariaGenesisForms.Repository.Interfaces;
using Newtonsoft.Json;

namespace VeterinariaGenesisForms.Repository;

public class PropietarioRepository : IPropietarioRepository
{
    private readonly ApiClient _apiClient;

    public PropietarioRepository(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<List<PropietarioDto>> ListarActivosAsync()
    {
        var resultado = await _apiClient.GetAsync<List<PropietarioDto>>("Propietario");
        return resultado ?? new List<PropietarioDto>();
    }

    public async Task<PropietarioDto?> BuscarPorIDAsync(int id)
    {
        return await _apiClient.GetAsync<PropietarioDto>($"Propietario/{id}");
    }

    public async Task<int> CrearAsync(PropietarioCreateDto dto)
    {
        var response = await _apiClient.PostAsync<dynamic>("Propietario", dto);
        if (response != null && response.id != null)
            return (int)response.id;
        throw new Exception("No se pudo crear el propietario");
    }

    public async Task ActualizarAsync(PropietarioUpdateDto dto)
    {
        await _apiClient.PutAsync("Propietario", dto);
    }

    public async Task DesactivarAsync(int id)
    {
        await _apiClient.DeleteAsync($"Propietario/{id}");
    }
}

