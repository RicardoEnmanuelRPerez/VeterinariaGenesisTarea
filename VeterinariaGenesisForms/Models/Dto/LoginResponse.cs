namespace VeterinariaGenesisForms.Models.Dto;

public class LoginResponse
{
    public string Token { get; set; } = string.Empty;
    public UsuarioInfo Usuario { get; set; } = new();
}

public class UsuarioInfo
{
    public int ID_Usuario { get; set; }
    public string NombreLogin { get; set; } = string.Empty;
    public string NombreCompleto { get; set; } = string.Empty;
    public string NombreRol { get; set; } = string.Empty;
    public int? ID_Veterinario { get; set; }
}

