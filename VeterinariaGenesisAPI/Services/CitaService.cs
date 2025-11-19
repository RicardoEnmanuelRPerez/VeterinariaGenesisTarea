using VeterinariaGenesisAPI.DAO.Interfaces;
using VeterinariaGenesisAPI.Models.DTOs;
using VeterinariaGenesisAPI.Services.Interfaces;

namespace VeterinariaGenesisAPI.Services;

public class CitaService : ICitaService
{
    private readonly ICitaDAO _citaDAO;

    public CitaService(ICitaDAO citaDAO)
    {
        _citaDAO = citaDAO;
    }

    public async Task<int> AgendarAsync(CitaCreateDto dto)
    {
        return await _citaDAO.AgendarAsync(dto);
    }

    public async Task ActualizarAsync(CitaUpdateDto dto)
    {
        await _citaDAO.ActualizarAsync(dto);
    }

    public async Task CancelarAsync(int id)
    {
        await _citaDAO.CancelarAsync(id);
    }

    public async Task<List<CitaDto>> ListarPorFechaAsync(DateTime fecha)
    {
        return await _citaDAO.ListarPorFechaAsync(fecha);
    }

    public async Task<List<CitaDto>> ListarPorVeterinarioAsync(int idVeterinario)
    {
        return await _citaDAO.ListarPorVeterinarioAsync(idVeterinario);
    }

    public async Task<List<CitaDto>> ListarCompletadasSinFacturaAsync()
    {
        return await _citaDAO.ListarCompletadasSinFacturaAsync();
    }
}


