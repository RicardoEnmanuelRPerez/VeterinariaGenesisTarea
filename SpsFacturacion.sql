/*
==================================================================================
SCRIPT 05: STORED PROCEDURES DE FACTURAS - VeterinariaGenesisDB
==================================================================================
EJECUTAR DESPUÉS DE 04_StoredProcedures_CRUD.sql
==================================================================================
*/

USE VeterinariaGenesisDB;
GO

PRINT '--- Creando Stored Procedures de Facturas ---';
GO

-- ====================================================
-- SP: Crear Factura desde Cita
-- ====================================================
IF OBJECT_ID('sp_Factura_CrearDesdeCita', 'P') IS NOT NULL DROP PROCEDURE sp_Factura_CrearDesdeCita;
GO
CREATE PROCEDURE sp_Factura_CrearDesdeCita
    @ID_Cita INT
WITH EXECUTE AS OWNER
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @ID_Propietario INT, @ID_Servicio INT, @CostoServicio DECIMAL(10,2);
    DECLARE @ID_NuevaFactura INT;

    IF EXISTS (SELECT 1 FROM Factura WHERE ID_Cita = @ID_Cita)
    BEGIN
        RAISERROR('La cita ya tiene una factura asociada.', 16, 1);
        RETURN;
    END

    SELECT 
        @ID_Propietario = M.ID_Propietario, 
        @ID_Servicio = C.ID_Servicio, 
        @CostoServicio = S.Costo
    FROM Cita C
    JOIN Mascota M ON C.ID_Mascota = M.ID_Mascota
    JOIN Servicio S ON C.ID_Servicio = S.ID_Servicio
    WHERE C.ID_Cita = @ID_Cita;

    IF @ID_Propietario IS NULL
    BEGIN
        RAISERROR('La cita no existe o no se pudo encontrar el servicio.', 16, 1);
        RETURN;
    END

    BEGIN TRANSACTION;
    BEGIN TRY
        INSERT INTO Factura (Fecha, Total, ID_Propietario, ID_Cita, EstadoPago)
        VALUES (GETDATE(), 0, @ID_Propietario, @ID_Cita, 'Pendiente');
        SET @ID_NuevaFactura = SCOPE_IDENTITY();

        INSERT INTO FacturaDetalle (ID_Factura, ID_Servicio, Cantidad, PrecioUnitario)
        VALUES (@ID_NuevaFactura, @ID_Servicio, 1, @CostoServicio);

        COMMIT TRANSACTION;
        SELECT @ID_NuevaFactura AS NuevaID_Factura;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- ====================================================
-- SP: Agregar Item a Factura
-- ====================================================
IF OBJECT_ID('sp_Factura_AgregarItem', 'P') IS NOT NULL DROP PROCEDURE sp_Factura_AgregarItem;
GO
CREATE PROCEDURE sp_Factura_AgregarItem
    @ID_Factura INT,
    @ID_Servicio INT,
    @Cantidad INT
AS
BEGIN
    DECLARE @CostoServicio DECIMAL(10,2) = (SELECT Costo FROM Servicio WHERE ID_Servicio = @ID_Servicio);
    INSERT INTO FacturaDetalle (ID_Factura, ID_Servicio, Cantidad, PrecioUnitario)
    VALUES (@ID_Factura, @ID_Servicio, @Cantidad, @CostoServicio);
END
GO

-- ====================================================
-- SP: Pagar Factura
-- ====================================================
IF OBJECT_ID('sp_Factura_Pagar', 'P') IS NOT NULL DROP PROCEDURE sp_Factura_Pagar;
GO
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
        SELECT @TotalFactura = Total, @ID_Cita = ID_Cita, @EstadoActual = EstadoPago
        FROM Factura WITH (UPDLOCK, HOLDLOCK, ROWLOCK)
        WHERE ID_Factura = @ID_Factura;

        IF @TotalFactura IS NULL
        BEGIN
            ROLLBACK TRANSACTION;
            RAISERROR('Factura no encontrada.', 16, 1);
            RETURN;
        END

        IF @EstadoActual != 'Pendiente'
        BEGIN
            ROLLBACK TRANSACTION;
            SET @MensajeEstado = 'La factura ya fue pagada o está en otro estado. Estado actual: ' + @EstadoActual;
            RAISERROR(@MensajeEstado, 16, 1);
            RETURN;
        END

        SELECT @PagosExistentes = COUNT(*)
        FROM Pago
        WHERE ID_Factura = @ID_Factura;

        IF @PagosExistentes > 0
        BEGIN
            ROLLBACK TRANSACTION;
            RAISERROR('Esta factura ya tiene un pago registrado. No se pueden procesar pagos duplicados.', 16, 1);
            RETURN;
        END

        IF @MontoPagado < @TotalFactura
        BEGIN
            ROLLBACK TRANSACTION;
            SET @MensajeMonto = 'El monto es insuficiente. El total de la factura es $' + CAST(@TotalFactura AS VARCHAR(20));
            RAISERROR(@MensajeMonto, 16, 1);
            RETURN;
        END

        INSERT INTO Pago (ID_Factura, MetodoPago, Monto, FechaPago)
        VALUES (@ID_Factura, @MetodoPago, @MontoPagado, GETDATE());

        UPDATE Factura 
        SET EstadoPago = 'Pagada' 
        WHERE ID_Factura = @ID_Factura 
          AND EstadoPago = 'Pendiente';

        IF @@ROWCOUNT = 0
        BEGIN
            ROLLBACK TRANSACTION;
            RAISERROR('Error al actualizar el estado de la factura. La factura puede haber sido pagada por otro proceso.', 16, 1);
            RETURN;
        END

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

-- ====================================================
-- SP: Buscar Factura por ID
-- ====================================================
IF OBJECT_ID('sp_Factura_BuscarPorID', 'P') IS NOT NULL DROP PROCEDURE sp_Factura_BuscarPorID;
GO
CREATE PROCEDURE sp_Factura_BuscarPorID
    @ID_Factura INT
AS
BEGIN
    SET NOCOUNT ON;
    
    IF NOT EXISTS (SELECT 1 FROM Factura WHERE ID_Factura = @ID_Factura)
    BEGIN
        RETURN;
    END
    
    SELECT 
        F.ID_Factura, F.Fecha, F.Total, F.ID_Propietario, F.ID_Cita, F.EstadoPago
    FROM Factura F
    WHERE F.ID_Factura = @ID_Factura;
    
    SELECT 
        FD.ID_FacturaDetalle, FD.ID_Factura, FD.ID_Servicio, FD.Cantidad, FD.PrecioUnitario, FD.Subtotal
    FROM FacturaDetalle FD
    WHERE FD.ID_Factura = @ID_Factura;
END
GO

-- ====================================================
-- SP: Listar Todas las Facturas
-- ====================================================
IF OBJECT_ID('sp_Factura_Listar', 'P') IS NOT NULL DROP PROCEDURE sp_Factura_Listar;
GO
CREATE PROCEDURE sp_Factura_Listar
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        F.ID_Factura, F.Fecha, F.Total, F.ID_Propietario, F.ID_Cita, F.EstadoPago
    FROM Factura F
    ORDER BY F.Fecha DESC, F.ID_Factura DESC;
END
GO

-- ====================================================
-- SP: Obtener Detalles de Factura
-- ====================================================
IF OBJECT_ID('sp_Factura_DetallesPorID', 'P') IS NOT NULL DROP PROCEDURE sp_Factura_DetallesPorID;
GO
CREATE PROCEDURE sp_Factura_DetallesPorID
    @ID_Factura INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        FD.ID_FacturaDetalle, FD.ID_Factura, FD.ID_Servicio, FD.Cantidad, FD.PrecioUnitario, FD.Subtotal
    FROM FacturaDetalle FD
    WHERE FD.ID_Factura = @ID_Factura;
END
GO

PRINT '*** STORED PROCEDURES DE FACTURAS CREADOS ***';
GO

