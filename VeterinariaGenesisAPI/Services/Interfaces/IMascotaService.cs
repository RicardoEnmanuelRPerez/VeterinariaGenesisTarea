using VeterinariaGenesisAPI.Models.DTOs;

namespace VeterinariaGenesisAPI.Services.Interfaces;

public interface IMascotaService
{
    Task<int> CrearAsync(MascotaCreateDto dto);
    Task ActualizarAsync(MascotaUpdateDto dto);
    Task EliminarAsync(int id);
    Task<List<MascotaDto>> ListarPorPropietarioAsync(int idPropietario);
    Task<MascotaDto?> BuscarPorIDAsync(int id);
}


