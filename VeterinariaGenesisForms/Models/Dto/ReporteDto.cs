namespace VeterinariaGenesisForms.Models.Dto;

// DTO para Reporte de Propietarios
public class ReportePropietarioDto
{
    public int IdPropietario { get; set; }
    public string NombreCompleto { get; set; } = string.Empty;
    public string? Telefono { get; set; }
    public string? Direccion { get; set; }
    public int CantidadFacturas { get; set; }
    public decimal TotalPagado { get; set; }
    public decimal TotalPendiente { get; set; }
    public int CantidadMascotas { get; set; }
}

// DTO para Reporte de Servicios Vendidos
public class ReporteServicioVendidoDto
{
    public int IdServicio { get; set; }
    public string NombreServicio { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public decimal PrecioUnitario { get; set; }
    public int CantidadVendida { get; set; }
    public decimal TotalIngresos { get; set; }
    public int CantidadFacturas { get; set; }
}

// DTO para Reporte de Citas por Veterinario
public class ReporteCitaVeterinarioDto
{
    public int IdVeterinario { get; set; }
    public string NombreVeterinario { get; set; } = string.Empty;
    public string? Especialidad { get; set; }
    public int CantidadCitas { get; set; }
    public int CitasCompletadas { get; set; }
    public int CitasCanceladas { get; set; }
    public int CitasProgramadas { get; set; }
    public decimal TotalIngresos { get; set; }
}

// DTO para Reporte de Ingresos por Período
public class ReporteIngresoPeriodoDto
{
    public DateTime Fecha { get; set; }
    public int CantidadFacturas { get; set; }
    public int CantidadClientes { get; set; }
    public decimal IngresosPagados { get; set; }
    public decimal IngresosPendientes { get; set; }
    public decimal TotalFacturado { get; set; }
    public int FacturasPagadas { get; set; }
    public int FacturasPendientes { get; set; }
}

// DTO para Reporte de Mascotas por Especie
public class ReporteMascotaEspecieDto
{
    public string Especie { get; set; } = string.Empty;
    public int CantidadMascotas { get; set; }
    public int CantidadPropietarios { get; set; }
    public int CantidadCitas { get; set; }
    public int CantidadTratamientos { get; set; }
    public decimal TotalIngresos { get; set; }
}

// DTO para Reporte de Tratamientos Comunes
public class ReporteTratamientoDto
{
    public int IdTratamiento { get; set; }
    public string Diagnostico { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
    public string Especie { get; set; } = string.Empty;
    public string NombreMascota { get; set; } = string.Empty;
    public string NombrePropietario { get; set; } = string.Empty;
    public int CantidadMedicamentos { get; set; }
}

// DTO para Reporte de Métodos de Pago
public class ReporteMetodoPagoDto
{
    public string MetodoPago { get; set; } = string.Empty;
    public int CantidadPagos { get; set; }
    public decimal TotalRecaudado { get; set; }
    public decimal PromedioPago { get; set; }
    public decimal PagoMinimo { get; set; }
    public decimal PagoMaximo { get; set; }
    public decimal PorcentajeUso { get; set; }
}

// DTO para Reporte Resumen General (Dashboard)
public class ReporteResumenGeneralDto
{
    public int TotalPropietarios { get; set; }
    public int TotalMascotas { get; set; }
    public int TotalCitas { get; set; }
    public int FacturasPagadas { get; set; }
    public decimal IngresosTotales { get; set; }
    public int TotalVeterinarios { get; set; }
    public int TotalTratamientos { get; set; }
}

