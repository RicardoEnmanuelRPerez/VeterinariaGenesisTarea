-- ==========================================================
-- SCRIPT PARA VERIFICAR CITAS COMPLETADAS
-- ==========================================================
-- Este script te ayudará a diagnosticar por qué no aparecen
-- las citas completadas en el formulario de facturas.
-- ==========================================================

USE VeterinariaGenesisDB;
GO

-- 1. VER TODAS LAS CITAS Y SUS ESTADOS
PRINT '=== 1. TODAS LAS CITAS CON SUS ESTADOS ===';
SELECT 
    ID_Cita,
    Fecha,
    Hora,
    Estado,
    M.Nombre AS Mascota,
    P.Nombre + ' ' + P.Apellidos AS Propietario,
    V.Nombre AS Veterinario,
    S.Nombre AS Servicio
FROM Cita C
JOIN Mascota M ON C.ID_Mascota = M.ID_Mascota
JOIN Propietario P ON M.ID_Propietario = P.ID_Propietario
JOIN Veterinario V ON C.ID_Veterinario = V.ID_Veterinario
JOIN Servicio S ON C.ID_Servicio = S.ID_Servicio
ORDER BY Fecha DESC, Hora DESC;
GO

-- 2. CONTAR CITAS POR ESTADO
PRINT '=== 2. CONTEO DE CITAS POR ESTADO ===';
SELECT 
    Estado,
    COUNT(*) AS Cantidad
FROM Cita
GROUP BY Estado
ORDER BY Cantidad DESC;
GO

-- 3. VER CITAS COMPLETADAS (con diferentes variaciones del texto)
PRINT '=== 3. CITAS COMPLETADAS (todas las variaciones) ===';
SELECT 
    ID_Cita,
    Fecha,
    Hora,
    Estado,
    M.Nombre AS Mascota,
    P.Nombre + ' ' + P.Apellidos AS Propietario
FROM Cita C
JOIN Mascota M ON C.ID_Mascota = M.ID_Mascota
JOIN Propietario P ON M.ID_Propietario = P.ID_Propietario
WHERE Estado LIKE '%Complet%'  -- Busca cualquier variación
ORDER BY Fecha DESC, Hora DESC;
GO

-- 4. PROBAR EL STORED PROCEDURE QUE USA LA APLICACIÓN
PRINT '=== 4. PROBAR sp_Cita_ListarPorFecha (últimos 7 días) ===';
DECLARE @FechaActual DATE = CAST(GETDATE() AS DATE);
DECLARE @FechaInicio DATE = DATEADD(DAY, -7, @FechaActual);

DECLARE @Fecha DATE = @FechaInicio;
WHILE @Fecha <= @FechaActual
BEGIN
    PRINT '--- Fecha: ' + CAST(@Fecha AS VARCHAR(10)) + ' ---';
    EXEC sp_Cita_ListarPorFecha @Fecha = @Fecha;
    SET @Fecha = DATEADD(DAY, 1, @Fecha);
END;
GO

-- 5. VER LA VISTA QUE USA EL STORED PROCEDURE
PRINT '=== 5. CONTENIDO DE LA VISTA vw_AgendaCitas (últimas 20 citas) ===';
SELECT TOP 20
    ID_Cita,
    Fecha,
    Hora,
    Estado,
    Mascota,
    Propietario,
    Veterinario,
    Servicio
FROM vw_AgendaCitas
ORDER BY Fecha DESC, Hora DESC;
GO

-- 6. VERIFICAR SI HAY CITAS COMPLETADAS EN LA VISTA
PRINT '=== 6. CITAS COMPLETADAS EN LA VISTA (últimos 60 días) ===';
SELECT 
    ID_Cita,
    Fecha,
    Hora,
    Estado,
    Mascota,
    Propietario,
    Veterinario,
    Servicio
FROM vw_AgendaCitas
WHERE Estado = 'Completada'
  AND Fecha >= DATEADD(DAY, -60, CAST(GETDATE() AS DATE))
ORDER BY Fecha DESC, Hora DESC;
GO

-- 7. ACTUALIZAR CITAS A "Completada" (SOLO PARA PRUEBAS - COMENTA ESTO SI NO QUIERES MODIFICAR DATOS)
-- Descomenta las siguientes líneas si quieres marcar algunas citas como completadas para probar:
/*
PRINT '=== 7. ACTUALIZANDO ALGUNAS CITAS A "Completada" (SOLO PRUEBAS) ===';
-- Actualizar las últimas 5 citas programadas a "Completada"
UPDATE TOP (5) Cita
SET Estado = 'Completada'
WHERE Estado = 'Programada'
  AND Fecha < CAST(GETDATE() AS DATE);
GO

SELECT 'Citas actualizadas. Total de citas completadas: ' + CAST(COUNT(*) AS VARCHAR(10))
FROM Cita
WHERE Estado = 'Completada';
GO
*/

PRINT '=== FIN DEL DIAGNÓSTICO ===';
PRINT 'Revisa los resultados anteriores para identificar el problema.';
PRINT 'Si no hay citas con estado "Completada", puedes:';
PRINT '1. Actualizar manualmente algunas citas: UPDATE Cita SET Estado = ''Completada'' WHERE ID_Cita = X;';
PRINT '2. O usar el formulario de Citas para cambiar el estado de las citas.';
GO

