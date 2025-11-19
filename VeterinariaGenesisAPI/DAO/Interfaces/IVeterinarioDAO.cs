using VeterinariaGenesisAPI.Models.DTOs;

namespace VeterinariaGenesisAPI.DAO.Interfaces;

public interface IVeterinarioDAO
{
    Task<List<VeterinarioDto>> ListarActivosAsync();
    Task<VeterinarioDto?> BuscarPorIDAsync(int id);
}

