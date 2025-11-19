/*
==================================================================================
SCRIPT 06: STORED PROCEDURES DE HISTORIAL CLÍNICO - VeterinariaGenesisDB
==================================================================================
EJECUTAR DESPUÉS DE 05_StoredProcedures_Facturas.sql
==================================================================================
*/

USE VeterinariaGenesisDB;
GO

PRINT '--- Creando Stored Procedures de Historial Clínico ---';
GO

-- ====================================================
-- SP: Obtener Historial Clínico Completo de una Mascota
-- ====================================================
IF OBJECT_ID('sp_Historial_ObtenerPorMascota', 'P') IS NOT NULL 
    DROP PROCEDURE sp_Historial_ObtenerPorMascota;
GO

CREATE PROCEDURE sp_Historial_ObtenerPorMascota
    @ID_Mascota INT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        'Cita' AS TipoEvento,
        CAST(C.ID_Cita AS VARCHAR(50)) AS ID_Evento,
        C.Fecha AS Fecha,
        C.Hora AS Hora,
        S.Nombre AS Descripcion,
        V.Nombre AS Veterinario,
        S.Costo AS Costo,
        C.Estado AS Estado,
        NULL AS Observaciones
    FROM Cita C
    INNER JOIN Servicio S ON C.ID_Servicio = S.ID_Servicio
    INNER JOIN Veterinario V ON C.ID_Veterinario = V.ID_Veterinario
    WHERE C.ID_Mascota = @ID_Mascota
    
    UNION ALL
    
    SELECT 
        'Tratamiento' AS TipoEvento,
        CAST(T.ID_Tratamiento AS VARCHAR(50)) AS ID_Evento,
        T.Fecha AS Fecha,
        NULL AS Hora,
        T.Diagnostico AS Descripcion,
        NULL AS Veterinario,
        NULL AS Costo,
        NULL AS Estado,
        NULL AS Observaciones
    FROM Tratamiento T
    WHERE T.ID_Mascota = @ID_Mascota
    
    UNION ALL
    
    SELECT 
        'Cirugía' AS TipoEvento,
        CAST(CIR.ID_Cirugia AS VARCHAR(50)) AS ID_Evento,
        CIR.Fecha AS Fecha,
        NULL AS Hora,
        CIR.Tipo + ' - ' + ISNULL(CIR.Descripcion, '') AS Descripcion,
        V.Nombre AS Veterinario,
        NULL AS Costo,
        NULL AS Estado,
        NULL AS Observaciones
    FROM Cirugia CIR
    INNER JOIN Veterinario V ON CIR.ID_Veterinario = V.ID_Veterinario
    WHERE CIR.ID_Mascota = @ID_Mascota
    
    UNION ALL
    
    SELECT 
        'Hospitalización' AS TipoEvento,
        CAST(H.ID_Hospitalizacion AS VARCHAR(50)) AS ID_Evento,
        H.FechaIngreso AS Fecha,
        NULL AS Hora,
        'Hospitalización' AS Descripcion,
        NULL AS Veterinario,
        NULL AS Costo,
        CASE WHEN H.FechaSalida IS NULL THEN 'En Curso' ELSE 'Finalizada' END AS Estado,
        H.Observaciones AS Observaciones
    FROM Hospitalizacion H
    WHERE H.ID_Mascota = @ID_Mascota
    
    UNION ALL
    
    SELECT 
        'Vacuna' AS TipoEvento,
        CAST(MV.ID_Vacuna AS VARCHAR(50)) AS ID_Evento,
        MV.FechaAplicacion AS Fecha,
        NULL AS Hora,
        VAC.Nombre + ' - ' + ISNULL(VAC.Dosis, '') AS Descripcion,
        NULL AS Veterinario,
        NULL AS Costo,
        CASE WHEN MV.FechaProximaDosis IS NULL OR MV.FechaProximaDosis > GETDATE() THEN 'Vigente' ELSE 'Vencida' END AS Estado,
        'Próxima dosis: ' + ISNULL(CONVERT(VARCHAR, MV.FechaProximaDosis, 103), 'N/A') AS Observaciones
    FROM Mascota_Vacuna MV
    INNER JOIN Vacuna VAC ON MV.ID_Vacuna = VAC.ID_Vacuna
    WHERE MV.ID_Mascota = @ID_Mascota
    
    ORDER BY Fecha DESC;
END
GO

-- ====================================================
-- SP: Buscar Mascotas por Nombre o Propietario
-- ====================================================
IF OBJECT_ID('sp_Mascota_BuscarParaHistorial', 'P') IS NOT NULL 
    DROP PROCEDURE sp_Mascota_BuscarParaHistorial;
GO

CREATE PROCEDURE sp_Mascota_BuscarParaHistorial
    @Busqueda VARCHAR(200) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        M.ID_Mascota,
        M.Nombre AS NombreMascota,
        M.Especie,
        M.Raza,
        M.Edad,
        P.ID_Propietario,
        P.Nombre + ' ' + P.Apellidos AS NombrePropietario,
        P.Telefono,
        P.Direccion
    FROM Mascota M
    INNER JOIN Propietario P ON M.ID_Propietario = P.ID_Propietario
    WHERE P.Activo = 1
        AND (
            @Busqueda IS NULL 
            OR M.Nombre LIKE '%' + @Busqueda + '%'
            OR P.Nombre LIKE '%' + @Busqueda + '%'
            OR P.Apellidos LIKE '%' + @Busqueda + '%'
            OR (P.Nombre + ' ' + P.Apellidos) LIKE '%' + @Busqueda + '%'
        )
    ORDER BY M.Nombre, P.Apellidos, P.Nombre;
END
GO

-- ====================================================
-- SP: Agregar Tratamiento
-- ====================================================
IF OBJECT_ID('sp_Historial_AgregarTratamiento', 'P') IS NOT NULL DROP PROCEDURE sp_Historial_AgregarTratamiento;
GO
CREATE PROCEDURE sp_Historial_AgregarTratamiento
    @ID_Mascota INT,
    @Fecha DATE,
    @Diagnostico VARCHAR(250)
AS
BEGIN
    INSERT INTO Tratamiento (Fecha, Diagnostico, ID_Mascota)
    VALUES (@Fecha, @Diagnostico, @ID_Mascota);
    SELECT SCOPE_IDENTITY() AS NuevoID_Tratamiento;
END
GO

-- ====================================================
-- SP: Agregar Vacuna
-- ====================================================
IF OBJECT_ID('sp_Historial_AgregarVacuna', 'P') IS NOT NULL DROP PROCEDURE sp_Historial_AgregarVacuna;
GO
CREATE PROCEDURE sp_Historial_AgregarVacuna
    @ID_Mascota INT,
    @ID_Vacuna INT,
    @FechaAplicacion DATE,
    @FechaProximaDosis DATE = NULL
AS
BEGIN
    INSERT INTO Mascota_Vacuna (ID_Mascota, ID_Vacuna, FechaAplicacion, FechaProximaDosis)
    VALUES (@ID_Mascota, @ID_Vacuna, @FechaAplicacion, @FechaProximaDosis);
END
GO

PRINT '*** STORED PROCEDURES DE HISTORIAL CLÍNICO CREADOS ***';
GO

