/*
==================================================================================
SCRIPT DE L�GICA Y SEGURIDAD PARA VeterinariaGenesisDB
QU� HACE ESTE SCRIPT:
1.  Crea el Login y Usuario de BAJOS PRIVILEGIOS para la API ('api_veterinaria_login').
2.  Crea las tablas 'Roles' y 'Usuario' para TUS EMPLEADOS.
3.  Inserta 5 empleados de ejemplo (1 Admin, 2 Vets, 2 Recepcionistas).
4.  Crea el Trigger para recalcular el Total de las facturas autom�ticamente.
5.  Crea Vistas (Views) para facilitar las consultas de lectura.
6.  Crea un conjunto COMPLETO de Stored Procedures (SPs) para todo el CRUD.
7.  Aplica los permisos de seguridad (DCL) para que la API SOLO pueda usar los SPs.
==================================================================================
*/

USE VeterinariaGenesisDB;
GO

-- ==========================================================
-- 1. SEGURIDAD DE API (EL "CONECTOR")
-- ==========================================================
PRINT '--- 1. Creando Login y Usuario para la API ---';

USE master;
GO
-- 1.1. Login a nivel de Servidor (La llave de la API)
IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'api_veterinaria_login')
BEGIN
    -- �DEBES USAR ESTA CONTRASE�A EN TU CADENA DE CONEXI�N DE LA API!
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

-- 1.2. Usuario a nivel de Base de Datos (El usuario "tonto")
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'api_veterinaria_user')
BEGIN
    CREATE USER api_veterinaria_user FOR LOGIN api_veterinaria_login;
    PRINT 'Usuario [api_veterinaria_user] Creado.';
END
ELSE
    PRINT 'Usuario [api_veterinaria_user] ya existe.';
GO

-- 1.3. Rol a nivel de Base de Datos (El grupo de permisos de la API)
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'rol_api_ejecutor' AND type = 'R')
BEGIN
    CREATE ROLE rol_api_ejecutor;
    PRINT 'Rol [rol_api_ejecutor] Creado.';
END
ELSE
    PRINT 'Rol [rol_api_ejecutor] ya existe.';
GO

-- 1.4. Asignar el Usuario al Rol
EXEC sp_addrolemember 'rol_api_ejecutor', 'api_veterinaria_user';
PRINT 'Usuario [api_veterinaria_user] asignado a [rol_api_ejecutor].';
GO

-- ==========================================================
-- 2. TABLAS DE SEGURIDAD DE APLICACI�N (LOS "EMPLEADOS")
-- ==========================================================
PRINT '--- 2. Creando Tablas de Empleados (Usuario y Roles) ---';

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type in (N'U'))
BEGIN
    CREATE TABLE Roles (
        ID_Rol INT PRIMARY KEY IDENTITY(1,1),
        NombreRol VARCHAR(50) NOT NULL UNIQUE
    );
    PRINT 'Tabla [Roles] creada.';
END
ELSE
    PRINT 'Tabla [Roles] ya existe.';
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuario]') AND type in (N'U'))
BEGIN
    CREATE TABLE Usuario (
        ID_Usuario INT PRIMARY KEY IDENTITY(1,1),
        NombreLogin VARCHAR(50) NOT NULL UNIQUE,
        ContrasenaHash VARBINARY(32) NOT NULL, -- SHA2_256 es 32 bytes
        NombreCompleto VARCHAR(200) NOT NULL,
        ID_Rol INT NOT NULL REFERENCES Roles(ID_Rol),
        -- Este enlace es clave para saber QU� veterinario es
        ID_Veterinario INT NULL REFERENCES Veterinario(ID_Veterinario),
        Activo BIT NOT NULL DEFAULT 1
    );
    PRINT 'Tabla [Usuario] creada.';
END
ELSE
    PRINT 'Tabla [Usuario] ya existe.';
GO

-- ==========================================================
-- 3. DATOS DE EJEMPLO (ROLES Y 5 EMPLEADOS)
-- ==========================================================
PRINT '--- 3. Insertando Roles y 5 Empleados de Ejemplo ---';

-- Insertar Roles (Si no existen)
IF NOT EXISTS (SELECT 1 FROM Roles WHERE NombreRol = 'Administrador')
    INSERT INTO Roles (NombreRol) VALUES ('Administrador');
IF NOT EXISTS (SELECT 1 FROM Roles WHERE NombreRol = 'Veterinario')
    INSERT INTO Roles (NombreRol) VALUES ('Veterinario');
IF NOT EXISTS (SELECT 1 FROM Roles WHERE NombreRol = 'Recepcionista')
    INSERT INTO Roles (NombreRol) VALUES ('Recepcionista');
GO

-- Insertar 5 Empleados (Contrase�a para todos: 'P@ssw0rd123')
-- Asumimos que ID_Veterinario 1 y 2 existen de tus datos de muestra
DECLARE @AdminRol INT = (SELECT ID_Rol FROM Roles WHERE NombreRol = 'Administrador');
DECLARE @VetRol INT = (SELECT ID_Rol FROM Roles WHERE NombreRol = 'Veterinario');
DECLARE @RecRol INT = (SELECT ID_Rol FROM Roles WHERE NombreRol = 'Recepcionista');

IF NOT EXISTS (SELECT 1 FROM Usuario WHERE NombreLogin = 'admin')
    INSERT INTO Usuario (NombreLogin, ContrasenaHash, NombreCompleto, ID_Rol, Activo)
    VALUES ('admin', HASHBYTES('SHA2_256', 'P@ssw0rd123'), 'Administrador del Sistema', @AdminRol, 1);

IF NOT EXISTS (SELECT 1 FROM Usuario WHERE NombreLogin = 'asolis')
    INSERT INTO Usuario (NombreLogin, ContrasenaHash, NombreCompleto, ID_Rol, ID_Veterinario, Activo)
    VALUES ('asolis', HASHBYTES('SHA2_256', 'P@ssw0rd123'), 'Dr. Alejandro Solas', @VetRol, 1, 1); -- Vinculado a Vet ID 1

IF NOT EXISTS (SELECT 1 FROM Usuario WHERE NombreLogin = 'bpena')
    INSERT INTO Usuario (NombreLogin, ContrasenaHash, NombreCompleto, ID_Rol, ID_Veterinario, Activo)
    VALUES ('bpena', HASHBYTES('SHA2_256', 'P@ssw0rd123'), 'Dra. Beatriz Pena', @VetRol, 2, 1); -- Vinculado a Vet ID 2

IF NOT EXISTS (SELECT 1 FROM Usuario WHERE NombreLogin = 'r.gomez')
    INSERT INTO Usuario (NombreLogin, ContrasenaHash, NombreCompleto, ID_Rol, Activo)
    VALUES ('r.gomez', HASHBYTES('SHA2_256', 'P@ssw0rd123'), 'Raquel Gomez (Recepcion)', @RecRol, 1);

IF NOT EXISTS (SELECT 1 FROM Usuario WHERE NombreLogin = 'j.perez')
    INSERT INTO Usuario (NombreLogin, ContrasenaHash, NombreCompleto, ID_Rol, Activo)
    VALUES ('j.perez', HASHBYTES('SHA2_256', 'P@ssw0rd123'), 'Javier Perez (Recepcion)', @RecRol, 1);
GO
PRINT '5 usuarios de ejemplo creados.';
GO

-- ==========================================================
-- 4. TRIGGERS (AUTOMATIZACI�N)
-- ==========================================================
PRINT '--- 4. Creando Trigger de Facturaci�n ---';

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
PRINT 'Trigger [tr_ActualizarTotalFactura] creado.';
GO

-- ==========================================================
-- 5. VISTAS (LECTURA SIMPLIFICADA)
-- ==========================================================
PRINT '--- 5. Creando Vistas (Views) ---';

IF OBJECT_ID('vw_PropietariosActivos', 'V') IS NOT NULL DROP VIEW vw_PropietariosActivos;
GO
CREATE VIEW vw_PropietariosActivos AS
SELECT ID_Propietario, Nombre, Apellidos, Direccion, Telefono 
FROM Propietario 
WHERE Activo = 1;
GO

IF OBJECT_ID('vw_MascotasConPropietario', 'V') IS NOT NULL DROP VIEW vw_MascotasConPropietario;
GO
CREATE VIEW vw_MascotasConPropietario AS
SELECT 
    M.ID_Mascota, M.Nombre, M.Especie, M.Raza, M.Edad, M.Sexo,
    P.ID_Propietario, 
    P.Nombre + ' ' + P.Apellidos AS NombrePropietario
FROM Mascota M
JOIN Propietario P ON M.ID_Propietario = P.ID_Propietario
WHERE P.Activo = 1;
GO

IF OBJECT_ID('vw_VeterinariosActivos', 'V') IS NOT NULL DROP VIEW vw_VeterinariosActivos;
GO
CREATE VIEW vw_VeterinariosActivos AS
SELECT ID_Veterinario, Nombre, Especialidad, Telefono, Correo 
FROM Veterinario 
WHERE Activo = 1;
GO

IF OBJECT_ID('vw_AgendaCitas', 'V') IS NOT NULL DROP VIEW vw_AgendaCitas;
GO
CREATE VIEW vw_AgendaCitas AS
SELECT 
    C.ID_Cita, C.Fecha, C.Hora, C.Estado,
    M.ID_Mascota, M.Nombre AS Mascota,
    P.ID_Propietario, P.Nombre + ' ' + P.Apellidos AS Propietario,
    V.ID_Veterinario, V.Nombre AS Veterinario,
    S.ID_Servicio, S.Nombre AS Servicio
FROM Cita C
JOIN Mascota M ON C.ID_Mascota = M.ID_Mascota
JOIN Propietario P ON M.ID_Propietario = P.ID_Propietario
JOIN Veterinario V ON C.ID_Veterinario = V.ID_Veterinario
JOIN Servicio S ON C.ID_Servicio = S.ID_Servicio
WHERE P.Activo = 1 AND V.Activo = 1;
GO

PRINT '4 Vistas (vw_PropietariosActivos, vw_MascotasConPropietario, vw_VeterinariosActivos, vw_AgendaCitas) creadas.';
GO

-- ==========================================================
-- 6. STORED PROCEDURES (L�GICA DE NEGOCIO Y CRUD COMPLETO)
-- ==========================================================
PRINT '--- 6. Creando Stored Procedures (SPs) ---';

-- 6.1. SP DE SEGURIDAD
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
        U.ID_Veterinario -- Clave para tu API
    FROM Usuario U
    JOIN Roles R ON U.ID_Rol = R.ID_Rol
    WHERE U.NombreLogin = @NombreLogin
      AND U.ContrasenaHash = @Hash
      AND U.Activo = 1;
END
GO
PRINT 'SP [sp_Usuario_Login] creado.';
GO

-- 6.2. SPs CRUD: PROPIETARIO
IF OBJECT_ID('sp_Propietario_Crear', 'P') IS NOT NULL DROP PROCEDURE sp_Propietario_Crear;
GO
CREATE PROCEDURE sp_Propietario_Crear
    @Nombre VARCHAR(100),
    @Apellidos VARCHAR(120),
    @Direccion VARCHAR(200) = NULL,
    @Telefono VARCHAR(20) = NULL
AS
BEGIN
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
    SELECT * FROM vw_PropietariosActivos ORDER BY Apellidos, Nombre;
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
PRINT 'SPs CRUD para [Propietario] creados.';
GO

-- 6.3. SPs CRUD: MASCOTA
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
    SELECT * FROM vw_MascotasConPropietario WHERE ID_Propietario = @ID_Propietario;
END
GO

IF OBJECT_ID('sp_Mascota_BuscarPorID', 'P') IS NOT NULL DROP PROCEDURE sp_Mascota_BuscarPorID;
GO
CREATE PROCEDURE sp_Mascota_BuscarPorID
    @ID_Mascota INT
AS
BEGIN
    SELECT * FROM vw_MascotasConPropietario WHERE ID_Mascota = @ID_Mascota;
END
GO

PRINT 'SPs CRUD para [Mascota] creados.';
GO

-- 6.4. SPs CRUD: CITA
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
    -- Validaci�n para evitar doble reserva (L�gica de negocio clave)
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
    SELECT * FROM vw_AgendaCitas WHERE Fecha = @Fecha ORDER BY Hora;
END
GO

IF OBJECT_ID('sp_Cita_ListarPorVeterinario', 'P') IS NOT NULL DROP PROCEDURE sp_Cita_ListarPorVeterinario;
GO
CREATE PROCEDURE sp_Cita_ListarPorVeterinario
    @ID_Veterinario INT
AS
BEGIN
    -- Esto cumple tu requisito: "que maneja �l"
    -- La API leer� el ID_Veterinario del TOKEN y lo pasar� aqu�.
    SELECT * FROM vw_AgendaCitas 
    WHERE ID_Veterinario = @ID_Veterinario 
      AND Fecha >= CAST(GETDATE() AS DATE) -- Solo citas de hoy en adelante
    ORDER BY Fecha, Hora;
END
GO

IF OBJECT_ID('sp_Cita_ListarCompletadasSinFactura', 'P') IS NOT NULL DROP PROCEDURE sp_Cita_ListarCompletadasSinFactura;
GO
CREATE PROCEDURE sp_Cita_ListarCompletadasSinFactura
AS
BEGIN
    SET NOCOUNT ON;
    -- Lista solo las citas completadas que NO tienen factura asociada
    SELECT C.* 
    FROM vw_AgendaCitas C
    WHERE C.Estado = 'Completada'
      AND NOT EXISTS (
          SELECT 1 FROM Factura F 
          WHERE F.ID_Cita = C.ID_Cita
      )
    ORDER BY C.Fecha DESC, C.Hora DESC;
END
GO

PRINT 'SPs CRUD para [Cita] creados.';
GO

-- 6.5. SPs TRANSACCIONALES: FACTURACI�N E HISTORIAL
IF OBJECT_ID('sp_Factura_CrearDesdeCita', 'P') IS NOT NULL DROP PROCEDURE sp_Factura_CrearDesdeCita;
GO
CREATE PROCEDURE sp_Factura_CrearDesdeCita
    @ID_Cita INT
WITH EXECUTE AS OWNER
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @ID_Propietario INT, @ID_Servicio INT, @CostoServicio DECIMAL(10,2);
    DECLARE @ID_NuevaFactura INT;

    -- Validar si la factura ya existe
    IF EXISTS (SELECT 1 FROM Factura WHERE ID_Cita = @ID_Cita)
    BEGIN
        RAISERROR('La cita ya tiene una factura asociada.', 16, 1);
        RETURN;
    END

    -- Obtener datos de la cita
    SELECT 
        @ID_Propietario = M.ID_Propietario, 
        @ID_Servicio = C.ID_Servicio, 
        @CostoServicio = S.Costo
    FROM Cita C
    JOIN Mascota M ON C.ID_Mascota = M.ID_Mascota
    JOIN Servicio S ON C.ID_Servicio = S.ID_Servicio
    WHERE C.ID_Cita = @ID_Cita;

    IF @ID_Propietario IS NULL
    BEGIN
        RAISERROR('La cita no existe o no se pudo encontrar el servicio.', 16, 1);
        RETURN;
    END

    BEGIN TRANSACTION;
    BEGIN TRY
        -- 1. Crear el encabezado de la Factura
        INSERT INTO Factura (Fecha, Total, ID_Propietario, ID_Cita, EstadoPago)
        VALUES (GETDATE(), 0, @ID_Propietario, @ID_Cita, 'Pendiente');
        
        SET @ID_NuevaFactura = SCOPE_IDENTITY();

        -- 2. A�adir el primer item (el servicio de la cita)
        INSERT INTO FacturaDetalle (ID_Factura, ID_Servicio, Cantidad, PrecioUnitario)
        VALUES (@ID_NuevaFactura, @ID_Servicio, 1, @CostoServicio);
        -- (El Trigger 'tr_ActualizarTotalFactura' se disparar� aqu� y actualizar� el Total)

        COMMIT TRANSACTION;
        SELECT @ID_NuevaFactura AS NuevaID_Factura;

    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

IF OBJECT_ID('sp_Factura_AgregarItem', 'P') IS NOT NULL DROP PROCEDURE sp_Factura_AgregarItem;
GO
CREATE PROCEDURE sp_Factura_AgregarItem
    @ID_Factura INT,
    @ID_Servicio INT,
    @Cantidad INT
AS
BEGIN
    DECLARE @CostoServicio DECIMAL(10,2) = (SELECT Costo FROM Servicio WHERE ID_Servicio = @ID_Servicio);
    
    INSERT INTO FacturaDetalle (ID_Factura, ID_Servicio, Cantidad, PrecioUnitario)
    VALUES (@ID_Factura, @ID_Servicio, @Cantidad, @CostoServicio);
    -- (El Trigger recalcular� el total)
END
GO

IF OBJECT_ID('sp_Factura_Pagar', 'P') IS NOT NULL DROP PROCEDURE sp_Factura_Pagar;
GO
CREATE PROCEDURE sp_Factura_Pagar
    @ID_Factura INT,
    @MontoPagado DECIMAL(10,2),
    @MetodoPago VARCHAR(50)
WITH EXECUTE AS OWNER
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @TotalFactura DECIMAL(10,2), @ID_Cita INT;
    DECLARE @EstadoActual VARCHAR(20);
    DECLARE @PagosExistentes INT;
    DECLARE @MensajeEstado NVARCHAR(4000);
    DECLARE @MensajeMonto NVARCHAR(4000);

    BEGIN TRANSACTION;
    BEGIN TRY
        -- Bloquear la factura con UPDLOCK y HOLDLOCK para evitar condiciones de carrera
        -- Esto asegura que solo un proceso pueda procesar el pago a la vez
        SELECT @TotalFactura = Total, @ID_Cita = ID_Cita, @EstadoActual = EstadoPago
        FROM Factura WITH (UPDLOCK, HOLDLOCK, ROWLOCK)
        WHERE ID_Factura = @ID_Factura;

        -- Validar que la factura existe
        IF @TotalFactura IS NULL
        BEGIN
            ROLLBACK TRANSACTION;
            RAISERROR('Factura no encontrada.', 16, 1);
            RETURN;
        END

        -- Validar que la factura está pendiente
        IF @EstadoActual != 'Pendiente'
        BEGIN
            ROLLBACK TRANSACTION;
            SET @MensajeEstado = 'La factura ya fue pagada o está en otro estado. Estado actual: ' + @EstadoActual;
            RAISERROR(@MensajeEstado, 16, 1);
            RETURN;
        END

        -- Verificar si ya existe un pago para esta factura (doble validación)
        SELECT @PagosExistentes = COUNT(*)
        FROM Pago
        WHERE ID_Factura = @ID_Factura;

        IF @PagosExistentes > 0
        BEGIN
            ROLLBACK TRANSACTION;
            RAISERROR('Esta factura ya tiene un pago registrado. No se pueden procesar pagos duplicados.', 16, 1);
            RETURN;
        END

        -- Validar que el monto es suficiente
        IF @MontoPagado < @TotalFactura
        BEGIN
            ROLLBACK TRANSACTION;
            SET @MensajeMonto = 'El monto es insuficiente. El total de la factura es $' + CAST(@TotalFactura AS VARCHAR(20));
            RAISERROR(@MensajeMonto, 16, 1);
            RETURN;
        END

        -- 1. Insertar el Pago
        INSERT INTO Pago (ID_Factura, MetodoPago, Monto, FechaPago)
        VALUES (@ID_Factura, @MetodoPago, @MontoPagado, GETDATE());

        -- 2. Actualizar la Factura a 'Pagada' (con la misma condición de estado para seguridad)
        UPDATE Factura 
        SET EstadoPago = 'Pagada' 
        WHERE ID_Factura = @ID_Factura 
          AND EstadoPago = 'Pendiente';  -- Doble verificación para evitar condiciones de carrera

        -- Verificar que se actualizó correctamente
        IF @@ROWCOUNT = 0
        BEGIN
            ROLLBACK TRANSACTION;
            RAISERROR('Error al actualizar el estado de la factura. La factura puede haber sido pagada por otro proceso.', 16, 1);
            RETURN;
        END

        -- 3. Actualizar la Cita a 'Completada' (si tiene cita asociada)
        IF @ID_Cita IS NOT NULL
        BEGIN
            UPDATE Cita 
            SET Estado = 'Completada' 
            WHERE ID_Cita = @ID_Cita AND Estado != 'Completada';
        END

        COMMIT TRANSACTION;
        SELECT 1 AS Exito;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();
        
        RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END
GO

PRINT 'SPs Transaccionales para [Facturaci�n] creados.';
GO

-- 6.6. SPs DE HISTORIAL CL�NICO
IF OBJECT_ID('sp_Historial_AgregarTratamiento', 'P') IS NOT NULL DROP PROCEDURE sp_Historial_AgregarTratamiento;
GO
CREATE PROCEDURE sp_Historial_AgregarTratamiento
    @ID_Mascota INT,
    @Fecha DATE,
    @Diagnostico VARCHAR(250)
AS
BEGIN
    INSERT INTO Tratamiento (Fecha, Diagnostico, ID_Mascota)
    VALUES (@Fecha, @Diagnostico, @ID_Mascota);
    SELECT SCOPE_IDENTITY() AS NuevoID_Tratamiento;
END
GO

IF OBJECT_ID('sp_Historial_AgregarVacuna', 'P') IS NOT NULL DROP PROCEDURE sp_Historial_AgregarVacuna;
GO
CREATE PROCEDURE sp_Historial_AgregarVacuna
    @ID_Mascota INT,
    @ID_Vacuna INT,
    @FechaAplicacion DATE,
    @FechaProximaDosis DATE = NULL
AS
BEGIN
    INSERT INTO Mascota_Vacuna (ID_Mascota, ID_Vacuna, FechaAplicacion, FechaProximaDosis)
    VALUES (@ID_Mascota, @ID_Vacuna, @FechaAplicacion, @FechaProximaDosis);
END
GO

IF OBJECT_ID('sp_Reporte_HistoriaClinicaCompleta', 'P') IS NOT NULL DROP PROCEDURE sp_Reporte_HistoriaClinicaCompleta;
GO
CREATE PROCEDURE sp_Reporte_HistoriaClinicaCompleta
    @ID_Mascota INT
AS
BEGIN
    SET NOCOUNT ON;
    (SELECT C.Fecha, 'Consulta' AS TipoEvento, S.Nombre AS Titulo, V.Nombre AS Veterinario
     FROM Cita C
     JOIN Servicio S ON C.ID_Servicio = S.ID_Servicio
     JOIN Veterinario V ON C.ID_Veterinario = V.ID_Veterinario
     WHERE C.ID_Mascota = @ID_Mascota AND C.Estado = 'Completada')
    UNION ALL
    (SELECT T.Fecha, 'Tratamiento' AS TipoEvento, T.Diagnostico AS Titulo, NULL AS Veterinario
     FROM Tratamiento T
     WHERE T.ID_Mascota = @ID_Mascota)
    UNION ALL
    (SELECT C.Fecha, 'Cirug�a' AS TipoEvento, C.Tipo AS Titulo, V.Nombre AS Veterinario
     FROM Cirugia C
     JOIN Veterinario V ON C.ID_Veterinario = V.ID_Veterinario
     WHERE C.ID_Mascota = @ID_Mascota)
    UNION ALL
    (SELECT H.FechaIngreso AS Fecha, 'Hospitalizaci�n' AS TipoEvento, H.Observaciones AS Titulo, NULL AS Veterinario
     FROM Hospitalizacion H
     WHERE H.ID_Mascota = @ID_Mascota)
    UNION ALL
    (SELECT MV.FechaAplicacion AS Fecha, 'Vacunaci�n' AS TipoEvento, V.Nombre AS Titulo, NULL AS Veterinario
     FROM Mascota_Vacuna MV
     JOIN Vacuna V ON MV.ID_Vacuna = V.ID_Vacuna
     WHERE MV.ID_Mascota = @ID_Mascota)
    ORDER BY Fecha DESC;
END
GO

PRINT 'SPs para [Historial Cl�nico] creados.';
GO

-- ==========================================================
-- 7. ASIGNACI�N DE PERMISOS (DCL)
-- ==========================================================
PRINT '--- 7. Asignando permisos finales al rol de la API ---';

-- Otorgar permisos de ejecuci�n a TODOS los SPs
-- Otorgar permisos con verificacin de existencia para evitar errores
IF OBJECT_ID('sp_Usuario_Login', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Usuario_Login TO rol_api_ejecutor;
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
IF OBJECT_ID('sp_Mascota_Crear', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Mascota_Crear TO rol_api_ejecutor;
IF OBJECT_ID('sp_Mascota_Actualizar', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Mascota_Actualizar TO rol_api_ejecutor;
IF OBJECT_ID('sp_Mascota_ListarPorPropietario', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Mascota_ListarPorPropietario TO rol_api_ejecutor;
IF OBJECT_ID('sp_Mascota_BuscarPorID', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Mascota_BuscarPorID TO rol_api_ejecutor;
IF OBJECT_ID('sp_Cita_Agendar', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Cita_Agendar TO rol_api_ejecutor;
IF OBJECT_ID('sp_Cita_Cancelar', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Cita_Cancelar TO rol_api_ejecutor;
IF OBJECT_ID('sp_Cita_ListarPorFecha', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Cita_ListarPorFecha TO rol_api_ejecutor;
IF OBJECT_ID('sp_Cita_ListarPorVeterinario', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Cita_ListarPorVeterinario TO rol_api_ejecutor;
IF OBJECT_ID('sp_Cita_ListarCompletadasSinFactura', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Cita_ListarCompletadasSinFactura TO rol_api_ejecutor;
IF OBJECT_ID('sp_Factura_CrearDesdeCita', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Factura_CrearDesdeCita TO rol_api_ejecutor;
IF OBJECT_ID('sp_Factura_AgregarItem', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Factura_AgregarItem TO rol_api_ejecutor;
IF OBJECT_ID('sp_Factura_Pagar', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Factura_Pagar TO rol_api_ejecutor;
ELSE
    PRINT 'ADVERTENCIA: sp_Factura_Pagar no existe. Verifica que se haya creado correctamente.';
IF OBJECT_ID('sp_Historial_AgregarTratamiento', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Historial_AgregarTratamiento TO rol_api_ejecutor;
IF OBJECT_ID('sp_Historial_AgregarVacuna', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Historial_AgregarVacuna TO rol_api_ejecutor;
IF OBJECT_ID('sp_Reporte_HistoriaClinicaCompleta', 'P') IS NOT NULL
    GRANT EXECUTE ON sp_Reporte_HistoriaClinicaCompleta TO rol_api_ejecutor;
-- (A�ade aqu� cualquier SP que falte)

-- Otorgar permisos de lectura a TODAS las Vistas
GRANT SELECT ON vw_PropietariosActivos TO rol_api_ejecutor;
GRANT SELECT ON vw_MascotasConPropietario TO rol_api_ejecutor;
GRANT SELECT ON vw_VeterinariosActivos TO rol_api_ejecutor;
GRANT SELECT ON vw_AgendaCitas TO rol_api_ejecutor;

-- DENEGAR acceso directo a las tablas (La medida de seguridad m�s importante)
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
-- El usuario de la API no puede ver las tablas de seguridad
DENY SELECT, INSERT, UPDATE, DELETE ON Usuario TO rol_api_ejecutor;
DENY SELECT, INSERT, UPDATE, DELETE ON Roles TO rol_api_ejecutor;
GO

PRINT '*** SCRIPT DE L�GICA Y SEGURIDAD COMPLETADO ***';