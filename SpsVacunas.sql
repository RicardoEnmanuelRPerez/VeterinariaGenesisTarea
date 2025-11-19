/*
==================================================================================
SCRIPT 08: STORED PROCEDURES DE VACUNAS - VeterinariaGenesisDB
==================================================================================
EJECUTAR DESPUÉS DE 07_StoredProcedures_Dashboard.sql
==================================================================================
*/

USE VeterinariaGenesisDB;
GO

PRINT '--- Creando Stored Procedures de Vacunas ---';
GO

-- ====================================================
-- SP: Recordatorios de Vacunación
-- ====================================================
IF OBJECT_ID('sp_Vacuna_Recordatorios', 'P') IS NOT NULL 
    DROP PROCEDURE sp_Vacuna_Recordatorios;
GO

CREATE PROCEDURE sp_Vacuna_Recordatorios
    @DiasAnticipacion INT = 30
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        M.ID_Mascota,
        M.Nombre AS NombreMascota,
        M.Especie,
        M.Raza,
        P.ID_Propietario,
        P.Nombre + ' ' + P.Apellidos AS NombrePropietario,
        P.Telefono,
        P.Direccion,
        VAC.Nombre AS NombreVacuna,
        VAC.Dosis,
        MV.FechaAplicacion,
        MV.FechaProximaDosis,
        CASE 
            WHEN MV.FechaProximaDosis IS NULL THEN 'Sin próxima dosis programada'
            WHEN MV.FechaProximaDosis < GETDATE() THEN 'Vencida'
            WHEN MV.FechaProximaDosis <= DATEADD(DAY, @DiasAnticipacion, GETDATE()) THEN 'Por vencer'
            ELSE 'Vigente'
        END AS Estado,
        DATEDIFF(DAY, GETDATE(), MV.FechaProximaDosis) AS DiasRestantes
    FROM Mascota_Vacuna MV
    INNER JOIN Mascota M ON MV.ID_Mascota = M.ID_Mascota
    INNER JOIN Propietario P ON M.ID_Propietario = P.ID_Propietario
    INNER JOIN Vacuna VAC ON MV.ID_Vacuna = VAC.ID_Vacuna
    WHERE P.Activo = 1
        AND (
            MV.FechaProximaDosis IS NULL
            OR MV.FechaProximaDosis <= DATEADD(DAY, @DiasAnticipacion, GETDATE())
        )
    ORDER BY 
        CASE 
            WHEN MV.FechaProximaDosis IS NULL THEN 0
            WHEN MV.FechaProximaDosis < GETDATE() THEN 1
            ELSE 2
        END,
        MV.FechaProximaDosis ASC;
END
GO

PRINT '*** STORED PROCEDURES DE VACUNAS CREADOS ***';
GO

