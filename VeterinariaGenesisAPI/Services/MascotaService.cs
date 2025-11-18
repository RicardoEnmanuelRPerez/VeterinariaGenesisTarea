using VeterinariaGenesisAPI.DAO.Interfaces;
using VeterinariaGenesisAPI.Models.DTOs;
using VeterinariaGenesisAPI.Services.Interfaces;

namespace VeterinariaGenesisAPI.Services;

public class MascotaService : IMascotaService
{
    private readonly IMascotaDAO _mascotaDAO;

    public MascotaService(IMascotaDAO mascotaDAO)
    {
        _mascotaDAO = mascotaDAO;
    }

    public async Task<int> CrearAsync(MascotaCreateDto dto)
    {
        return await _mascotaDAO.CrearAsync(dto);
    }

    public async Task ActualizarAsync(MascotaUpdateDto dto)
    {
        await _mascotaDAO.ActualizarAsync(dto);
    }

    public async Task EliminarAsync(int id)
    {
        await _mascotaDAO.EliminarAsync(id);
    }

    public async Task<List<MascotaDto>> ListarPorPropietarioAsync(int idPropietario)
    {
        return await _mascotaDAO.ListarPorPropietarioAsync(idPropietario);
    }

    public async Task<MascotaDto?> BuscarPorIDAsync(int id)
    {
        return await _mascotaDAO.BuscarPorIDAsync(id);
    }
}


