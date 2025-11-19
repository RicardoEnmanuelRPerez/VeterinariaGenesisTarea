-- ==========================================================
-- SCRIPT COMPLETO: ACTUALIZAR CITAS PASADAS Y VALIDACIONES
-- ==========================================================
-- Este script:
-- 1. Actualiza las citas pasadas a "Completada"
-- 2. Actualiza el stored procedure sp_Cita_Agendar para validar fechas pasadas
-- 3. Crea un trigger para actualizar automáticamente las citas pasadas
-- ==========================================================

USE VeterinariaGenesisDB;
GO

PRINT '=== PASO 1: ACTUALIZAR CITAS PASADAS A "Completada" ===';
GO

-- Mostrar cuántas citas se van a actualizar
DECLARE @CitasAActualizar INT;
SELECT @CitasAActualizar = COUNT(*)
FROM Cita
WHERE Estado = 'Programada'
  AND Fecha < CAST(GETDATE() AS DATE);

PRINT 'Citas que se actualizarán: ' + CAST(@CitasAActualizar AS VARCHAR(10));
GO

-- Actualizar las citas
UPDATE Cita
SET Estado = 'Completada'
WHERE Estado = 'Programada'
  AND Fecha < CAST(GETDATE() AS DATE);

DECLARE @CitasActualizadas INT = @@ROWCOUNT;
PRINT 'Citas actualizadas: ' + CAST(@CitasActualizadas AS VARCHAR(10));
GO

PRINT '';
PRINT '=== PASO 2: ACTUALIZAR sp_Cita_Agendar CON VALIDACIÓN DE FECHAS ===';
GO

-- Actualizar el stored procedure para validar fechas pasadas
IF OBJECT_ID('sp_Cita_Agendar', 'P') IS NOT NULL DROP PROCEDURE sp_Cita_Agendar;
GO

CREATE PROCEDURE sp_Cita_Agendar
    @Fecha DATE,
    @Hora TIME,
    @ID_Mascota INT,
    @ID_Veterinario INT,
    @ID_Servicio INT
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Validación: No permitir fechas pasadas
    IF @Fecha < CAST(GETDATE() AS DATE)
    BEGIN
        RAISERROR('No se pueden agendar citas para fechas pasadas.', 16, 1);
        RETURN;
    END
    
    -- Validación: Si la fecha es hoy, no permitir horas pasadas
    IF @Fecha = CAST(GETDATE() AS DATE)
    BEGIN
        DECLARE @HoraActual TIME = CAST(GETDATE() AS TIME);
        IF @Hora < @HoraActual
        BEGIN
            RAISERROR('No se pueden agendar citas para horas pasadas en el día de hoy.', 16, 1);
            RETURN;
        END
    END
    
    -- Validación para evitar doble reserva (Lógica de negocio clave)
    IF EXISTS (SELECT 1 FROM Cita 
               WHERE ID_Veterinario = @ID_Veterinario 
               AND Fecha = @Fecha 
               AND Hora = @Hora
               AND Estado = 'Programada')
    BEGIN
        RAISERROR('El veterinario ya tiene una cita programada a esa hora.', 16, 1);
        RETURN;
    END

    INSERT INTO Cita (Fecha, Hora, ID_Mascota, ID_Veterinario, ID_Servicio, Estado)
    VALUES (@Fecha, @Hora, @ID_Mascota, @ID_Veterinario, @ID_Servicio, 'Programada');
    SELECT SCOPE_IDENTITY() AS NuevoID;
END
GO

PRINT 'Stored procedure [sp_Cita_Agendar] actualizado con validaciones de fecha.';
GO

PRINT '';
PRINT '=== PASO 3: CREAR TRIGGER PARA ACTUALIZAR CITAS PASADAS AUTOMÁTICAMENTE ===';
GO

-- Eliminar el trigger si ya existe
IF OBJECT_ID('trg_ActualizarCitasPasadas', 'TR') IS NOT NULL
    DROP TRIGGER trg_ActualizarCitasPasadas;
GO

-- Crear el trigger
CREATE TRIGGER trg_ActualizarCitasPasadas
ON Cita
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Actualizar citas que están "Programada" pero tienen fecha pasada
    UPDATE Cita
    SET Estado = 'Completada'
    WHERE Estado = 'Programada'
      AND Fecha < CAST(GETDATE() AS DATE);
END;
GO

PRINT 'Trigger [trg_ActualizarCitasPasadas] creado exitosamente.';
PRINT 'Este trigger actualizará automáticamente las citas pasadas a "Completada".';
GO

PRINT '';
PRINT '=== PASO 4: RESUMEN FINAL ===';
GO

-- Mostrar resumen de estados después de la actualización
SELECT 
    Estado,
    COUNT(*) AS Cantidad
FROM Cita
GROUP BY Estado
ORDER BY Cantidad DESC;
GO

PRINT '';
PRINT '=== SCRIPT COMPLETADO ===';
PRINT 'Las citas pasadas han sido actualizadas a "Completada".';
PRINT 'El stored procedure ahora valida que no se puedan agendar citas en fechas pasadas.';
PRINT 'El trigger actualizará automáticamente las citas pasadas en el futuro.';
GO

