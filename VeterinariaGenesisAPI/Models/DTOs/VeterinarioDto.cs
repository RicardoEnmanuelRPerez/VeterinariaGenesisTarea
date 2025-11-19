namespace VeterinariaGenesisAPI.Models.DTOs;

public class VeterinarioDto
{
    public int ID_Veterinario { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Especialidad { get; set; }
    public string? Telefono { get; set; }
    public string? Correo { get; set; }
    public bool Activo { get; set; }
}

