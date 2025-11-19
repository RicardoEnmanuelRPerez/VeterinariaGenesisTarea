namespace VeterinariaGenesisForms.Models.Dto;

// DTO para Dashboard
public class DashboardCirugiasDto
{
    public int ID_Veterinario { get; set; }
    public string NombreVeterinario { get; set; } = string.Empty;
    public string? Especialidad { get; set; }
    public int CantidadCirugias { get; set; }
    public decimal PorcentajeTotal { get; set; }
}

public class DashboardCitasDiaSemanaDto
{
    public string DiaSemana { get; set; } = string.Empty;
    public int CantidadCitas { get; set; }
    public int CitasCompletadas { get; set; }
    public int CitasCanceladas { get; set; }
}

public class DashboardProductividadDto
{
    public int ID_Veterinario { get; set; }
    public string NombreVeterinario { get; set; } = string.Empty;
    public string? Especialidad { get; set; }
    public int TotalCitas { get; set; }
    public int TotalCirugias { get; set; }
    public int TotalTratamientos { get; set; }
    public decimal IngresosGenerados { get; set; }
}

