/*
==================================================================================
SCRIPT 12: USUARIOS Y PERMISOS - VeterinariaGenesisDB
==================================================================================
Este script crea el login/usuario de la API y asigna todos los permisos.
EJECUTAR DESPUÉS DE 11_Vistas.sql
==================================================================================
*/

USE VeterinariaGenesisDB;
GO

PRINT '--- Creando Login y Usuario para la API ---';
GO

USE master;
GO

-- Login a nivel de Servidor
IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'api_veterinaria_login')
BEGIN
    CREATE LOGIN api_veterinaria_login 
    WITH PASSWORD = 'Api.Pass.Vet2025!', 
    CHECK_POLICY = ON;
    PRINT 'Login [api_veterinaria_login] Creado.';
END
ELSE
    PRINT 'Login [api_veterinaria_login] ya existe.';
GO

USE VeterinariaGenesisDB;
GO

-- Usuario a nivel de Base de Datos
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'api_veterinaria_user')
BEGIN
    CREATE USER api_veterinaria_user FOR LOGIN api_veterinaria_login;
    PRINT 'Usuario [api_veterinaria_user] Creado.';
END
ELSE
    PRINT 'Usuario [api_veterinaria_user] ya existe.';
GO

-- Rol a nivel de Base de Datos
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'rol_api_ejecutor' AND type = 'R')
BEGIN
    CREATE ROLE rol_api_ejecutor;
    PRINT 'Rol [rol_api_ejecutor] Creado.';
END
ELSE
    PRINT 'Rol [rol_api_ejecutor] ya existe.';
GO

-- Asignar el Usuario al Rol
EXEC sp_addrolemember 'rol_api_ejecutor', 'api_veterinaria_user';
PRINT 'Usuario [api_veterinaria_user] asignado a [rol_api_ejecutor].';
GO

-- ====================================================
-- INSERTAR ROLES Y USUARIOS DE EJEMPLO
-- ====================================================
PRINT '--- Insertando Roles y Usuarios de Ejemplo ---';
GO

IF NOT EXISTS (SELECT 1 FROM Roles WHERE NombreRol = 'Administrador')
    INSERT INTO Roles (NombreRol) VALUES ('Administrador');
IF NOT EXISTS (SELECT 1 FROM Roles WHERE NombreRol = 'Veterinario')
    INSERT INTO Roles (NombreRol) VALUES ('Veterinario');
IF NOT EXISTS (SELECT 1 FROM Roles WHERE NombreRol = 'Recepcionista')
    INSERT INTO Roles (NombreRol) VALUES ('Recepcionista');
GO

DECLARE @AdminRol INT = (SELECT ID_Rol FROM Roles WHERE NombreRol = 'Administrador');
DECLARE @VetRol INT = (SELECT ID_Rol FROM Roles WHERE NombreRol = 'Veterinario');
DECLARE @RecRol INT = (SELECT ID_Rol FROM Roles WHERE NombreRol = 'Recepcionista');

IF NOT EXISTS (SELECT 1 FROM Usuario WHERE NombreLogin = 'admin')
    INSERT INTO Usuario (NombreLogin, ContrasenaHash, NombreCompleto, ID_Rol, Activo)
    VALUES ('admin', HASHBYTES('SHA2_256', 'P@ssw0rd123'), 'Administrador del Sistema', @AdminRol, 1);

IF NOT EXISTS (SELECT 1 FROM Usuario WHERE NombreLogin = 'asolis')
    INSERT INTO Usuario (NombreLogin, ContrasenaHash, NombreCompleto, ID_Rol, ID_Veterinario, Activo)
    VALUES ('asolis', HASHBYTES('SHA2_256', 'P@ssw0rd123'), 'Dr. Alejandro Solas', @VetRol, 1, 1);

IF NOT EXISTS (SELECT 1 FROM Usuario WHERE NombreLogin = 'bpena')
    INSERT INTO Usuario (NombreLogin, ContrasenaHash, NombreCompleto, ID_Rol, ID_Veterinario, Activo)
    VALUES ('bpena', HASHBYTES('SHA2_256', 'P@ssw0rd123'), 'Dra. Beatriz Pena', @VetRol, 2, 1);

IF NOT EXISTS (SELECT 1 FROM Usuario WHERE NombreLogin = 'r.gomez')
    INSERT INTO Usuario (NombreLogin, ContrasenaHash, NombreCompleto, ID_Rol, Activo)
    VALUES ('r.gomez', HASHBYTES('SHA2_256', 'P@ssw0rd123'), 'Raquel Gomez (Recepcion)', @RecRol, 1);

IF NOT EXISTS (SELECT 1 FROM Usuario WHERE NombreLogin = 'j.perez')
    INSERT INTO Usuario (NombreLogin, ContrasenaHash, NombreCompleto, ID_Rol, Activo)
    VALUES ('j.perez', HASHBYTES('SHA2_256', 'P@ssw0rd123'), 'Javier Perez (Recepcion)', @RecRol, 1);
GO

PRINT '5 usuarios de ejemplo creados.';
GO

-- ====================================================
-- OTORGAR PERMISOS DE EJECUCIÓN A TODOS LOS SPs
-- ====================================================
PRINT '--- Otorgando permisos de ejecución a los SPs ---';
GO

-- SPs de Usuario
IF OBJECT_ID('sp_Usuario_Login', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Usuario_Login TO rol_api_ejecutor;

-- SPs de Propietario
IF OBJECT_ID('sp_Propietario_Crear', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Propietario_Crear TO rol_api_ejecutor;
IF OBJECT_ID('sp_Propietario_Actualizar', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Propietario_Actualizar TO rol_api_ejecutor;
IF OBJECT_ID('sp_Propietario_Desactivar', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Propietario_Desactivar TO rol_api_ejecutor;
IF OBJECT_ID('sp_Propietario_ListarActivos', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Propietario_ListarActivos TO rol_api_ejecutor;
IF OBJECT_ID('sp_Propietario_BuscarPorID', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Propietario_BuscarPorID TO rol_api_ejecutor;

-- SPs de Mascota
IF OBJECT_ID('sp_Mascota_Crear', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Mascota_Crear TO rol_api_ejecutor;
IF OBJECT_ID('sp_Mascota_Actualizar', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Mascota_Actualizar TO rol_api_ejecutor;
IF OBJECT_ID('sp_Mascota_ListarPorPropietario', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Mascota_ListarPorPropietario TO rol_api_ejecutor;
IF OBJECT_ID('sp_Mascota_BuscarPorID', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Mascota_BuscarPorID TO rol_api_ejecutor;
IF OBJECT_ID('sp_Mascota_BuscarParaHistorial', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Mascota_BuscarParaHistorial TO rol_api_ejecutor;

-- SPs de Cita
IF OBJECT_ID('sp_Cita_Agendar', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Cita_Agendar TO rol_api_ejecutor;
IF OBJECT_ID('sp_Cita_Actualizar', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Cita_Actualizar TO rol_api_ejecutor;
IF OBJECT_ID('sp_Cita_Cancelar', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Cita_Cancelar TO rol_api_ejecutor;
IF OBJECT_ID('sp_Cita_ListarPorFecha', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Cita_ListarPorFecha TO rol_api_ejecutor;
IF OBJECT_ID('sp_Cita_ListarPorVeterinario', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Cita_ListarPorVeterinario TO rol_api_ejecutor;
IF OBJECT_ID('sp_Cita_ListarCompletadasSinFactura', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Cita_ListarCompletadasSinFactura TO rol_api_ejecutor;

-- SPs de Factura
IF OBJECT_ID('sp_Factura_CrearDesdeCita', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Factura_CrearDesdeCita TO rol_api_ejecutor;
IF OBJECT_ID('sp_Factura_AgregarItem', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Factura_AgregarItem TO rol_api_ejecutor;
IF OBJECT_ID('sp_Factura_Pagar', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Factura_Pagar TO rol_api_ejecutor;
IF OBJECT_ID('sp_Factura_BuscarPorID', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Factura_BuscarPorID TO rol_api_ejecutor;
IF OBJECT_ID('sp_Factura_Listar', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Factura_Listar TO rol_api_ejecutor;
IF OBJECT_ID('sp_Factura_DetallesPorID', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Factura_DetallesPorID TO rol_api_ejecutor;

-- SPs de Historial
IF OBJECT_ID('sp_Historial_ObtenerPorMascota', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Historial_ObtenerPorMascota TO rol_api_ejecutor;
IF OBJECT_ID('sp_Historial_AgregarTratamiento', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Historial_AgregarTratamiento TO rol_api_ejecutor;
IF OBJECT_ID('sp_Historial_AgregarVacuna', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Historial_AgregarVacuna TO rol_api_ejecutor;

-- SPs de Dashboard
IF OBJECT_ID('sp_Dashboard_CirugiasPorVeterinario', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Dashboard_CirugiasPorVeterinario TO rol_api_ejecutor;
IF OBJECT_ID('sp_Dashboard_CitasPorDiaSemana', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Dashboard_CitasPorDiaSemana TO rol_api_ejecutor;
IF OBJECT_ID('sp_Dashboard_ProductividadVeterinario', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Dashboard_ProductividadVeterinario TO rol_api_ejecutor;

-- SPs de Vacunas
IF OBJECT_ID('sp_Vacuna_Recordatorios', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Vacuna_Recordatorios TO rol_api_ejecutor;

-- SPs de Reportes
IF OBJECT_ID('sp_Reporte_Propietarios', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Reporte_Propietarios TO rol_api_ejecutor;
IF OBJECT_ID('sp_Reporte_ServiciosVendidos', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Reporte_ServiciosVendidos TO rol_api_ejecutor;
IF OBJECT_ID('sp_Reporte_CitasPorVeterinario', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Reporte_CitasPorVeterinario TO rol_api_ejecutor;
IF OBJECT_ID('sp_Reporte_IngresosPorPeriodo', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Reporte_IngresosPorPeriodo TO rol_api_ejecutor;

-- SPs de Servicios
IF OBJECT_ID('sp_Servicio_Listar', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Servicio_Listar TO rol_api_ejecutor;
IF OBJECT_ID('sp_Servicio_BuscarPorID', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Servicio_BuscarPorID TO rol_api_ejecutor;
IF OBJECT_ID('sp_Servicio_Crear', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Servicio_Crear TO rol_api_ejecutor;
IF OBJECT_ID('sp_Servicio_Actualizar', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Servicio_Actualizar TO rol_api_ejecutor;
IF OBJECT_ID('sp_Servicio_Eliminar', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Servicio_Eliminar TO rol_api_ejecutor;

-- SPs de Veterinario
IF OBJECT_ID('sp_Veterinario_ListarActivos', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Veterinario_ListarActivos TO rol_api_ejecutor;
IF OBJECT_ID('sp_Veterinario_BuscarPorID', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Veterinario_BuscarPorID TO rol_api_ejecutor;
GO

-- ====================================================
-- OTORGAR PERMISOS DE LECTURA A LAS VISTAS
-- ====================================================
PRINT '--- Otorgando permisos de lectura a las Vistas ---';
GO

GRANT SELECT ON vw_PropietariosActivos TO rol_api_ejecutor;
GRANT SELECT ON vw_MascotasConPropietario TO rol_api_ejecutor;
GRANT SELECT ON vw_VeterinariosActivos TO rol_api_ejecutor;
GRANT SELECT ON vw_AgendaCitas TO rol_api_ejecutor;
GO

-- ====================================================
-- DENEGAR ACCESO DIRECTO A LAS TABLAS
-- ====================================================
PRINT '--- Denegando acceso directo a las tablas ---';
GO

DENY SELECT, INSERT, UPDATE, DELETE ON Propietario TO rol_api_ejecutor;
DENY SELECT, INSERT, UPDATE, DELETE ON Mascota TO rol_api_ejecutor;
DENY SELECT, INSERT, UPDATE, DELETE ON Veterinario TO rol_api_ejecutor;
DENY SELECT, INSERT, UPDATE, DELETE ON Cita TO rol_api_ejecutor;
DENY SELECT, INSERT, UPDATE, DELETE ON Factura TO rol_api_ejecutor;
DENY SELECT, INSERT, UPDATE, DELETE ON FacturaDetalle TO rol_api_ejecutor;
DENY SELECT, INSERT, UPDATE, DELETE ON Pago TO rol_api_ejecutor;
DENY SELECT, INSERT, UPDATE, DELETE ON Servicio TO rol_api_ejecutor;
DENY SELECT, INSERT, UPDATE, DELETE ON Tratamiento TO rol_api_ejecutor;
DENY SELECT, INSERT, UPDATE, DELETE ON Medicamento TO rol_api_ejecutor;
DENY SELECT, INSERT, UPDATE, DELETE ON Tratamiento_Medicamento TO rol_api_ejecutor;
DENY SELECT, INSERT, UPDATE, DELETE ON Vacuna TO rol_api_ejecutor;
DENY SELECT, INSERT, UPDATE, DELETE ON Mascota_Vacuna TO rol_api_ejecutor;
DENY SELECT, INSERT, UPDATE, DELETE ON Hospitalizacion TO rol_api_ejecutor;
DENY SELECT, INSERT, UPDATE, DELETE ON Cirugia TO rol_api_ejecutor;
DENY SELECT, INSERT, UPDATE, DELETE ON Usuario TO rol_api_ejecutor;
DENY SELECT, INSERT, UPDATE, DELETE ON Roles TO rol_api_ejecutor;
GO

PRINT '*** USUARIOS Y PERMISOS CONFIGURADOS EXITOSAMENTE ***';
GO

