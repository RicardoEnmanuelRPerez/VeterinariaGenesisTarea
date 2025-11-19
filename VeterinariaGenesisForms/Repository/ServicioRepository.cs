using VeterinariaGenesisForms.Controllers;
using VeterinariaGenesisForms.Models.Dto;
using VeterinariaGenesisForms.Repository.Interfaces;

namespace VeterinariaGenesisForms.Repository;

public class ServicioRepository : IServicioRepository
{
    private readonly ApiClient _apiClient;

    public ServicioRepository(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<List<ServicioDto>> ListarAsync()
    {
        var resultado = await _apiClient.GetAsync<List<ServicioDto>>("Servicio");
        return resultado ?? new List<ServicioDto>();
    }

    public async Task<ServicioDto?> BuscarPorIDAsync(int id)
    {
        return await _apiClient.GetAsync<ServicioDto>($"Servicio/{id}");
    }

    public async Task<int> CrearAsync(ServicioCreateDto dto)
    {
        var resultado = await _apiClient.PostAsync<Dictionary<string, object>>("Servicio", dto);
        if (resultado != null && resultado.ContainsKey("id"))
        {
            return Convert.ToInt32(resultado["id"]);
        }
        throw new Exception("No se pudo obtener el ID del servicio creado");
    }

    public async Task ActualizarAsync(ServicioUpdateDto dto)
    {
        await _apiClient.PutAsync("Servicio", dto);
    }

    public async Task EliminarAsync(int id)
    {
        await _apiClient.DeleteAsync($"Servicio/{id}");
    }
}

