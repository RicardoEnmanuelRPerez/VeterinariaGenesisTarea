using VeterinariaGenesisAPI.DAO.Interfaces;
using VeterinariaGenesisAPI.Models.DTOs;
using VeterinariaGenesisAPI.Services.Interfaces;

namespace VeterinariaGenesisAPI.Services;

public class HistorialService : IHistorialService
{
    private readonly IHistorialDAO _historialDAO;

    public HistorialService(IHistorialDAO historialDAO)
    {
        _historialDAO = historialDAO;
    }

    public async Task<List<HistorialClinicoDto>> ObtenerHistorialPorMascotaAsync(int idMascota)
    {
        try
        {
            return await _historialDAO.ObtenerHistorialPorMascotaAsync(idMascota);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error en el servicio al obtener historial clínico: {ex.Message}", ex);
        }
    }

    public async Task<List<MascotaBusquedaDto>> BuscarMascotasAsync(string? busqueda)
    {
        try
        {
            return await _historialDAO.BuscarMascotasAsync(busqueda);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error en el servicio al buscar mascotas: {ex.Message}", ex);
        }
    }
}

