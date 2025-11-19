/*
==================================================================================
SCRIPT 10: STORED PROCEDURES DE SERVICIOS Y VETERINARIOS - VeterinariaGenesisDB
==================================================================================
EJECUTAR DESPUÉS DE 09_StoredProcedures_Reportes.sql
==================================================================================
*/

USE VeterinariaGenesisDB;
GO

PRINT '--- Creando Stored Procedures de Servicios y Veterinarios ---';
GO

-- ====================================================
-- SPs CRUD: SERVICIO
-- ====================================================
IF OBJECT_ID('sp_Servicio_Listar', 'P') IS NOT NULL DROP PROCEDURE sp_Servicio_Listar;
GO
CREATE PROCEDURE sp_Servicio_Listar
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ID_Servicio, Nombre, Descripcion, Costo
    FROM Servicio
    ORDER BY Nombre;
END
GO

IF OBJECT_ID('sp_Servicio_BuscarPorID', 'P') IS NOT NULL DROP PROCEDURE sp_Servicio_BuscarPorID;
GO
CREATE PROCEDURE sp_Servicio_BuscarPorID
    @ID_Servicio INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ID_Servicio, Nombre, Descripcion, Costo
    FROM Servicio
    WHERE ID_Servicio = @ID_Servicio;
END
GO

IF OBJECT_ID('sp_Servicio_Crear', 'P') IS NOT NULL DROP PROCEDURE sp_Servicio_Crear;
GO
CREATE PROCEDURE sp_Servicio_Crear
    @Nombre VARCHAR(100),
    @Descripcion VARCHAR(250) = NULL,
    @Costo DECIMAL(10,2)
AS
BEGIN
    SET NOCOUNT ON;
    IF @Nombre IS NULL OR LEN(LTRIM(RTRIM(@Nombre))) = 0
    BEGIN
        RAISERROR('El nombre del servicio es requerido.', 16, 1);
        RETURN;
    END
    IF @Costo < 0
    BEGIN
        RAISERROR('El costo debe ser mayor o igual a 0.', 16, 1);
        RETURN;
    END
    INSERT INTO Servicio (Nombre, Descripcion, Costo)
    VALUES (@Nombre, @Descripcion, @Costo);
    SELECT SCOPE_IDENTITY() AS NuevoID;
END
GO

IF OBJECT_ID('sp_Servicio_Actualizar', 'P') IS NOT NULL DROP PROCEDURE sp_Servicio_Actualizar;
GO
CREATE PROCEDURE sp_Servicio_Actualizar
    @ID_Servicio INT,
    @Nombre VARCHAR(100),
    @Descripcion VARCHAR(250) = NULL,
    @Costo DECIMAL(10,2)
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM Servicio WHERE ID_Servicio = @ID_Servicio)
    BEGIN
        RAISERROR('El servicio no existe.', 16, 1);
        RETURN;
    END
    IF @Nombre IS NULL OR LEN(LTRIM(RTRIM(@Nombre))) = 0
    BEGIN
        RAISERROR('El nombre del servicio es requerido.', 16, 1);
        RETURN;
    END
    IF @Costo < 0
    BEGIN
        RAISERROR('El costo debe ser mayor o igual a 0.', 16, 1);
        RETURN;
    END
    UPDATE Servicio
    SET Nombre = @Nombre, Descripcion = @Descripcion, Costo = @Costo
    WHERE ID_Servicio = @ID_Servicio;
END
GO

IF OBJECT_ID('sp_Servicio_Eliminar', 'P') IS NOT NULL DROP PROCEDURE sp_Servicio_Eliminar;
GO
CREATE PROCEDURE sp_Servicio_Eliminar
    @ID_Servicio INT
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM Servicio WHERE ID_Servicio = @ID_Servicio)
    BEGIN
        RAISERROR('El servicio no existe.', 16, 1);
        RETURN;
    END
    IF EXISTS (SELECT 1 FROM Cita WHERE ID_Servicio = @ID_Servicio)
    BEGIN
        RAISERROR('No se puede eliminar el servicio porque está siendo usado en citas.', 16, 1);
        RETURN;
    END
    IF EXISTS (SELECT 1 FROM FacturaDetalle WHERE ID_Servicio = @ID_Servicio)
    BEGIN
        RAISERROR('No se puede eliminar el servicio porque está siendo usado en facturas.', 16, 1);
        RETURN;
    END
    DELETE FROM Servicio WHERE ID_Servicio = @ID_Servicio;
END
GO

-- ====================================================
-- SPs CRUD: VETERINARIO
-- ====================================================
IF OBJECT_ID('sp_Veterinario_ListarActivos', 'P') IS NOT NULL DROP PROCEDURE sp_Veterinario_ListarActivos;
GO
CREATE PROCEDURE sp_Veterinario_ListarActivos
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ID_Veterinario, Nombre, Especialidad, Telefono, Correo, Activo
    FROM Veterinario
    WHERE Activo = 1
    ORDER BY Nombre;
END
GO

IF OBJECT_ID('sp_Veterinario_BuscarPorID', 'P') IS NOT NULL DROP PROCEDURE sp_Veterinario_BuscarPorID;
GO
CREATE PROCEDURE sp_Veterinario_BuscarPorID
    @ID_Veterinario INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ID_Veterinario, Nombre, Especialidad, Telefono, Correo, Activo
    FROM Veterinario
    WHERE ID_Veterinario = @ID_Veterinario;
END
GO

PRINT '*** STORED PROCEDURES DE SERVICIOS Y VETERINARIOS CREADOS ***';
GO

