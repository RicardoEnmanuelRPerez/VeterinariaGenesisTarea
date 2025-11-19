using VeterinariaGenesisAPI.DAO.Interfaces;
using VeterinariaGenesisAPI.Models.DTOs;
using VeterinariaGenesisAPI.Services.Interfaces;

namespace VeterinariaGenesisAPI.Services;

public class VeterinarioService : IVeterinarioService
{
    private readonly IVeterinarioDAO _veterinarioDAO;

    public VeterinarioService(IVeterinarioDAO veterinarioDAO)
    {
        _veterinarioDAO = veterinarioDAO;
    }

    public async Task<List<VeterinarioDto>> ListarActivosAsync()
    {
        return await _veterinarioDAO.ListarActivosAsync();
    }

    public async Task<VeterinarioDto?> BuscarPorIDAsync(int id)
    {
        return await _veterinarioDAO.BuscarPorIDAsync(id);
    }
}

