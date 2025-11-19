-- ==========================================================
-- STORED PROCEDURE: sp_Cita_Actualizar
-- ==========================================================
-- Este stored procedure actualiza una cita existente,
-- incluyendo el estado (Programada, Completada, Cancelada)
-- ==========================================================

USE VeterinariaGenesisDB;
GO

-- Eliminar el stored procedure si ya existe
IF OBJECT_ID('sp_Cita_Actualizar', 'P') IS NOT NULL 
    DROP PROCEDURE sp_Cita_Actualizar;
GO

-- Crear el stored procedure
CREATE PROCEDURE sp_Cita_Actualizar
    @ID_Cita INT,
    @Fecha DATE,
    @Hora TIME,
    @ID_Mascota INT,
    @ID_Veterinario INT,
    @ID_Servicio INT,
    @Estado VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Validar que la cita existe
    IF NOT EXISTS (SELECT 1 FROM Cita WHERE ID_Cita = @ID_Cita)
    BEGIN
        RAISERROR('La cita especificada no existe.', 16, 1);
        RETURN;
    END
    
    -- Validar que el estado sea válido
    IF @Estado NOT IN ('Programada', 'Completada', 'Cancelada')
    BEGIN
        RAISERROR('El estado debe ser: Programada, Completada o Cancelada.', 16, 1);
        RETURN;
    END
    
    -- Validar que no haya conflicto de horario con otra cita del mismo veterinario
    -- (solo si el estado es Programada y la fecha/hora cambian)
    IF @Estado = 'Programada'
    BEGIN
        IF EXISTS (SELECT 1 FROM Cita 
                   WHERE ID_Veterinario = @ID_Veterinario 
                   AND Fecha = @Fecha 
                   AND Hora = @Hora
                   AND Estado = 'Programada'
                   AND ID_Cita <> @ID_Cita)
        BEGIN
            RAISERROR('El veterinario ya tiene una cita programada a esa hora.', 16, 1);
            RETURN;
        END
    END
    
    -- Actualizar la cita
    UPDATE Cita
    SET Fecha = @Fecha,
        Hora = @Hora,
        ID_Mascota = @ID_Mascota,
        ID_Veterinario = @ID_Veterinario,
        ID_Servicio = @ID_Servicio,
        Estado = @Estado
    WHERE ID_Cita = @ID_Cita;
    
    -- Verificar que se actualizó correctamente
    IF @@ROWCOUNT = 0
    BEGIN
        RAISERROR('No se pudo actualizar la cita.', 16, 1);
        RETURN;
    END
END;
GO

-- Otorgar permisos al rol de la API
GRANT EXECUTE ON sp_Cita_Actualizar TO rol_api_ejecutor;
GO

PRINT 'Stored procedure [sp_Cita_Actualizar] creado exitosamente.';
PRINT 'Permisos otorgados a rol_api_ejecutor.';
GO


