/*
==================================================================================
SCRIPT DE DIAGNÓSTICO PARA CONEXIÓN SQL SERVER
Este script te ayudará a encontrar el nombre correcto de tu servidor SQL
==================================================================================
*/

-- 1. Ver el nombre del servidor actual
SELECT 
    @@SERVERNAME AS NombreServidor,
    @@VERSION AS VersionSQL,
    SERVERPROPERTY('ServerName') AS NombreInstancia,
    SERVERPROPERTY('InstanceName') AS NombreInstanciaEspecifica,
    SERVERPROPERTY('MachineName') AS NombreMaquina;

-- 2. Ver todas las instancias disponibles
EXEC xp_regread 
    'HKEY_LOCAL_MACHINE',
    'SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL',
    'MSSQLSERVER';

-- 3. Verificar si la base de datos existe
USE master;
GO

IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'VeterinariaGenesisDB')
    PRINT '✓ La base de datos VeterinariaGenesisDB EXISTE';
ELSE
    PRINT '✗ La base de datos VeterinariaGenesisDB NO EXISTE';

-- 4. Verificar si el login existe
IF EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'api_veterinaria_login')
    PRINT '✓ El login api_veterinaria_login EXISTE';
ELSE
    PRINT '✗ El login api_veterinaria_login NO EXISTE';

-- 5. Probar conexión con diferentes formatos
-- Copia estos valores para usar en tu appsettings.json

PRINT '';
PRINT '=== OPCIONES DE CADENA DE CONEXIÓN ===';
PRINT '';
PRINT 'Opción 1 (localhost):';
PRINT 'Server=localhost;Database=VeterinariaGenesisDB;User Id=api_veterinaria_login;Password=Api.Pass.Vet2025!;TrustServerCertificate=True;';
PRINT '';
PRINT 'Opción 2 (localhost con instancia por defecto):';
PRINT 'Server=localhost\\MSSQLSERVER;Database=VeterinariaGenesisDB;User Id=api_veterinaria_login;Password=Api.Pass.Vet2025!;TrustServerCertificate=True;';
PRINT '';
PRINT 'Opción 3 (localhost con SQLEXPRESS):';
PRINT 'Server=localhost\\SQLEXPRESS;Database=VeterinariaGenesisDB;User Id=api_veterinaria_login;Password=Api.Pass.Vet2025!;TrustServerCertificate=True;';
PRINT '';
PRINT 'Opción 4 (127.0.0.1):';
PRINT 'Server=127.0.0.1;Database=VeterinariaGenesisDB;User Id=api_veterinaria_login;Password=Api.Pass.Vet2025!;TrustServerCertificate=True;';
PRINT '';
PRINT 'Opción 5 (nombre de máquina - usa el resultado de @@SERVERNAME):';
PRINT 'Server=' + @@SERVERNAME + ';Database=VeterinariaGenesisDB;User Id=api_veterinaria_login;Password=Api.Pass.Vet2025!;TrustServerCertificate=True;';
GO

