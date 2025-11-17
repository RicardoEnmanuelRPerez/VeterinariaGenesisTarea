namespace VeterinariaGenesisAPI.Models.DTOs;

public class LoginDto
{
    public string NombreLogin { get; set; } = string.Empty;
    public string Contrasena { get; set; } = string.Empty;
}

public class LoginResponseDto
{
    public string Token { get; set; } = string.Empty;
    public UsuarioInfoDto Usuario { get; set; } = new();
}

public class UsuarioInfoDto
{
    public int ID_Usuario { get; set; }
    public string NombreLogin { get; set; } = string.Empty;
    public string NombreCompleto { get; set; } = string.Empty;
    public string NombreRol { get; set; } = string.Empty;
    public int? ID_Veterinario { get; set; }
}


