namespace VeterinariaGenesisAPI.Models.DTOs;

public class MascotaDto
{
    public int ID_Mascota { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Especie { get; set; } = string.Empty;
    public string? Raza { get; set; }
    public int? Edad { get; set; }
    public string Sexo { get; set; } = string.Empty;
    public int ID_Propietario { get; set; }
    public string? NombrePropietario { get; set; }
}

public class MascotaCreateDto
{
    public string Nombre { get; set; } = string.Empty;
    public string Especie { get; set; } = string.Empty;
    public string? Raza { get; set; }
    public int? Edad { get; set; }
    public string Sexo { get; set; } = string.Empty;
    public int ID_Propietario { get; set; }
}

public class MascotaUpdateDto
{
    public int ID_Mascota { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Especie { get; set; } = string.Empty;
    public string? Raza { get; set; }
    public int? Edad { get; set; }
    public string Sexo { get; set; } = string.Empty;
    public int ID_Propietario { get; set; }
}


