/*
==================================================================================
SCRIPT 03: TRIGGERS - VeterinariaGenesisDB
==================================================================================
Este script crea todos los triggers necesarios.
EJECUTAR DESPUÉS DE 02_Indices.sql
==================================================================================
*/

USE VeterinariaGenesisDB;
GO

PRINT '--- Creando Triggers ---';
GO

-- ====================================================
-- TRIGGER: Actualizar Total de Factura
-- ====================================================
IF OBJECT_ID('tr_ActualizarTotalFactura', 'TR') IS NOT NULL
    DROP TRIGGER tr_ActualizarTotalFactura;
GO

CREATE TRIGGER tr_ActualizarTotalFactura
ON FacturaDetalle
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @FacturasAfectadas TABLE (ID_Factura INT UNIQUE);

    INSERT INTO @FacturasAfectadas (ID_Factura) SELECT ID_Factura FROM inserted;
    INSERT INTO @FacturasAfectadas (ID_Factura) SELECT ID_Factura FROM deleted;

    UPDATE F
    SET Total = ISNULL((SELECT SUM(fd.Subtotal) 
                        FROM FacturaDetalle fd 
                        WHERE fd.ID_Factura = F.ID_Factura), 0)
    FROM Factura F
    JOIN @FacturasAfectadas FA ON F.ID_Factura = FA.ID_Factura;
END
GO
PRINT 'Trigger [tr_ActualizarTotalFactura] creado.';
GO

-- ====================================================
-- TRIGGER: Actualizar Citas Pasadas
-- ====================================================
IF OBJECT_ID('trg_ActualizarCitasPasadas', 'TR') IS NOT NULL
    DROP TRIGGER trg_ActualizarCitasPasadas;
GO

CREATE TRIGGER trg_ActualizarCitasPasadas
ON Cita
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE Cita
    SET Estado = 'Completada'
    WHERE Estado = 'Programada'
      AND Fecha < CAST(GETDATE() AS DATE);
END
GO
PRINT 'Trigger [trg_ActualizarCitasPasadas] creado.';
GO

PRINT '*** TRIGGERS CREADOS EXITOSAMENTE ***';
GO

