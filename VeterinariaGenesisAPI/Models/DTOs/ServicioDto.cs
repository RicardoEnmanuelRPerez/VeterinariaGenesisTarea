namespace VeterinariaGenesisAPI.Models.DTOs;

public class ServicioDto
{
    public int ID_Servicio { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public decimal Costo { get; set; }
}

public class ServicioCreateDto
{
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public decimal Costo { get; set; }
}

public class ServicioUpdateDto
{
    public int ID_Servicio { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public decimal Costo { get; set; }
}

