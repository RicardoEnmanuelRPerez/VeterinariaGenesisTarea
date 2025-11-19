using VeterinariaGenesisForms.Models.Dto;

namespace VeterinariaGenesisForms.Repository.Interfaces;

public interface IServicioRepository
{
    Task<List<ServicioDto>> ListarAsync();
    Task<ServicioDto?> BuscarPorIDAsync(int id);
    Task<int> CrearAsync(ServicioCreateDto dto);
    Task ActualizarAsync(ServicioUpdateDto dto);
    Task EliminarAsync(int id);
}

