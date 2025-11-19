/*
==================================================================================
SCRIPT PARA PREVENIR PAGOS DUPLICADOS - VeterinariaGenesisDB
==================================================================================
Este script:
1. Crea stored procedures con permisos de OWNER para limpiar pagos duplicados
2. Agrega una restricción única para prevenir pagos duplicados en el futuro
3. Ejecuta la limpieza de pagos duplicados existentes

IMPORTANTE: Este script debe ejecutarse con permisos de administrador (sa o dbo)
==================================================================================
*/

USE VeterinariaGenesisDB;
GO

-- ====================================================
-- 1. CREAR STORED PROCEDURE PARA LIMPIAR PAGOS DUPLICADOS
-- ====================================================
PRINT '--- Creando stored procedure para limpiar pagos duplicados ---';

IF OBJECT_ID('sp_Factura_LimpiarPagosDuplicados', 'P') IS NOT NULL 
    DROP PROCEDURE sp_Factura_LimpiarPagosDuplicados;
GO

CREATE PROCEDURE sp_Factura_LimpiarPagosDuplicados
WITH EXECUTE AS OWNER
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @PagosEliminados INT = 0;
    DECLARE @FacturasActualizadas INT = 0;

    BEGIN TRANSACTION;
    BEGIN TRY
        -- 1. Eliminar pagos duplicados (mantener solo el más reciente)
        WITH PagosDuplicados AS (
            SELECT 
                ID_Pago,
                ID_Factura,
                ROW_NUMBER() OVER (PARTITION BY ID_Factura ORDER BY FechaPago DESC, ID_Pago DESC) AS RowNum
            FROM Pago
        )
        DELETE FROM Pago
        WHERE ID_Pago IN (
            SELECT ID_Pago 
            FROM PagosDuplicados 
            WHERE RowNum > 1
        );

        SET @PagosEliminados = @@ROWCOUNT;

        -- 2. Actualizar facturas que tienen pago pero están marcadas como Pendiente
        UPDATE F
        SET F.EstadoPago = 'Pagada'
        FROM Factura F
        INNER JOIN Pago P ON F.ID_Factura = P.ID_Factura
        WHERE F.EstadoPago = 'Pendiente';

        SET @FacturasActualizadas = @@ROWCOUNT;

        COMMIT TRANSACTION;

        SELECT 
            @PagosEliminados AS PagosEliminados,
            @FacturasActualizadas AS FacturasActualizadas;
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

PRINT 'Stored procedure sp_Factura_LimpiarPagosDuplicados creado exitosamente.';
GO

-- ====================================================
-- 2. AGREGAR RESTRICCIÓN ÚNICA PARA PREVENIR DUPLICADOS
-- ====================================================
PRINT '--- Agregando restricción única para prevenir pagos duplicados ---';

-- Verificar si ya existe la restricción
IF NOT EXISTS (
    SELECT 1 
    FROM sys.indexes 
    WHERE name = 'UQ_Pago_ID_Factura' 
    AND object_id = OBJECT_ID('Pago')
)
BEGIN
    -- Crear índice único en ID_Factura
    CREATE UNIQUE NONCLUSTERED INDEX UQ_Pago_ID_Factura
    ON Pago(ID_Factura);
    
    PRINT 'Restricción única UQ_Pago_ID_Factura creada exitosamente.';
END
ELSE
BEGIN
    PRINT 'La restricción única UQ_Pago_ID_Factura ya existe.';
END
GO

-- ====================================================
-- 3. EJECUTAR LIMPIEZA DE PAGOS DUPLICADOS
-- ====================================================
PRINT '--- Ejecutando limpieza de pagos duplicados ---';

DECLARE @PagosEliminados INT;
DECLARE @FacturasActualizadas INT;

EXEC sp_Factura_LimpiarPagosDuplicados;

-- Los resultados se mostrarán en el resultado del stored procedure
PRINT 'Limpieza de pagos duplicados completada.';
GO

-- ====================================================
-- 4. OTORGAR PERMISOS AL ROL DE LA API (OPCIONAL)
-- ====================================================
PRINT '--- Otorgando permisos al rol de la API ---';

-- No otorgamos permisos de ejecución porque este SP es solo para administración
-- El usuario de la API no debería poder ejecutar este procedimiento
PRINT 'Nota: Este stored procedure es solo para uso administrativo.';
GO

PRINT '';
PRINT '=== SCRIPT COMPLETADO ===';
PRINT 'El stored procedure sp_Factura_LimpiarPagosDuplicados ha sido creado.';
PRINT 'La restricción única UQ_Pago_ID_Factura ha sido verificada/creada.';
PRINT 'La limpieza de pagos duplicados ha sido ejecutada.';
PRINT '';
PRINT 'IMPORTANTE: Revisa los resultados del stored procedure para ver cuántos pagos';
PRINT 'duplicados fueron eliminados y cuántas facturas fueron actualizadas.';
GO

