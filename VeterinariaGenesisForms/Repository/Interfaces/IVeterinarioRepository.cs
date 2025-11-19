using VeterinariaGenesisForms.Models.Dto;

namespace VeterinariaGenesisForms.Repository.Interfaces;

public interface IVeterinarioRepository
{
    Task<List<VeterinarioDto>> ListarActivosAsync();
    Task<VeterinarioDto?> BuscarPorIDAsync(int id);
}

