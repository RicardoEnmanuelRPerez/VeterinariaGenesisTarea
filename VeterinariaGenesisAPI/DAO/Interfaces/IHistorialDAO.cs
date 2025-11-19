using VeterinariaGenesisAPI.Models.DTOs;

namespace VeterinariaGenesisAPI.DAO.Interfaces;

public interface IHistorialDAO
{
    Task<List<HistorialClinicoDto>> ObtenerHistorialPorMascotaAsync(int idMascota);
    Task<List<MascotaBusquedaDto>> BuscarMascotasAsync(string? busqueda);
}

