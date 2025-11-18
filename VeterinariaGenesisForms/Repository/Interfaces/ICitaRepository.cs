using VeterinariaGenesisForms.Models.Dto;

namespace VeterinariaGenesisForms.Repository.Interfaces;

public interface ICitaRepository
{
    Task<List<CitaDto>> ListarPorFechaAsync(DateTime fecha);
    Task<List<CitaDto>> ListarPorVeterinarioAsync(int idVeterinario);
    Task<List<CitaDto>> MisCitasAsync();
    Task<int> AgendarAsync(CitaCreateDto dto);
    Task CancelarAsync(int id);
}

