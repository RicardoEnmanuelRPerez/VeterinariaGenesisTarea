/*
==================================================================================
SCRIPT PARA OTORGAR PERMISOS COMPLETOS A api_veterinaria_login
Este script otorga permisos equivalentes a 'sa' (System Administrator)
==================================================================================
ADVERTENCIA: Esto otorga permisos completos. Úsalo solo en desarrollo o si realmente
necesitas que la API tenga control total sobre la base de datos.
==================================================================================
*/

USE master;
GO

PRINT '--- Otorgando permisos de SYSADMIN a api_veterinaria_login ---';

-- Verificar que el login existe
IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'api_veterinaria_login')
BEGIN
    PRINT 'ERROR: El login [api_veterinaria_login] no existe.';
    PRINT 'Por favor, ejecuta primero el script SP,Trigger,users-Veterinaria.sql';
    RETURN;
END
GO

-- Opción 1: Agregar al rol sysadmin (EQUIVALENTE A SA)
-- Esto le da control total sobre TODO el servidor SQL
ALTER SERVER ROLE sysadmin ADD MEMBER api_veterinaria_login;
PRINT 'Login [api_veterinaria_login] agregado al rol SYSADMIN (permisos completos de servidor).';
GO

USE VeterinariaGenesisDB;
GO

-- Opción 2: Agregar al rol db_owner (Control total sobre la base de datos)
-- Esto le da control total sobre la base de datos VeterinariaGenesisDB
ALTER ROLE db_owner ADD MEMBER api_veterinaria_user;
PRINT 'Usuario [api_veterinaria_user] agregado al rol DB_OWNER (permisos completos de base de datos).';
GO

-- Verificar permisos otorgados
PRINT '';
PRINT '--- Verificación de Permisos ---';
PRINT 'Login: api_veterinaria_login';
PRINT 'Usuario: api_veterinaria_user';
PRINT '';
PRINT 'Permisos otorgados:';
PRINT '  - SYSADMIN (Control total del servidor SQL)';
PRINT '  - DB_OWNER (Control total de VeterinariaGenesisDB)';
PRINT '';
PRINT 'El usuario ahora tiene permisos equivalentes a SA.';
GO

