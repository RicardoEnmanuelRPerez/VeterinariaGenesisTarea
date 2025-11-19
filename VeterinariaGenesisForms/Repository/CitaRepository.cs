using VeterinariaGenesisForms.Controllers;
using VeterinariaGenesisForms.Models.Dto;
using VeterinariaGenesisForms.Repository.Interfaces;

namespace VeterinariaGenesisForms.Repository;

public class CitaRepository : ICitaRepository
{
    private readonly ApiClient _apiClient;

    public CitaRepository(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<List<CitaDto>> ListarPorFechaAsync(DateTime fecha)
    {
        var fechaStr = fecha.ToString("yyyy-MM-dd");
        var resultado = await _apiClient.GetAsync<List<CitaDto>>($"Cita/fecha/{fechaStr}");
        return resultado ?? new List<CitaDto>();
    }

    public async Task<List<CitaDto>> ListarPorVeterinarioAsync(int idVeterinario)
    {
        var resultado = await _apiClient.GetAsync<List<CitaDto>>($"Cita/veterinario/{idVeterinario}");
        return resultado ?? new List<CitaDto>();
    }

    public async Task<List<CitaDto>> MisCitasAsync()
    {
        var resultado = await _apiClient.GetAsync<List<CitaDto>>("Cita/mis-citas");
        return resultado ?? new List<CitaDto>();
    }

    public async Task<int> AgendarAsync(CitaCreateDto dto)
    {
        var response = await _apiClient.PostAsync<dynamic>("Cita/agendar", dto);
        if (response != null && response.id != null)
            return (int)response.id;
        throw new Exception("No se pudo agendar la cita");
    }

    public async Task ActualizarAsync(CitaUpdateDto dto)
    {
        await _apiClient.PutAsync("Cita", dto);
    }

    public async Task CancelarAsync(int id)
    {
        await _apiClient.PostAsync($"Cita/{id}/cancelar", new { });
    }

    public async Task<List<CitaDto>> ListarCompletadasSinFacturaAsync()
    {
        var resultado = await _apiClient.GetAsync<List<CitaDto>>("Cita/completadas-sin-factura");
        return resultado ?? new List<CitaDto>();
    }
}

