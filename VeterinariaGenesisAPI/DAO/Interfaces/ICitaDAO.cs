using VeterinariaGenesisAPI.Models.DTOs;

namespace VeterinariaGenesisAPI.DAO.Interfaces;

public interface ICitaDAO
{
    Task<int> AgendarAsync(CitaCreateDto dto);
    Task CancelarAsync(int id);
    Task<List<CitaDto>> ListarPorFechaAsync(DateTime fecha);
    Task<List<CitaDto>> ListarPorVeterinarioAsync(int idVeterinario);
}

