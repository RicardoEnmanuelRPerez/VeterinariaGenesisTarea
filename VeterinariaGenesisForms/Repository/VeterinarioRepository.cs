using VeterinariaGenesisForms.Controllers;
using VeterinariaGenesisForms.Models.Dto;
using VeterinariaGenesisForms.Repository.Interfaces;

namespace VeterinariaGenesisForms.Repository;

public class VeterinarioRepository : IVeterinarioRepository
{
    private readonly ApiClient _apiClient;

    public VeterinarioRepository(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<List<VeterinarioDto>> ListarActivosAsync()
    {
        var resultado = await _apiClient.GetAsync<List<VeterinarioDto>>("Veterinario");
        return resultado ?? new List<VeterinarioDto>();
    }

    public async Task<VeterinarioDto?> BuscarPorIDAsync(int id)
    {
        return await _apiClient.GetAsync<VeterinarioDto>($"Veterinario/{id}");
    }
}

