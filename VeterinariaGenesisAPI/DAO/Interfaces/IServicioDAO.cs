using VeterinariaGenesisAPI.Models.DTOs;

namespace VeterinariaGenesisAPI.DAO.Interfaces;

public interface IServicioDAO
{
    Task<List<ServicioDto>> ListarAsync();
    Task<ServicioDto?> BuscarPorIDAsync(int id);
    Task<int> CrearAsync(ServicioCreateDto dto);
    Task ActualizarAsync(ServicioUpdateDto dto);
    Task EliminarAsync(int id);
}

