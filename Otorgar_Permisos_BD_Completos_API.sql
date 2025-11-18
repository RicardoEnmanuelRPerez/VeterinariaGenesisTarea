/*
==================================================================================
SCRIPT PARA OTORGAR PERMISOS COMPLETOS SOLO A NIVEL DE BASE DE DATOS
Este script otorga permisos completos SOLO sobre VeterinariaGenesisDB
(Sin permisos de servidor - MÁS SEGURO)
==================================================================================
*/

USE VeterinariaGenesisDB;
GO

PRINT '--- Otorgando permisos completos de BASE DE DATOS a api_veterinaria_user ---';

-- Verificar que el usuario existe
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'api_veterinaria_user')
BEGIN
    PRINT 'ERROR: El usuario [api_veterinaria_user] no existe.';
    PRINT 'Por favor, ejecuta primero el script SP,Trigger,users-Veterinaria.sql';
    RETURN;
END
GO

-- Agregar al rol db_owner (Control total sobre la base de datos)
-- Esto le permite hacer TODO en VeterinariaGenesisDB pero NO en otras bases de datos
IF IS_ROLEMEMBER('db_owner', 'api_veterinaria_user') = 0
BEGIN
    ALTER ROLE db_owner ADD MEMBER api_veterinaria_user;
    PRINT 'Usuario [api_veterinaria_user] agregado al rol DB_OWNER.';
END
ELSE
    PRINT 'Usuario [api_veterinaria_user] ya es miembro de DB_OWNER.';
GO

-- Otorgar permisos explícitos adicionales (por si acaso)
GRANT CONTROL ON DATABASE::VeterinariaGenesisDB TO api_veterinaria_user;
PRINT 'Permiso CONTROL otorgado sobre la base de datos.';
GO

-- Verificar permisos otorgados
PRINT '';
PRINT '--- Verificación de Permisos ---';
PRINT 'Usuario: api_veterinaria_user';
PRINT 'Base de datos: VeterinariaGenesisDB';
PRINT '';
PRINT 'Permisos otorgados:';
PRINT '  - DB_OWNER (Control total de VeterinariaGenesisDB)';
PRINT '  - CONTROL (Permiso completo sobre la base de datos)';
PRINT '';
PRINT 'El usuario ahora tiene permisos completos sobre VeterinariaGenesisDB.';
PRINT '(Sin permisos de servidor - más seguro)';
GO

