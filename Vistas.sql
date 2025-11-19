/*
==================================================================================
SCRIPT 11: VISTAS - VeterinariaGenesisDB
==================================================================================
EJECUTAR DESPUÉS DE 10_StoredProcedures_Servicios.sql
==================================================================================
*/

USE VeterinariaGenesisDB;
GO

PRINT '--- Creando Vistas ---';
GO

-- ====================================================
-- VISTA: Propietarios Activos
-- ====================================================
IF OBJECT_ID('vw_PropietariosActivos', 'V') IS NOT NULL DROP VIEW vw_PropietariosActivos;
GO
CREATE VIEW vw_PropietariosActivos AS
SELECT ID_Propietario, Nombre, Apellidos, Direccion, Telefono 
FROM Propietario 
WHERE Activo = 1;
GO

-- ====================================================
-- VISTA: Mascotas con Propietario
-- ====================================================
IF OBJECT_ID('vw_MascotasConPropietario', 'V') IS NOT NULL DROP VIEW vw_MascotasConPropietario;
GO
CREATE VIEW vw_MascotasConPropietario AS
SELECT 
    M.ID_Mascota, M.Nombre, M.Especie, M.Raza, M.Edad, M.Sexo,
    P.ID_Propietario, 
    P.Nombre + ' ' + P.Apellidos AS NombrePropietario
FROM Mascota M
JOIN Propietario P ON M.ID_Propietario = P.ID_Propietario
WHERE P.Activo = 1;
GO

-- ====================================================
-- VISTA: Veterinarios Activos
-- ====================================================
IF OBJECT_ID('vw_VeterinariosActivos', 'V') IS NOT NULL DROP VIEW vw_VeterinariosActivos;
GO
CREATE VIEW vw_VeterinariosActivos AS
SELECT ID_Veterinario, Nombre, Especialidad, Telefono, Correo 
FROM Veterinario 
WHERE Activo = 1;
GO

-- ====================================================
-- VISTA: Agenda de Citas
-- ====================================================
IF OBJECT_ID('vw_AgendaCitas', 'V') IS NOT NULL DROP VIEW vw_AgendaCitas;
GO
CREATE VIEW vw_AgendaCitas AS
SELECT 
    C.ID_Cita, C.Fecha, C.Hora, C.Estado,
    M.ID_Mascota, M.Nombre AS Mascota,
    P.ID_Propietario, P.Nombre + ' ' + P.Apellidos AS Propietario,
    V.ID_Veterinario, V.Nombre AS Veterinario,
    S.ID_Servicio, S.Nombre AS Servicio
FROM Cita C
JOIN Mascota M ON C.ID_Mascota = M.ID_Mascota
JOIN Propietario P ON M.ID_Propietario = P.ID_Propietario
JOIN Veterinario V ON C.ID_Veterinario = V.ID_Veterinario
JOIN Servicio S ON C.ID_Servicio = S.ID_Servicio
WHERE P.Activo = 1 AND V.Activo = 1;
GO

PRINT '*** VISTAS CREADAS EXITOSAMENTE ***';
GO

