using VeterinariaGenesisAPI.Models.DTOs;

namespace VeterinariaGenesisAPI.Services.Interfaces;

public interface IVeterinarioService
{
    Task<List<VeterinarioDto>> ListarActivosAsync();
    Task<VeterinarioDto?> BuscarPorIDAsync(int id);
}

