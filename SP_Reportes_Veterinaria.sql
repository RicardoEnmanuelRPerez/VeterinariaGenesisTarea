/*
==================================================================================
STORED PROCEDURES PARA REPORTES DINÁMICOS - VeterinariaGenesisDB
==================================================================================
Este script contiene los Stored Procedures optimizados para generar reportes
que serán consumidos por la API REST y luego por el cliente Windows Forms.

INSTRUCCIONES:
1. Ejecuta este script después de crear la base de datos y poblar los datos
2. Todos los SPs manejan parámetros opcionales de fecha (@fechaInicio, @fechaFin)
3. Los SPs devuelven datos ya procesados y listos para ser consumidos
==================================================================================
*/

USE VeterinariaGenesisDB;
GO

-- ====================================================
-- 1. SP: Reporte de Propietarios con Total de Facturas
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
END;
GO

-- ====================================================
-- 2. SP: Reporte de Servicios Más Vendidos
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
END;
GO

-- ====================================================
-- 3. SP: Reporte de Citas por Veterinario
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
END;
GO

-- ====================================================
-- 4. SP: Reporte de Ingresos por Período
-- ====================================================
CREATE OR ALTER PROCEDURE sp_Reporte_IngresosPorPeriodo
    @fechaInicio DATE = NULL,
    @fechaFin DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Si no se proporcionan fechas, usar el último mes
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
END;
GO

-- ====================================================
-- 5. SP: Reporte de Mascotas por Especie
-- ====================================================
CREATE OR ALTER PROCEDURE sp_Reporte_MascotasPorEspecie
    @fechaInicio DATE = NULL,
    @fechaFin DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        M.Especie,
        COUNT(DISTINCT M.ID_Mascota) AS CantidadMascotas,
        COUNT(DISTINCT M.ID_Propietario) AS CantidadPropietarios,
        COUNT(DISTINCT C.ID_Cita) AS CantidadCitas,
        COUNT(DISTINCT T.ID_Tratamiento) AS CantidadTratamientos,
        ISNULL(SUM(CASE WHEN F.EstadoPago = 'Pagada' THEN F.Total ELSE 0 END), 0) AS TotalIngresos
    FROM Mascota M
    LEFT JOIN Cita C ON M.ID_Mascota = C.ID_Mascota
        AND (@fechaInicio IS NULL OR C.Fecha >= @fechaInicio)
        AND (@fechaFin IS NULL OR C.Fecha <= @fechaFin)
    LEFT JOIN Tratamiento T ON M.ID_Mascota = T.ID_Mascota
        AND (@fechaInicio IS NULL OR T.Fecha >= @fechaInicio)
        AND (@fechaFin IS NULL OR T.Fecha <= @fechaFin)
    LEFT JOIN Factura F ON M.ID_Propietario = F.ID_Propietario
        AND (@fechaInicio IS NULL OR F.Fecha >= @fechaInicio)
        AND (@fechaFin IS NULL OR F.Fecha <= @fechaFin)
    GROUP BY M.Especie
    ORDER BY CantidadMascotas DESC;
END;
GO

-- ====================================================
-- 6. SP: Reporte de Tratamientos Más Comunes
-- ====================================================
CREATE OR ALTER PROCEDURE sp_Reporte_TratamientosComunes
    @fechaInicio DATE = NULL,
    @fechaFin DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        T.ID_Tratamiento AS IdTratamiento,
        T.Diagnostico,
        T.Fecha,
        M.Especie,
        M.Nombre AS NombreMascota,
        P.Nombre + ' ' + P.Apellidos AS NombrePropietario,
        COUNT(TM.ID_Medicamento) AS CantidadMedicamentos
    FROM Tratamiento T
    INNER JOIN Mascota M ON T.ID_Mascota = M.ID_Mascota
    INNER JOIN Propietario P ON M.ID_Propietario = P.ID_Propietario
    LEFT JOIN Tratamiento_Medicamento TM ON T.ID_Tratamiento = TM.ID_Tratamiento
    WHERE (@fechaInicio IS NULL OR T.Fecha >= @fechaInicio)
        AND (@fechaFin IS NULL OR T.Fecha <= @fechaFin)
    GROUP BY T.ID_Tratamiento, T.Diagnostico, T.Fecha, M.Especie, M.Nombre, P.Nombre, P.Apellidos
    ORDER BY T.Fecha DESC, CantidadMedicamentos DESC;
END;
GO

-- ====================================================
-- 7. SP: Reporte de Métodos de Pago
-- ====================================================
CREATE OR ALTER PROCEDURE sp_Reporte_MetodosPago
    @fechaInicio DATE = NULL,
    @fechaFin DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        P.MetodoPago,
        COUNT(P.ID_Pago) AS CantidadPagos,
        SUM(P.Monto) AS TotalRecaudado,
        AVG(P.Monto) AS PromedioPago,
        MIN(P.Monto) AS PagoMinimo,
        MAX(P.Monto) AS PagoMaximo,
        CAST(COUNT(P.ID_Pago) * 100.0 / NULLIF((SELECT COUNT(*) FROM Pago P2 
            WHERE (@fechaInicio IS NULL OR P2.FechaPago >= @fechaInicio)
                AND (@fechaFin IS NULL OR P2.FechaPago <= @fechaFin)), 0) AS DECIMAL(5,2)) AS PorcentajeUso
    FROM Pago P
    WHERE (@fechaInicio IS NULL OR P.FechaPago >= @fechaInicio)
        AND (@fechaFin IS NULL OR P.FechaPago <= @fechaFin)
    GROUP BY P.MetodoPago
    ORDER BY TotalRecaudado DESC;
END;
GO

-- ====================================================
-- 8. SP: Reporte Resumen General (Dashboard)
-- ====================================================
CREATE OR ALTER PROCEDURE sp_Reporte_ResumenGeneral
    @fechaInicio DATE = NULL,
    @fechaFin DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Si no se proporcionan fechas, usar el último mes
    IF @fechaInicio IS NULL
        SET @fechaInicio = DATEADD(MONTH, -1, GETDATE());
    IF @fechaFin IS NULL
        SET @fechaFin = GETDATE();
    
    SELECT 
        (SELECT COUNT(*) FROM Propietario WHERE Activo = 1) AS TotalPropietarios,
        (SELECT COUNT(*) FROM Mascota) AS TotalMascotas,
        (SELECT COUNT(*) FROM Cita 
         WHERE (@fechaInicio IS NULL OR Fecha >= @fechaInicio)
            AND (@fechaFin IS NULL OR Fecha <= @fechaFin)) AS TotalCitas,
        (SELECT COUNT(*) FROM Factura 
         WHERE EstadoPago = 'Pagada'
            AND (@fechaInicio IS NULL OR Fecha >= @fechaInicio)
            AND (@fechaFin IS NULL OR Fecha <= @fechaFin)) AS FacturasPagadas,
        (SELECT ISNULL(SUM(Total), 0) FROM Factura 
         WHERE EstadoPago = 'Pagada'
            AND (@fechaInicio IS NULL OR Fecha >= @fechaInicio)
            AND (@fechaFin IS NULL OR Fecha <= @fechaFin)) AS IngresosTotales,
        (SELECT COUNT(*) FROM Veterinario WHERE Activo = 1) AS TotalVeterinarios,
        (SELECT COUNT(*) FROM Tratamiento 
         WHERE (@fechaInicio IS NULL OR Fecha >= @fechaInicio)
            AND (@fechaFin IS NULL OR Fecha <= @fechaFin)) AS TotalTratamientos;
END;
GO

PRINT 'Stored Procedures de reportes creados exitosamente.';
GO

