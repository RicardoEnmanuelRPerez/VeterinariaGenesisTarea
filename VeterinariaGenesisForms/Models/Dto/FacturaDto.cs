namespace VeterinariaGenesisForms.Models.Dto;

public class FacturaDto
{
    public int ID_Factura { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Total { get; set; }
    public int ID_Propietario { get; set; }
    public int? ID_Cita { get; set; }
    public string EstadoPago { get; set; } = string.Empty;
    public List<FacturaDetalleDto> Detalles { get; set; } = new();
}

public class FacturaDetalleDto
{
    public int ID_FacturaDetalle { get; set; }
    public int ID_Factura { get; set; }
    public int ID_Servicio { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal Subtotal { get; set; }
}

public class FacturaCreateDto
{
    public int ID_Cita { get; set; }
}

public class FacturaItemDto
{
    public int ID_Factura { get; set; }
    public int ID_Servicio { get; set; }
    public int Cantidad { get; set; }
}

public class FacturaPagoDto
{
    public int ID_Factura { get; set; }
    public decimal MontoPagado { get; set; }
    public string MetodoPago { get; set; } = string.Empty;
}

