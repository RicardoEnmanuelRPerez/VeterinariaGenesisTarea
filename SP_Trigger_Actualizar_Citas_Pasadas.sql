-- ==========================================================
-- TRIGGER PARA ACTUALIZAR AUTOMÁTICAMENTE CITAS PASADAS
-- ==========================================================
-- Este trigger se ejecuta automáticamente cuando se inserta
-- o actualiza una cita, y actualiza las citas pasadas a "Completada"
-- ==========================================================

USE VeterinariaGenesisDB;
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

