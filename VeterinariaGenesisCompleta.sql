/*
==================================================================================
SCRIPT 01: ESQUEMA BASE DE DATOS - VeterinariaGenesisDB
==================================================================================
Este script crea la base de datos y todas las tablas necesarias.
EJECUTAR PRIMERO
==================================================================================
*/

-- Crear base de datos
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'VeterinariaGenesisDB')
BEGIN
    CREATE DATABASE VeterinariaGenesisDB;
    PRINT 'Base de datos VeterinariaGenesisDB creada.';
END
ELSE
    PRINT 'Base de datos VeterinariaGenesisDB ya existe.';
GO

USE VeterinariaGenesisDB;
GO

-- ==========================================================
-- CREACIÓN DE TABLAS
-- ==========================================================

-- TABLA: Propietario
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Propietario]') AND type in (N'U'))
BEGIN
    CREATE TABLE Propietario (
        ID_Propietario INT PRIMARY KEY IDENTITY(1,1),
        Nombre VARCHAR(100) NOT NULL,
        Apellidos VARCHAR(120) NOT NULL,
        Direccion VARCHAR(200),
        Telefono VARCHAR(20),
        Activo BIT NOT NULL DEFAULT 1
    );
    PRINT 'Tabla [Propietario] creada.';
END
ELSE
    PRINT 'Tabla [Propietario] ya existe.';
GO

-- TABLA: Mascota
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Mascota]') AND type in (N'U'))
BEGIN
    CREATE TABLE Mascota (
        ID_Mascota INT PRIMARY KEY IDENTITY(1,1),
        Nombre VARCHAR(100) NOT NULL,
        Especie VARCHAR(50) NOT NULL,
        Raza VARCHAR(50),
        Edad INT CHECK (Edad >= 0),
        Sexo VARCHAR(10) CHECK (Sexo IN ('Macho','Hembra')),
        ID_Propietario INT NOT NULL,
        CONSTRAINT FK_Mascota_Propietario FOREIGN KEY (ID_Propietario)
            REFERENCES Propietario(ID_Propietario)
            ON DELETE NO ACTION,
        CONSTRAINT UQ_Mascota_Nombre UNIQUE (Nombre, ID_Propietario)
    );
    PRINT 'Tabla [Mascota] creada.';
END
ELSE
    PRINT 'Tabla [Mascota] ya existe.';
GO

-- TABLA: Veterinario
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Veterinario]') AND type in (N'U'))
BEGIN
    CREATE TABLE Veterinario (
        ID_Veterinario INT PRIMARY KEY IDENTITY(1,1),
        Nombre VARCHAR(120) NOT NULL,
        Especialidad VARCHAR(100),
        Telefono VARCHAR(20) NULL,
        Correo VARCHAR(100) NULL,
        Activo BIT NOT NULL DEFAULT 1
    );
    PRINT 'Tabla [Veterinario] creada.';
    
    -- Índice único filtrado para correo
    CREATE UNIQUE INDEX UQ_Veterinario_Correo_NotNull
    ON Veterinario(Correo)
    WHERE Correo IS NOT NULL;
    PRINT 'Índice único para correo de veterinario creado.';
END
ELSE
    PRINT 'Tabla [Veterinario] ya existe.';
GO

-- TABLA: Servicio
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Servicio]') AND type in (N'U'))
BEGIN
    CREATE TABLE Servicio (
        ID_Servicio INT PRIMARY KEY IDENTITY(1,1),
        Nombre VARCHAR(100) NOT NULL,
        Descripcion VARCHAR(250),
        Costo DECIMAL(10,2) NOT NULL CHECK (Costo >= 0)
    );
    PRINT 'Tabla [Servicio] creada.';
END
ELSE
    PRINT 'Tabla [Servicio] ya existe.';
GO

-- TABLA: Cita
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cita]') AND type in (N'U'))
BEGIN
    CREATE TABLE Cita (
        ID_Cita INT PRIMARY KEY IDENTITY(1,1),
        Fecha DATE NOT NULL,
        Hora TIME NOT NULL,
        ID_Mascota INT NOT NULL,
        ID_Veterinario INT NOT NULL,
        ID_Servicio INT NOT NULL,
        Estado VARCHAR(20) NOT NULL 
            CONSTRAINT CHK_Cita_Estado CHECK (Estado IN ('Programada','Completada','Cancelada')) 
            DEFAULT 'Programada',
        CONSTRAINT FK_Cita_Mascota FOREIGN KEY (ID_Mascota)
            REFERENCES Mascota(ID_Mascota)
            ON DELETE CASCADE,
        CONSTRAINT FK_Cita_Veterinario FOREIGN KEY (ID_Veterinario)
            REFERENCES Veterinario(ID_Veterinario),
        CONSTRAINT FK_Cita_Servicio FOREIGN KEY (ID_Servicio)
            REFERENCES Servicio(ID_Servicio)
    );
    PRINT 'Tabla [Cita] creada.';
END
ELSE
    PRINT 'Tabla [Cita] ya existe.';
GO

-- TABLA: Factura
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Factura]') AND type in (N'U'))
BEGIN
    CREATE TABLE Factura (
        ID_Factura INT PRIMARY KEY IDENTITY(1,1),
        Fecha DATE NOT NULL DEFAULT GETDATE(),
        Total DECIMAL(10,2) NOT NULL CHECK (Total >= 0),
        ID_Propietario INT NOT NULL,
        ID_Cita INT NULL,
        EstadoPago VARCHAR(20) NOT NULL 
            CONSTRAINT CHK_Factura_EstadoPago CHECK (EstadoPago IN ('Pendiente','Pagada','Anulada')) 
            DEFAULT 'Pendiente',
        CONSTRAINT FK_Factura_Propietario FOREIGN KEY (ID_Propietario)
            REFERENCES Propietario(ID_Propietario),
        CONSTRAINT FK_Factura_Cita FOREIGN KEY (ID_Cita)
            REFERENCES Cita(ID_Cita)
    );
    PRINT 'Tabla [Factura] creada.';
END
ELSE
    PRINT 'Tabla [Factura] ya existe.';
GO

-- TABLA: FacturaDetalle
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FacturaDetalle]') AND type in (N'U'))
BEGIN
    CREATE TABLE FacturaDetalle (
        ID_FacturaDetalle INT PRIMARY KEY IDENTITY(1,1),
        ID_Factura INT NOT NULL,
        ID_Servicio INT NOT NULL,
        Cantidad INT NOT NULL DEFAULT 1 CHECK (Cantidad > 0),
        PrecioUnitario DECIMAL(10, 2) NOT NULL,
        Subtotal AS (Cantidad * PrecioUnitario),
        CONSTRAINT FK_Detalle_Factura FOREIGN KEY (ID_Factura)
            REFERENCES Factura(ID_Factura)
            ON DELETE CASCADE,
        CONSTRAINT FK_Detalle_Servicio FOREIGN KEY (ID_Servicio)
            REFERENCES Servicio(ID_Servicio)
    );
    PRINT 'Tabla [FacturaDetalle] creada.';
END
ELSE
    PRINT 'Tabla [FacturaDetalle] ya existe.';
GO

-- TABLA: Pago
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pago]') AND type in (N'U'))
BEGIN
    CREATE TABLE Pago (
        ID_Pago INT PRIMARY KEY IDENTITY(1,1),
        ID_Factura INT NOT NULL,
        MetodoPago VARCHAR(50) NOT NULL CHECK (MetodoPago IN ('Efectivo','Tarjeta','Transferencia')),
        Monto DECIMAL(10,2) NOT NULL CHECK (Monto >= 0),
        FechaPago DATE NOT NULL DEFAULT GETDATE(),
        CONSTRAINT FK_Pago_Factura FOREIGN KEY (ID_Factura)
            REFERENCES Factura(ID_Factura)
            ON DELETE CASCADE
    );
    PRINT 'Tabla [Pago] creada.';
    
    -- Restricción única para prevenir pagos duplicados
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'UQ_Pago_ID_Factura')
    BEGIN
        CREATE UNIQUE NONCLUSTERED INDEX UQ_Pago_ID_Factura
        ON Pago(ID_Factura);
        PRINT 'Índice único UQ_Pago_ID_Factura creado.';
    END
END
ELSE
    PRINT 'Tabla [Pago] ya existe.';
GO

-- TABLA: Tratamiento
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tratamiento]') AND type in (N'U'))
BEGIN
    CREATE TABLE Tratamiento (
        ID_Tratamiento INT PRIMARY KEY IDENTITY(1,1),
        Fecha DATE NOT NULL,
        Diagnostico VARCHAR(250) NOT NULL,
        ID_Mascota INT NOT NULL,
        CONSTRAINT FK_Tratamiento_Mascota FOREIGN KEY (ID_Mascota)
            REFERENCES Mascota(ID_Mascota)
            ON DELETE CASCADE
    );
    PRINT 'Tabla [Tratamiento] creada.';
END
ELSE
    PRINT 'Tabla [Tratamiento] ya existe.';
GO

-- TABLA: Medicamento
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Medicamento]') AND type in (N'U'))
BEGIN
    CREATE TABLE Medicamento (
        ID_Medicamento INT PRIMARY KEY IDENTITY(1,1),
        Nombre VARCHAR(100) NOT NULL
    );
    PRINT 'Tabla [Medicamento] creada.';
END
ELSE
    PRINT 'Tabla [Medicamento] ya existe.';
GO

-- TABLA: Tratamiento_Medicamento
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tratamiento_Medicamento]') AND type in (N'U'))
BEGIN
    CREATE TABLE Tratamiento_Medicamento (
        ID_Tratamiento INT NOT NULL,
        ID_Medicamento INT NOT NULL,
        Dosis VARCHAR(100) NULL,
        Frecuencia VARCHAR(100) NULL,
        Duracion VARCHAR(100) NULL,
        PRIMARY KEY (ID_Tratamiento, ID_Medicamento),
        CONSTRAINT FK_TM_Tratamiento FOREIGN KEY (ID_Tratamiento)
            REFERENCES Tratamiento(ID_Tratamiento)
            ON DELETE CASCADE,
        CONSTRAINT FK_TM_Medicamento FOREIGN KEY (ID_Medicamento)
            REFERENCES Medicamento(ID_Medicamento)
    );
    PRINT 'Tabla [Tratamiento_Medicamento] creada.';
END
ELSE
    PRINT 'Tabla [Tratamiento_Medicamento] ya existe.';
GO

-- TABLA: Vacuna
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Vacuna]') AND type in (N'U'))
BEGIN
    CREATE TABLE Vacuna (
        ID_Vacuna INT PRIMARY KEY IDENTITY(1,1),
        Nombre VARCHAR(100) NOT NULL,
        Dosis VARCHAR(50)
    );
    PRINT 'Tabla [Vacuna] creada.';
END
ELSE
    PRINT 'Tabla [Vacuna] ya existe.';
GO

-- TABLA: Mascota_Vacuna
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Mascota_Vacuna]') AND type in (N'U'))
BEGIN
    CREATE TABLE Mascota_Vacuna (
        ID_Mascota INT NOT NULL,
        ID_Vacuna INT NOT NULL,
        FechaAplicacion DATE NOT NULL DEFAULT GETDATE(),
        FechaProximaDosis DATE NULL,
        PRIMARY KEY (ID_Mascota, ID_Vacuna, FechaAplicacion),
        CONSTRAINT FK_MV_Mascota FOREIGN KEY (ID_Mascota)
            REFERENCES Mascota(ID_Mascota)
            ON DELETE CASCADE,
        CONSTRAINT FK_MV_Vacuna FOREIGN KEY (ID_Vacuna)
            REFERENCES Vacuna(ID_Vacuna)
    );
    PRINT 'Tabla [Mascota_Vacuna] creada.';
END
ELSE
    PRINT 'Tabla [Mascota_Vacuna] ya existe.';
GO

-- TABLA: Hospitalizacion
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Hospitalizacion]') AND type in (N'U'))
BEGIN
    CREATE TABLE Hospitalizacion (
        ID_Hospitalizacion INT PRIMARY KEY IDENTITY(1,1),
        FechaIngreso DATE NOT NULL,
        FechaSalida DATE,
        Observaciones VARCHAR(250),
        ID_Mascota INT NOT NULL,
        CONSTRAINT FK_Hospitalizacion_Mascota FOREIGN KEY (ID_Mascota)
            REFERENCES Mascota(ID_Mascota)
            ON DELETE CASCADE,
        CONSTRAINT CHK_Hosp_Fechas CHECK (FechaSalida IS NULL OR FechaSalida >= FechaIngreso)
    );
    PRINT 'Tabla [Hospitalizacion] creada.';
END
ELSE
    PRINT 'Tabla [Hospitalizacion] ya existe.';
GO

-- TABLA: Cirugia
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cirugia]') AND type in (N'U'))
BEGIN
    CREATE TABLE Cirugia (
        ID_Cirugia INT PRIMARY KEY IDENTITY(1,1),
        Fecha DATE NOT NULL,
        Tipo VARCHAR(100) NOT NULL,
        Descripcion VARCHAR(250),
        ID_Mascota INT NOT NULL,
        ID_Veterinario INT NOT NULL,
        CONSTRAINT FK_Cirugia_Mascota FOREIGN KEY (ID_Mascota)
            REFERENCES Mascota(ID_Mascota)
            ON DELETE CASCADE,
        CONSTRAINT FK_Cirugia_Veterinario FOREIGN KEY (ID_Veterinario)
            REFERENCES Veterinario(ID_Veterinario)
    );
    PRINT 'Tabla [Cirugia] creada.';
END
ELSE
    PRINT 'Tabla [Cirugia] ya existe.';
GO

-- TABLA: Roles (para usuarios de la aplicación)
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

-- TABLA: Usuario (para usuarios de la aplicación)
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuario]') AND type in (N'U'))
BEGIN
    CREATE TABLE Usuario (
        ID_Usuario INT PRIMARY KEY IDENTITY(1,1),
        NombreLogin VARCHAR(50) NOT NULL UNIQUE,
        ContrasenaHash VARBINARY(32) NOT NULL,
        NombreCompleto VARCHAR(200) NOT NULL,
        ID_Rol INT NOT NULL REFERENCES Roles(ID_Rol),
        ID_Veterinario INT NULL REFERENCES Veterinario(ID_Veterinario),
        Activo BIT NOT NULL DEFAULT 1
    );
    PRINT 'Tabla [Usuario] creada.';
END
ELSE
    PRINT 'Tabla [Usuario] ya existe.';
GO

PRINT '*** ESQUEMA BASE COMPLETADO ***';
GO

  /*
==================================================================================
SCRIPT 02: ÍNDICES DE RENDIMIENTO - VeterinariaGenesisDB
==================================================================================
Este script crea los índices para optimizar las consultas.
EJECUTAR DESPUÉS DE 01_Esquema_Base.sql
==================================================================================
*/

USE VeterinariaGenesisDB;
GO

PRINT '--- Creando índices de rendimiento ---';
GO

-- Índices para Mascota
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Mascota_Propietario')
    CREATE INDEX IX_Mascota_Propietario ON Mascota(ID_Propietario);
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Mascota_Nombre')
    CREATE INDEX IX_Mascota_Nombre ON Mascota(Nombre);

-- Índices para Cita
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Cita_Veterinario_Fecha')
    CREATE INDEX IX_Cita_Veterinario_Fecha ON Cita(ID_Veterinario, Fecha);
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Cita_Mascota')
    CREATE INDEX IX_Cita_Mascota ON Cita(ID_Mascota);

-- Índices para Tratamiento
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Tratamiento_Mascota')
    CREATE INDEX IX_Tratamiento_Mascota ON Tratamiento(ID_Mascota);

-- Índices para Hospitalizacion
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Hospitalizacion_Mascota')
    CREATE INDEX IX_Hospitalizacion_Mascota ON Hospitalizacion(ID_Mascota);

-- Índices para Propietario
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Propietario_Apellidos_Nombre')
    CREATE INDEX IX_Propietario_Apellidos_Nombre ON Propietario(Apellidos, Nombre);

-- Índices para Factura
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Factura_Propietario_Estado')
    CREATE INDEX IX_Factura_Propietario_Estado ON Factura(ID_Propietario, EstadoPago);

-- Índices para FacturaDetalle
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_FacturaDetalle_Factura')
    CREATE INDEX IX_FacturaDetalle_Factura ON FacturaDetalle(ID_Factura);

-- Índices para Cirugia
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Cirugia_Mascota')
    CREATE INDEX IX_Cirugia_Mascota ON Cirugia(ID_Mascota);

-- Índices para Mascota_Vacuna
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Mascota_Vacuna_Mascota')
    CREATE INDEX IX_Mascota_Vacuna_Mascota ON Mascota_Vacuna(ID_Mascota);

PRINT '*** ÍNDICES CREADOS EXITOSAMENTE ***';
GO

/*
==================================================================================
SCRIPT 03: TRIGGERS - VeterinariaGenesisDB
==================================================================================
Este script crea todos los triggers necesarios.
EJECUTAR DESPUÉS DE 02_Indices.sql
==================================================================================
*/

USE VeterinariaGenesisDB;
GO

PRINT '--- Creando Triggers ---';
GO

-- ====================================================
-- TRIGGER: Actualizar Total de Factura
-- ====================================================
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

-- ====================================================
-- TRIGGER: Actualizar Citas Pasadas
-- ====================================================
IF OBJECT_ID('trg_ActualizarCitasPasadas', 'TR') IS NOT NULL
    DROP TRIGGER trg_ActualizarCitasPasadas;
GO

CREATE TRIGGER trg_ActualizarCitasPasadas
ON Cita
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE Cita
    SET Estado = 'Completada'
    WHERE Estado = 'Programada'
      AND Fecha < CAST(GETDATE() AS DATE);
END
GO
PRINT 'Trigger [trg_ActualizarCitasPasadas] creado.';
GO

PRINT '*** TRIGGERS CREADOS EXITOSAMENTE ***';
GO

/*
==================================================================================
SCRIPT 04: STORED PROCEDURES CRUD PRINCIPALES - VeterinariaGenesisDB
==================================================================================
Este script crea los SPs principales de CRUD (Propietario, Mascota, Cita, Factura).
EJECUTAR DESPUÉS DE 03_Triggers.sql
==================================================================================
*/

USE VeterinariaGenesisDB;
GO

PRINT '--- Creando Stored Procedures CRUD Principales ---';
GO

-- ====================================================
-- SP: LOGIN DE USUARIO
-- ====================================================
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
        U.ID_Veterinario
    FROM Usuario U
    JOIN Roles R ON U.ID_Rol = R.ID_Rol
    WHERE U.NombreLogin = @NombreLogin
      AND U.ContrasenaHash = @Hash
      AND U.Activo = 1;
END
GO

-- ====================================================
-- SPs CRUD: PROPIETARIO
-- ====================================================
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
    SELECT * FROM Propietario WHERE Activo = 1 ORDER BY Apellidos, Nombre;
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

-- ====================================================
-- SPs CRUD: MASCOTA
-- ====================================================
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
    SELECT M.*, P.Nombre + ' ' + P.Apellidos AS NombrePropietario
    FROM Mascota M
    JOIN Propietario P ON M.ID_Propietario = P.ID_Propietario
    WHERE M.ID_Propietario = @ID_Propietario AND P.Activo = 1;
END
GO

IF OBJECT_ID('sp_Mascota_BuscarPorID', 'P') IS NOT NULL DROP PROCEDURE sp_Mascota_BuscarPorID;
GO
CREATE PROCEDURE sp_Mascota_BuscarPorID
    @ID_Mascota INT
AS
BEGIN
    SELECT M.*, P.Nombre + ' ' + P.Apellidos AS NombrePropietario
    FROM Mascota M
    JOIN Propietario P ON M.ID_Propietario = P.ID_Propietario
    WHERE M.ID_Mascota = @ID_Mascota AND P.Activo = 1;
END
GO

-- ====================================================
-- SPs CRUD: CITA
-- ====================================================
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

IF OBJECT_ID('sp_Cita_Actualizar', 'P') IS NOT NULL DROP PROCEDURE sp_Cita_Actualizar;
GO
CREATE PROCEDURE sp_Cita_Actualizar
    @ID_Cita INT,
    @Fecha DATE,
    @Hora TIME,
    @ID_Mascota INT,
    @ID_Veterinario INT,
    @ID_Servicio INT,
    @Estado VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    
    IF NOT EXISTS (SELECT 1 FROM Cita WHERE ID_Cita = @ID_Cita)
    BEGIN
        RAISERROR('La cita especificada no existe.', 16, 1);
        RETURN;
    END
    
    IF @Estado NOT IN ('Programada', 'Completada', 'Cancelada')
    BEGIN
        RAISERROR('El estado debe ser: Programada, Completada o Cancelada.', 16, 1);
        RETURN;
    END
    
    IF @Estado = 'Programada'
    BEGIN
        IF EXISTS (SELECT 1 FROM Cita 
                   WHERE ID_Veterinario = @ID_Veterinario 
                   AND Fecha = @Fecha 
                   AND Hora = @Hora
                   AND Estado = 'Programada'
                   AND ID_Cita <> @ID_Cita)
        BEGIN
            RAISERROR('El veterinario ya tiene una cita programada a esa hora.', 16, 1);
            RETURN;
        END
    END
    
    UPDATE Cita
    SET Fecha = @Fecha, Hora = @Hora, ID_Mascota = @ID_Mascota,
        ID_Veterinario = @ID_Veterinario, ID_Servicio = @ID_Servicio, Estado = @Estado
    WHERE ID_Cita = @ID_Cita;
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
    SELECT C.*, M.Nombre AS Mascota, V.Nombre AS Veterinario, S.Nombre AS Servicio,
           P.Nombre + ' ' + P.Apellidos AS Propietario
    FROM Cita C
    JOIN Mascota M ON C.ID_Mascota = M.ID_Mascota
    JOIN Propietario P ON M.ID_Propietario = P.ID_Propietario
    JOIN Veterinario V ON C.ID_Veterinario = V.ID_Veterinario
    JOIN Servicio S ON C.ID_Servicio = S.ID_Servicio
    WHERE C.Fecha = @Fecha AND P.Activo = 1 AND V.Activo = 1
    ORDER BY C.Hora;
END
GO

IF OBJECT_ID('sp_Cita_ListarPorVeterinario', 'P') IS NOT NULL DROP PROCEDURE sp_Cita_ListarPorVeterinario;
GO
CREATE PROCEDURE sp_Cita_ListarPorVeterinario
    @ID_Veterinario INT
AS
BEGIN
    SELECT C.*, M.Nombre AS Mascota, V.Nombre AS Veterinario, S.Nombre AS Servicio,
           P.Nombre + ' ' + P.Apellidos AS Propietario
    FROM Cita C
    JOIN Mascota M ON C.ID_Mascota = M.ID_Mascota
    JOIN Propietario P ON M.ID_Propietario = P.ID_Propietario
    JOIN Veterinario V ON C.ID_Veterinario = V.ID_Veterinario
    JOIN Servicio S ON C.ID_Servicio = S.ID_Servicio
    WHERE C.ID_Veterinario = @ID_Veterinario 
      AND C.Fecha >= CAST(GETDATE() AS DATE)
      AND P.Activo = 1 AND V.Activo = 1
    ORDER BY C.Fecha, C.Hora;
END
GO

IF OBJECT_ID('sp_Cita_ListarCompletadasSinFactura', 'P') IS NOT NULL DROP PROCEDURE sp_Cita_ListarCompletadasSinFactura;
GO
CREATE PROCEDURE sp_Cita_ListarCompletadasSinFactura
AS
BEGIN
    SET NOCOUNT ON;
    SELECT C.*, M.Nombre AS Mascota, V.Nombre AS Veterinario, S.Nombre AS Servicio,
           P.Nombre + ' ' + P.Apellidos AS Propietario
    FROM Cita C
    JOIN Mascota M ON C.ID_Mascota = M.ID_Mascota
    JOIN Propietario P ON M.ID_Propietario = P.ID_Propietario
    JOIN Veterinario V ON C.ID_Veterinario = V.ID_Veterinario
    JOIN Servicio S ON C.ID_Servicio = S.ID_Servicio
    WHERE C.Estado = 'Completada'
      AND NOT EXISTS (SELECT 1 FROM Factura F WHERE F.ID_Cita = C.ID_Cita)
      AND P.Activo = 1 AND V.Activo = 1
    ORDER BY C.Fecha DESC, C.Hora DESC;
END
GO

PRINT '*** STORED PROCEDURES CRUD PRINCIPALES CREADOS ***';
GO

/*
==================================================================================
SCRIPT 05: STORED PROCEDURES DE FACTURAS - VeterinariaGenesisDB
==================================================================================
EJECUTAR DESPUÉS DE 04_StoredProcedures_CRUD.sql
==================================================================================
*/

USE VeterinariaGenesisDB;
GO

PRINT '--- Creando Stored Procedures de Facturas ---';
GO

-- ====================================================
-- SP: Crear Factura desde Cita
-- ====================================================
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

    IF EXISTS (SELECT 1 FROM Factura WHERE ID_Cita = @ID_Cita)
    BEGIN
        RAISERROR('La cita ya tiene una factura asociada.', 16, 1);
        RETURN;
    END

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
        INSERT INTO Factura (Fecha, Total, ID_Propietario, ID_Cita, EstadoPago)
        VALUES (GETDATE(), 0, @ID_Propietario, @ID_Cita, 'Pendiente');
        SET @ID_NuevaFactura = SCOPE_IDENTITY();

        INSERT INTO FacturaDetalle (ID_Factura, ID_Servicio, Cantidad, PrecioUnitario)
        VALUES (@ID_NuevaFactura, @ID_Servicio, 1, @CostoServicio);

        COMMIT TRANSACTION;
        SELECT @ID_NuevaFactura AS NuevaID_Factura;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- ====================================================
-- SP: Agregar Item a Factura
-- ====================================================
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
END
GO

-- ====================================================
-- SP: Pagar Factura
-- ====================================================
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
        SELECT @TotalFactura = Total, @ID_Cita = ID_Cita, @EstadoActual = EstadoPago
        FROM Factura WITH (UPDLOCK, HOLDLOCK, ROWLOCK)
        WHERE ID_Factura = @ID_Factura;

        IF @TotalFactura IS NULL
        BEGIN
            ROLLBACK TRANSACTION;
            RAISERROR('Factura no encontrada.', 16, 1);
            RETURN;
        END

        IF @EstadoActual != 'Pendiente'
        BEGIN
            ROLLBACK TRANSACTION;
            SET @MensajeEstado = 'La factura ya fue pagada o está en otro estado. Estado actual: ' + @EstadoActual;
            RAISERROR(@MensajeEstado, 16, 1);
            RETURN;
        END

        SELECT @PagosExistentes = COUNT(*)
        FROM Pago
        WHERE ID_Factura = @ID_Factura;

        IF @PagosExistentes > 0
        BEGIN
            ROLLBACK TRANSACTION;
            RAISERROR('Esta factura ya tiene un pago registrado. No se pueden procesar pagos duplicados.', 16, 1);
            RETURN;
        END

        IF @MontoPagado < @TotalFactura
        BEGIN
            ROLLBACK TRANSACTION;
            SET @MensajeMonto = 'El monto es insuficiente. El total de la factura es $' + CAST(@TotalFactura AS VARCHAR(20));
            RAISERROR(@MensajeMonto, 16, 1);
            RETURN;
        END

        INSERT INTO Pago (ID_Factura, MetodoPago, Monto, FechaPago)
        VALUES (@ID_Factura, @MetodoPago, @MontoPagado, GETDATE());

        UPDATE Factura 
        SET EstadoPago = 'Pagada' 
        WHERE ID_Factura = @ID_Factura 
          AND EstadoPago = 'Pendiente';

        IF @@ROWCOUNT = 0
        BEGIN
            ROLLBACK TRANSACTION;
            RAISERROR('Error al actualizar el estado de la factura. La factura puede haber sido pagada por otro proceso.', 16, 1);
            RETURN;
        END

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

-- ====================================================
-- SP: Buscar Factura por ID
-- ====================================================
IF OBJECT_ID('sp_Factura_BuscarPorID', 'P') IS NOT NULL DROP PROCEDURE sp_Factura_BuscarPorID;
GO
CREATE PROCEDURE sp_Factura_BuscarPorID
    @ID_Factura INT
AS
BEGIN
    SET NOCOUNT ON;
    
    IF NOT EXISTS (SELECT 1 FROM Factura WHERE ID_Factura = @ID_Factura)
    BEGIN
        RETURN;
    END
    
    SELECT 
        F.ID_Factura, F.Fecha, F.Total, F.ID_Propietario, F.ID_Cita, F.EstadoPago
    FROM Factura F
    WHERE F.ID_Factura = @ID_Factura;
    
    SELECT 
        FD.ID_FacturaDetalle, FD.ID_Factura, FD.ID_Servicio, FD.Cantidad, FD.PrecioUnitario, FD.Subtotal
    FROM FacturaDetalle FD
    WHERE FD.ID_Factura = @ID_Factura;
END
GO

-- ====================================================
-- SP: Listar Todas las Facturas
-- ====================================================
IF OBJECT_ID('sp_Factura_Listar', 'P') IS NOT NULL DROP PROCEDURE sp_Factura_Listar;
GO
CREATE PROCEDURE sp_Factura_Listar
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        F.ID_Factura, F.Fecha, F.Total, F.ID_Propietario, F.ID_Cita, F.EstadoPago
    FROM Factura F
    ORDER BY F.Fecha DESC, F.ID_Factura DESC;
END
GO

-- ====================================================
-- SP: Obtener Detalles de Factura
-- ====================================================
IF OBJECT_ID('sp_Factura_DetallesPorID', 'P') IS NOT NULL DROP PROCEDURE sp_Factura_DetallesPorID;
GO
CREATE PROCEDURE sp_Factura_DetallesPorID
    @ID_Factura INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        FD.ID_FacturaDetalle, FD.ID_Factura, FD.ID_Servicio, FD.Cantidad, FD.PrecioUnitario, FD.Subtotal
    FROM FacturaDetalle FD
    WHERE FD.ID_Factura = @ID_Factura;
END
GO

PRINT '*** STORED PROCEDURES DE FACTURAS CREADOS ***';
GO

/*
==================================================================================
SCRIPT 06: STORED PROCEDURES DE HISTORIAL CLÍNICO - VeterinariaGenesisDB
==================================================================================
EJECUTAR DESPUÉS DE 05_StoredProcedures_Facturas.sql
==================================================================================
*/

USE VeterinariaGenesisDB;
GO

PRINT '--- Creando Stored Procedures de Historial Clínico ---';
GO

-- ====================================================
-- SP: Obtener Historial Clínico Completo de una Mascota
-- ====================================================
IF OBJECT_ID('sp_Historial_ObtenerPorMascota', 'P') IS NOT NULL 
    DROP PROCEDURE sp_Historial_ObtenerPorMascota;
GO

CREATE PROCEDURE sp_Historial_ObtenerPorMascota
    @ID_Mascota INT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        'Cita' AS TipoEvento,
        CAST(C.ID_Cita AS VARCHAR(50)) AS ID_Evento,
        C.Fecha AS Fecha,
        C.Hora AS Hora,
        S.Nombre AS Descripcion,
        V.Nombre AS Veterinario,
        S.Costo AS Costo,
        C.Estado AS Estado,
        NULL AS Observaciones
    FROM Cita C
    INNER JOIN Servicio S ON C.ID_Servicio = S.ID_Servicio
    INNER JOIN Veterinario V ON C.ID_Veterinario = V.ID_Veterinario
    WHERE C.ID_Mascota = @ID_Mascota
    
    UNION ALL
    
    SELECT 
        'Tratamiento' AS TipoEvento,
        CAST(T.ID_Tratamiento AS VARCHAR(50)) AS ID_Evento,
        T.Fecha AS Fecha,
        NULL AS Hora,
        T.Diagnostico AS Descripcion,
        NULL AS Veterinario,
        NULL AS Costo,
        NULL AS Estado,
        NULL AS Observaciones
    FROM Tratamiento T
    WHERE T.ID_Mascota = @ID_Mascota
    
    UNION ALL
    
    SELECT 
        'Cirugía' AS TipoEvento,
        CAST(CIR.ID_Cirugia AS VARCHAR(50)) AS ID_Evento,
        CIR.Fecha AS Fecha,
        NULL AS Hora,
        CIR.Tipo + ' - ' + ISNULL(CIR.Descripcion, '') AS Descripcion,
        V.Nombre AS Veterinario,
        NULL AS Costo,
        NULL AS Estado,
        NULL AS Observaciones
    FROM Cirugia CIR
    INNER JOIN Veterinario V ON CIR.ID_Veterinario = V.ID_Veterinario
    WHERE CIR.ID_Mascota = @ID_Mascota
    
    UNION ALL
    
    SELECT 
        'Hospitalización' AS TipoEvento,
        CAST(H.ID_Hospitalizacion AS VARCHAR(50)) AS ID_Evento,
        H.FechaIngreso AS Fecha,
        NULL AS Hora,
        'Hospitalización' AS Descripcion,
        NULL AS Veterinario,
        NULL AS Costo,
        CASE WHEN H.FechaSalida IS NULL THEN 'En Curso' ELSE 'Finalizada' END AS Estado,
        H.Observaciones AS Observaciones
    FROM Hospitalizacion H
    WHERE H.ID_Mascota = @ID_Mascota
    
    UNION ALL
    
    SELECT 
        'Vacuna' AS TipoEvento,
        CAST(MV.ID_Vacuna AS VARCHAR(50)) AS ID_Evento,
        MV.FechaAplicacion AS Fecha,
        NULL AS Hora,
        VAC.Nombre + ' - ' + ISNULL(VAC.Dosis, '') AS Descripcion,
        NULL AS Veterinario,
        NULL AS Costo,
        CASE WHEN MV.FechaProximaDosis IS NULL OR MV.FechaProximaDosis > GETDATE() THEN 'Vigente' ELSE 'Vencida' END AS Estado,
        'Próxima dosis: ' + ISNULL(CONVERT(VARCHAR, MV.FechaProximaDosis, 103), 'N/A') AS Observaciones
    FROM Mascota_Vacuna MV
    INNER JOIN Vacuna VAC ON MV.ID_Vacuna = VAC.ID_Vacuna
    WHERE MV.ID_Mascota = @ID_Mascota
    
    ORDER BY Fecha DESC;
END
GO

-- ====================================================
-- SP: Buscar Mascotas por Nombre o Propietario
-- ====================================================
IF OBJECT_ID('sp_Mascota_BuscarParaHistorial', 'P') IS NOT NULL 
    DROP PROCEDURE sp_Mascota_BuscarParaHistorial;
GO

CREATE PROCEDURE sp_Mascota_BuscarParaHistorial
    @Busqueda VARCHAR(200) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        M.ID_Mascota,
        M.Nombre AS NombreMascota,
        M.Especie,
        M.Raza,
        M.Edad,
        P.ID_Propietario,
        P.Nombre + ' ' + P.Apellidos AS NombrePropietario,
        P.Telefono,
        P.Direccion
    FROM Mascota M
    INNER JOIN Propietario P ON M.ID_Propietario = P.ID_Propietario
    WHERE P.Activo = 1
        AND (
            @Busqueda IS NULL 
            OR M.Nombre LIKE '%' + @Busqueda + '%'
            OR P.Nombre LIKE '%' + @Busqueda + '%'
            OR P.Apellidos LIKE '%' + @Busqueda + '%'
            OR (P.Nombre + ' ' + P.Apellidos) LIKE '%' + @Busqueda + '%'
        )
    ORDER BY M.Nombre, P.Apellidos, P.Nombre;
END
GO

-- ====================================================
-- SP: Agregar Tratamiento
-- ====================================================
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

-- ====================================================
-- SP: Agregar Vacuna
-- ====================================================
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

PRINT '*** STORED PROCEDURES DE HISTORIAL CLÍNICO CREADOS ***';
GO

/*
==================================================================================
SCRIPT 07: STORED PROCEDURES DE DASHBOARD - VeterinariaGenesisDB
==================================================================================
EJECUTAR DESPUÉS DE 06_StoredProcedures_Historial.sql
==================================================================================
*/

USE VeterinariaGenesisDB;
GO

PRINT '--- Creando Stored Procedures de Dashboard ---';
GO

-- ====================================================
-- SP: Cirugías por Veterinario
-- ====================================================
IF OBJECT_ID('sp_Dashboard_CirugiasPorVeterinario', 'P') IS NOT NULL 
    DROP PROCEDURE sp_Dashboard_CirugiasPorVeterinario;
GO

CREATE PROCEDURE sp_Dashboard_CirugiasPorVeterinario
    @fechaInicio DATE = NULL,
    @fechaFin DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        V.ID_Veterinario,
        V.Nombre AS NombreVeterinario,
        V.Especialidad,
        COUNT(CIR.ID_Cirugia) AS CantidadCirugias,
        CAST(COUNT(CIR.ID_Cirugia) * 100.0 / NULLIF(
            (SELECT COUNT(*) FROM Cirugia CIR2 
             WHERE (@fechaInicio IS NULL OR CIR2.Fecha >= @fechaInicio)
                AND (@fechaFin IS NULL OR CIR2.Fecha <= @fechaFin)), 0) 
        AS DECIMAL(5,2)) AS PorcentajeTotal
    FROM Veterinario V
    LEFT JOIN Cirugia CIR ON V.ID_Veterinario = CIR.ID_Veterinario
        AND (@fechaInicio IS NULL OR CIR.Fecha >= @fechaInicio)
        AND (@fechaFin IS NULL OR CIR.Fecha <= @fechaFin)
    WHERE V.Activo = 1
    GROUP BY V.ID_Veterinario, V.Nombre, V.Especialidad
    HAVING COUNT(CIR.ID_Cirugia) > 0
    ORDER BY CantidadCirugias DESC;
END
GO

-- ====================================================
-- SP: Citas por Día de la Semana
-- ====================================================
IF OBJECT_ID('sp_Dashboard_CitasPorDiaSemana', 'P') IS NOT NULL 
    DROP PROCEDURE sp_Dashboard_CitasPorDiaSemana;
GO

CREATE PROCEDURE sp_Dashboard_CitasPorDiaSemana
    @fechaInicio DATE = NULL,
    @fechaFin DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        CASE DATEPART(WEEKDAY, C.Fecha)
            WHEN 1 THEN 'Domingo'
            WHEN 2 THEN 'Lunes'
            WHEN 3 THEN 'Martes'
            WHEN 4 THEN 'Miércoles'
            WHEN 5 THEN 'Jueves'
            WHEN 6 THEN 'Viernes'
            WHEN 7 THEN 'Sábado'
        END AS DiaSemana,
        COUNT(C.ID_Cita) AS CantidadCitas,
        COUNT(CASE WHEN C.Estado = 'Completada' THEN 1 END) AS CitasCompletadas,
        COUNT(CASE WHEN C.Estado = 'Cancelada' THEN 1 END) AS CitasCanceladas
    FROM Cita C
    WHERE (@fechaInicio IS NULL OR C.Fecha >= @fechaInicio)
        AND (@fechaFin IS NULL OR C.Fecha <= @fechaFin)
    GROUP BY DATEPART(WEEKDAY, C.Fecha)
    ORDER BY DATEPART(WEEKDAY, C.Fecha);
END
GO

-- ====================================================
-- SP: Productividad por Veterinario
-- ====================================================
IF OBJECT_ID('sp_Dashboard_ProductividadVeterinario', 'P') IS NOT NULL 
    DROP PROCEDURE sp_Dashboard_ProductividadVeterinario;
GO

CREATE PROCEDURE sp_Dashboard_ProductividadVeterinario
    @fechaInicio DATE = NULL,
    @fechaFin DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        V.ID_Veterinario,
        V.Nombre AS NombreVeterinario,
        V.Especialidad,
        COUNT(DISTINCT C.ID_Cita) AS TotalCitas,
        COUNT(DISTINCT CIR.ID_Cirugia) AS TotalCirugias,
        COUNT(DISTINCT T.ID_Tratamiento) AS TotalTratamientos,
        ISNULL(SUM(CASE WHEN F.EstadoPago = 'Pagada' THEN F.Total ELSE 0 END), 0) AS IngresosGenerados
    FROM Veterinario V
    LEFT JOIN Cita C ON V.ID_Veterinario = C.ID_Veterinario
        AND (@fechaInicio IS NULL OR C.Fecha >= @fechaInicio)
        AND (@fechaFin IS NULL OR C.Fecha <= @fechaFin)
    LEFT JOIN Cirugia CIR ON V.ID_Veterinario = CIR.ID_Veterinario
        AND (@fechaInicio IS NULL OR CIR.Fecha >= @fechaInicio)
        AND (@fechaFin IS NULL OR CIR.Fecha <= @fechaFin)
    LEFT JOIN Tratamiento T ON EXISTS (
        SELECT 1 FROM Cita C2 
        WHERE C2.ID_Veterinario = V.ID_Veterinario 
        AND C2.ID_Mascota = T.ID_Mascota
        AND (@fechaInicio IS NULL OR T.Fecha >= @fechaInicio)
        AND (@fechaFin IS NULL OR T.Fecha <= @fechaFin)
    )
    LEFT JOIN Factura F ON F.ID_Cita = C.ID_Cita
        AND (@fechaInicio IS NULL OR F.Fecha >= @fechaInicio)
        AND (@fechaFin IS NULL OR F.Fecha <= @fechaFin)
    WHERE V.Activo = 1
    GROUP BY V.ID_Veterinario, V.Nombre, V.Especialidad
    HAVING COUNT(DISTINCT C.ID_Cita) > 0 
        OR COUNT(DISTINCT CIR.ID_Cirugia) > 0
    ORDER BY TotalCitas DESC, IngresosGenerados DESC;
END
GO

PRINT '*** STORED PROCEDURES DE DASHBOARD CREADOS ***';
GO

/*
==================================================================================
SCRIPT 08: STORED PROCEDURES DE VACUNAS - VeterinariaGenesisDB
==================================================================================
EJECUTAR DESPUÉS DE 07_StoredProcedures_Dashboard.sql
==================================================================================
*/

USE VeterinariaGenesisDB;
GO

PRINT '--- Creando Stored Procedures de Vacunas ---';
GO

-- ====================================================
-- SP: Recordatorios de Vacunación
-- ====================================================
IF OBJECT_ID('sp_Vacuna_Recordatorios', 'P') IS NOT NULL 
    DROP PROCEDURE sp_Vacuna_Recordatorios;
GO

CREATE PROCEDURE sp_Vacuna_Recordatorios
    @DiasAnticipacion INT = 30
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        M.ID_Mascota,
        M.Nombre AS NombreMascota,
        M.Especie,
        M.Raza,
        P.ID_Propietario,
        P.Nombre + ' ' + P.Apellidos AS NombrePropietario,
        P.Telefono,
        P.Direccion,
        VAC.Nombre AS NombreVacuna,
        VAC.Dosis,
        MV.FechaAplicacion,
        MV.FechaProximaDosis,
        CASE 
            WHEN MV.FechaProximaDosis IS NULL THEN 'Sin próxima dosis programada'
            WHEN MV.FechaProximaDosis < GETDATE() THEN 'Vencida'
            WHEN MV.FechaProximaDosis <= DATEADD(DAY, @DiasAnticipacion, GETDATE()) THEN 'Por vencer'
            ELSE 'Vigente'
        END AS Estado,
        DATEDIFF(DAY, GETDATE(), MV.FechaProximaDosis) AS DiasRestantes
    FROM Mascota_Vacuna MV
    INNER JOIN Mascota M ON MV.ID_Mascota = M.ID_Mascota
    INNER JOIN Propietario P ON M.ID_Propietario = P.ID_Propietario
    INNER JOIN Vacuna VAC ON MV.ID_Vacuna = VAC.ID_Vacuna
    WHERE P.Activo = 1
        AND (
            MV.FechaProximaDosis IS NULL
            OR MV.FechaProximaDosis <= DATEADD(DAY, @DiasAnticipacion, GETDATE())
        )
    ORDER BY 
        CASE 
            WHEN MV.FechaProximaDosis IS NULL THEN 0
            WHEN MV.FechaProximaDosis < GETDATE() THEN 1
            ELSE 2
        END,
        MV.FechaProximaDosis ASC;
END
GO

PRINT '*** STORED PROCEDURES DE VACUNAS CREADOS ***';
GO

/*
==================================================================================
SCRIPT 09: STORED PROCEDURES DE REPORTES - VeterinariaGenesisDB
==================================================================================
EJECUTAR DESPUÉS DE 08_StoredProcedures_Vacunas.sql
==================================================================================
*/

USE VeterinariaGenesisDB;
GO

PRINT '--- Creando Stored Procedures de Reportes ---';
GO

-- ====================================================
-- SP: Reporte de Propietarios
-- ====================================================
CREATE OR ALTER PROCEDURE sp_Reporte_Propietarios
    @fechaInicio DATE = NULL,
    @fechaFin DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        P.ID_Propietario AS IdPropietario,
        P.Nombre + ' ' + P.Apellidos AS NombreCompleto,
        P.Telefono,
        P.Direccion,
        COUNT(DISTINCT F.ID_Factura) AS CantidadFacturas,
        ISNULL(SUM(CASE WHEN F.EstadoPago = 'Pagada' THEN F.Total ELSE 0 END), 0) AS TotalPagado,
        ISNULL(SUM(CASE WHEN F.EstadoPago = 'Pendiente' THEN F.Total ELSE 0 END), 0) AS TotalPendiente,
        COUNT(DISTINCT M.ID_Mascota) AS CantidadMascotas
    FROM Propietario P
    LEFT JOIN Factura F ON P.ID_Propietario = F.ID_Propietario
        AND (@fechaInicio IS NULL OR F.Fecha >= @fechaInicio)
        AND (@fechaFin IS NULL OR F.Fecha <= @fechaFin)
    LEFT JOIN Mascota M ON P.ID_Propietario = M.ID_Propietario
    WHERE P.Activo = 1
    GROUP BY P.ID_Propietario, P.Nombre, P.Apellidos, P.Telefono, P.Direccion
    ORDER BY TotalPagado DESC;
END
GO

-- ====================================================
-- SP: Reporte de Servicios Vendidos
-- ====================================================
CREATE OR ALTER PROCEDURE sp_Reporte_ServiciosVendidos
    @fechaInicio DATE = NULL,
    @fechaFin DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        S.ID_Servicio AS IdServicio,
        S.Nombre AS NombreServicio,
        S.Descripcion,
        S.Costo AS PrecioUnitario,
        SUM(FD.Cantidad) AS CantidadVendida,
        SUM(FD.Subtotal) AS TotalIngresos,
        COUNT(DISTINCT FD.ID_Factura) AS CantidadFacturas
    FROM Servicio S
    INNER JOIN FacturaDetalle FD ON S.ID_Servicio = FD.ID_Servicio
    INNER JOIN Factura F ON FD.ID_Factura = F.ID_Factura
    WHERE F.EstadoPago = 'Pagada'
        AND (@fechaInicio IS NULL OR F.Fecha >= @fechaInicio)
        AND (@fechaFin IS NULL OR F.Fecha <= @fechaFin)
    GROUP BY S.ID_Servicio, S.Nombre, S.Descripcion, S.Costo
    ORDER BY CantidadVendida DESC, TotalIngresos DESC;
END
GO

-- ====================================================
-- SP: Reporte de Citas por Veterinario
-- ====================================================
CREATE OR ALTER PROCEDURE sp_Reporte_CitasPorVeterinario
    @fechaInicio DATE = NULL,
    @fechaFin DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        V.ID_Veterinario AS IdVeterinario,
        V.Nombre AS NombreVeterinario,
        V.Especialidad,
        COUNT(C.ID_Cita) AS CantidadCitas,
        COUNT(CASE WHEN C.Estado = 'Completada' THEN 1 END) AS CitasCompletadas,
        COUNT(CASE WHEN C.Estado = 'Cancelada' THEN 1 END) AS CitasCanceladas,
        COUNT(CASE WHEN C.Estado = 'Programada' THEN 1 END) AS CitasProgramadas,
        ISNULL(SUM(CASE WHEN C.Estado = 'Completada' THEN S.Costo ELSE 0 END), 0) AS TotalIngresos
    FROM Veterinario V
    LEFT JOIN Cita C ON V.ID_Veterinario = C.ID_Veterinario
        AND (@fechaInicio IS NULL OR C.Fecha >= @fechaInicio)
        AND (@fechaFin IS NULL OR C.Fecha <= @fechaFin)
    LEFT JOIN Servicio S ON C.ID_Servicio = S.ID_Servicio
    WHERE V.Activo = 1
    GROUP BY V.ID_Veterinario, V.Nombre, V.Especialidad
    HAVING COUNT(C.ID_Cita) > 0
    ORDER BY CantidadCitas DESC, TotalIngresos DESC;
END
GO

-- ====================================================
-- SP: Reporte de Ingresos por Período
-- ====================================================
CREATE OR ALTER PROCEDURE sp_Reporte_IngresosPorPeriodo
    @fechaInicio DATE = NULL,
    @fechaFin DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;
    IF @fechaInicio IS NULL
        SET @fechaInicio = DATEADD(MONTH, -1, GETDATE());
    IF @fechaFin IS NULL
        SET @fechaFin = GETDATE();
    
    SELECT 
        CAST(F.Fecha AS DATE) AS Fecha,
        COUNT(DISTINCT F.ID_Factura) AS CantidadFacturas,
        COUNT(DISTINCT F.ID_Propietario) AS CantidadClientes,
        SUM(CASE WHEN F.EstadoPago = 'Pagada' THEN F.Total ELSE 0 END) AS IngresosPagados,
        SUM(CASE WHEN F.EstadoPago = 'Pendiente' THEN F.Total ELSE 0 END) AS IngresosPendientes,
        SUM(F.Total) AS TotalFacturado,
        SUM(CASE WHEN F.EstadoPago = 'Pagada' THEN 1 ELSE 0 END) AS FacturasPagadas,
        SUM(CASE WHEN F.EstadoPago = 'Pendiente' THEN 1 ELSE 0 END) AS FacturasPendientes
    FROM Factura F
    WHERE F.Fecha >= @fechaInicio
        AND F.Fecha <= @fechaFin
    GROUP BY CAST(F.Fecha AS DATE)
    ORDER BY Fecha DESC;
END
GO

PRINT '*** STORED PROCEDURES DE REPORTES CREADOS ***';
GO

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

/*
==================================================================================
SCRIPT 11: VISTAS - VeterinariaGenesisDB
==================================================================================
EJECUTAR DESPUÉS DE 10_StoredProcedures_Servicios.sql
==================================================================================
*/

USE VeterinariaGenesisDB;
GO

PRINT '--- Creando Vistas ---';
GO

-- ====================================================
-- VISTA: Propietarios Activos
-- ====================================================
IF OBJECT_ID('vw_PropietariosActivos', 'V') IS NOT NULL DROP VIEW vw_PropietariosActivos;
GO
CREATE VIEW vw_PropietariosActivos AS
SELECT ID_Propietario, Nombre, Apellidos, Direccion, Telefono 
FROM Propietario 
WHERE Activo = 1;
GO

-- ====================================================
-- VISTA: Mascotas con Propietario
-- ====================================================
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

-- ====================================================
-- VISTA: Veterinarios Activos
-- ====================================================
IF OBJECT_ID('vw_VeterinariosActivos', 'V') IS NOT NULL DROP VIEW vw_VeterinariosActivos;
GO
CREATE VIEW vw_VeterinariosActivos AS
SELECT ID_Veterinario, Nombre, Especialidad, Telefono, Correo 
FROM Veterinario 
WHERE Activo = 1;
GO

-- ====================================================
-- VISTA: Agenda de Citas
-- ====================================================
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

PRINT '*** VISTAS CREADAS EXITOSAMENTE ***';
GO

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

/*
==================================================================================
SCRIPT 13: DATOS DE EJEMPLO - VeterinariaGenesisDB
==================================================================================
Este script inserta todos los datos de ejemplo necesarios para probar la aplicación.
EJECUTAR ÚLTIMO, DESPUÉS DE 12_Usuarios_Permisos.sql

Contiene:
- Propietarios, Veterinarios, Servicios, Medicamentos, Vacunas
- Mascotas, Citas, Facturas, FacturaDetalle, Pagos
- Tratamientos, Hospitalizaciones, Cirugías, Mascota_Vacuna
==================================================================================
*/

USE VeterinariaGenesisDB;
GO

-- ====================================================
-- 1. TABLA: Propietario 
-- ====================================================
INSERT INTO Propietario (Nombre, Apellidos, Direccion, Telefono) VALUES
('Carlos', 'Hernández', 'Residencial Los Robles, A-10', '8881-1001'),
('Ana', 'Martínez', 'Barrio Monseñor Lezcano, Casa 20', '8881-1002'),
('Luis', 'García', 'Carretera a Masaya, Km 14', '8881-1003'),
('María', 'Rodríguez', 'Altamira D''Este, #45', '8881-1004'),
('Javier', 'López', 'Bello Horizonte, IV Etapa', '8881-1005'),
('Sofía', 'Pérez', 'Las Colinas, Calle Principal', '8881-1006'),
('Miguel', 'González', 'Villa Fontana, C-5', '8881-1007'),
('Lucía', 'Sánchez', 'Reparto San Juan, Casa 80', '8881-1008'),
('Diego', 'Ramírez', 'Planes de Altamira, #12', '8881-1009'),
('Elena', 'Flores', 'Camino de Oriente, Mod C-2', '8881-1010'),
('Pedro', 'Díaz', 'Masaya, Barrio San Miguel', '8881-1011'),
('Laura', 'Torres', 'Granada, Calle La Calzada', '8881-1012'),
('Sergio', 'Morales', 'León, Reparto Fátima', '8881-1013'),
('Valeria', 'Cruz', 'Santo Domingo, Km 10', '8881-1014'),
('Andrés', 'Ortiz', 'Esquipulas, Km 11.5', '8881-1015'),
('Gabriela', 'Reyes', 'Ticuantepe, Lotificación 30', '8881-1016'),
('Fernando', 'Jiménez', 'Veracruz, Condominio 4', '8881-1017'),
('Paula', 'Moreno', 'Nindirí, Km 20', '8881-1018'),
('Ricardo', 'Alonso', 'Reparto Tiscapa, #5', '8881-1019'),
('Camila', 'Gutiérrez', 'Bolonia, Hotel Mansión Teodolinda 2c. al Sur', '8881-1020'),
('Mateo', 'Silva', 'Catarina, Mirador', '8881-1021'),
('Isabela', 'Mendoza', 'Jinotepe, Carazo', '8881-1022'),
('Daniel', 'Castillo', 'Rivas, San Juan del Sur', '8881-1023'),
('Alejandra', 'Navarro', 'Estelí, Barrio Nuevo', '8881-1024'),
('Jorge', 'Castro', 'Matagalpa, Centro', '8881-1025'),
('Carmen', 'Ruiz', 'Chinandega, Reparto Los Maderos', '8881-1026'),
('Roberto', 'Vargas', 'Pochomil, Casa 15', '8881-1027'),
('Patricia', 'Medina', 'Montelimar, Playa', '8881-1028'),
('Francisco', 'Ramos', 'Boaco, Barrio San Miguel', '8881-1029'),
('Natalia', 'Vega', 'Juigalpa, Chontales', '8881-1030');
GO

-- ====================================================
-- 2. TABLA: Veterinario 
-- ====================================================
INSERT INTO Veterinario (Nombre, Especialidad) VALUES
('Dr. Alejandro Solís', 'Cirugía General'),
('Dra. Beatriz Peña', 'Medicina Interna'),
('Dr. Miguel Cifuentes', 'Dermatología'),
('Dra. Laura Campos', 'Animales Exóticos'),
('Dr. Roberto Cruz', 'Consulta General'),
('Dra. Sandra Guido', 'Cardiología'),
('Dr. Esteban Lacayo', 'Neurología'),
('Dra. Fabiola Téllez', 'Oncología'),
('Dr. Norman Gaitán', 'Fisioterapia'),
('Dra. Rebeca Argüello', 'Medicina Felina'),
('Dr. Arturo Casco', 'Ortopedia'),
('Dra. Melissa Baltodano', 'Consulta General'),
('Dr. Enrique Fonseca', 'Oftalmología'),
('Dra. Victoria Ponce', 'Odontología Veterinaria'),
('Dr. Julio Bendaña', 'Cirugía Ortopédica'),
('Dra. Karen Mendieta', 'Medicina Preventiva'),
('Dr. Oscar Valle', 'Consulta General'),
('Dra. Claudia Paguaga', 'Endocrinología'),
('Dr. Luis Felipe Román', 'Anestesiología'),
('Dra. Ana Cecilia Gallo', 'Laboratorio Clínico'),
('Dr. Marlon Estrada', 'Cirugía General'),
('Dra. Gabriela Solórzano', 'Medicina Interna'),
('Dr. Ariel Dávila', 'Dermatología'),
('Dra. Patricia Ocampo', 'Animales Exóticos'),
('Dr. Félix Rivas', 'Consulta General'),
('Dra. Marcela Sevilla', 'Cardiología'),
('Dr. Xavier Torres', 'Neurología'),
('Dra. Ingrid Zamora', 'Oncología'),
('Dr. Guillermo Terán', 'Fisioterapia'),
('Dra. Carolina Ortega', 'Medicina Felina');
GO

-- ====================================================
-- 3. TABLA: Servicio 
-- ====================================================
INSERT INTO Servicio (Nombre, Descripcion, Costo) VALUES
('Consulta General', 'Revisión estándar de salud', 35.00),
('Consulta Especializada', 'Consulta con especialista (Cardiología, Dermatología, etc.)', 50.00),
('Vacuna Rabia', 'Dosis anual antirrábica', 20.00),
('Vacuna Múltiple (Perro)', 'Refuerzo anual Parvo, Moquillo, Hepatitis, Lepto', 30.00),
('Vacuna Triple (Gato)', 'Refuerzo anual Rino, Calici, Panleuco', 28.00),
('Desparasitación Interna (Perro)', 'Pastilla según peso (precio base)', 15.00),
('Desparasitación Interna (Gato)', 'Pastilla o pipeta (precio base)', 12.00),
('Aplicación Pipeta (Pulgas/Garrapatas)', 'Producto antiparasitario externo (base)', 18.00),
('Examen Heces (Coprológico)', 'Análisis de parásitos en heces', 22.00),
('Hemograma Completo', 'Análisis de sangre completo', 40.00),
('Química Sanguínea (Panel Básico)', 'Revisión de función renal y hepática', 38.00),
('Urianálisis', 'Análisis físico-químico de orina', 25.00),
('Radiografía (Dos Placas)', 'Estudio radiográfico estándar', 55.00),
('Ultrasonido Abdominal', 'Ecografía de órganos internos', 60.00),
('Ecocardiograma', 'Ultrasonido especializado del corazón', 85.00),
('Hospitalización (Día)', 'Cuidado intensivo, monitoreo y fluidoterapia (base)', 80.00),
('Hospitalización (Medio Día)', 'Monitoreo y tratamiento (menos de 12h)', 45.00),
('Cirugía Esterilización (Gato)', 'Ovariohisterectomía felina', 80.00),
('Cirugía Esterilización (Gata)', 'Ovariohisterectomía felina', 95.00),
('Cirugía Esterilización (Perro Macho)', 'Orquiectomía canina (precio base)', 120.00),
('Cirugía Esterilización (Perra)', 'Ovariohisterectomía canina (precio base)', 150.00),
('Cirugía Menor (Suturas)', 'Cierre de heridas simples (base)', 65.00),
('Limpieza Dental (Profilaxis)', 'Limpieza con ultrasonido (sin extracciones)', 110.00),
('Extracción Dental Simple', 'Extracción de pieza dental (por pieza)', 30.00),
('Toma de Presión Arterial', 'Medición de presión en consulta', 15.00),
('Microchip (Implantación)', 'Implantación y registro de microchip', 40.00),
('Certificado de Salud (Viaje)', 'Emisión de certificado para viaje nacional', 25.00),
('Baño Medicado (Pequeño)', 'Baño terapéutico dermatológico', 20.00),
('Corte de Pelo (Grooming Básico)', 'Corte higiénico y baño (base)', 30.00),
('Eutanasia', 'Procedimiento humanitario (incluye sedación)', 60.00);
GO

-- ====================================================
-- 4. TABLA: Medicamento (CORREGIDO: sin Dosis)
-- ====================================================
INSERT INTO Medicamento (Nombre) VALUES
('Amoxicilina + Ac. Clavulánico'),
('Prednisona'),
('Meloxicam (Perro)'),
('Meloxicam (Gato)'),
('Furosemida'),
('Enalapril'),
('Carprofeno (Rimadyl)'),
('Gabapentina'),
('Tramadol'),
('Metronidazol'),
('Doxiciclina'),
('Cefalexina'),
('Omeprazol'),
('Sucralfato'),
('Ondansetrón (Inyectable)'),
('Maropitant (Cerenia)'),
('Ivermectina'),
('Selamectina (Revolution)'),
('Fipronil (Frontline)'),
('Praziquantel (Droncit)'),
('Tilosina'),
('Diazepam'),
('Propofol'),
('Isoflurano'),
('Clorhexidina (Solución)'),
('Yodo Povidona'),
('Suero Ringer Lactato'),
('Suero Salino 0.9%'),
('Vitamina K (Inyectable)'),
('Atropina (Inyectable)');
GO

-- ====================================================
-- 5. TABLA: Vacuna 
-- ====================================================
INSERT INTO Vacuna (Nombre, Dosis) VALUES
('Rabia (Anual) - Lote R100A', '1ml'),
('Rabia (Anual) - Lote R100B', '1ml'),
('Rabia (Refuerzo 3 años) - Lote R301A', '1ml'),
('Múltiple Canina (Cachorro 1) - Lote MC101', '1ml'),
('Múltiple Canina (Cachorro 2) - Lote MC102', '1ml'),
('Múltiple Canina (Cachorro 3) - Lote MC103', '1ml'),
('Múltiple Canina (Refuerzo Anual) - Lote MCA10', '1ml'),
('Múltiple Canina + Lepto (Anual) - Lote MCL20', '1ml'),
('KC (Bordetella Oral) - Lote KCO30', '0.5ml'),
('KC (Bordetella Inyectable) - Lote KCI31', '1ml'),
('Triple Felina (Gatito 1) - Lote TF01', '1ml'),
('Triple Felina (Gatito 2) - Lote TF02', '1ml'),
('Triple Felina (Refuerzo Anual) - Lote TFA1', '1ml'),
('Leucemia Felina (Gatito 1) - Lote LF10', '0.5ml'),
('Leucemia Felina (Gatito 2) - Lote LF11', '0.5ml'),
('Leucemia Felina (Refuerzo Anual) - Lote LFA2', '0.5ml'),
('VIF (SIDA Felino) - Lote VIF01', '0.5ml'),
('PIF (Peritonitis Infecciosa Felina) - Lote PIF02', '0.5ml'),
('Giardia (Preventiva Canina) - Lote GIA10', '1ml'),
('Leptospira (Refuerzo semestral) - Lote LEP50', '1ml'),
('Múltiple Canina (Puppy DP) - Lote DP01', '1ml'),
('Rabia (Anual) - Lote R100C', '1ml'),
('Múltiple Canina (Refuerzo Anual) - Lote MCA11', '1ml'),
('Triple Felina (Refuerzo Anual) - Lote TFA2', '1ml'),
('Leucemia Felina (Refuerzo Anual) - Lote LFA3', '0.5ml'),
('KC (Bordetella Oral) - Lote KCO31', '0.5ml'),
('Rabia (Anual) - Lote R100D', '1ml'),
('Múltiple Canina + Lepto (Anual) - Lote MCL21', '1ml'),
('Triple Felina (Gatito 1) - Lote TF03', '1ml'),
('Múltiple Canina (Cachorro 1) - Lote MC104', '1ml');
GO

-- ====================================================
-- 6. TABLA: Mascota 
-- ====================================================
INSERT INTO Mascota (Nombre, Especie, Raza, Edad, Sexo, ID_Propietario) VALUES
('Max', 'Perro', 'Labrador', 5, 'Macho', 1),
('Luna', 'Gato', 'Siamés', 3, 'Hembra', 2),
('Rocky', 'Perro', 'Pastor Alemán', 7, 'Macho', 1),
('Nala', 'Gato', 'Mestizo', 2, 'Hembra', 3),
('Coco', 'Perro', 'Bulldog Francés', 4, 'Macho', 4),
('Simba', 'Gato', 'Persa', 6, 'Macho', 5),
('Lola', 'Perro', 'Pug', 1, 'Hembra', 6),
('Thor', 'Perro', 'Rottweiler', 3, 'Macho', 7),
('Mía', 'Gato', 'Angora', 8, 'Hembra', 8),
('Toby', 'Perro', 'Golden Retriever', 0, 'Macho', 9),
('Kiwi', 'Ave', 'Perico Australiano', 2, 'Macho', 10),
('Bella', 'Perro', 'Chihuahua', 10, 'Hembra', 11),
('Zeus', 'Perro', 'Husky Siberiano', 4, 'Macho', 12),
('Frida', 'Gato', 'Mestizo', 5, 'Hembra', 13),
('Bruno', 'Perro', 'Boxer', 6, 'Macho', 14),
('Oreo', 'Gato', 'Doméstico Pelo Corto', 2, 'Macho', 15),
('Daisy', 'Perro', 'Beagle', 3, 'Hembra', 16),
('Milo', 'Perro', 'Shih Tzu', 1, 'Macho', 17),
('Cleo', 'Gato', 'Sphynx', 4, 'Hembra', 18),
('Leo', 'Perro', 'Doberman', 2, 'Macho', 19),
('Jack', 'Perro', 'Jack Russell', 9, 'Macho', 20),
('Shadow', 'Gato', 'Maine Coon', 5, 'Macho', 21),
('Molly', 'Perro', 'Cocker Spaniel', 7, 'Hembra', 22),
('Apolo', 'Perro', 'Gran Danés', 3, 'Macho', 23),
('Pelusa', 'Conejo', 'Cabeza de León', 1, 'Hembra', 24),
('Pipo', 'Perro', 'Mestizo', 8, 'Macho', 25),
('Nina', 'Gato', 'Ragdoll', 2, 'Hembra', 26),
('Chispa', 'Perro', 'Caniche (Toy)', 4, 'Hembra', 27),
('Buddy', 'Perro', 'Mestizo', 6, 'Macho', 28),
('Misha', 'Gato', 'Azul Ruso', 3, 'Hembra', 29),
('Hachi', 'Perro', 'Akita', 5, 'Macho', 30),
('Pancha', 'Tortuga', 'De Orejas Rojas', 15, 'Hembra', 10),
('Copito', 'Hámster', 'Sirio', 1, 'Macho', 15),
('Felix', 'Gato', 'Doméstico Pelo Corto', 1, 'Macho', 2),
('Sasha', 'Perro', 'Pastor Belga', 2, 'Hembra', 7);
GO

-- NOTA: La tabla HistoriaClinica no existe en el esquema, se omite esta sección
-- ====================================================
-- 7. TABLA: Cita
-- ====================================================
INSERT INTO Cita (Fecha, Hora, ID_Mascota, ID_Veterinario, ID_Servicio) VALUES
-- Citas de Consulta General (ID_Servicio = 1)
('2024-01-05', '10:00:00', 1, 5, 1),   -- Max (Labrador) con Dr. Roberto Cruz
('2024-01-05', '10:30:00', 2, 10, 1),  -- Luna (Siamés) con Dra. Rebeca Argüello (Medicina Felina)
('2024-01-05', '11:00:00', 4, 10, 1),  -- Nala (Gato)
('2024-01-06', '09:00:00', 5, 5, 1),   -- Coco (Bulldog Francés)
('2024-01-06', '09:30:00', 7, 12, 1),  -- Lola (Pug) con Dra. Melissa Baltodano
('2024-01-06', '10:00:00', 8, 5, 1),   -- Thor (Rottweiler)
('2024-01-07', '14:00:00', 12, 17, 1), -- Bella (Chihuahua) con Dr. Oscar Valle
('2024-01-07', '15:00:00', 16, 25, 1), -- Oreo (Gato) con Dr. Félix Rivas
('2024-01-08', '11:30:00', 21, 2, 1),  -- Jack (Jack Russell) con Dra. Beatriz Peña
('2024-01-08', '12:00:00', 25, 25, 1), -- Pelusa (Conejo)
-- Citas de Vacunación (ID_Servicio: 3 (Rabia), 4 (Múltiple Canina), 5 (Triple Felina))
('2024-01-10', '08:00:00', 1, 16, 4),  -- Max (Labrador) con Dra. Karen Mendieta (Preventiva)
('2024-01-10', '08:30:00', 2, 16, 5),  -- Luna (Gato)
('2024-01-10', '09:00:00', 10, 16, 4), -- Toby (Golden Retriever)
('2024-01-11', '16:00:00', 14, 16, 5), -- Frida (Gato)
('2024-01-11', '16:30:00', 18, 16, 5), -- Cleo (Gato)
('2024-01-12', '10:00:00', 22, 16, 3), -- Shadow (Maine Coon)
('2024-01-12', '10:30:00', 27, 16, 5), -- Nina (Ragdoll)
('2024-01-12', '11:00:00', 33, 16, 3), -- Copito (Hamster) - Vacunación atípica o desparasitación
-- Citas Especializadas (ID_Servicio: 2 (Especializada), 13 (Radiografía), 14 (Ultrasonido))
('2024-01-15', '14:00:00', 3, 2, 2),   -- Rocky (Pastor Alemán) con Dra. Beatriz Peña (Medicina Interna)
('2024-01-15', '14:30:00', 5, 3, 2),   -- Coco (Bulldog Francés) con Dr. Miguel Cifuentes (Dermatología)
('2024-01-16', '10:00:00', 8, 6, 15),  -- Thor (Rottweiler) con Dra. Sandra Guido (Cardiología) - Ecocardiograma
('2024-01-16', '11:00:00', 13, 7, 2),  -- Zeus (Husky) con Dr. Esteban Lacayo (Neurología)
('2024-01-17', '15:00:00', 19, 13, 2), -- Leo (Doberman) con Dr. Enrique Fonseca (Oftalmología)
('2024-01-17', '16:00:00', 29, 23, 2), -- Buddy (Mestizo) con Dr. Ariel Dávila (Dermatología)
('2024-01-18', '09:00:00', 35, 1, 13), -- Sasha (Pastor Belga) con Dr. Alejandro Solís (Cirugía) - Pre-quirúrgica
-- Citas de Control (ID_Servicio: 1 (Consulta), 9 (Heces), 10 (Hemograma))
('2024-01-20', '10:00:00', 1, 5, 10),
('2024-01-20', '10:30:00', 2, 10, 9),
('2024-01-21', '09:00:00', 4, 12, 1),
('2024-01-21', '09:30:00', 6, 17, 1),
('2024-01-22', '14:00:00', 9, 5, 10),
('2024-01-22', '14:30:00', 15, 25, 9),
-- Más Citas Generales y de Vacunación para superar 100
('2024-01-25', '10:00:00', 3, 5, 4),
('2024-01-25', '10:30:00', 4, 10, 5),
('2024-01-26', '09:00:00', 5, 5, 1),
('2024-01-26', '09:30:00', 6, 12, 1),
('2024-01-27', '14:00:00', 7, 17, 4),
('2024-01-27', '15:00:00', 8, 25, 1),
('2024-01-28', '11:30:00', 9, 2, 1),
('2024-01-28', '12:00:00', 10, 10, 4),
('2024-01-29', '08:00:00', 11, 4, 1),
('2024-01-29', '08:30:00', 12, 5, 1),
('2024-01-30', '09:00:00', 13, 12, 1),
('2024-01-30', '09:30:00', 14, 17, 5),
('2024-01-31', '16:00:00', 15, 25, 1),
('2024-01-31', '16:30:00', 16, 2, 5),
('2024-02-01', '10:00:00', 17, 12, 1),
('2024-02-01', '10:30:00', 18, 10, 5),
('2024-02-02', '11:00:00', 19, 5, 1),
('2024-02-02', '11:30:00', 20, 12, 4),
('2024-02-03', '14:00:00', 21, 17, 1),
('2024-02-03', '14:30:00', 22, 25, 5),
('2024-02-04', '09:00:00', 23, 2, 1),
('2024-02-04', '09:30:00', 24, 10, 1),
('2024-02-05', '10:00:00', 25, 5, 1),
('2024-02-05', '10:30:00', 26, 12, 1),
('2024-02-06', '11:00:00', 27, 17, 5),
('2024-02-06', '11:30:00', 28, 25, 4),
('2024-02-07', '14:00:00', 29, 2, 1),
('2024-02-07', '14:30:00', 30, 10, 5),
('2024-02-08', '09:00:00', 31, 5, 4),
('2024-02-08', '09:30:00', 32, 4, 1),
('2024-02-09', '10:00:00', 33, 12, 1),
('2024-02-09', '10:30:00', 34, 10, 5),
('2024-02-10', '11:00:00', 35, 5, 1),
-- Más Citas Especializadas, Limpieza Dental (23), Desparasitación (6, 7)
('2024-02-12', '15:00:00', 5, 14, 23), -- Coco (Bulldog Francés) - Limpieza Dental con Dra. Victoria Ponce
('2024-02-12', '16:00:00', 19, 15, 2), -- Leo (Doberman) - Ortopedia con Dr. Julio Bendaña
('2024-02-13', '10:00:00', 23, 21, 2), -- Apolo (Gran Danés) - Cirugía con Dr. Marlon Estrada (Pre-op)
('2024-02-13', '11:00:00', 3, 22, 2),  -- Rocky (Pastor Alemán) - Interna con Dra. Gabriela Solórzano
('2024-02-14', '08:00:00', 1, 16, 6),  -- Max - Desparasitación Perro
('2024-02-14', '08:30:00', 2, 16, 7),  -- Luna - Desparasitación Gato
('2024-02-14', '09:00:00', 3, 16, 6),
('2024-02-15', '14:00:00', 4, 16, 7),
('2024-02-15', '14:30:00', 5, 16, 6),
('2024-02-16', '10:00:00', 6, 16, 7),
('2024-02-16', '10:30:00', 7, 16, 6),
('2024-02-17', '11:00:00', 8, 16, 6),
('2024-02-17', '11:30:00', 9, 16, 6),
('2024-02-18', '09:00:00', 10, 16, 6),
('2024-02-18', '09:30:00', 12, 16, 6),
('2024-02-19', '14:00:00', 13, 16, 1),
('2024-02-19', '14:30:00', 14, 16, 7),
('2024-02-20', '10:00:00', 15, 16, 1),
('2024-02-20', '10:30:00', 16, 16, 7),
('2024-02-21', '11:00:00', 17, 16, 1),
('2024-02-21', '11:30:00', 18, 16, 7),
('2024-02-22', '14:00:00', 19, 16, 1),
('2024-02-22', '14:30:00', 20, 16, 6),
('2024-02-23', '09:00:00', 21, 16, 1),
('2024-02-23', '09:30:00', 22, 16, 7),
('2024-02-24', '10:00:00', 23, 16, 6),
('2024-02-24', '10:30:00', 24, 16, 1),
('2024-02-25', '11:00:00', 25, 16, 1),
('2024-02-25', '11:30:00', 26, 16, 1),
('2024-02-26', '14:00:00', 27, 16, 7),
('2024-02-26', '14:30:00', 28, 16, 6),
('2024-02-27', '09:00:00', 29, 16, 1),
('2024-02-27', '09:30:00', 30, 16, 7),
('2024-02-28', '10:00:00', 31, 16, 6),
('2024-02-28', '10:30:00', 32, 16, 1),
('2024-02-29', '11:00:00', 33, 16, 1),
('2024-02-29', '11:30:00', 34, 16, 7),
('2024-03-01', '14:00:00', 35, 16, 6),
-- Más Citas de chequeo general
('2024-03-02', '10:00:00', 1, 5, 1),
('2024-03-02', '10:30:00', 2, 10, 1),
('2024-03-03', '09:00:00', 3, 5, 1),
('2024-03-03', '09:30:00', 4, 10, 1),
('2024-03-04', '14:00:00', 5, 12, 1),
('2024-03-04', '14:30:00', 6, 17, 1),
('2024-03-05', '10:00:00', 7, 25, 1),
('2024-03-05', '10:30:00', 8, 2, 1),
('2024-03-06', '11:00:00', 9, 10, 1),
('2024-03-06', '11:30:00', 10, 5, 1),
('2024-03-07', '14:00:00', 11, 4, 1),
('2024-03-07', '14:30:00', 12, 12, 1),
('2024-03-08', '09:00:00', 13, 17, 1),
('2024-03-08', '09:30:00', 14, 25, 1),
('2024-03-09', '10:00:00', 15, 2, 1),
('2024-03-09', '10:30:00', 16, 10, 1),
('2024-03-10', '11:00:00', 17, 5, 1),
('2024-03-10', '11:30:00', 18, 12, 1),
('2024-03-11', '14:00:00', 19, 17, 1),
('2024-03-11', '14:30:00', 20, 25, 1),
('2024-03-12', '09:00:00', 21, 2, 1),
('2024-03-12', '09:30:00', 22, 10, 1),
('2024-03-13', '10:00:00', 23, 5, 1),
('2024-03-13', '10:30:00', 24, 12, 1),
('2024-03-14', '11:00:00', 25, 17, 1),
('2024-03-14', '11:30:00', 26, 25, 1),
('2024-03-15', '14:00:00', 27, 2, 1),
('2024-03-15', '14:30:00', 28, 10, 1),
('2024-03-16', '09:00:00', 29, 5, 1),
('2024-03-16', '09:30:00', 30, 12, 1),
('2024-03-17', '10:00:00', 31, 17, 1),
('2024-03-17', '10:30:00', 32, 25, 1),
('2024-03-18', '11:00:00', 33, 2, 1),
('2024-03-18', '11:30:00', 34, 10, 1),
('2024-03-19', '14:00:00', 35, 5, 1),
-- Más citas para desparasitación
('2024-03-20', '08:00:00', 1, 16, 6),
('2024-03-20', '08:30:00', 2, 16, 7),
('2024-03-20', '09:00:00', 3, 16, 6),
('2024-03-21', '14:00:00', 4, 16, 7),
('2024-03-21', '14:30:00', 5, 16, 6),
('2024-03-22', '10:00:00', 6, 16, 7),
('2024-03-22', '10:30:00', 7, 16, 6),
('2024-03-23', '11:00:00', 8, 16, 6),
('2024-03-23', '11:30:00', 9, 16, 6),
('2024-03-24', '09:00:00', 10, 16, 6),
('2024-03-24', '09:30:00', 11, 16, 1), -- Consulta de control
('2024-03-25', '14:00:00', 12, 16, 6),
('2024-03-25', '14:30:00', 13, 16, 1),
('2024-03-26', '10:00:00', 14, 16, 7),
('2024-03-26', '10:30:00', 15, 16, 1),
('2024-03-27', '11:00:00', 16, 16, 7),
('2024-03-27', '11:30:00', 17, 16, 1),
('2024-03-28', '14:00:00', 18, 16, 7),
('2024-03-28', '14:30:00', 19, 16, 1),
('2024-03-29', '09:00:00', 20, 16, 6),
('2024-03-29', '09:30:00', 21, 16, 1),
('2024-03-30', '10:00:00', 22, 16, 7),
('2024-03-30', '10:30:00', 23, 16, 6),
('2024-03-31', '11:00:00', 24, 16, 1),
('2024-03-31', '11:30:00', 25, 16, 1),
('2024-04-01', '14:00:00', 26, 16, 1),
('2024-04-01', '14:30:00', 27, 16, 7),
('2024-04-02', '09:00:00', 28, 16, 6),
('2024-04-02', '09:30:00', 29, 16, 1),
('2024-04-03', '10:00:00', 30, 16, 7),
('2024-04-03', '10:30:00', 31, 16, 6),
('2024-04-04', '11:00:00', 32, 16, 1),
('2024-04-04', '11:30:00', 33, 16, 1),
('2024-04-05', '14:00:00', 34, 16, 7),
('2024-04-05', '14:30:00', 35, 16, 6);
GO

-- ====================================================
-- 8. TABLA: Factura (CORREGIDO: todas con EstadoPago = 'Pagada')
-- ====================================================
INSERT INTO Factura (Fecha, Total, ID_Propietario, ID_Cita, EstadoPago) VALUES
-- Las primeras facturas coinciden con las primeras citas
('2024-01-05', 35.00, 1, 1, 'Pagada'),   -- Max, Consulta General
('2024-01-05', 35.00, 2, 2, 'Pagada'),   -- Luna, Consulta General
('2024-01-05', 35.00, 3, 3, 'Pagada'),   -- Nala, Consulta General
('2024-01-06', 35.00, 4, 4, 'Pagada'),   -- Coco, Consulta General
('2024-01-06', 35.00, 6, 6, 'Pagada'),   -- Lola, Consulta General
('2024-01-06', 35.00, 7, 7, 'Pagada'),   -- Thor, Consulta General
('2024-01-07', 35.00, 11, 11, 'Pagada'),  -- Bella, Consulta General
('2024-01-07', 35.00, 15, 15, 'Pagada'),  -- Oreo, Consulta General
('2024-01-08', 35.00, 20, 20, 'Pagada'),  -- Jack, Consulta General
('2024-01-08', 35.00, 24, 25, 'Pagada'), -- Pelusa, Consulta General
('2024-01-10', 30.00, 1, 1, 'Pagada'),  -- Max, Vacuna Múltiple
('2024-01-10', 28.00, 2, 2, 'Pagada'),  -- Luna, Triple Felina
('2024-01-10', 30.00, 9, 9, 'Pagada'),  -- Toby, Vacuna Múltiple
('2024-01-11', 28.00, 13, 13, 'Pagada'), -- Frida, Triple Felina
('2024-01-11', 28.00, 18, 18, 'Pagada'), -- Cleo, Triple Felina
('2024-01-12', 20.00, 21, 21, 'Pagada'), -- Shadow, Vacuna Rabia
('2024-01-12', 28.00, 26, 26, 'Pagada'), -- Nina, Triple Felina
('2024-01-12', 20.00, 15, 15, 'Pagada'), -- Copito, Vacuna Rabia (simulado)
('2024-01-15', 50.00, 1, 1, 'Pagada'),  -- Rocky, Consulta Especializada
('2024-01-15', 50.00, 4, 4, 'Pagada'),  -- Coco, Consulta Especializada
('2024-01-16', 85.00, 7, 7, 'Pagada'), -- Thor, Ecocardiograma
('2024-01-16', 50.00, 12, 12, 'Pagada'), -- Zeus, Consulta Especializada
('2024-01-17', 50.00, 19, 19, 'Pagada'), -- Leo, Consulta Especializada
('2024-01-17', 50.00, 28, 29, 'Pagada'), -- Buddy, Consulta Especializada
('2024-01-18', 55.00, 7, 7, 'Pagada'), -- Sasha, Radiografía
('2024-01-20', 40.00, 1, 1, 'Pagada'), -- Max, Hemograma
('2024-01-20', 22.00, 2, 2, 'Pagada'),  -- Luna, Examen Heces
('2024-01-21', 35.00, 3, 3, 'Pagada'),
('2024-01-21', 35.00, 5, 5, 'Pagada'),
('2024-01-22', 40.00, 8, 8, 'Pagada'),
('2024-01-22', 22.00, 14, 14, 'Pagada'),
('2024-01-25', 30.00, 1, 1, 'Pagada'),
('2024-01-25', 28.00, 2, 3, 'Pagada'),
('2024-01-26', 35.00, 4, 4, 'Pagada'),
('2024-01-26', 35.00, 5, 5, 'Pagada'),
('2024-01-27', 30.00, 6, 6, 'Pagada'),
('2024-01-27', 35.00, 7, 7, 'Pagada'),
('2024-01-28', 35.00, 8, 8, 'Pagada'),
('2024-01-28', 30.00, 9, 9, 'Pagada'),
('2024-01-29', 35.00, 10, 10, 'Pagada'),
('2024-01-29', 35.00, 11, 11, 'Pagada'),
('2024-01-30', 35.00, 12, 12, 'Pagada'),
('2024-01-30', 28.00, 13, 13, 'Pagada'),
('2024-01-31', 35.00, 14, 14, 'Pagada'),
('2024-01-31', 28.00, 15, 15, 'Pagada'),
('2024-02-01', 35.00, 16, 16, 'Pagada'),
('2024-02-01', 28.00, 17, 17, 'Pagada'),
('2024-02-02', 35.00, 18, 18, 'Pagada'),
('2024-02-02', 30.00, 19, 19, 'Pagada'),
('2024-02-03', 35.00, 20, 20, 'Pagada'),
('2024-02-03', 28.00, 21, 21, 'Pagada'),
('2024-02-04', 35.00, 22, 22, 'Pagada'),
('2024-02-04', 35.00, 23, 23, 'Pagada'),
('2024-02-05', 35.00, 24, 24, 'Pagada'),
('2024-02-05', 35.00, 25, 25, 'Pagada'),
('2024-02-06', 28.00, 26, 26, 'Pagada'),
('2024-02-06', 30.00, 27, 27, 'Pagada'),
('2024-02-07', 35.00, 28, 28, 'Pagada'),
('2024-02-07', 28.00, 29, 29, 'Pagada'),
('2024-02-08', 30.00, 30, 30, 'Pagada'),
('2024-02-08', 35.00, 10, 10, 'Pagada'),
('2024-02-09', 35.00, 15, 15, 'Pagada'),
('2024-02-09', 28.00, 2, 2, 'Pagada'),
('2024-02-10', 35.00, 7, 7, 'Pagada'),
('2024-02-12', 110.00, 4, 4, 'Pagada'), 
('2024-02-12', 50.00, 19, 19, 'Pagada'),
('2024-02-13', 50.00, 23, 23, 'Pagada'),
('2024-02-13', 50.00, 1, 1, 'Pagada'),
('2024-02-14', 15.00, 1, 1, 'Pagada'),  
('2024-02-14', 12.00, 2, 2, 'Pagada'),  
('2024-02-14', 15.00, 3, 1, 'Pagada'),
('2024-02-15', 12.00, 4, 3, 'Pagada'),
('2024-02-15', 15.00, 5, 4, 'Pagada'),
('2024-02-16', 12.00, 6, 5, 'Pagada'),
('2024-02-16', 15.00, 7, 6, 'Pagada'),
('2024-02-17', 15.00, 8, 7, 'Pagada'),
('2024-02-17', 15.00, 9, 8, 'Pagada'),
('2024-02-18', 15.00, 10, 9, 'Pagada'),
('2024-02-18', 15.00, 12, 11, 'Pagada'),
('2024-02-19', 35.00, 13, 12, 'Pagada'),
('2024-02-19', 12.00, 14, 13, 'Pagada'),
('2024-02-20', 35.00, 15, 14, 'Pagada'),
('2024-02-20', 12.00, 16, 15, 'Pagada'),
('2024-02-21', 35.00, 17, 16, 'Pagada'),
('2024-02-21', 12.00, 18, 17, 'Pagada'),
('2024-02-22', 35.00, 19, 18, 'Pagada'),
('2024-02-22', 15.00, 20, 19, 'Pagada'),
('2024-02-23', 35.00, 21, 20, 'Pagada'),
('2024-02-23', 12.00, 22, 21, 'Pagada'),
('2024-02-24', 15.00, 23, 22, 'Pagada'),
('2024-02-24', 35.00, 24, 23, 'Pagada'),
('2024-02-25', 35.00, 25, 24, 'Pagada'),
('2024-02-25', 35.00, 25, 25, 'Pagada'),
('2024-02-26', 12.00, 27, 26, 'Pagada'),
('2024-02-26', 15.00, 28, 27, 'Pagada'),
('2024-02-27', 35.00, 29, 28, 'Pagada'),
('2024-02-27', 12.00, 30, 29, 'Pagada'),
('2024-02-28', 15.00, 31, 30, 'Pagada'),
('2024-02-28', 35.00, 10, 10, 'Pagada'),
('2024-02-29', 35.00, 15, 15, 'Pagada'),
('2024-02-29', 12.00, 2, 2, 'Pagada'),
('2024-03-01', 15.00, 7, 7, 'Pagada'),
('2024-03-02', 35.00, 1, 1, 'Pagada'),
('2024-03-02', 35.00, 2, 2, 'Pagada'),
('2024-03-03', 35.00, 1, 1, 'Pagada'),
('2024-03-03', 35.00, 3, 3, 'Pagada'),
('2024-03-04', 35.00, 4, 4, 'Pagada'),
('2024-03-04', 35.00, 5, 5, 'Pagada'),
('2024-03-05', 35.00, 6, 6, 'Pagada'),
('2024-03-05', 35.00, 7, 7, 'Pagada'),
('2024-03-06', 35.00, 8, 8, 'Pagada'),
('2024-03-06', 35.00, 9, 9, 'Pagada'),
('2024-03-07', 35.00, 10, 10, 'Pagada'),
('2024-03-07', 35.00, 11, 11, 'Pagada'),
('2024-03-08', 35.00, 12, 12, 'Pagada'),
('2024-03-08', 35.00, 13, 13, 'Pagada'),
('2024-03-09', 35.00, 14, 14, 'Pagada'),
('2024-03-09', 35.00, 15, 15, 'Pagada'),
('2024-03-10', 35.00, 16, 16, 'Pagada'),
('2024-03-10', 35.00, 17, 17, 'Pagada'),
('2024-03-11', 35.00, 18, 18, 'Pagada'),
('2024-03-11', 35.00, 19, 19, 'Pagada'),
('2024-03-12', 35.00, 20, 20, 'Pagada'),
('2024-03-12', 35.00, 21, 21, 'Pagada'),
('2024-03-13', 35.00, 22, 22, 'Pagada'),
('2024-03-13', 35.00, 23, 23, 'Pagada'),
('2024-03-14', 35.00, 24, 24, 'Pagada'),
('2024-03-14', 35.00, 25, 25, 'Pagada'),
('2024-03-15', 35.00, 26, 26, 'Pagada'),
('2024-03-15', 35.00, 27, 27, 'Pagada'),
('2024-03-16', 35.00, 28, 28, 'Pagada'),
('2024-03-16', 35.00, 29, 29, 'Pagada'),
('2024-03-17', 35.00, 30, 30, 'Pagada'),
('2024-03-17', 35.00, 10, 10, 'Pagada'),
('2024-03-18', 35.00, 15, 15, 'Pagada'),
('2024-03-18', 35.00, 2, 2, 'Pagada'),
('2024-03-19', 35.00, 7, 7, 'Pagada'),
('2024-03-20', 15.00, 1, 1, 'Pagada'),
('2024-03-20', 12.00, 2, 2, 'Pagada'),
('2024-03-20', 15.00, 3, 1, 'Pagada'),
('2024-03-21', 12.00, 4, 3, 'Pagada'),
('2024-03-21', 15.00, 5, 4, 'Pagada'),
('2024-03-22', 12.00, 6, 5, 'Pagada'),
('2024-03-22', 15.00, 7, 6, 'Pagada'),
('2024-03-23', 15.00, 8, 7, 'Pagada'),
('2024-03-23', 15.00, 9, 8, 'Pagada'),
('2024-03-24', 15.00, 10, 9, 'Pagada'),
('2024-03-24', 35.00, 11, 10, 'Pagada'),
('2024-03-25', 15.00, 12, 11, 'Pagada'),
('2024-03-25', 35.00, 13, 12, 'Pagada');
GO

-- ====================================================
-- 9. TABLA: Tratamiento 
-- ====================================================
INSERT INTO Tratamiento (Fecha, Diagnostico, ID_Mascota) VALUES
('2024-01-05', 'Otitis externa aguda. Iniciar antibiótico tópico.', 1), -- Max (Perro)
('2024-01-05', 'Gingivitis leve. Se recomienda profilaxis dental.', 2), -- Luna (Gato)
('2024-01-15', 'Enfermedad articular degenerativa. Control de dolor.', 3), -- Rocky (Perro)
('2024-01-15', 'Dermatitis atópica, brote agudo. Iniciar esteroides.', 5), -- Coco (Perro)
('2024-01-16', 'Soplo cardiaco Grado III. Se requiere ecocardiograma.', 8), -- Thor (Perro)
('2024-01-17', 'Úlcera corneal superficial. Tratamiento con colirio antibiótico.', 19), -- Leo (Perro)
('2024-01-20', 'Anaplasmosis canina (resultado positivo). Iniciar Doxiciclina.', 1), -- Max (Perro)
('2024-01-22', 'Infección urinaria. Cultivo en proceso. Iniciar tratamiento empírico.', 10), -- Toby (Perro)
('2024-01-26', 'Infección de vías respiratorias superiores (Gripe felina).', 6), -- Simba (Gato)
('2024-01-28', 'Dermatitis por pulgas. Aplicación de antipulgas y antinflamatorio.', 12), -- Bella (Perro)
('2024-02-02', 'Linfoma cutáneo. Inicio de protocolo de quimioterapia oral.', 20), -- Jack (Perro)
('2024-02-05', 'Insuficiencia renal crónica (estadio II). Dieta y manejo de fluidos.', 24), -- Apolo (Perro)
('2024-02-13', 'Trauma por caída. Múltiples contusiones y hematomas.', 23), -- Apolo (Perro)
('2024-02-14', 'Control de parásitos. Desparasitación interna de rutina.', 1), -- Max
('2024-02-14', 'Control de parásitos. Desparasitación interna de rutina.', 2), -- Luna
('2024-02-14', 'Control de parásitos. Desparasitación interna de rutina.', 3), -- Rocky
('2024-02-15', 'Control de parásitos. Desparasitación interna de rutina.', 4), -- Nala
('2024-02-15', 'Control de parásitos. Desparasitación interna de rutina.', 5), -- Coco
('2024-02-16', 'Control de parásitos. Desparasitación interna de rutina.', 6), -- Simba
('2024-02-16', 'Control de parásitos. Desparasitación interna de rutina.', 7), -- Lola
('2024-02-17', 'Control de parásitos. Desparasitación interna de rutina.', 8), -- Thor
('2024-02-17', 'Control de parásitos. Desparasitación interna de rutina.', 9), -- Mía
('2024-02-18', 'Control de parásitos. Desparasitación interna de rutina.', 10), -- Toby
('2024-02-18', 'Control de parásitos. Desparasitación interna de rutina.', 12), -- Bella
('2024-02-19', 'Control de parásitos. Desparasitación interna de rutina.', 14), -- Frida
('2024-02-20', 'Control de parásitos. Desparasitación interna de rutina.', 16), -- Oreo
('2024-02-21', 'Control de parásitos. Desparasitación interna de rutina.', 18), -- Cleo
('2024-02-22', 'Control de parásitos. Desparasitación interna de rutina.', 20), -- Jack
('2024-02-23', 'Control de parásitos. Desparasitación interna de rutina.', 22), -- Shadow
('2024-02-24', 'Control de parásitos. Desparasitación interna de rutina.', 23), -- Apolo
('2024-02-26', 'Control de parásitos. Desparasitación interna de rutina.', 27), -- Nina
('2024-02-27', 'Control de parásitos. Desparasitación interna de rutina.', 28), -- Chispa
('2024-02-27', 'Control de parásitos. Desparasitación interna de rutina.', 29), -- Buddy
('2024-02-28', 'Control de parásitos. Desparasitación interna de rutina.', 30), -- Misha
('2024-02-29', 'Control de parásitos. Desparasitación interna de rutina.', 31), -- Hachi
('2024-03-01', 'Control de parásitos. Desparasitación interna de rutina.', 35), -- Sasha
-- Tratamientos de seguimiento y nuevos casos
('2024-03-02', 'Control de Otitis. Mejoría, continuar con gotas 5 días más.', 1),
('2024-03-03', 'Control de Dolor Crónico. Ajuste de dosis de Meloxicam.', 3),
('2024-03-04', 'Revisión de piel. La dermatitis mejora con tratamiento. Reducir dosis de Prednisona.', 5),
('2024-03-05', 'Revisión Úlcera Corneal. Curación completa. Suspensión de tratamiento.', 19),
('2024-03-06', 'Gastroenteritis aguda. Dieta blanda y antieméticos.', 7),
('2024-03-07', 'Mordedura de otro perro. Herida superficial. Sutura simple y antibiótico.', 29),
('2024-03-08', 'Sospecha de intoxicación por raticida. Administrar Vitamina K.', 10),
('2024-03-09', 'Chequeo geriátrico. Iniciar suplemento articular.', 21),
('2024-03-10', 'Problemas dentales severos. Programar Limpieza Dental y posibles extracciones.', 23),
('2024-03-11', 'Absceso en pata. Drenaje y antibiótico.', 26),
('2024-03-12', 'Vigilancia de enfermedad cardiaca. Próxima revisión en 3 meses.', 8),
('2024-03-13', 'Chequeo de mascota exótica. Dieta y ambiente óptimos.', 11),
('2024-03-14', 'Revisión de la Leucemia Felina. Parámetros estables.', 14),
('2024-03-15', 'Otitis crónica. Mantenimiento con limpiador de oídos.', 17),
('2024-03-16', 'Revisión de ISR (Insuficiencia Renal). Ajuste de fluidos subcutáneos.', 24),
('2024-03-17', 'Problema de comportamiento: Ansiedad por separación. Iniciar terapia conductual y medicación.', 35),
('2024-03-18', 'Cálculos en vejiga (Diagnóstico por ultrasonido). Programar cistotomía.', 19),
('2024-03-19', 'Tos de perrera. Iniciar Doxiciclina y antitusivo.', 3),
('2024-03-20', 'Infección en herida post-quirúrgica (cirugía anterior). Lavado y antibiótico.', 23),
('2024-03-21', 'Control de desparasitación. Sin parásitos en heces.', 1),
('2024-03-22', 'Control de desparasitación. Sin parásitos en heces.', 2),
('2024-03-23', 'Control de dolor por osteoartritis. Meloxicam.', 12),
('2024-03-24', 'Deshidratación por vómitos. Fluidoterapia IV.', 7),
('2024-03-25', 'Sospecha de tumoración abdominal. Cita para TAC.', 8),
('2024-03-26', 'Alergia alimentaria. Cambio a dieta hipoalergénica.', 5),
('2024-03-27', 'Eclampsia postparto (emergencia). Calcio IV y monitoreo.', 28),
('2024-03-28', 'Dermatitis fúngica. Tratamiento con Ketoconazol tópico.', 10),
('2024-03-29', 'Problemas de motilidad intestinal. Cisaprida.', 13),
('2024-03-30', 'Control de anemia. Suplemento de hierro.', 15),
('2024-03-31', 'Revisión de mordedura (control). Herida sana.', 29),
-- Más seguimientos de tratamientos
('2024-04-01', 'Seguimiento de Anaplasmosis. Control de hemograma.', 1),
('2024-04-02', 'Seguimiento de IRA. Parámetros renales estables.', 24),
('2024-04-03', 'Control de Gastroenteritis. Dieta blanda continúa.', 7),
('2024-04-04', 'Control de Tos de Perrera. Mejoría notable.', 3),
('2024-04-05', 'Revisión de ansiedad. Dosis de medicación estable.', 35),
('2024-04-06', 'Control de Absceso. Listo para retirar puntos.', 26),
('2024-04-07', 'Control de Linfoma. Quimioterapia tolerada.', 20),
('2024-04-08', 'Revisión de Sonda de alimentación (anterior hospitalización).', 23),
('2024-04-09', 'Dolor en la espalda. Reposo y antiinflamatorio (Meloxicam).', 31),
('2024-04-10', 'Revisión de piel por Dermatitis. Cambio de medicación.', 5),
('2024-04-11', 'Vómitos esporádicos. Antiácido (Omeprazol) y ayuno.', 14),
('2024-04-12', 'Revisión de úlcera corneal (nuevo caso). Aplicación de antibiótico.', 12),
('2024-04-13', 'Control de Gingivitis. Se programa la profilaxis dental.', 2),
('2024-04-14', 'Infección ocular. Colirio de Tilosina.', 9),
('2024-04-15', 'Tratamiento preventivo para Leishmania (viaje).', 1),
('2024-04-16', 'Dolor por Osteoartritis. Reajuste de dosis de Gabapentina.', 3),
('2024-04-17', 'Revisión de masa en cuello. Punción (FNA) para citología.', 5),
('2024-04-18', 'Control de hipertiroidismo (nuevo caso). Iniciar Metimazol.', 14),
('2024-04-19', 'Seguimiento de mordedura grave. Curación por segunda intención.', 29),
('2024-04-20', 'Otitis media. Tratamiento con Maropitant y antibiótico sistémico.', 8),
('2024-04-21', 'Revisión de la alimentación en conejos. Ajuste de heno.', 25),
('2024-04-22', 'Profilaxis dental post-operatoria. Recomendaciones de cepillado.', 23),
('2024-04-23', 'Alergia ambiental. Antihistamínico.', 7),
('2024-04-24', 'Chequeo pre-quirúrgico para esterilización.', 28),
('2024-04-25', 'Infección de herida. Limpieza y curación.', 31),
('2024-04-26', 'Control de dolor por fractura antigua. Tramadol.', 19),
('2024-04-27', 'Revisión de anemia felina. Transfusión de sangre.', 15),
('2024-04-28', 'Diagnóstico de Piómetra. Cirugía de emergencia programada.', 28),
('2024-04-29', 'Dolor articular. Carprofeno.', 10),
('2024-04-30', 'Infección en pata. Cefalexina.', 5),
('2024-05-01', 'Revisión de Anaplasmosis. Hemograma con mejoría.', 1),
('2024-05-02', 'Control de tos. Antitusivo.', 3),
('2024-05-03', 'Gastroenteritis (leve). Dieta blanda.', 7),
('2024-05-04', 'Dermatitis. Tratamiento tópico.', 5),
('2024-05-05', 'Control de ansiedad. Ajuste de dosis.', 35),
('2024-05-06', 'Chequeo de mascota geriátrica. Sin cambios.', 21),
('2024-05-07', 'Dolor por Osteoartritis. Meloxicam.', 12),
('2024-05-08', 'Revisión de IRC. Fluidos subcutáneos.', 24),
('2024-05-09', 'Absceso. Drenaje y antibiótico.', 26),
('2024-05-10', 'Control post-cirugía dental.', 2),
('2024-05-11', 'Infección ocular. Colirio de Tilosina.', 9),
('2024-05-12', 'Revisión de Anemia. Suplemento de hierro.', 15),
('2024-05-13', 'Control de hipertiroidismo. Dosis estable.', 14),
('2024-05-14', 'Dolor abdominal. Radiografía y antiinflamatorio.', 10),
('2024-05-15', 'Revisión de mordedura (final). Cicatrización completa.', 29),
('2024-05-16', 'Tos de perrera (recaída). Doxiciclina y antitusivo.', 3),
('2024-05-17', 'Otitis. Tratamiento tópico.', 1),
('2024-05-18', 'Control de dolor por fractura antigua. Tramadol.', 19),
('2024-05-19', 'Alergia ambiental. Antihistamínico.', 7),
('2024-05-20', 'Control de tumoración. Pendiente citología.', 5),
('2024-05-21', 'Chequeo de mascota exótica. Sin problemas.', 11),
('2024-05-22', 'Dolor articular. Carprofeno.', 31),
('2024-05-23', 'Revisión de Piómetra (post-cirugía). Retiro de puntos.', 28),
('2024-05-24', 'Dermatitis fúngica. Tratamiento tópico.', 10),
('2024-05-25', 'Problemas de motilidad intestinal. Cisaprida.', 13),
('2024-05-26', 'Control de hipertiroidismo. Reajuste de dosis.', 14),
('2024-05-27', 'Infección en pata. Cefalexina.', 31),
('2024-05-28', 'Revisión de úlcera corneal. Curación en proceso.', 12),
('2024-05-29', 'Control de Lymphoma. Próxima quimioterapia.', 20),
('2024-05-30', 'Seguimiento de anemia felina. Suplemento de hierro.', 15),
('2024-05-31', 'Otitis crónica. Mantenimiento con limpiador.', 17),
('2024-06-01', 'Dolor por Osteoartritis. Meloxicam.', 12),
('2024-06-02', 'Revisión de IRC. Dieta renal.', 24);
GO

-- ====================================================
-- 10. TABLA: Tratamiento_Medicamento 
-- ====================================================
INSERT INTO Tratamiento_Medicamento (ID_Tratamiento, ID_Medicamento) VALUES
(1, 1), (1, 3), -- Otitis: Amoxicilina + Meloxicam
(2, 23), -- Gingivitis: Propofol (si se requiere sedación para examinar)
(3, 3), (3, 8), -- Osteoartritis: Meloxicam + Gabapentina
(4, 2), (4, 12), -- Dermatitis: Prednisona + Cefalexina
(5, 5), (5, 6), -- Soplo Cardiaco: Furosemida + Enalapril
(6, 11), -- Úlcera corneal: Doxiciclina (colirio o sistémico)
(7, 11), -- Anaplasmosis: Doxiciclina
(8, 12), (8, 14), -- Infección urinaria: Cefalexina + Sucralfato (protector)
(9, 11), (9, 16), -- Gripe Felina: Doxiciclina + Maropitant (antivomitivo/náusea)
(10, 2), (10, 17), -- Dermatitis por pulgas: Prednisona + Ivermectina
(11, 2), (11, 15), -- Linfoma cutáneo: Prednisona + Ondansetrón
(12, 5), (12, 28), -- IRC: Furosemida + Suero Salino
(13, 3), (13, 27), -- Trauma: Meloxicam + Suero Ringer
(14, 20), -- Desparasitación: Praziquantel
(15, 20), (16, 20), (17, 20), (18, 20), (19, 20), (20, 20), (21, 20), (22, 20), (23, 20), (24, 20), (25, 20), (26, 20), (27, 20), (28, 20), (29, 20), (30, 20), (31, 20), (32, 20), (33, 20), (34, 20), (35, 20),
(36, 1), (36, 25), -- Control de Otitis: Amoxicilina + Clorhexidina
(37, 3), (37, 8), -- Control de dolor: Meloxicam + Gabapentina
(38, 2), (38, 1), -- Dermatitis: Prednisona + Amoxicilina
(39, 11), -- Úlcera Corneal: Doxiciclina
(40, 16), (40, 14), -- Gastroenteritis: Maropitant + Sucralfato
(41, 1), (41, 26), -- Mordedura: Amoxicilina + Yodo Povidona
(42, 29), (42, 27), -- Intoxicación: Vitamina K + Suero Ringer
(43, 3), -- Chequeo geriátrico: Meloxicam
(44, 23), -- Problemas dentales: Propofol (para examen)
(45, 12), (45, 25), -- Absceso: Cefalexina + Clorhexidina
(46, 5), (46, 6), -- Enfermedad cardiaca: Furosemida + Enalapril
(47, 12), -- Mascota exótica: Cefalexina (preventivo si aplica)
(48, 2), -- Leucemia felina: Prednisona
(49, 1), -- Otitis crónica: Amoxicilina
(50, 28), -- IRC: Suero Salino
(51, 8), (51, 2), -- Ansiedad: Gabapentina + Prednisona
(52, 1), (52, 3), -- Cálculos: Amoxicilina + Meloxicam
(53, 11), (53, 9), -- Tos de perrera: Doxiciclina + Tramadol (antitusivo)
(54, 1), (54, 25), -- Infección post-quirúrgica: Amoxicilina + Clorhexidina
(55, 20), (56, 20), (57, 3), (57, 8), (58, 16), (58, 27), (59, 15), (59, 27), (60, 2), (60, 11), (61, 28), (61, 27), (62, 1), (62, 25), (63, 1), (63, 2), (64, 11), (64, 16), (65, 3), (65, 8), (66, 2), (67, 1), (68, 11), (69, 16), (70, 2), (70, 17), (71, 25), (72, 23), (73, 2), (74, 1), (75, 12), (75, 3), (76, 9), (77, 12), (78, 11), (78, 28), (79, 1), (79, 3), (80, 2), (80, 12), (81, 2), (81, 11), (82, 3), (82, 8), (83, 1), (83, 27), (84, 1), (84, 25), (85, 3), (85, 8), (86, 1), (86, 12), (87, 2), (88, 11), (88, 16), (89, 2), (89, 27), (90, 1), (90, 3), (91, 11), (92, 12), (93, 2), (94, 3), (95, 1), (95, 11), (96, 14), (96, 16), (97, 1), (97, 2), (98, 3), (98, 8), (99, 11), (100, 27), (100, 28), (101, 1), (102, 3), (102, 8), (103, 16), (103, 14), (104, 2), (105, 11), (106, 2), (106, 17), (107, 12), (107, 3), (108, 9), (109, 12), (110, 2);
GO

-- ====================================================
-- 11. TABLA: Hospitalizacion (30 Registros)
-- ====================================================
INSERT INTO Hospitalizacion (FechaIngreso, FechaSalida, Observaciones, ID_Mascota) VALUES
('2024-01-25', '2024-01-28', 'Diagnóstico de Pancreatitis. Fluidoterapia IV y control de dolor. Estuvo 3 días.', 7), -- Lola
('2024-01-27', '2024-01-27', 'Observación por post-quirúrgico de tumor. Alta el mismo día.', 1), -- Max
('2024-02-13', '2024-02-15', 'Trauma grave por atropello. Monitoreo constante, sonda de alimentación. 2 días.', 23), -- Apolo
('2024-02-20', '2024-02-25', 'Insuficiencia Renal Aguda, requiere fluidos de por vida. Hospitalización inicial 5 días.', 24), -- Apolo
('2024-03-08', '2024-03-09', 'Sospecha de intoxicación. Lavado gástrico y fluidoterapia. 1 día.', 10), -- Toby
('2024-03-27', '2024-03-28', 'Eclampsia (convulsiones postparto). Calcio IV y estabilización. 1 día.', 28), -- Chispa
('2024-04-27', '2024-04-27', 'Anemia Felina grave. Transfusión de sangre. Monitoreo intensivo de 6 horas. (Se registra como 1 día).', 15), -- Oreo
('2024-04-28', '2024-05-01', 'Piómetra. Cirugía de emergencia (Ovariohisterectomía). Postoperatorio 3 días.', 28), -- Chispa
('2024-05-18', '2024-05-20', 'Deshidratación severa por gastroenteritis. Fluidoterapia y reposo. 2 días.', 7), -- Lola
('2024-05-25', '2024-05-26', 'Crisis de hipertiroidismo felino. Monitoreo cardiaco. 1 día.', 14), -- Frida
('2024-06-05', '2024-06-06', 'Dificultad respiratoria. Terapia con oxígeno y nebulización. 1 día.', 3), -- Rocky
('2024-06-15', '2024-06-17', 'Vómitos incoercibles. Hospitalización para diagnóstico y tratamiento. 2 días.', 5), -- Coco
('2024-06-25', '2024-06-25', 'Pre-quirúrgico de Cirugía Ortopédica. Observación.', 19), -- Leo
('2024-07-01', '2024-07-03', 'Fiebre de origen desconocido. Hemocultivos. 2 días.', 1), -- Max
('2024-07-10', '2024-07-11', 'Trauma ocular. Tratamiento intensivo con colirios. 1 día.', 12), -- Bella
('2024-07-20', '2024-07-21', 'Anorexia felina. Sonda de alimentación. 1 día.', 2), -- Luna
('2024-08-01', '2024-08-03', 'Hemorragia gastrointestinal. Transfusión y monitoreo. 2 días.', 10), -- Toby
('2024-08-10', '2024-08-12', 'Neumonía. Antibiótico IV y nebulizaciones. 2 días.', 35), -- Sasha
('2024-08-20', '2024-08-22', 'Postoperatorio de extracción dental compleja. 2 días.', 23), -- Apolo
('2024-09-01', '2024-09-04', 'Parvovirus canino (cachorro). 3 días.', 30), -- Misha
('2024-09-10', '2024-09-11', 'Crisis asmática. Terapia inhalada. 1 día.', 4), -- Nala
('2024-09-20', '2024-09-22', 'Diabetes descompensada. Ajuste de insulina. 2 días.', 8), -- Thor
('2024-10-01', '2024-10-05', 'Infección abdominal grave. 4 días.', 7), -- Lola
('2024-10-10', '2024-10-10', 'Intoxicación leve. Observación y fluidos. 6 horas (1 día).', 1), -- Max
('2024-10-20', '2024-10-22', 'Control de dolor por cáncer. 2 días.', 20), -- Jack
('2024-11-01', '2024-11-01', 'Pre-quirúrgico de Cirugía de Tumor. Observación.', 5), -- Coco
('2024-11-10', '2024-11-12', 'Hepatitis aguda. Tratamiento de soporte. 2 días.', 31), -- Hachi
('2024-12-01', '2024-12-03', 'Fractura de pata (Post-cirugía). Cuidado post-ortopedia. 2 días.', 19), -- Leo
('2024-12-10', '2024-12-14', 'Fallo Renal Crónico (descompensación). Fluidoterapia. 4 días.', 24); -- Apolo
GO

-- ====================================================
-- 12. TABLA: Cirugia (20 Registros)
-- ====================================================
INSERT INTO Cirugia (Fecha, Tipo, Descripcion, ID_Mascota, ID_Veterinario) VALUES
('2024-01-27', 'Excisión de masa', 'Extracción de tumor cutáneo en hombro. Margen limpio.', 1, 1), -- Max con Dr. Solís (Cirugía General)
('2024-02-12', 'Profilaxis Dental', 'Limpieza dental con ultrasonido. Sin extracciones.', 5, 14), -- Coco con Dra. Ponce (Odontología)
('2024-02-28', 'Esterilización (OVH)', 'Ovariohisterectomía canina de rutina.', 28, 21), -- Chispa con Dr. Estrada (Cirugía General)
('2024-03-18', 'Cistotomía', 'Extracción de cálculos vesicales. Envío a patología.', 19, 1), -- Leo con Dr. Solís (Cirugía General)
('2024-04-28', 'OVH de emergencia', 'Ovariohisterectomía por Piómetra (Infección uterina).', 28, 21), -- Chispa con Dr. Estrada (Cirugía General)
('2024-05-05', 'Esterilización (Castración)', 'Orquiectomía canina (castración).', 10, 1), -- Toby con Dr. Solís
('2024-05-10', 'Extracciones Dentales', 'Profilaxis dental y extracción de 4 premolares.', 2, 14), -- Luna con Dra. Ponce
('2024-06-26', 'Cirugía Ortopédica', 'Reparación de fractura de tibia con placa y tornillos.', 19, 15), -- Leo con Dr. Bendaña (Ortopédica)
('2024-07-05', 'Extirpación de tumor', 'Mastectomía unilateral simple. Envío a patología.', 12, 21), -- Bella con Dr. Estrada
('2024-08-05', 'Corrección de entropión', 'Cirugía palpebral para corregir párpado invertido.', 13, 13), -- Zeus con Dr. Fonseca (Oftalmología)
('2024-09-05', 'Laparotomía Exploratoria', 'Abdomen agudo, se encontró cuerpo extraño en intestino. Remoción.', 7, 1), -- Lola con Dr. Solís
('2024-10-01', 'Cirugía de Tumor (Masa abdominal)', 'Excisión de masa en bazo. Esplenectomía.', 8, 8), -- Thor con Dra. Téllez (Oncología)
('2024-11-02', 'Biopsia incisional', 'Toma de muestra de tumoración mamaria.', 5, 21), -- Coco con Dr. Estrada
('2024-12-05', 'Grooming Quirúrgico', 'Corte de pelo y limpieza profunda en sedación.', 33, 4), -- Copito (Hámster) con Dra. Campos (Exóticos)
('2024-12-15', 'Extracción de dientes', 'Extracción dental en perro geriátrico.', 21, 14), -- Jack con Dra. Ponce
('2025-01-05', 'Esterilización (Gata)', 'OVH felina.', 30, 21), -- Misha
('2025-01-15', 'Cirugía Ortopédica', 'Fijación externa de fractura de fémur.', 31, 15), -- Hachi
('2025-02-05', 'Excisión de Lipoma', 'Remoción de tumoración benigna de grasa.', 1, 1), -- Max
('2025-03-05', 'Corrección de hernia umbilical', 'Herniorrafia de rutina.', 10, 21), -- Toby
('2025-04-05', 'Amputación de cola', 'Amputación por lesión crónica.', 29, 1); -- Buddy
GO

-- ====================================================
-- 13. TABLA: Mascota_Vacuna 
-- ====================================================
INSERT INTO Mascota_Vacuna (ID_Mascota, ID_Vacuna) VALUES
-- Mascota 1 (Max - Perro)
(1, 3), (1, 7), (1, 23), (1, 4), (1, 8),
-- Mascota 2 (Luna - Gato)
(2, 11), (2, 13), (2, 24), (2, 18), (2, 9),
-- Mascota 3 (Rocky - Perro)
(3, 4), (3, 7), (3, 23), (3, 8), (3, 5),
-- Mascota 4 (Nala - Gato)
(4, 11), (4, 13), (4, 24), (4, 12), (4, 17),
-- Mascota 5 (Coco - Perro)
(5, 4), (5, 7), (5, 23), (5, 8), (5, 3),
-- Mascota 6 (Simba - Gato)
(6, 11), (6, 13), (6, 24), (6, 12), (6, 14),
-- Mascota 7 (Lola - Perro)
(7, 4), (7, 7), (7, 23), (7, 8), (7, 6),
-- Mascota 8 (Thor - Perro)
(8, 4), (8, 7), (8, 23), (8, 5), (8, 18),
-- Mascota 9 (Mía - Gato)
(9, 11), (9, 13), (9, 24), (9, 18), (9, 14),
-- Mascota 10 (Toby - Perro) - Cachorro
(10, 4), (10, 5), (10, 6), (10, 7), (10, 1),
-- Mascota 11 (Kiwi - Ave)
(11, 1), (11, 3), (11, 5), (11, 8),
-- Mascota 12 (Bella - Perro)
(12, 7), (12, 1), (12, 23), (12, 9), (12, 3),
-- Mascota 13 (Zeus - Perro)
(13, 7), (13, 1), (13, 23), (13, 12), (13, 24),
-- Mascota 14 (Frida - Gato)
(14, 13), (14, 24), (14, 12), (14, 17),
-- Mascota 15 (Bruno - Perro)
(15, 7), (15, 1), (15, 23),
-- Mascota 16 (Oreo - Gato)
(16, 13), (16, 24), (16, 18),
-- Mascota 17 (Daisy - Perro)
(17, 7), (17, 1), (17, 23),
-- Mascota 18 (Milo - Perro)
(18, 7), (18, 1), (18, 23),
-- Mascota 19 (Cleo - Gato)
(19, 13), (19, 24), (19, 14),
-- Mascota 20 (Leo - Perro)
(20, 7), (20, 1), (20, 23),
-- Mascota 21 (Jack - Perro)
(21, 7), (21, 1), (21, 23),
-- Mascota 22 (Shadow - Gato)
(22, 13), (22, 24), (22, 14),
-- Mascota 23 (Molly - Perro)
(23, 7), (23, 1), (23, 23),
-- Mascota 24 (Apolo - Perro)
(24, 7), (24, 1), (24, 23),
-- Mascota 25 (Pelusa - Conejo)
(25, 1), (25, 3),
-- Mascota 26 (Pipo - Perro)
(26, 7), (26, 1), (26, 23),
-- Mascota 27 (Nina - Gato)
(27, 13), (27, 24), (27, 14),
-- Mascota 28 (Chispa - Perro)
(28, 7), (28, 1), (28, 23),
-- Mascota 29 (Buddy - Perro)
(29, 7), (29, 1), (29, 23),
-- Mascota 30 (Misha - Gato)
(30, 13), (30, 24), (30, 18),
-- Mascota 31 (Hachi - Perro)
(31, 7), (31, 1), (31, 23),
-- Mascota 32 (Pancha - Tortuga)
(32, 1), (32, 3),
-- Mascota 33 (Copito - Hámster)
(33, 1), (33, 3),
-- Mascota 34 (Felix - Gato)
(34, 11), (34, 13),
-- Mascota 35 (Sasha - Perro)
(35, 7), (35, 1), (35, 23);
GO

-- NOTA: La tabla DetalleHistoria no existe en el esquema, se omite esta sección
-- ====================================================
-- 14. TABLA: FacturaDetalle
-- ====================================================
-- Crear FacturaDetalle basado en las citas y facturas
INSERT INTO FacturaDetalle (ID_Factura, ID_Servicio, Cantidad, PrecioUnitario)
SELECT 
    F.ID_Factura,
    C.ID_Servicio,
    1 AS Cantidad,
    S.Costo AS PrecioUnitario
FROM Factura F
INNER JOIN Cita C ON F.ID_Cita = C.ID_Cita
INNER JOIN Servicio S ON C.ID_Servicio = S.ID_Servicio
WHERE F.ID_Cita IS NOT NULL;
GO

-- Para facturas sin cita, usar Consulta General como servicio por defecto
INSERT INTO FacturaDetalle (ID_Factura, ID_Servicio, Cantidad, PrecioUnitario)
SELECT 
    F.ID_Factura,
    1 AS ID_Servicio, -- Consulta General
    1 AS Cantidad,
    35.00 AS PrecioUnitario
FROM Factura F
WHERE F.ID_Cita IS NULL
AND NOT EXISTS (SELECT 1 FROM FacturaDetalle FD WHERE FD.ID_Factura = F.ID_Factura);
GO

-- ====================================================
-- 15. TABLA: Pago 
-- ====================================================
INSERT INTO Pago (ID_Factura, MetodoPago, Monto, FechaPago) VALUES
(1, 'Tarjeta', 35.00, '2024-01-05'),
(2, 'Efectivo', 35.00, '2024-01-05'),
(3, 'Transferencia', 35.00, '2024-01-06'),
(4, 'Tarjeta', 35.00, '2024-01-06'),
(5, 'Efectivo', 35.00, '2024-01-06'),
(6, 'Transferencia', 35.00, '2024-01-07'),
(7, 'Tarjeta', 35.00, '2024-01-07'),
(8, 'Efectivo', 35.00, '2024-01-07'),
(9, 'Transferencia', 35.00, '2024-01-08'),
(10, 'Tarjeta', 35.00, '2024-01-08'),
(11, 'Efectivo', 30.00, '2024-01-10'),
(12, 'Transferencia', 28.00, '2024-01-10'),
(13, 'Tarjeta', 30.00, '2024-01-10'),
(14, 'Efectivo', 28.00, '2024-01-11'),
(15, 'Transferencia', 28.00, '2024-01-11'),
(16, 'Tarjeta', 20.00, '2024-01-12'),
(17, 'Efectivo', 28.00, '2024-01-12'),
(18, 'Transferencia', 20.00, '2024-01-12'),
(19, 'Tarjeta', 50.00, '2024-01-15'),
(20, 'Efectivo', 50.00, '2024-01-15'),
(21, 'Transferencia', 85.00, '2024-01-16'),
(22, 'Tarjeta', 50.00, '2024-01-16'),
(23, 'Efectivo', 50.00, '2024-01-17'),
(24, 'Transferencia', 50.00, '2024-01-17'),
(25, 'Tarjeta', 55.00, '2024-01-18'),
(26, 'Efectivo', 40.00, '2024-01-20'),
(27, 'Transferencia', 22.00, '2024-01-20'),
(28, 'Tarjeta', 35.00, '2024-01-21'),
(29, 'Efectivo', 35.00, '2024-01-21'),
(30, 'Transferencia', 40.00, '2024-01-22'),
(31, 'Tarjeta', 22.00, '2024-01-22'),
(32, 'Efectivo', 30.00, '2024-01-25'),
(33, 'Transferencia', 28.00, '2024-01-25'),
(34, 'Tarjeta', 35.00, '2024-01-26'),
(35, 'Efectivo', 35.00, '2024-01-26'),
(36, 'Transferencia', 30.00, '2024-01-27'),
(37, 'Tarjeta', 35.00, '2024-01-27'),
(38, 'Efectivo', 35.00, '2024-01-28'),
(39, 'Transferencia', 30.00, '2024-01-28'),
(40, 'Tarjeta', 35.00, '2024-01-29'),
(41, 'Efectivo', 35.00, '2024-01-29'),
(42, 'Transferencia', 35.00, '2024-01-30'),
(43, 'Tarjeta', 28.00, '2024-01-30'),
(44, 'Efectivo', 35.00, '2024-01-31'),
(45, 'Transferencia', 28.00, '2024-01-31'),
(46, 'Tarjeta', 35.00, '2024-02-01'),
(47, 'Efectivo', 28.00, '2024-02-01'),
(48, 'Transferencia', 35.00, '2024-02-02'),
(49, 'Tarjeta', 30.00, '2024-02-02'),
(50, 'Efectivo', 35.00, '2024-02-03'),
(51, 'Transferencia', 28.00, '2024-02-03'),
(52, 'Tarjeta', 35.00, '2024-02-04'),
(53, 'Efectivo', 35.00, '2024-02-04'),
(54, 'Transferencia', 35.00, '2024-02-05'),
(55, 'Tarjeta', 35.00, '2024-02-05'),
(56, 'Efectivo', 28.00, '2024-02-06'),
(57, 'Transferencia', 30.00, '2024-02-06'),
(58, 'Tarjeta', 35.00, '2024-02-07'),
(59, 'Efectivo', 28.00, '2024-02-07'),
(60, 'Transferencia', 30.00, '2024-02-08'),
(61, 'Tarjeta', 35.00, '2024-02-08'),
(62, 'Efectivo', 35.00, '2024-02-09'),
(63, 'Transferencia', 28.00, '2024-02-09'),
(64, 'Tarjeta', 35.00, '2024-02-10'),
(65, 'Efectivo', 110.00, '2024-02-12'),
(66, 'Transferencia', 50.00, '2024-02-12'),
(67, 'Tarjeta', 50.00, '2024-02-13'),
(68, 'Efectivo', 50.00, '2024-02-13'),
(69, 'Transferencia', 15.00, '2024-02-14'),
(70, 'Tarjeta', 12.00, '2024-02-14'),
(71, 'Efectivo', 15.00, '2024-02-14'),
(72, 'Transferencia', 12.00, '2024-02-15'),
(73, 'Tarjeta', 15.00, '2024-02-15'),
(74, 'Efectivo', 12.00, '2024-02-16'),
(75, 'Transferencia', 15.00, '2024-02-16'),
(76, 'Tarjeta', 15.00, '2024-02-17'),
(77, 'Efectivo', 15.00, '2024-02-17'),
(78, 'Transferencia', 15.00, '2024-02-18'),
(79, 'Tarjeta', 15.00, '2024-02-18'),
(80, 'Efectivo', 35.00, '2024-02-19'),
(81, 'Transferencia', 12.00, '2024-02-19'),
(82, 'Tarjeta', 35.00, '2024-02-20'),
(83, 'Efectivo', 12.00, '2024-02-20'),
(84, 'Transferencia', 35.00, '2024-02-21'),
(85, 'Tarjeta', 12.00, '2024-02-21'),
(86, 'Efectivo', 35.00, '2024-02-22'),
(87, 'Transferencia', 15.00, '2024-02-22'),
(88, 'Tarjeta', 35.00, '2024-02-23'),
(89, 'Efectivo', 12.00, '2024-02-23'),
(90, 'Transferencia', 15.00, '2024-02-24'),
(91, 'Tarjeta', 35.00, '2024-02-24'),
(92, 'Efectivo', 35.00, '2024-02-25'),
(93, 'Transferencia', 35.00, '2024-02-25'),
(94, 'Tarjeta', 12.00, '2024-02-26'),
(95, 'Efectivo', 15.00, '2024-02-26'),
(96, 'Transferencia', 35.00, '2024-02-27'),
(97, 'Tarjeta', 12.00, '2024-02-27'),
(98, 'Efectivo', 15.00, '2024-02-28'),
(99, 'Transferencia', 35.00, '2024-02-28'),
(100, 'Tarjeta', 35.00, '2024-02-29'),
(101, 'Efectivo', 12.00, '2024-02-29'),
(102, 'Transferencia', 15.00, '2024-03-01'),
(103, 'Tarjeta', 35.00, '2024-03-02'),
(104, 'Efectivo', 35.00, '2024-03-02'),
(105, 'Transferencia', 35.00, '2024-03-03'),
(106, 'Tarjeta', 35.00, '2024-03-03'),
(107, 'Efectivo', 35.00, '2024-03-04'),
(108, 'Transferencia', 35.00, '2024-03-04'),
(109, 'Tarjeta', 35.00, '2024-03-05'),
(110, 'Efectivo', 35.00, '2024-03-05'),
(111, 'Transferencia', 35.00, '2024-03-06'),
(112, 'Tarjeta', 35.00, '2024-03-06'),
(113, 'Efectivo', 35.00, '2024-03-07'),
(114, 'Transferencia', 35.00, '2024-03-07'),
(115, 'Tarjeta', 35.00, '2024-03-08'),
(116, 'Efectivo', 35.00, '2024-03-08'),
(117, 'Transferencia', 35.00, '2024-03-09'),
(118, 'Tarjeta', 35.00, '2024-03-09'),
(119, 'Efectivo', 35.00, '2024-03-10'),
(120, 'Transferencia', 35.00, '2024-03-10'),
(121, 'Tarjeta', 35.00, '2024-03-11'),
(122, 'Efectivo', 35.00, '2024-03-11'),
(123, 'Transferencia', 35.00, '2024-03-12'),
(124, 'Tarjeta', 35.00, '2024-03-12'),
(125, 'Efectivo', 35.00, '2024-03-13'),
(126, 'Transferencia', 35.00, '2024-03-13'),
(127, 'Tarjeta', 35.00, '2024-03-14'),
(128, 'Efectivo', 35.00, '2024-03-14'),
(129, 'Transferencia', 35.00, '2024-03-15'),
(130, 'Tarjeta', 35.00, '2024-03-15'),
(131, 'Efectivo', 35.00, '2024-03-16'),
(132, 'Transferencia', 35.00, '2024-03-16'),
(133, 'Tarjeta', 35.00, '2024-03-17'),
(134, 'Efectivo', 35.00, '2024-03-17'),
(135, 'Transferencia', 35.00, '2024-03-18'),
(136, 'Tarjeta', 35.00, '2024-03-18'),
(137, 'Efectivo', 35.00, '2024-03-19'),
(138, 'Transferencia', 15.00, '2024-03-20'),
(139, 'Tarjeta', 12.00, '2024-03-20'),
(140, 'Efectivo', 15.00, '2024-03-20'),
(141, 'Transferencia', 12.00, '2024-03-21'),
(142, 'Tarjeta', 15.00, '2024-03-21'),
(143, 'Efectivo', 12.00, '2024-03-22'),
(144, 'Transferencia', 15.00, '2024-03-22'),
(145, 'Tarjeta', 15.00, '2024-03-23'),
(146, 'Efectivo', 15.00, '2024-03-23'),
(147, 'Transferencia', 15.00, '2024-03-24'),
(148, 'Tarjeta', 35.00, '2024-03-24'),
(149, 'Efectivo', 15.00, '2024-03-25'),
(150, 'Transferencia', 35.00, '2024-03-25');
GO

PRINT 'Script de datos completado exitosamente.';
PRINT 'Todas las tablas han sido pobladas con datos compatibles con el esquema actual.';
GO
