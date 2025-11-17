using VeterinariaGenesisAPI.DAO.Interfaces;
using VeterinariaGenesisAPI.Models.DTOs;
using VeterinariaGenesisAPI.Services.Interfaces;

namespace VeterinariaGenesisAPI.Services;

public class PropietarioService : IPropietarioService
{
    private readonly IPropietarioDAO _propietarioDAO;

    public PropietarioService(IPropietarioDAO propietarioDAO)
    {
        _propietarioDAO = propietarioDAO;
    }

    public async Task<int> CrearAsync(PropietarioCreateDto dto)
    {
        return await _propietarioDAO.CrearAsync(dto);
    }

    public async Task ActualizarAsync(PropietarioUpdateDto dto)
    {
        await _propietarioDAO.ActualizarAsync(dto);
    }

    public async Task DesactivarAsync(int id)
    {
        await _propietarioDAO.DesactivarAsync(id);
    }

    public async Task<List<PropietarioDto>> ListarActivosAsync()
    {
        return await _propietarioDAO.ListarActivosAsync();
    }

    public async Task<PropietarioDto?> BuscarPorIDAsync(int id)
    {
        return await _propietarioDAO.BuscarPorIDAsync(id);
    }
}


