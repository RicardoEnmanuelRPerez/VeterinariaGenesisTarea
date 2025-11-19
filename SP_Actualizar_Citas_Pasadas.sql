-- ==========================================================
-- SCRIPT PARA ACTUALIZAR CITAS PASADAS A "Completada"
-- ==========================================================
-- Este script actualiza todas las citas que están "Programada"
-- pero tienen fecha anterior a la fecha actual, cambiándolas
-- automáticamente a "Completada"
-- ==========================================================

USE VeterinariaGenesisDB;
GO

PRINT '=== ACTUALIZANDO CITAS PASADAS A "Completada" ===';
PRINT '';

-- Mostrar cuántas citas se van a actualizar
DECLARE @CitasAActualizar INT;
SELECT @CitasAActualizar = COUNT(*)
FROM Cita
WHERE Estado = 'Programada'
  AND Fecha < CAST(GETDATE() AS DATE);

PRINT 'Citas que se actualizarán: ' + CAST(@CitasAActualizar AS VARCHAR(10));
PRINT '';

-- Mostrar las citas que se van a actualizar
IF @CitasAActualizar > 0
BEGIN
    PRINT 'Citas que serán actualizadas:';
    SELECT 
        ID_Cita,
        Fecha,
        Hora,
        Estado AS Estado_Actual,
        'Completada' AS Estado_Nuevo
    FROM Cita
    WHERE Estado = 'Programada'
      AND Fecha < CAST(GETDATE() AS DATE)
    ORDER BY Fecha DESC, Hora DESC;
    PRINT '';
END
ELSE
BEGIN
    PRINT 'No hay citas programadas con fechas pasadas.';
    PRINT '';
END

-- Actualizar las citas
UPDATE Cita
SET Estado = 'Completada'
WHERE Estado = 'Programada'
  AND Fecha < CAST(GETDATE() AS DATE);

DECLARE @CitasActualizadas INT = @@ROWCOUNT;

PRINT '=== RESULTADO ===';
PRINT 'Citas actualizadas: ' + CAST(@CitasActualizadas AS VARCHAR(10));
PRINT '';

-- Mostrar resumen de estados después de la actualización
PRINT '=== RESUMEN DE ESTADOS DESPUÉS DE LA ACTUALIZACIÓN ===';
SELECT 
    Estado,
    COUNT(*) AS Cantidad
FROM Cita
GROUP BY Estado
ORDER BY Cantidad DESC;
GO

PRINT '';
PRINT '=== FIN DEL SCRIPT ===';
GO

