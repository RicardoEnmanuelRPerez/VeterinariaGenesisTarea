/*
==================================================================================
SCRIPT 09: STORED PROCEDURES DE REPORTES - VeterinariaGenesisDB
==================================================================================
EJECUTAR DESPUÉS DE 08_StoredProcedures_Vacunas.sql
==================================================================================
*/

USE VeterinariaGenesisDB;
GO

PRINT '--- Creando Stored Procedures de Reportes ---';
GO

-- ====================================================
-- SP: Reporte de Propietarios
-- ====================================================
CREATE OR ALTER PROCEDURE sp_Reporte_Propietarios
    @fechaInicio DATE = NULL,
    @fechaFin DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        P.ID_Propietario AS IdPropietario,
        P.Nombre + ' ' + P.Apellidos AS NombreCompleto,
        P.Telefono,
        P.Direccion,
        COUNT(DISTINCT F.ID_Factura) AS CantidadFacturas,
        ISNULL(SUM(CASE WHEN F.EstadoPago = 'Pagada' THEN F.Total ELSE 0 END), 0) AS TotalPagado,
        ISNULL(SUM(CASE WHEN F.EstadoPago = 'Pendiente' THEN F.Total ELSE 0 END), 0) AS TotalPendiente,
        COUNT(DISTINCT M.ID_Mascota) AS CantidadMascotas
    FROM Propietario P
    LEFT JOIN Factura F ON P.ID_Propietario = F.ID_Propietario
        AND (@fechaInicio IS NULL OR F.Fecha >= @fechaInicio)
        AND (@fechaFin IS NULL OR F.Fecha <= @fechaFin)
    LEFT JOIN Mascota M ON P.ID_Propietario = M.ID_Propietario
    WHERE P.Activo = 1
    GROUP BY P.ID_Propietario, P.Nombre, P.Apellidos, P.Telefono, P.Direccion
    ORDER BY TotalPagado DESC;
END
GO

-- ====================================================
-- SP: Reporte de Servicios Vendidos
-- ====================================================
CREATE OR ALTER PROCEDURE sp_Reporte_ServiciosVendidos
    @fechaInicio DATE = NULL,
    @fechaFin DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        S.ID_Servicio AS IdServicio,
        S.Nombre AS NombreServicio,
        S.Descripcion,
        S.Costo AS PrecioUnitario,
        SUM(FD.Cantidad) AS CantidadVendida,
        SUM(FD.Subtotal) AS TotalIngresos,
        COUNT(DISTINCT FD.ID_Factura) AS CantidadFacturas
    FROM Servicio S
    INNER JOIN FacturaDetalle FD ON S.ID_Servicio = FD.ID_Servicio
    INNER JOIN Factura F ON FD.ID_Factura = F.ID_Factura
    WHERE F.EstadoPago = 'Pagada'
        AND (@fechaInicio IS NULL OR F.Fecha >= @fechaInicio)
        AND (@fechaFin IS NULL OR F.Fecha <= @fechaFin)
    GROUP BY S.ID_Servicio, S.Nombre, S.Descripcion, S.Costo
    ORDER BY CantidadVendida DESC, TotalIngresos DESC;
END
GO

-- ====================================================
-- SP: Reporte de Citas por Veterinario
-- ====================================================
CREATE OR ALTER PROCEDURE sp_Reporte_CitasPorVeterinario
    @fechaInicio DATE = NULL,
    @fechaFin DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        V.ID_Veterinario AS IdVeterinario,
        V.Nombre AS NombreVeterinario,
        V.Especialidad,
        COUNT(C.ID_Cita) AS CantidadCitas,
        COUNT(CASE WHEN C.Estado = 'Completada' THEN 1 END) AS CitasCompletadas,
        COUNT(CASE WHEN C.Estado = 'Cancelada' THEN 1 END) AS CitasCanceladas,
        COUNT(CASE WHEN C.Estado = 'Programada' THEN 1 END) AS CitasProgramadas,
        ISNULL(SUM(CASE WHEN C.Estado = 'Completada' THEN S.Costo ELSE 0 END), 0) AS TotalIngresos
    FROM Veterinario V
    LEFT JOIN Cita C ON V.ID_Veterinario = C.ID_Veterinario
        AND (@fechaInicio IS NULL OR C.Fecha >= @fechaInicio)
        AND (@fechaFin IS NULL OR C.Fecha <= @fechaFin)
    LEFT JOIN Servicio S ON C.ID_Servicio = S.ID_Servicio
    WHERE V.Activo = 1
    GROUP BY V.ID_Veterinario, V.Nombre, V.Especialidad
    HAVING COUNT(C.ID_Cita) > 0
    ORDER BY CantidadCitas DESC, TotalIngresos DESC;
END
GO

-- ====================================================
-- SP: Reporte de Ingresos por Período
-- ====================================================
CREATE OR ALTER PROCEDURE sp_Reporte_IngresosPorPeriodo
    @fechaInicio DATE = NULL,
    @fechaFin DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;
    IF @fechaInicio IS NULL
        SET @fechaInicio = DATEADD(MONTH, -1, GETDATE());
    IF @fechaFin IS NULL
        SET @fechaFin = GETDATE();
    
    SELECT 
        CAST(F.Fecha AS DATE) AS Fecha,
        COUNT(DISTINCT F.ID_Factura) AS CantidadFacturas,
        COUNT(DISTINCT F.ID_Propietario) AS CantidadClientes,
        SUM(CASE WHEN F.EstadoPago = 'Pagada' THEN F.Total ELSE 0 END) AS IngresosPagados,
        SUM(CASE WHEN F.EstadoPago = 'Pendiente' THEN F.Total ELSE 0 END) AS IngresosPendientes,
        SUM(F.Total) AS TotalFacturado,
        SUM(CASE WHEN F.EstadoPago = 'Pagada' THEN 1 ELSE 0 END) AS FacturasPagadas,
        SUM(CASE WHEN F.EstadoPago = 'Pendiente' THEN 1 ELSE 0 END) AS FacturasPendientes
    FROM Factura F
    WHERE F.Fecha >= @fechaInicio
        AND F.Fecha <= @fechaFin
    GROUP BY CAST(F.Fecha AS DATE)
    ORDER BY Fecha DESC;
END
GO

PRINT '*** STORED PROCEDURES DE REPORTES CREADOS ***';
GO

