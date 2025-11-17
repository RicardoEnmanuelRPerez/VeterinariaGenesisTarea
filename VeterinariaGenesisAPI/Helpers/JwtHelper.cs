using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using VeterinariaGenesisAPI.Models.DTOs;

namespace VeterinariaGenesisAPI.Helpers;

public class JwtHelper
{
    private readonly IConfiguration _configuration;

    public JwtHelper(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(UsuarioInfoDto usuario)
    {
        try
        {
            var key = _configuration["Jwt:Key"];
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            
            if (string.IsNullOrEmpty(key))
                throw new InvalidOperationException("JWT Key no está configurado en appsettings.json");
            if (string.IsNullOrEmpty(issuer))
                throw new InvalidOperationException("JWT Issuer no está configurado en appsettings.json");
            if (string.IsNullOrEmpty(audience))
                throw new InvalidOperationException("JWT Audience no está configurado en appsettings.json");

            var keyBytes = Encoding.UTF8.GetBytes(key);
            var expirationMinutes = int.Parse(_configuration["Jwt:ExpirationMinutes"] ?? "60");

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, usuario.ID_Usuario.ToString()),
                new(ClaimTypes.Name, usuario.NombreLogin),
                new(ClaimTypes.GivenName, usuario.NombreCompleto),
                new(ClaimTypes.Role, usuario.NombreRol)
            };

            if (usuario.ID_Veterinario.HasValue)
            {
                claims.Add(new Claim("ID_Veterinario", usuario.ID_Veterinario.Value.ToString()));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(expirationMinutes),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(keyBytes),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error al generar el token JWT: {ex.Message}", ex);
        }
    }
}


