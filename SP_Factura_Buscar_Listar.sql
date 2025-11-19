/*
==================================================================================
STORED PROCEDURES PARA FACTURAS - VeterinariaGenesisDB
==================================================================================
Este script contiene los Stored Procedures para buscar y listar facturas
que serán consumidos por la API REST.

INSTRUCCIONES:
1. Ejecuta este script después de crear la base de datos
2. Estos SPs devuelven datos de facturas con sus detalles
==================================================================================
*/

USE VeterinariaGenesisDB;
GO

-- ====================================================
-- SP: Buscar Factura por ID
-- ====================================================
IF OBJECT_ID('sp_Factura_BuscarPorID', 'P') IS NOT NULL 
    DROP PROCEDURE sp_Factura_BuscarPorID;
GO

CREATE PROCEDURE sp_Factura_BuscarPorID
    @ID_Factura INT
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Validar que la factura existe
    IF NOT EXISTS (SELECT 1 FROM Factura WHERE ID_Factura = @ID_Factura)
    BEGIN
        RETURN; -- Retornar sin resultados si no existe
    END
    
    -- Primer conjunto de resultados: Datos de la factura
    SELECT 
        F.ID_Factura,
        F.Fecha,
        F.Total,
        F.ID_Propietario,
        F.ID_Cita,
        F.EstadoPago
    FROM Factura F
    WHERE F.ID_Factura = @ID_Factura;
    
    -- Segundo conjunto de resultados: Detalles de la factura
    SELECT 
        FD.ID_FacturaDetalle,
        FD.ID_Factura,
        FD.ID_Servicio,
        FD.Cantidad,
        FD.PrecioUnitario,
        FD.Subtotal
    FROM FacturaDetalle FD
    WHERE FD.ID_Factura = @ID_Factura;
END;
GO

PRINT 'Stored procedure [sp_Factura_BuscarPorID] creado exitosamente.';
GO

-- ====================================================
-- SP: Listar Todas las Facturas
-- ====================================================
IF OBJECT_ID('sp_Factura_Listar', 'P') IS NOT NULL 
    DROP PROCEDURE sp_Factura_Listar;
GO

CREATE PROCEDURE sp_Factura_Listar
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        F.ID_Factura,
        F.Fecha,
        F.Total,
        F.ID_Propietario,
        F.ID_Cita,
        F.EstadoPago
    FROM Factura F
    ORDER BY F.Fecha DESC, F.ID_Factura DESC;
END;
GO

PRINT 'Stored procedure [sp_Factura_Listar] creado exitosamente.';
GO

-- ====================================================
-- SP: Obtener Detalles de Factura por ID
-- ====================================================
IF OBJECT_ID('sp_Factura_DetallesPorID', 'P') IS NOT NULL 
    DROP PROCEDURE sp_Factura_DetallesPorID;
GO

CREATE PROCEDURE sp_Factura_DetallesPorID
    @ID_Factura INT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        FD.ID_FacturaDetalle,
        FD.ID_Factura,
        FD.ID_Servicio,
        FD.Cantidad,
        FD.PrecioUnitario,
        FD.Subtotal
    FROM FacturaDetalle FD
    WHERE FD.ID_Factura = @ID_Factura;
END;
GO

PRINT 'Stored procedure [sp_Factura_DetallesPorID] creado exitosamente.';
GO

-- ====================================================
-- PERMISOS PARA LOS STORED PROCEDURES
-- ====================================================
PRINT '=== Otorgando permisos a rol_api_ejecutor ===';
GO

GRANT EXECUTE ON sp_Factura_BuscarPorID TO rol_api_ejecutor;
GRANT EXECUTE ON sp_Factura_Listar TO rol_api_ejecutor;
GRANT EXECUTE ON sp_Factura_DetallesPorID TO rol_api_ejecutor;
GO

PRINT 'Permisos otorgados exitosamente.';
GO

PRINT '';
PRINT '=== SCRIPT COMPLETADO ===';
PRINT 'Los stored procedures han sido creados:';
PRINT '  - sp_Factura_BuscarPorID (devuelve factura y detalles)';
PRINT '  - sp_Factura_Listar';
PRINT '  - sp_Factura_DetallesPorID';
PRINT 'Los permisos han sido otorgados al rol_api_ejecutor.';
GO

