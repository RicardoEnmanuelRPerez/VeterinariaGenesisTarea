namespace VeterinariaGenesisAPI.Data;

public static class Procedimientos
{
    // Stored Procedures de Usuario/Auth
    public const string Usuario_Login = "sp_Usuario_Login";

    // Stored Procedures de Propietario
    public const string Propietario_Crear = "sp_Propietario_Crear";
    public const string Propietario_Actualizar = "sp_Propietario_Actualizar";
    public const string Propietario_Desactivar = "sp_Propietario_Desactivar";
    public const string Propietario_ListarActivos = "sp_Propietario_ListarActivos";
    public const string Propietario_BuscarPorID = "sp_Propietario_BuscarPorID";

    // Stored Procedures de Mascota
    public const string Mascota_Crear = "sp_Mascota_Crear";
    public const string Mascota_Actualizar = "sp_Mascota_Actualizar";
    public const string Mascota_ListarPorPropietario = "sp_Mascota_ListarPorPropietario";
    public const string Mascota_BuscarPorID = "sp_Mascota_BuscarPorID";

    // Stored Procedures de Cita
    public const string Cita_Agendar = "sp_Cita_Agendar";
    public const string Cita_Actualizar = "sp_Cita_Actualizar";
    public const string Cita_Cancelar = "sp_Cita_Cancelar";
    public const string Cita_ListarPorFecha = "sp_Cita_ListarPorFecha";
    public const string Cita_ListarPorVeterinario = "sp_Cita_ListarPorVeterinario";
    public const string Cita_ListarCompletadasSinFactura = "sp_Cita_ListarCompletadasSinFactura";

    // Stored Procedures de Factura
    public const string Factura_CrearDesdeCita = "sp_Factura_CrearDesdeCita";
    public const string Factura_AgregarItem = "sp_Factura_AgregarItem";
    public const string Factura_Pagar = "sp_Factura_Pagar";
    public const string Factura_BuscarPorID = "sp_Factura_BuscarPorID";
    public const string Factura_Listar = "sp_Factura_Listar";
    public const string Factura_DetallesPorID = "sp_Factura_DetallesPorID";

    // Stored Procedures de Veterinario
    public const string Veterinario_ListarActivos = "sp_Veterinario_ListarActivos";
    public const string Veterinario_BuscarPorID = "sp_Veterinario_BuscarPorID";

    // Stored Procedures de Servicio
    public const string Servicio_Listar = "sp_Servicio_Listar";
    public const string Servicio_BuscarPorID = "sp_Servicio_BuscarPorID";
    public const string Servicio_Crear = "sp_Servicio_Crear";
    public const string Servicio_Actualizar = "sp_Servicio_Actualizar";
    public const string Servicio_Eliminar = "sp_Servicio_Eliminar";

    // Stored Procedures de Reportes
    public const string Reporte_Propietarios = "sp_Reporte_Propietarios";
    public const string Reporte_ServiciosVendidos = "sp_Reporte_ServiciosVendidos";
    public const string Reporte_CitasPorVeterinario = "sp_Reporte_CitasPorVeterinario";
    public const string Reporte_IngresosPorPeriodo = "sp_Reporte_IngresosPorPeriodo";
    public const string Reporte_MascotasPorEspecie = "sp_Reporte_MascotasPorEspecie";
    public const string Reporte_TratamientosComunes = "sp_Reporte_TratamientosComunes";
    public const string Reporte_MetodosPago = "sp_Reporte_MetodosPago";
    public const string Reporte_ResumenGeneral = "sp_Reporte_ResumenGeneral";

    // Stored Procedures de Historial Clínico
    public const string Historial_ObtenerPorMascota = "sp_Historial_ObtenerPorMascota";
    public const string Mascota_BuscarParaHistorial = "sp_Mascota_BuscarParaHistorial";

    // Stored Procedures de Dashboard
    public const string Dashboard_CirugiasPorVeterinario = "sp_Dashboard_CirugiasPorVeterinario";
    public const string Dashboard_CitasPorDiaSemana = "sp_Dashboard_CitasPorDiaSemana";
    public const string Dashboard_ProductividadVeterinario = "sp_Dashboard_ProductividadVeterinario";

    // Stored Procedures de Vacunación
    public const string Vacuna_Recordatorios = "sp_Vacuna_Recordatorios";
}

