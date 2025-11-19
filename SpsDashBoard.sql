/*
==================================================================================
SCRIPT 07: STORED PROCEDURES DE DASHBOARD - VeterinariaGenesisDB
==================================================================================
EJECUTAR DESPUÉS DE 06_StoredProcedures_Historial.sql
==================================================================================
*/

USE VeterinariaGenesisDB;
GO

PRINT '--- Creando Stored Procedures de Dashboard ---';
GO

-- ====================================================
-- SP: Cirugías por Veterinario
-- ====================================================
IF OBJECT_ID('sp_Dashboard_CirugiasPorVeterinario', 'P') IS NOT NULL 
    DROP PROCEDURE sp_Dashboard_CirugiasPorVeterinario;
GO

CREATE PROCEDURE sp_Dashboard_CirugiasPorVeterinario
    @fechaInicio DATE = NULL,
    @fechaFin DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        V.ID_Veterinario,
        V.Nombre AS NombreVeterinario,
        V.Especialidad,
        COUNT(CIR.ID_Cirugia) AS CantidadCirugias,
        CAST(COUNT(CIR.ID_Cirugia) * 100.0 / NULLIF(
            (SELECT COUNT(*) FROM Cirugia CIR2 
             WHERE (@fechaInicio IS NULL OR CIR2.Fecha >= @fechaInicio)
                AND (@fechaFin IS NULL OR CIR2.Fecha <= @fechaFin)), 0) 
        AS DECIMAL(5,2)) AS PorcentajeTotal
    FROM Veterinario V
    LEFT JOIN Cirugia CIR ON V.ID_Veterinario = CIR.ID_Veterinario
        AND (@fechaInicio IS NULL OR CIR.Fecha >= @fechaInicio)
        AND (@fechaFin IS NULL OR CIR.Fecha <= @fechaFin)
    WHERE V.Activo = 1
    GROUP BY V.ID_Veterinario, V.Nombre, V.Especialidad
    HAVING COUNT(CIR.ID_Cirugia) > 0
    ORDER BY CantidadCirugias DESC;
END
GO

-- ====================================================
-- SP: Citas por Día de la Semana
-- ====================================================
IF OBJECT_ID('sp_Dashboard_CitasPorDiaSemana', 'P') IS NOT NULL 
    DROP PROCEDURE sp_Dashboard_CitasPorDiaSemana;
GO

CREATE PROCEDURE sp_Dashboard_CitasPorDiaSemana
    @fechaInicio DATE = NULL,
    @fechaFin DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        CASE DATEPART(WEEKDAY, C.Fecha)
            WHEN 1 THEN 'Domingo'
            WHEN 2 THEN 'Lunes'
            WHEN 3 THEN 'Martes'
            WHEN 4 THEN 'Miércoles'
            WHEN 5 THEN 'Jueves'
            WHEN 6 THEN 'Viernes'
            WHEN 7 THEN 'Sábado'
        END AS DiaSemana,
        COUNT(C.ID_Cita) AS CantidadCitas,
        COUNT(CASE WHEN C.Estado = 'Completada' THEN 1 END) AS CitasCompletadas,
        COUNT(CASE WHEN C.Estado = 'Cancelada' THEN 1 END) AS CitasCanceladas
    FROM Cita C
    WHERE (@fechaInicio IS NULL OR C.Fecha >= @fechaInicio)
        AND (@fechaFin IS NULL OR C.Fecha <= @fechaFin)
    GROUP BY DATEPART(WEEKDAY, C.Fecha)
    ORDER BY DATEPART(WEEKDAY, C.Fecha);
END
GO

-- ====================================================
-- SP: Productividad por Veterinario
-- ====================================================
IF OBJECT_ID('sp_Dashboard_ProductividadVeterinario', 'P') IS NOT NULL 
    DROP PROCEDURE sp_Dashboard_ProductividadVeterinario;
GO

CREATE PROCEDURE sp_Dashboard_ProductividadVeterinario
    @fechaInicio DATE = NULL,
    @fechaFin DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        V.ID_Veterinario,
        V.Nombre AS NombreVeterinario,
        V.Especialidad,
        COUNT(DISTINCT C.ID_Cita) AS TotalCitas,
        COUNT(DISTINCT CIR.ID_Cirugia) AS TotalCirugias,
        COUNT(DISTINCT T.ID_Tratamiento) AS TotalTratamientos,
        ISNULL(SUM(CASE WHEN F.EstadoPago = 'Pagada' THEN F.Total ELSE 0 END), 0) AS IngresosGenerados
    FROM Veterinario V
    LEFT JOIN Cita C ON V.ID_Veterinario = C.ID_Veterinario
        AND (@fechaInicio IS NULL OR C.Fecha >= @fechaInicio)
        AND (@fechaFin IS NULL OR C.Fecha <= @fechaFin)
    LEFT JOIN Cirugia CIR ON V.ID_Veterinario = CIR.ID_Veterinario
        AND (@fechaInicio IS NULL OR CIR.Fecha >= @fechaInicio)
        AND (@fechaFin IS NULL OR CIR.Fecha <= @fechaFin)
    LEFT JOIN Tratamiento T ON EXISTS (
        SELECT 1 FROM Cita C2 
        WHERE C2.ID_Veterinario = V.ID_Veterinario 
        AND C2.ID_Mascota = T.ID_Mascota
        AND (@fechaInicio IS NULL OR T.Fecha >= @fechaInicio)
        AND (@fechaFin IS NULL OR T.Fecha <= @fechaFin)
    )
    LEFT JOIN Factura F ON F.ID_Cita = C.ID_Cita
        AND (@fechaInicio IS NULL OR F.Fecha >= @fechaInicio)
        AND (@fechaFin IS NULL OR F.Fecha <= @fechaFin)
    WHERE V.Activo = 1
    GROUP BY V.ID_Veterinario, V.Nombre, V.Especialidad
    HAVING COUNT(DISTINCT C.ID_Cita) > 0 
        OR COUNT(DISTINCT CIR.ID_Cirugia) > 0
    ORDER BY TotalCitas DESC, IngresosGenerados DESC;
END
GO

PRINT '*** STORED PROCEDURES DE DASHBOARD CREADOS ***';
GO

