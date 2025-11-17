using VeterinariaGenesisAPI.DAO.Interfaces;
using VeterinariaGenesisAPI.Helpers;
using VeterinariaGenesisAPI.Models.DTOs;
using VeterinariaGenesisAPI.Services.Interfaces;

namespace VeterinariaGenesisAPI.Services;

public class AuthService : IAuthService
{
    private readonly IAuthDAO _authDAO;
    private readonly JwtHelper _jwtHelper;

    public AuthService(IAuthDAO authDAO, JwtHelper jwtHelper)
    {
        _authDAO = authDAO;
        _jwtHelper = jwtHelper;
    }

    public async Task<LoginResponseDto?> LoginAsync(LoginDto loginDto)
    {
        try
        {
            var usuario = await _authDAO.LoginAsync(loginDto.NombreLogin, loginDto.Contrasena);
            
            if (usuario == null)
            {
                return null;
            }

            var token = _jwtHelper.GenerateToken(usuario);

            return new LoginResponseDto
            {
                Token = token,
                Usuario = usuario
            };
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error en el servicio de autenticación: {ex.Message}", ex);
        }
    }
}


