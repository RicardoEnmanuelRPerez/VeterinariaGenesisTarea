/*
==================================================================================
STORED PROCEDURES PARA SERVICIO Y VETERINARIO
Este script agrega los stored procedures faltantes para gestionar Servicios y Veterinarios
==================================================================================
*/

USE VeterinariaGenesisDB;
GO

-- ==========================================================
-- STORED PROCEDURES PARA SERVICIO
-- ==========================================================
PRINT '--- Creando SPs para [Servicio] ---';

-- Listar todos los servicios
IF OBJECT_ID('sp_Servicio_Listar', 'P') IS NOT NULL DROP PROCEDURE sp_Servicio_Listar;
GO
CREATE PROCEDURE sp_Servicio_Listar
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        ID_Servicio,
        Nombre,
        Descripcion,
        Costo
    FROM Servicio
    ORDER BY Nombre;
END
GO

-- Buscar servicio por ID
IF OBJECT_ID('sp_Servicio_BuscarPorID', 'P') IS NOT NULL DROP PROCEDURE sp_Servicio_BuscarPorID;
GO
CREATE PROCEDURE sp_Servicio_BuscarPorID
    @ID_Servicio INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        ID_Servicio,
        Nombre,
        Descripcion,
        Costo
    FROM Servicio
    WHERE ID_Servicio = @ID_Servicio;
END
GO

-- Crear nuevo servicio
IF OBJECT_ID('sp_Servicio_Crear', 'P') IS NOT NULL DROP PROCEDURE sp_Servicio_Crear;
GO
CREATE PROCEDURE sp_Servicio_Crear
    @Nombre VARCHAR(100),
    @Descripcion VARCHAR(250) = NULL,
    @Costo DECIMAL(10,2)
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Validar que el nombre no esté vacío
    IF @Nombre IS NULL OR LEN(LTRIM(RTRIM(@Nombre))) = 0
    BEGIN
        RAISERROR('El nombre del servicio es requerido.', 16, 1);
        RETURN;
    END
    
    -- Validar que el costo sea positivo
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

-- Actualizar servicio
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
    
    -- Validar que el servicio exista
    IF NOT EXISTS (SELECT 1 FROM Servicio WHERE ID_Servicio = @ID_Servicio)
    BEGIN
        RAISERROR('El servicio no existe.', 16, 1);
        RETURN;
    END
    
    -- Validar que el nombre no esté vacío
    IF @Nombre IS NULL OR LEN(LTRIM(RTRIM(@Nombre))) = 0
    BEGIN
        RAISERROR('El nombre del servicio es requerido.', 16, 1);
        RETURN;
    END
    
    -- Validar que el costo sea positivo
    IF @Costo < 0
    BEGIN
        RAISERROR('El costo debe ser mayor o igual a 0.', 16, 1);
        RETURN;
    END
    
    UPDATE Servicio
    SET Nombre = @Nombre,
        Descripcion = @Descripcion,
        Costo = @Costo
    WHERE ID_Servicio = @ID_Servicio;
END
GO

-- Eliminar servicio
IF OBJECT_ID('sp_Servicio_Eliminar', 'P') IS NOT NULL DROP PROCEDURE sp_Servicio_Eliminar;
GO
CREATE PROCEDURE sp_Servicio_Eliminar
    @ID_Servicio INT
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Validar que el servicio exista
    IF NOT EXISTS (SELECT 1 FROM Servicio WHERE ID_Servicio = @ID_Servicio)
    BEGIN
        RAISERROR('El servicio no existe.', 16, 1);
        RETURN;
    END
    
    -- Validar que no esté siendo usado en citas
    IF EXISTS (SELECT 1 FROM Cita WHERE ID_Servicio = @ID_Servicio)
    BEGIN
        RAISERROR('No se puede eliminar el servicio porque está siendo usado en citas.', 16, 1);
        RETURN;
    END
    
    -- Validar que no esté siendo usado en facturas
    IF EXISTS (SELECT 1 FROM FacturaDetalle WHERE ID_Servicio = @ID_Servicio)
    BEGIN
        RAISERROR('No se puede eliminar el servicio porque está siendo usado en facturas.', 16, 1);
        RETURN;
    END
    
    DELETE FROM Servicio WHERE ID_Servicio = @ID_Servicio;
END
GO

PRINT 'SPs para [Servicio] creados.';
GO

-- ==========================================================
-- STORED PROCEDURES PARA VETERINARIO
-- ==========================================================
PRINT '--- Creando SPs para [Veterinario] ---';

-- Listar veterinarios activos
IF OBJECT_ID('sp_Veterinario_ListarActivos', 'P') IS NOT NULL DROP PROCEDURE sp_Veterinario_ListarActivos;
GO
CREATE PROCEDURE sp_Veterinario_ListarActivos
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        ID_Veterinario,
        Nombre,
        Especialidad,
        Telefono,
        Correo,
        Activo
    FROM Veterinario
    WHERE Activo = 1
    ORDER BY Nombre;
END
GO

-- Buscar veterinario por ID
IF OBJECT_ID('sp_Veterinario_BuscarPorID', 'P') IS NOT NULL DROP PROCEDURE sp_Veterinario_BuscarPorID;
GO
CREATE PROCEDURE sp_Veterinario_BuscarPorID
    @ID_Veterinario INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        ID_Veterinario,
        Nombre,
        Especialidad,
        Telefono,
        Correo,
        Activo
    FROM Veterinario
    WHERE ID_Veterinario = @ID_Veterinario;
END
GO

PRINT 'SPs para [Veterinario] creados.';
GO

-- ==========================================================
-- ASIGNACIÓN DE PERMISOS
-- ==========================================================
PRINT '--- Asignando permisos a los nuevos SPs ---';

-- Permisos para Servicio
GRANT EXECUTE ON sp_Servicio_Listar TO rol_api_ejecutor;
GRANT EXECUTE ON sp_Servicio_BuscarPorID TO rol_api_ejecutor;
GRANT EXECUTE ON sp_Servicio_Crear TO rol_api_ejecutor;
GRANT EXECUTE ON sp_Servicio_Actualizar TO rol_api_ejecutor;
GRANT EXECUTE ON sp_Servicio_Eliminar TO rol_api_ejecutor;

-- Permisos para Veterinario
GRANT EXECUTE ON sp_Veterinario_ListarActivos TO rol_api_ejecutor;
GRANT EXECUTE ON sp_Veterinario_BuscarPorID TO rol_api_ejecutor;

PRINT 'Permisos asignados correctamente.';
GO

PRINT '*** SCRIPT DE SERVICIO Y VETERINARIO COMPLETADO ***';

