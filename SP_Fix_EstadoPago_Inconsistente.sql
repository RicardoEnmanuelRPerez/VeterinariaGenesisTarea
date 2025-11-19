/*
==================================================================================
SCRIPT PARA CORREGIR ESTADOS DE PAGO INCONSISTENTES - VeterinariaGenesisDB
==================================================================================
Este script corrige facturas que tienen pagos registrados pero su EstadoPago
sigue siendo "Pendiente". Esto puede ocurrir si los pagos se procesaron antes
de que se corrigiera el stored procedure sp_Factura_Pagar.

IMPORTANTE: Este script debe ejecutarse con permisos de administrador (sa o dbo)
==================================================================================
*/

USE VeterinariaGenesisDB;
GO

-- ====================================================
-- CREAR STORED PROCEDURE PARA CORREGIR ESTADOS
-- ====================================================
PRINT '--- Creando stored procedure para corregir estados de pago ---';

IF OBJECT_ID('sp_Factura_CorregirEstadosPago', 'P') IS NOT NULL 
    DROP PROCEDURE sp_Factura_CorregirEstadosPago;
GO

CREATE PROCEDURE sp_Factura_CorregirEstadosPago
WITH EXECUTE AS OWNER
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @FacturasActualizadas INT = 0;
    DECLARE @FacturasConPago INT = 0;
    DECLARE @FacturasPendientes INT = 0;

    BEGIN TRANSACTION;
    BEGIN TRY
        -- Contar facturas con pagos que están marcadas como Pendiente
        SELECT @FacturasConPago = COUNT(*)
        FROM Factura F
        INNER JOIN Pago P ON F.ID_Factura = P.ID_Factura
        WHERE F.EstadoPago = 'Pendiente';

        -- Contar facturas pendientes sin pago
        SELECT @FacturasPendientes = COUNT(*)
        FROM Factura F
        WHERE F.EstadoPago = 'Pendiente'
        AND NOT EXISTS (SELECT 1 FROM Pago P WHERE P.ID_Factura = F.ID_Factura);

        -- Actualizar facturas que tienen pago pero están marcadas como Pendiente
        UPDATE F
        SET F.EstadoPago = 'Pagada'
        FROM Factura F
        INNER JOIN Pago P ON F.ID_Factura = P.ID_Factura
        WHERE F.EstadoPago = 'Pendiente';

        SET @FacturasActualizadas = @@ROWCOUNT;

        COMMIT TRANSACTION;

        -- Retornar resultados
        SELECT 
            @FacturasConPago AS FacturasConPagoPendientes,
            @FacturasActualizadas AS FacturasActualizadas,
            @FacturasPendientes AS FacturasPendientesSinPago;
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

PRINT 'Stored procedure sp_Factura_CorregirEstadosPago creado exitosamente.';
GO

-- ====================================================
-- EJECUTAR CORRECCIÓN DE ESTADOS
-- ====================================================
PRINT '';
PRINT '--- Ejecutando corrección de estados de pago ---';
PRINT '';

DECLARE @FacturasConPago INT;
DECLARE @FacturasActualizadas INT;
DECLARE @FacturasPendientes INT;

EXEC sp_Factura_CorregirEstadosPago;

-- Los resultados se mostrarán en el resultado del stored procedure
PRINT '';
PRINT 'Corrección de estados de pago completada.';
PRINT '';
PRINT 'IMPORTANTE: Revisa los resultados del stored procedure para ver:';
PRINT '  - Cuántas facturas con pago estaban marcadas como Pendiente';
PRINT '  - Cuántas facturas fueron actualizadas a Pagada';
PRINT '  - Cuántas facturas siguen pendientes (sin pago)';
GO

-- ====================================================
-- VERIFICACIÓN ADICIONAL: Crear SP para mostrar facturas corregidas
-- ====================================================
PRINT '';
PRINT '--- Creando stored procedure para verificación ---';

IF OBJECT_ID('sp_Factura_VerificarEstadosPago', 'P') IS NOT NULL 
    DROP PROCEDURE sp_Factura_VerificarEstadosPago;
GO

CREATE PROCEDURE sp_Factura_VerificarEstadosPago
WITH EXECUTE AS OWNER
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Mostrar facturas con pago que están como Pagada
    SELECT 
        F.ID_Factura,
        F.Fecha,
        F.Total,
        F.ID_Propietario,
        F.EstadoPago,
        P.Monto AS MontoPagado,
        P.MetodoPago,
        P.FechaPago
    FROM Factura F
    INNER JOIN Pago P ON F.ID_Factura = P.ID_Factura
    WHERE F.EstadoPago = 'Pagada'
    ORDER BY F.ID_Factura DESC;
END
GO

PRINT 'Stored procedure sp_Factura_VerificarEstadosPago creado exitosamente.';
GO

-- Ejecutar verificación
PRINT '';
PRINT '--- Verificación: Facturas con pago que ahora están como Pagada ---';
EXEC sp_Factura_VerificarEstadosPago;
GO

PRINT '';
PRINT '=== SCRIPT COMPLETADO ===';
PRINT 'El stored procedure sp_Factura_CorregirEstadosPago ha sido creado y ejecutado.';
PRINT 'Todas las facturas con pagos registrados ahora tienen EstadoPago = ''Pagada''.';
GO

