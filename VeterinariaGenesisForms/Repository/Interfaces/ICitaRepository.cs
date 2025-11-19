using VeterinariaGenesisForms.Models.Dto;

namespace VeterinariaGenesisForms.Repository.Interfaces;

public interface ICitaRepository
{
    Task<List<CitaDto>> ListarPorFechaAsync(DateTime fecha);
    Task<List<CitaDto>> ListarPorVeterinarioAsync(int idVeterinario);
    Task<List<CitaDto>> MisCitasAsync();
    Task<List<CitaDto>> ListarCompletadasSinFacturaAsync();
    Task<int> AgendarAsync(CitaCreateDto dto);
    Task ActualizarAsync(CitaUpdateDto dto);
    Task CancelarAsync(int id);
}

