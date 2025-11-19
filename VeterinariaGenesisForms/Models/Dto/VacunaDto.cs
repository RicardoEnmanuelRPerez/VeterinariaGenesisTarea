namespace VeterinariaGenesisForms.Models.Dto;

// DTO para Recordatorios de Vacunación
public class RecordatorioVacunacionDto
{
    public int ID_Mascota { get; set; }
    public string NombreMascota { get; set; } = string.Empty;
    public string Especie { get; set; } = string.Empty;
    public string? Raza { get; set; }
    public int ID_Propietario { get; set; }
    public string NombrePropietario { get; set; } = string.Empty;
    public string? Telefono { get; set; }
    public string? Direccion { get; set; }
    public string NombreVacuna { get; set; } = string.Empty;
    public string? Dosis { get; set; }
    public DateTime FechaAplicacion { get; set; }
    public DateTime? FechaProximaDosis { get; set; }
    public string Estado { get; set; } = string.Empty;
    public int? DiasRestantes { get; set; }
}

