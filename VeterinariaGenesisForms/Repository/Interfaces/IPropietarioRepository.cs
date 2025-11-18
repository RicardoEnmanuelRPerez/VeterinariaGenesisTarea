using VeterinariaGenesisForms.Models.Dto;

namespace VeterinariaGenesisForms.Repository.Interfaces;

public interface IPropietarioRepository
{
    Task<List<PropietarioDto>> ListarActivosAsync();
    Task<PropietarioDto?> BuscarPorIDAsync(int id);
    Task<int> CrearAsync(PropietarioCreateDto dto);
    Task ActualizarAsync(PropietarioUpdateDto dto);
    Task DesactivarAsync(int id);
}

