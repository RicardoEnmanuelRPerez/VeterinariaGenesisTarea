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

