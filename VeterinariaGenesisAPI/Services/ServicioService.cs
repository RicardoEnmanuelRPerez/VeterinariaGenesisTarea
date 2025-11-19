using VeterinariaGenesisAPI.DAO.Interfaces;
using VeterinariaGenesisAPI.Models.DTOs;
using VeterinariaGenesisAPI.Services.Interfaces;

namespace VeterinariaGenesisAPI.Services;

public class ServicioService : IServicioService
{
    private readonly IServicioDAO _servicioDAO;

    public ServicioService(IServicioDAO servicioDAO)
    {
        _servicioDAO = servicioDAO;
    }

    public async Task<List<ServicioDto>> ListarAsync()
    {
        return await _servicioDAO.ListarAsync();
    }

    public async Task<ServicioDto?> BuscarPorIDAsync(int id)
    {
        return await _servicioDAO.BuscarPorIDAsync(id);
    }

    public async Task<int> CrearAsync(ServicioCreateDto dto)
    {
        return await _servicioDAO.CrearAsync(dto);
    }

    public async Task ActualizarAsync(ServicioUpdateDto dto)
    {
        await _servicioDAO.ActualizarAsync(dto);
    }

    public async Task EliminarAsync(int id)
    {
        await _servicioDAO.EliminarAsync(id);
    }
}

