using VeterinariaGenesisForms.Models.Dto;

namespace VeterinariaGenesisForms.Repository.Interfaces;

public interface IMascotaRepository
{
    Task<List<MascotaDto>> ListarPorPropietarioAsync(int idPropietario);
    Task<MascotaDto?> BuscarPorIDAsync(int id);
    Task<int> CrearAsync(MascotaCreateDto dto);
    Task ActualizarAsync(MascotaUpdateDto dto);
    Task EliminarAsync(int id);
}

