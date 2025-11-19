namespace VeterinariaGenesisForms.Models.Dto;

// DTO para Historial Clínico
public class HistorialClinicoDto
{
    public string TipoEvento { get; set; } = string.Empty;
    public string ID_Evento { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
    public TimeSpan? Hora { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public string? Veterinario { get; set; }
    public decimal? Costo { get; set; }
    public string? Estado { get; set; }
    public string? Observaciones { get; set; }
}

public class MascotaBusquedaDto
{
    public int ID_Mascota { get; set; }
    public string NombreMascota { get; set; } = string.Empty;
    public string Especie { get; set; } = string.Empty;
    public string? Raza { get; set; }
    public int? Edad { get; set; }
    public int ID_Propietario { get; set; }
    public string NombrePropietario { get; set; } = string.Empty;
    public string? Telefono { get; set; }
    public string? Direccion { get; set; }
}

