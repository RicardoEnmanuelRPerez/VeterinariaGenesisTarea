/*
==================================================================================
SCRIPT PARA CREAR sp_Factura_Pagar - VeterinariaGenesisDB
==================================================================================
Este script crea el stored procedure sp_Factura_Pagar que estaba faltando.
Ejecuta este script con permisos de administrador.
==================================================================================
*/

USE VeterinariaGenesisDB;
GO

PRINT '--- Creando stored procedure sp_Factura_Pagar ---';
GO

-- Eliminar si existe
IF OBJECT_ID('sp_Factura_Pagar', 'P') IS NOT NULL 
BEGIN
    DROP PROCEDURE sp_Factura_Pagar;
    PRINT 'Stored procedure sp_Factura_Pagar eliminado (si existía).';
END
GO

-- Crear el stored procedure
CREATE PROCEDURE sp_Factura_Pagar
    @ID_Factura INT,
    @MontoPagado DECIMAL(10,2),
    @MetodoPago VARCHAR(50)
WITH EXECUTE AS OWNER
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @TotalFactura DECIMAL(10,2), @ID_Cita INT;
    DECLARE @EstadoActual VARCHAR(20);
    DECLARE @PagosExistentes INT;

    DECLARE @MensajeEstado NVARCHAR(4000);
    DECLARE @MensajeMonto NVARCHAR(4000);

    BEGIN TRANSACTION;
    BEGIN TRY
        -- Bloquear la factura con UPDLOCK y HOLDLOCK para evitar condiciones de carrera
        -- Esto asegura que solo un proceso pueda procesar el pago a la vez
        SELECT @TotalFactura = Total, @ID_Cita = ID_Cita, @EstadoActual = EstadoPago
        FROM Factura WITH (UPDLOCK, HOLDLOCK, ROWLOCK)
        WHERE ID_Factura = @ID_Factura;

        -- Validar que la factura existe
        IF @TotalFactura IS NULL
        BEGIN
            ROLLBACK TRANSACTION;
            RAISERROR('Factura no encontrada.', 16, 1);
            RETURN;
        END

        -- Validar que la factura está pendiente
        IF @EstadoActual != 'Pendiente'
        BEGIN
            ROLLBACK TRANSACTION;
            SET @MensajeEstado = 'La factura ya fue pagada o está en otro estado. Estado actual: ' + @EstadoActual;
            RAISERROR(@MensajeEstado, 16, 1);
            RETURN;
        END

        -- Verificar si ya existe un pago para esta factura (doble validación)
        SELECT @PagosExistentes = COUNT(*)
        FROM Pago
        WHERE ID_Factura = @ID_Factura;

        IF @PagosExistentes > 0
        BEGIN
            ROLLBACK TRANSACTION;
            RAISERROR('Esta factura ya tiene un pago registrado. No se pueden procesar pagos duplicados.', 16, 1);
            RETURN;
        END

        -- Validar que el monto es suficiente
        IF @MontoPagado < @TotalFactura
        BEGIN
            ROLLBACK TRANSACTION;
            SET @MensajeMonto = 'El monto es insuficiente. El total de la factura es $' + CAST(@TotalFactura AS VARCHAR(20));
            RAISERROR(@MensajeMonto, 16, 1);
            RETURN;
        END

        -- 1. Insertar el Pago
        INSERT INTO Pago (ID_Factura, MetodoPago, Monto, FechaPago)
        VALUES (@ID_Factura, @MetodoPago, @MontoPagado, GETDATE());

        -- 2. Actualizar la Factura a 'Pagada' (con la misma condición de estado para seguridad)
        UPDATE Factura 
        SET EstadoPago = 'Pagada' 
        WHERE ID_Factura = @ID_Factura 
          AND EstadoPago = 'Pendiente';  -- Doble verificación para evitar condiciones de carrera

        -- Verificar que se actualizó correctamente
        IF @@ROWCOUNT = 0
        BEGIN
            ROLLBACK TRANSACTION;
            RAISERROR('Error al actualizar el estado de la factura. La factura puede haber sido pagada por otro proceso.', 16, 1);
            RETURN;
        END

        -- 3. Actualizar la Cita a 'Completada' (si tiene cita asociada)
        IF @ID_Cita IS NOT NULL
        BEGIN
            UPDATE Cita 
            SET Estado = 'Completada' 
            WHERE ID_Cita = @ID_Cita AND Estado != 'Completada';
        END

        COMMIT TRANSACTION;
        SELECT 1 AS Exito;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();
        
        RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END
GO

PRINT 'Stored procedure sp_Factura_Pagar creado exitosamente.';
GO

-- Otorgar permisos al rol de la API
IF EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'rol_api_ejecutor')
BEGIN
    GRANT EXECUTE ON sp_Factura_Pagar TO rol_api_ejecutor;
    PRINT 'Permisos otorgados a rol_api_ejecutor.';
END
ELSE
BEGIN
    PRINT 'ADVERTENCIA: El rol rol_api_ejecutor no existe.';
END
GO

-- Verificar que se creó correctamente
IF OBJECT_ID('sp_Factura_Pagar', 'P') IS NOT NULL
BEGIN
    PRINT '';
    PRINT '=== VERIFICACIÓN EXITOSA ===';
    PRINT 'El stored procedure sp_Factura_Pagar ha sido creado correctamente.';
    SELECT 
        name,
        create_date,
        modify_date
    FROM sys.procedures 
    WHERE name = 'sp_Factura_Pagar';
END
ELSE
BEGIN
    PRINT '';
    PRINT '=== ERROR ===';
    PRINT 'El stored procedure sp_Factura_Pagar NO se pudo crear.';
    PRINT 'Revisa los mensajes de error anteriores.';
END
GO

