using VeterinariaGenesisAPI.Models.DTOs;

namespace VeterinariaGenesisAPI.Services.Interfaces;

public interface ICitaService
{
    Task<int> AgendarAsync(CitaCreateDto dto);
    Task ActualizarAsync(CitaUpdateDto dto);
    Task CancelarAsync(int id);
    Task<List<CitaDto>> ListarPorFechaAsync(DateTime fecha);
    Task<List<CitaDto>> ListarPorVeterinarioAsync(int idVeterinario);
    Task<List<CitaDto>> ListarCompletadasSinFacturaAsync();
}


