using VeterinariaGenesisAPI.Models.DTOs;

namespace VeterinariaGenesisAPI.Services.Interfaces;

public interface IPropietarioService
{
    Task<int> CrearAsync(PropietarioCreateDto dto);
    Task ActualizarAsync(PropietarioUpdateDto dto);
    Task DesactivarAsync(int id);
    Task<List<PropietarioDto>> ListarActivosAsync();
    Task<PropietarioDto?> BuscarPorIDAsync(int id);
}


