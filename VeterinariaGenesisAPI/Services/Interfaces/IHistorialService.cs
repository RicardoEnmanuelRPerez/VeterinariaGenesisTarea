using VeterinariaGenesisAPI.Models.DTOs;

namespace VeterinariaGenesisAPI.Services.Interfaces;

public interface IHistorialService
{
    Task<List<HistorialClinicoDto>> ObtenerHistorialPorMascotaAsync(int idMascota);
    Task<List<MascotaBusquedaDto>> BuscarMascotasAsync(string? busqueda);
}

