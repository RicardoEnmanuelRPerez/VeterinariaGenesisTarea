namespace VeterinariaGenesisForms.Models.Dto;

public class CitaDto
{
    public int ID_Cita { get; set; }
    public DateTime Fecha { get; set; }
    public TimeSpan Hora { get; set; }
    public string Estado { get; set; } = string.Empty;
    public int ID_Mascota { get; set; }
    public string? Mascota { get; set; }
    public int ID_Propietario { get; set; }
    public string? Propietario { get; set; }
    public int ID_Veterinario { get; set; }
    public string? Veterinario { get; set; }
    public int ID_Servicio { get; set; }
    public string? Servicio { get; set; }
}

public class CitaCreateDto
{
    public DateTime Fecha { get; set; }
    public TimeSpan Hora { get; set; }
    public int ID_Mascota { get; set; }
    public int ID_Veterinario { get; set; }
    public int ID_Servicio { get; set; }
}

public class CitaUpdateDto
{
    public int ID_Cita { get; set; }
    public DateTime Fecha { get; set; }
    public TimeSpan Hora { get; set; }
    public int ID_Mascota { get; set; }
    public int ID_Veterinario { get; set; }
    public int ID_Servicio { get; set; }
    public string Estado { get; set; } = string.Empty;
}

