using VeterinariaGenesisAPI.Models.DTOs;

namespace VeterinariaGenesisAPI.Services.Interfaces;

public interface IServicioService
{
    Task<List<ServicioDto>> ListarAsync();
    Task<ServicioDto?> BuscarPorIDAsync(int id);
    Task<int> CrearAsync(ServicioCreateDto dto);
    Task ActualizarAsync(ServicioUpdateDto dto);
    Task EliminarAsync(int id);
}

