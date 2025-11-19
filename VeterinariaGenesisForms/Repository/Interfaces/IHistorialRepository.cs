using VeterinariaGenesisForms.Models.Dto;

namespace VeterinariaGenesisForms.Repository.Interfaces;

public interface IHistorialRepository
{
    Task<List<HistorialClinicoDto>> ObtenerHistorialPorMascotaAsync(int idMascota);
    Task<List<MascotaBusquedaDto>> BuscarMascotasAsync(string? busqueda);
}

