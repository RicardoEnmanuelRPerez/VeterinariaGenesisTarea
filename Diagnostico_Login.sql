-- Script de diagnóstico para el login de la API
-- Ejecuta este script como administrador para identificar problemas

USE VeterinariaGenesisDB;
GO

PRINT '========================================';
PRINT 'DIAGNÓSTICO DEL LOGIN DE LA API';
PRINT '========================================';
PRINT '';

-- 1. Verificar que el stored procedure existe
PRINT '1. Verificando stored procedure sp_Usuario_Login...';
IF EXISTS (SELECT 1 FROM sys.procedures WHERE name = 'sp_Usuario_Login')
BEGIN
    PRINT '✓ El stored procedure sp_Usuario_Login EXISTE.';
END
ELSE
BEGIN
    PRINT '✗ ERROR: El stored procedure sp_Usuario_Login NO EXISTE.';
    PRINT '  Ejecuta el script SP,Trigger,users-Veterinaria.sql';
END
GO

-- 2. Verificar permisos del usuario en el SP
PRINT '';
PRINT '2. Verificando permisos del usuario en sp_Usuario_Login...';
IF EXISTS (SELECT 1 FROM sys.database_permissions 
           WHERE grantee_principal_id = USER_ID('api_veterinaria_user')
           AND object_name(major_id) = 'sp_Usuario_Login'
           AND permission_name = 'EXECUTE')
BEGIN
    PRINT '✓ El usuario api_veterinaria_user tiene permiso EXECUTE en sp_Usuario_Login.';
END
ELSE
BEGIN
    PRINT '✗ ERROR: El usuario api_veterinaria_user NO tiene permiso EXECUTE.';
    PRINT '  Ejecuta: GRANT EXECUTE ON sp_Usuario_Login TO rol_api_ejecutor;';
END
GO

-- 3. Verificar que las tablas Usuario y Roles existen
PRINT '';
PRINT '3. Verificando tablas Usuario y Roles...';
IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Usuario')
    AND EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Roles')
BEGIN
    PRINT '✓ Las tablas Usuario y Roles EXISTEN.';
    
    -- Contar usuarios
    DECLARE @UsuarioCount INT;
    SELECT @UsuarioCount = COUNT(*) FROM Usuario WHERE Activo = 1;
    PRINT '  Usuarios activos en la tabla: ' + CAST(@UsuarioCount AS VARCHAR(10));
    
    IF @UsuarioCount = 0
    BEGIN
        PRINT '  ⚠ ADVERTENCIA: No hay usuarios activos en la tabla Usuario.';
        PRINT '    Los usuarios de ejemplo deben crearse con el script principal.';
    END
END
ELSE
BEGIN
    PRINT '✗ ERROR: Las tablas Usuario o Roles NO EXISTEN.';
    PRINT '  Ejecuta el script SP,Trigger,users-Veterinaria.sql';
END
GO

-- 4. Verificar que el usuario tiene permiso CONNECT
PRINT '';
PRINT '4. Verificando permiso CONNECT...';
IF EXISTS (SELECT 1 FROM sys.database_permissions 
           WHERE grantee_principal_id = USER_ID('api_veterinaria_user')
           AND permission_name = 'CONNECT')
BEGIN
    PRINT '✓ El usuario tiene permiso CONNECT.';
END
ELSE
BEGIN
    PRINT '✗ ERROR: El usuario NO tiene permiso CONNECT.';
    PRINT '  Ejecuta: GRANT CONNECT TO api_veterinaria_user;';
END
GO

-- 5. Verificar que el usuario está en el rol
PRINT '';
PRINT '5. Verificando rol rol_api_ejecutor...';
IF EXISTS (SELECT 1 FROM sys.database_role_members 
           WHERE role_principal_id = (SELECT principal_id FROM sys.database_principals WHERE name = 'rol_api_ejecutor')
           AND member_principal_id = (SELECT principal_id FROM sys.database_principals WHERE name = 'api_veterinaria_user'))
BEGIN
    PRINT '✓ El usuario está en el rol rol_api_ejecutor.';
END
ELSE
BEGIN
    PRINT '✗ ERROR: El usuario NO está en el rol rol_api_ejecutor.';
    PRINT '  Ejecuta: ALTER ROLE rol_api_ejecutor ADD MEMBER api_veterinaria_user;';
END
GO

-- 6. Listar usuarios de ejemplo si existen
PRINT '';
PRINT '6. Usuarios de ejemplo disponibles para login:';
SELECT 
    NombreLogin,
    NombreCompleto,
    (SELECT NombreRol FROM Roles WHERE ID_Rol = U.ID_Rol) AS Rol,
    CASE WHEN Activo = 1 THEN 'Activo' ELSE 'Inactivo' END AS Estado
FROM Usuario U
ORDER BY NombreLogin;

PRINT '';
PRINT '========================================';
PRINT 'FIN DEL DIAGNÓSTICO';
PRINT '========================================';
PRINT '';
PRINT 'NOTA: Para hacer login, usa uno de los usuarios listados arriba.';
PRINT 'La contraseña por defecto es: P@ssw0rd123';
PRINT '';

