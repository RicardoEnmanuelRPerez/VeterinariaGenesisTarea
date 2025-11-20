/*
==================================================================================
SCRIPT 04: STORED PROCEDURES CRUD PRINCIPALES - VeterinariaGenesisDB
==================================================================================
Este script crea los SPs principales de CRUD (Propietario, Mascota, Cita, Factura).
EJECUTAR DESPUÉS DE 03_Triggers.sql
==================================================================================
*/

USE VeterinariaGenesisDB;
GO

PRINT '--- Creando Stored Procedures CRUD Principales ---';
GO

-- ====================================================
-- SP: LOGIN DE USUARIO
-- ====================================================
IF OBJECT_ID('sp_Usuario_Login', 'P') IS NOT NULL DROP PROCEDURE sp_Usuario_Login;
GO
CREATE PROCEDURE sp_Usuario_Login
    @NombreLogin VARCHAR(50),
    @Contrasena VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Hash VARBINARY(32) = HASHBYTES('SHA2_256', @Contrasena);

    SELECT 
        U.ID_Usuario,
        U.NombreLogin,
        U.NombreCompleto,
        R.NombreRol,
        U.ID_Veterinario
    FROM Usuario U
    JOIN Roles R ON U.ID_Rol = R.ID_Rol
    WHERE U.NombreLogin = @NombreLogin
      AND U.ContrasenaHash = @Hash
      AND U.Activo = 1;
END
GO

-- ====================================================
-- SPs CRUD: PROPIETARIO
-- ====================================================
IF OBJECT_ID('sp_Propietario_Crear', 'P') IS NOT NULL DROP PROCEDURE sp_Propietario_Crear;
GO
CREATE PROCEDURE sp_Propietario_Crear
    @Nombre VARCHAR(100),
    @Apellidos VARCHAR(120),
    @Direccion VARCHAR(200) = NULL,
    @Telefono VARCHAR(20) = NULL
AS
BEGIN
    -- Validar si ya existe un propietario activo con el mismo nombre
    IF EXISTS (
        SELECT 1 FROM Propietario 
        WHERE LOWER(LTRIM(RTRIM(Nombre))) = LOWER(LTRIM(RTRIM(@Nombre)))
          AND Activo = 1
    )
    BEGIN
        RAISERROR('Ya existe un propietario activo con el nombre "%s". No se pueden registrar propietarios con nombres duplicados.', 16, 1, @Nombre);
        RETURN;
    END

    INSERT INTO Propietario (Nombre, Apellidos, Direccion, Telefono, Activo)
    VALUES (@Nombre, @Apellidos, @Direccion, @Telefono, 1);
    SELECT SCOPE_IDENTITY() AS NuevoID;
END
GO

IF OBJECT_ID('sp_Propietario_Actualizar', 'P') IS NOT NULL DROP PROCEDURE sp_Propietario_Actualizar;
GO
CREATE PROCEDURE sp_Propietario_Actualizar
    @ID_Propietario INT,
    @Nombre VARCHAR(100),
    @Apellidos VARCHAR(120),
    @Direccion VARCHAR(200) = NULL,
    @Telefono VARCHAR(20) = NULL
AS
BEGIN
    UPDATE Propietario
    SET Nombre = @Nombre, Apellidos = @Apellidos, Direccion = @Direccion, Telefono = @Telefono
    WHERE ID_Propietario = @ID_Propietario;
END
GO

IF OBJECT_ID('sp_Propietario_Desactivar', 'P') IS NOT NULL DROP PROCEDURE sp_Propietario_Desactivar;
GO
CREATE PROCEDURE sp_Propietario_Desactivar
    @ID_Propietario INT
AS
BEGIN
    UPDATE Propietario SET Activo = 0 WHERE ID_Propietario = @ID_Propietario;
END
GO

IF OBJECT_ID('sp_Propietario_ListarActivos', 'P') IS NOT NULL DROP PROCEDURE sp_Propietario_ListarActivos;
GO
CREATE PROCEDURE sp_Propietario_ListarActivos
AS
BEGIN
    SELECT * FROM Propietario WHERE Activo = 1 ORDER BY Apellidos, Nombre;
END
GO

IF OBJECT_ID('sp_Propietario_BuscarPorID', 'P') IS NOT NULL DROP PROCEDURE sp_Propietario_BuscarPorID;
GO
CREATE PROCEDURE sp_Propietario_BuscarPorID
    @ID_Propietario INT
AS
BEGIN
    SELECT * FROM Propietario WHERE ID_Propietario = @ID_Propietario;
END
GO

-- ====================================================
-- SPs CRUD: MASCOTA
-- ====================================================
IF OBJECT_ID('sp_Mascota_Crear', 'P') IS NOT NULL DROP PROCEDURE sp_Mascota_Crear;
GO
CREATE PROCEDURE sp_Mascota_Crear
    @Nombre VARCHAR(100),
    @Especie VARCHAR(50),
    @Raza VARCHAR(50) = NULL,
    @Edad INT = NULL,
    @Sexo VARCHAR(10),
    @ID_Propietario INT
AS
BEGIN
    INSERT INTO Mascota (Nombre, Especie, Raza, Edad, Sexo, ID_Propietario)
    VALUES (@Nombre, @Especie, @Raza, @Edad, @Sexo, @ID_Propietario);
    SELECT SCOPE_IDENTITY() AS NuevoID;
END
GO

IF OBJECT_ID('sp_Mascota_Actualizar', 'P') IS NOT NULL DROP PROCEDURE sp_Mascota_Actualizar;
GO
CREATE PROCEDURE sp_Mascota_Actualizar
    @ID_Mascota INT,
    @Nombre VARCHAR(100),
    @Especie VARCHAR(50),
    @Raza VARCHAR(50) = NULL,
    @Edad INT = NULL,
    @Sexo VARCHAR(10),
    @ID_Propietario INT
AS
BEGIN
    UPDATE Mascota
    SET Nombre = @Nombre, Especie = @Especie, Raza = @Raza, Edad = @Edad, Sexo = @Sexo, ID_Propietario = @ID_Propietario
    WHERE ID_Mascota = @ID_Mascota;
END
GO

IF OBJECT_ID('sp_Mascota_ListarPorPropietario', 'P') IS NOT NULL DROP PROCEDURE sp_Mascota_ListarPorPropietario;
GO
CREATE PROCEDURE sp_Mascota_ListarPorPropietario
    @ID_Propietario INT
AS
BEGIN
    SELECT M.*, P.Nombre + ' ' + P.Apellidos AS NombrePropietario
    FROM Mascota M
    JOIN Propietario P ON M.ID_Propietario = P.ID_Propietario
    WHERE M.ID_Propietario = @ID_Propietario AND P.Activo = 1;
END
GO

IF OBJECT_ID('sp_Mascota_BuscarPorID', 'P') IS NOT NULL DROP PROCEDURE sp_Mascota_BuscarPorID;
GO
CREATE PROCEDURE sp_Mascota_BuscarPorID
    @ID_Mascota INT
AS
BEGIN
    SELECT M.*, P.Nombre + ' ' + P.Apellidos AS NombrePropietario
    FROM Mascota M
    JOIN Propietario P ON M.ID_Propietario = P.ID_Propietario
    WHERE M.ID_Mascota = @ID_Mascota AND P.Activo = 1;
END
GO

-- ====================================================
-- SPs CRUD: CITA
-- ====================================================
IF OBJECT_ID('sp_Cita_Agendar', 'P') IS NOT NULL DROP PROCEDURE sp_Cita_Agendar;
GO
CREATE PROCEDURE sp_Cita_Agendar
    @Fecha DATE,
    @Hora TIME,
    @ID_Mascota INT,
    @ID_Veterinario INT,
    @ID_Servicio INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Cita 
               WHERE ID_Veterinario = @ID_Veterinario 
               AND Fecha = @Fecha 
               AND Hora = @Hora
               AND Estado = 'Programada')
    BEGIN
        RAISERROR('El veterinario ya tiene una cita programada a esa hora.', 16, 1);
        RETURN;
    END

    INSERT INTO Cita (Fecha, Hora, ID_Mascota, ID_Veterinario, ID_Servicio, Estado)
    VALUES (@Fecha, @Hora, @ID_Mascota, @ID_Veterinario, @ID_Servicio, 'Programada');
    SELECT SCOPE_IDENTITY() AS NuevoID;
END
GO

IF OBJECT_ID('sp_Cita_Actualizar', 'P') IS NOT NULL DROP PROCEDURE sp_Cita_Actualizar;
GO
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
    
    IF NOT EXISTS (SELECT 1 FROM Cita WHERE ID_Cita = @ID_Cita)
    BEGIN
        RAISERROR('La cita especificada no existe.', 16, 1);
        RETURN;
    END
    
    IF @Estado NOT IN ('Programada', 'Completada', 'Cancelada')
    BEGIN
        RAISERROR('El estado debe ser: Programada, Completada o Cancelada.', 16, 1);
        RETURN;
    END
    
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
    
    UPDATE Cita
    SET Fecha = @Fecha, Hora = @Hora, ID_Mascota = @ID_Mascota,
        ID_Veterinario = @ID_Veterinario, ID_Servicio = @ID_Servicio, Estado = @Estado
    WHERE ID_Cita = @ID_Cita;
END
GO

IF OBJECT_ID('sp_Cita_Cancelar', 'P') IS NOT NULL DROP PROCEDURE sp_Cita_Cancelar;
GO
CREATE PROCEDURE sp_Cita_Cancelar
    @ID_Cita INT
AS
BEGIN
    UPDATE Cita SET Estado = 'Cancelada' 
    WHERE ID_Cita = @ID_Cita AND Estado = 'Programada';
END
GO

IF OBJECT_ID('sp_Cita_ListarPorFecha', 'P') IS NOT NULL DROP PROCEDURE sp_Cita_ListarPorFecha;
GO
CREATE PROCEDURE sp_Cita_ListarPorFecha
    @Fecha DATE
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        C.ID_Cita,
        C.Fecha,
        C.Hora,
        C.Estado,
        C.ID_Mascota,
        M.Nombre AS Mascota,
        M.ID_Propietario AS ID_Propietario,
        P.Nombre + ' ' + P.Apellidos AS Propietario,
        C.ID_Veterinario,
        V.Nombre AS Veterinario,
        C.ID_Servicio,
        S.Nombre AS Servicio
    FROM Cita C
    JOIN Mascota M ON C.ID_Mascota = M.ID_Mascota
    JOIN Propietario P ON M.ID_Propietario = P.ID_Propietario
    JOIN Veterinario V ON C.ID_Veterinario = V.ID_Veterinario
    JOIN Servicio S ON C.ID_Servicio = S.ID_Servicio
    WHERE C.Fecha = @Fecha AND P.Activo = 1 AND V.Activo = 1
    ORDER BY C.Hora;
END
GO

IF OBJECT_ID('sp_Cita_ListarPorVeterinario', 'P') IS NOT NULL DROP PROCEDURE sp_Cita_ListarPorVeterinario;
GO
CREATE PROCEDURE sp_Cita_ListarPorVeterinario
    @ID_Veterinario INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        C.ID_Cita,
        C.Fecha,
        C.Hora,
        C.Estado,
        C.ID_Mascota,
        M.Nombre AS Mascota,
        M.ID_Propietario AS ID_Propietario,
        P.Nombre + ' ' + P.Apellidos AS Propietario,
        C.ID_Veterinario,
        V.Nombre AS Veterinario,
        C.ID_Servicio,
        S.Nombre AS Servicio
    FROM Cita C
    JOIN Mascota M ON C.ID_Mascota = M.ID_Mascota
    JOIN Propietario P ON M.ID_Propietario = P.ID_Propietario
    JOIN Veterinario V ON C.ID_Veterinario = V.ID_Veterinario
    JOIN Servicio S ON C.ID_Servicio = S.ID_Servicio
    WHERE C.ID_Veterinario = @ID_Veterinario 
      AND C.Fecha >= CAST(GETDATE() AS DATE)
      AND P.Activo = 1 AND V.Activo = 1
    ORDER BY C.Fecha, C.Hora;
END
GO

IF OBJECT_ID('sp_Cita_ListarCompletadasSinFactura', 'P') IS NOT NULL DROP PROCEDURE sp_Cita_ListarCompletadasSinFactura;
GO
CREATE PROCEDURE sp_Cita_ListarCompletadasSinFactura
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        C.ID_Cita,
        C.Fecha,
        C.Hora,
        C.Estado,
        C.ID_Mascota,
        M.Nombre AS Mascota,
        M.ID_Propietario AS ID_Propietario,
        P.Nombre + ' ' + P.Apellidos AS Propietario,
        C.ID_Veterinario,
        V.Nombre AS Veterinario,
        C.ID_Servicio,
        S.Nombre AS Servicio
    FROM Cita C
    JOIN Mascota M ON C.ID_Mascota = M.ID_Mascota
    JOIN Propietario P ON M.ID_Propietario = P.ID_Propietario
    JOIN Veterinario V ON C.ID_Veterinario = V.ID_Veterinario
    JOIN Servicio S ON C.ID_Servicio = S.ID_Servicio
    WHERE C.Estado = 'Completada'
      AND NOT EXISTS (SELECT 1 FROM Factura F WHERE F.ID_Cita = C.ID_Cita)
      AND P.Activo = 1 AND V.Activo = 1
    ORDER BY C.Fecha DESC, C.Hora DESC;
END
GO

PRINT '*** STORED PROCEDURES CRUD PRINCIPALES CREADOS ***';
GO

