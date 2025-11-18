/*
==================================================================================
SCRIPT COMPLETO PARA CONFIGURAR LOGIN, USUARIOS, ROLES Y TRIGGERS
Para iniciar sesión en la API VeterinariaGenesis
==================================================================================
Este script incluye:
1. Login y Usuario para la API
2. Tablas de Roles y Usuario
3. 5 Usuarios de ejemplo para login
4. Trigger de Facturación
5. Stored Procedure de Login
6. Permisos necesarios
==================================================================================
*/

USE VeterinariaGenesisDB;
GO

-- ==========================================================
-- 1. SEGURIDAD DE API (LOGIN Y USUARIO)
-- ==========================================================
PRINT '--- 1. Creando Login y Usuario para la API ---';

USE master;
GO

-- 1.1. Login a nivel de Servidor
IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'api_veterinaria_login')
BEGIN
    CREATE LOGIN api_veterinaria_login 
    WITH PASSWORD = 'Api.Pass.Vet2025!', 
    CHECK_POLICY = ON;
    PRINT '✓ Login [api_veterinaria_login] Creado.';
END
ELSE
    PRINT 'ℹ Login [api_veterinaria_login] ya existe.';
GO

USE VeterinariaGenesisDB;
GO

-- 1.2. Usuario a nivel de Base de Datos
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'api_veterinaria_user')
BEGIN
    CREATE USER api_veterinaria_user FOR LOGIN api_veterinaria_login;
    PRINT '✓ Usuario [api_veterinaria_user] Creado.';
END
ELSE
    PRINT 'ℹ Usuario [api_veterinaria_user] ya existe.';
GO

-- 1.3. Rol a nivel de Base de Datos
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'rol_api_ejecutor' AND type = 'R')
BEGIN
    CREATE ROLE rol_api_ejecutor;
    PRINT '✓ Rol [rol_api_ejecutor] Creado.';
END
ELSE
    PRINT 'ℹ Rol [rol_api_ejecutor] ya existe.';
GO

-- 1.4. Asignar el Usuario al Rol
IF NOT EXISTS (SELECT 1 FROM sys.database_role_members rm
               JOIN sys.database_principals dp ON rm.member_principal_id = dp.principal_id
               JOIN sys.database_principals r ON rm.role_principal_id = r.principal_id
               WHERE dp.name = 'api_veterinaria_user' AND r.name = 'rol_api_ejecutor')
BEGIN
    ALTER ROLE rol_api_ejecutor ADD MEMBER api_veterinaria_user;
    PRINT '✓ Usuario [api_veterinaria_user] asignado a [rol_api_ejecutor].';
END
ELSE
    PRINT 'ℹ Usuario [api_veterinaria_user] ya está en [rol_api_ejecutor].';
GO

-- ==========================================================
-- 2. TABLAS DE SEGURIDAD (ROLES Y USUARIO)
-- ==========================================================
PRINT '';
PRINT '--- 2. Creando Tablas de Empleados (Usuario y Roles) ---';

-- 2.1. Tabla Roles
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type in (N'U'))
BEGIN
    CREATE TABLE Roles (
        ID_Rol INT PRIMARY KEY IDENTITY(1,1),
        NombreRol VARCHAR(50) NOT NULL UNIQUE
    );
    PRINT '✓ Tabla [Roles] creada.';
END
ELSE
    PRINT 'ℹ Tabla [Roles] ya existe.';
GO

-- 2.2. Tabla Usuario
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuario]') AND type in (N'U'))
BEGIN
    CREATE TABLE Usuario (
        ID_Usuario INT PRIMARY KEY IDENTITY(1,1),
        NombreLogin VARCHAR(50) NOT NULL UNIQUE,
        ContrasenaHash VARBINARY(32) NOT NULL, -- SHA2_256 es 32 bytes
        NombreCompleto VARCHAR(200) NOT NULL,
        ID_Rol INT NOT NULL REFERENCES Roles(ID_Rol),
        ID_Veterinario INT NULL REFERENCES Veterinario(ID_Veterinario),
        Activo BIT NOT NULL DEFAULT 1
    );
    PRINT '✓ Tabla [Usuario] creada.';
END
ELSE
    PRINT 'ℹ Tabla [Usuario] ya existe.';
GO

-- ==========================================================
-- 3. DATOS DE EJEMPLO (ROLES Y USUARIOS PARA LOGIN)
-- ==========================================================
PRINT '';
PRINT '--- 3. Insertando Roles y Usuarios de Ejemplo ---';

-- 3.1. Insertar Roles
IF NOT EXISTS (SELECT 1 FROM Roles WHERE NombreRol = 'Administrador')
BEGIN
    INSERT INTO Roles (NombreRol) VALUES ('Administrador');
    PRINT '✓ Rol [Administrador] insertado.';
END
ELSE
    PRINT 'ℹ Rol [Administrador] ya existe.';

IF NOT EXISTS (SELECT 1 FROM Roles WHERE NombreRol = 'Veterinario')
BEGIN
    INSERT INTO Roles (NombreRol) VALUES ('Veterinario');
    PRINT '✓ Rol [Veterinario] insertado.';
END
ELSE
    PRINT 'ℹ Rol [Veterinario] ya existe.';

IF NOT EXISTS (SELECT 1 FROM Roles WHERE NombreRol = 'Recepcionista')
BEGIN
    INSERT INTO Roles (NombreRol) VALUES ('Recepcionista');
    PRINT '✓ Rol [Recepcionista] insertado.';
END
ELSE
    PRINT 'ℹ Rol [Recepcionista] ya existe.';
GO

-- 3.2. Insertar Usuarios (Contraseña para todos: 'P@ssw0rd123')
DECLARE @AdminRol INT = (SELECT ID_Rol FROM Roles WHERE NombreRol = 'Administrador');
DECLARE @VetRol INT = (SELECT ID_Rol FROM Roles WHERE NombreRol = 'Veterinario');
DECLARE @RecRol INT = (SELECT ID_Rol FROM Roles WHERE NombreRol = 'Recepcionista');

-- Usuario Administrador
IF NOT EXISTS (SELECT 1 FROM Usuario WHERE NombreLogin = 'admin')
BEGIN
    INSERT INTO Usuario (NombreLogin, ContrasenaHash, NombreCompleto, ID_Rol, Activo)
    VALUES ('admin', HASHBYTES('SHA2_256', 'P@ssw0rd123'), 'Administrador del Sistema', @AdminRol, 1);
    PRINT '✓ Usuario [admin] creado.';
END
ELSE
    PRINT 'ℹ Usuario [admin] ya existe.';

-- Usuario Veterinario 1 (asumiendo que existe Veterinario con ID=1)
IF NOT EXISTS (SELECT 1 FROM Usuario WHERE NombreLogin = 'asolis')
BEGIN
    IF EXISTS (SELECT 1 FROM Veterinario WHERE ID_Veterinario = 1)
    BEGIN
        INSERT INTO Usuario (NombreLogin, ContrasenaHash, NombreCompleto, ID_Rol, ID_Veterinario, Activo)
        VALUES ('asolis', HASHBYTES('SHA2_256', 'P@ssw0rd123'), 'Dr. Alejandro Solas', @VetRol, 1, 1);
        PRINT '✓ Usuario [asolis] creado.';
    END
    ELSE
        PRINT '⚠ Usuario [asolis] no creado: Veterinario ID=1 no existe.';
END
ELSE
    PRINT 'ℹ Usuario [asolis] ya existe.';

-- Usuario Veterinario 2 (asumiendo que existe Veterinario con ID=2)
IF NOT EXISTS (SELECT 1 FROM Usuario WHERE NombreLogin = 'bpena')
BEGIN
    IF EXISTS (SELECT 1 FROM Veterinario WHERE ID_Veterinario = 2)
    BEGIN
        INSERT INTO Usuario (NombreLogin, ContrasenaHash, NombreCompleto, ID_Rol, ID_Veterinario, Activo)
        VALUES ('bpena', HASHBYTES('SHA2_256', 'P@ssw0rd123'), 'Dra. Beatriz Pena', @VetRol, 2, 1);
        PRINT '✓ Usuario [bpena] creado.';
    END
    ELSE
        PRINT '⚠ Usuario [bpena] no creado: Veterinario ID=2 no existe.';
END
ELSE
    PRINT 'ℹ Usuario [bpena] ya existe.';

-- Usuario Recepcionista 1
IF NOT EXISTS (SELECT 1 FROM Usuario WHERE NombreLogin = 'r.gomez')
BEGIN
    INSERT INTO Usuario (NombreLogin, ContrasenaHash, NombreCompleto, ID_Rol, Activo)
    VALUES ('r.gomez', HASHBYTES('SHA2_256', 'P@ssw0rd123'), 'Raquel Gomez (Recepcion)', @RecRol, 1);
    PRINT '✓ Usuario [r.gomez] creado.';
END
ELSE
    PRINT 'ℹ Usuario [r.gomez] ya existe.';

-- Usuario Recepcionista 2
IF NOT EXISTS (SELECT 1 FROM Usuario WHERE NombreLogin = 'j.perez')
BEGIN
    INSERT INTO Usuario (NombreLogin, ContrasenaHash, NombreCompleto, ID_Rol, Activo)
    VALUES ('j.perez', HASHBYTES('SHA2_256', 'P@ssw0rd123'), 'Javier Perez (Recepcion)', @RecRol, 1);
    PRINT '✓ Usuario [j.perez] creado.';
END
ELSE
    PRINT 'ℹ Usuario [j.perez] ya existe.';
GO

PRINT '';
PRINT '✓ Usuarios de ejemplo creados.';
PRINT '  Credenciales de prueba:';
PRINT '  - admin / P@ssw0rd123 (Administrador)';
PRINT '  - asolis / P@ssw0rd123 (Veterinario)';
PRINT '  - bpena / P@ssw0rd123 (Veterinario)';
PRINT '  - r.gomez / P@ssw0rd123 (Recepcionista)';
PRINT '  - j.perez / P@ssw0rd123 (Recepcionista)';
GO

-- ==========================================================
-- 4. TRIGGER DE FACTURACIÓN
-- ==========================================================
PRINT '';
PRINT '--- 4. Creando Trigger de Facturación ---';

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
PRINT '✓ Trigger [tr_ActualizarTotalFactura] creado.';
GO

-- ==========================================================
-- 5. STORED PROCEDURE DE LOGIN
-- ==========================================================
PRINT '';
PRINT '--- 5. Creando Stored Procedure de Login ---';

IF OBJECT_ID('sp_Usuario_Login', 'P') IS NOT NULL 
    DROP PROCEDURE sp_Usuario_Login;
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
PRINT '✓ Stored Procedure [sp_Usuario_Login] creado.';
GO

-- ==========================================================
-- 6. PERMISOS PARA EL LOGIN
-- ==========================================================
PRINT '';
PRINT '--- 6. Asignando Permisos para Login ---';

-- Otorgar permiso de ejecución al SP de Login
GRANT EXECUTE ON sp_Usuario_Login TO rol_api_ejecutor;
PRINT '✓ Permiso EXECUTE otorgado a [sp_Usuario_Login].';
GO

-- ==========================================================
-- 7. VERIFICACIÓN FINAL
-- ==========================================================
PRINT '';
PRINT '--- 7. Verificación Final ---';

-- Verificar Login
IF EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'api_veterinaria_login')
    PRINT '✓ Login [api_veterinaria_login] existe.';
ELSE
    PRINT '✗ ERROR: Login [api_veterinaria_login] NO existe.';

-- Verificar Usuario
IF EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'api_veterinaria_user')
    PRINT '✓ Usuario [api_veterinaria_user] existe.';
ELSE
    PRINT '✗ ERROR: Usuario [api_veterinaria_user] NO existe.';

-- Verificar SP de Login
IF EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID('sp_Usuario_Login') AND type = 'P')
    PRINT '✓ Stored Procedure [sp_Usuario_Login] existe.';
ELSE
    PRINT '✗ ERROR: Stored Procedure [sp_Usuario_Login] NO existe.';

-- Verificar Usuarios creados
DECLARE @CantidadUsuarios INT = (SELECT COUNT(*) FROM Usuario);
PRINT '✓ Total de usuarios en la tabla: ' + CAST(@CantidadUsuarios AS VARCHAR(10));

-- Verificar Roles creados
DECLARE @CantidadRoles INT = (SELECT COUNT(*) FROM Roles);
PRINT '✓ Total de roles en la tabla: ' + CAST(@CantidadRoles AS VARCHAR(10));

PRINT '';
PRINT '==================================================================================';
PRINT '*** SCRIPT COMPLETADO ***';
PRINT '==================================================================================';
PRINT '';
PRINT 'Ahora puedes iniciar sesión en tu API con:';
PRINT '  Usuario: admin';
PRINT '  Contraseña: P@ssw0rd123';
PRINT '';
PRINT 'Cadena de conexión para appsettings.json:';
PRINT 'Server=PC-1\\SQLEXPRES;Database=VeterinariaGenesisDB;User Id=api_veterinaria_login;Password=Api.Pass.Vet2025!;TrustServerCertificate=True;';
PRINT '';
GO

