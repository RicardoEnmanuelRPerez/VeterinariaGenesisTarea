-- Script de corrección para el login de la API
-- CORRIGE los errores 4064 y 4060 SIN duplicar lógica del script principal
-- Ejecuta este script SOLO si tienes problemas de conexión
-- El script principal (SP,Trigger,users-Veterinaria.sql) ya crea todo lo necesario

USE master;
GO

PRINT '========================================';
PRINT 'Corrigiendo login de la API';
PRINT '========================================';
PRINT 'NOTA: Este script solo corrige la configuración del login.';
PRINT 'El script principal ya crea el usuario y roles.';
PRINT '';

-- Verificar que la base de datos existe
IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = 'VeterinariaGenesisDB')
BEGIN
    PRINT 'ERROR: La base de datos VeterinariaGenesisDB NO EXISTE.';
    RETURN;
END

-- Solo modificar la base de datos por defecto del login para corregir error 4064
IF EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'api_veterinaria_login')
BEGIN
    DECLARE @CurrentDefaultDB sysname;
    SELECT @CurrentDefaultDB = default_database_name 
    FROM sys.server_principals 
    WHERE name = 'api_veterinaria_login';
    
    -- Si la base de datos por defecto no es master, cambiarla para evitar error 4064
    IF @CurrentDefaultDB IS NULL OR @CurrentDefaultDB != 'master'
    BEGIN
        PRINT 'Corrigiendo base de datos por defecto del login a master...';
        ALTER LOGIN api_veterinaria_login WITH DEFAULT_DATABASE = master;
        PRINT 'Base de datos por defecto corregida.';
    END
    ELSE
    BEGIN
        PRINT 'La base de datos por defecto ya está configurada correctamente.';
    END
END
ELSE
BEGIN
    PRINT 'ERROR: El login api_veterinaria_login NO EXISTE.';
    PRINT 'Ejecuta primero el script principal SP,Trigger,users-Veterinaria.sql';
    RETURN;
END
GO

-- Asegurar que el usuario puede conectarse a VeterinariaGenesisDB
USE VeterinariaGenesisDB;
GO

IF EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'api_veterinaria_user')
BEGIN
    -- Solo otorgar CONNECT si no lo tiene (el script principal no lo otorga explícitamente)
    IF NOT EXISTS (SELECT 1 FROM sys.database_permissions 
                   WHERE grantee_principal_id = USER_ID('api_veterinaria_user') 
                   AND permission_name = 'CONNECT')
    BEGIN
        GRANT CONNECT TO api_veterinaria_user;
        PRINT 'Permiso CONNECT otorgado en VeterinariaGenesisDB.';
    END
    ELSE
    BEGIN
        PRINT 'El usuario ya tiene permiso CONNECT.';
    END
END
ELSE
BEGIN
    PRINT 'ADVERTENCIA: El usuario api_veterinaria_user NO EXISTE en VeterinariaGenesisDB.';
    PRINT 'Ejecuta primero el script principal SP,Trigger,users-Veterinaria.sql';
END
GO

PRINT '';
PRINT '========================================';
PRINT 'Corrección completada';
PRINT '========================================';
PRINT 'Este script solo corrige la configuración del login.';
PRINT 'Todos los permisos se gestionan desde SP,Trigger,users-Veterinaria.sql';
GO

