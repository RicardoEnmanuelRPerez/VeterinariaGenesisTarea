using VeterinariaGenesisAPI.Models.DTOs;

namespace VeterinariaGenesisAPI.DAO.Interfaces;

public interface IAuthDAO
{
    Task<UsuarioInfoDto?> LoginAsync(string nombreLogin, string contrasena);
}

