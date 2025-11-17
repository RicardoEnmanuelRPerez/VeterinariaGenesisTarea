CREATE DATABASE VeterinariaGenesisDB;
GO
USE VeterinariaGenesisDB;
GO

-- ==========================================================
-- 3. CREACIÓN DE TABLAS
-- ==========================================================

-- TABLA: Propietario
CREATE TABLE Propietario (
    ID_Propietario INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Apellidos VARCHAR(120) NOT NULL,
    Direccion VARCHAR(200),
    Telefono VARCHAR(20),
    Activo BIT NOT NULL DEFAULT 1
);
GO

-- TABLA: Mascota
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
        ON DELETE NO ACTION, -- Corrección clave
    CONSTRAINT UQ_Mascota_Nombre UNIQUE (Nombre, ID_Propietario)
);
GO

-- TABLA: Veterinario
-- CORRECCIÓN: Se quita 'UNIQUE' de la definición de la columna Correo
CREATE TABLE Veterinario (
    ID_Veterinario INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(120) NOT NULL,
    Especialidad VARCHAR(100),
    Telefono VARCHAR(20) NULL,
    Correo VARCHAR(100) NULL, -- SE QUITÓ UNIQUE
    Activo BIT NOT NULL DEFAULT 1
);
GO

-- MEJORA: Se añade un Índice Único Filtrado
-- Esto permite múltiples NULLs, pero solo un correo único si NO es NULL
CREATE UNIQUE INDEX UQ_Veterinario_Correo_NotNull
ON Veterinario(Correo)
WHERE Correo IS NOT NULL;
GO

-- TABLA: Servicio
CREATE TABLE Servicio (
    ID_Servicio INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(250),
    Costo DECIMAL(10,2) NOT NULL CHECK (Costo >= 0)
);
GO

-- TABLA: Cita
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
GO

-- TABLA: Factura (Modelo Maestro)
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
GO

-- NUEVA TABLA: FacturaDetalle (Modelo Detalle)
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
GO

-- TABLA: Pago
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
GO

-- TABLA: Tratamiento
CREATE TABLE Tratamiento (
    ID_Tratamiento INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATE NOT NULL,
    Diagnostico VARCHAR(250) NOT NULL,
    ID_Mascota INT NOT NULL,
    CONSTRAINT FK_Tratamiento_Mascota FOREIGN KEY (ID_Mascota)
        REFERENCES Mascota(ID_Mascota)
        ON DELETE CASCADE
);
GO

-- TABLA: Medicamento
CREATE TABLE Medicamento (
    ID_Medicamento INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL
);
GO

-- TABLA INTERMEDIA: Tratamiento_Medicamento
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
GO

-- TABLA: Vacuna
CREATE TABLE Vacuna (
    ID_Vacuna INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Dosis VARCHAR(50)
);
GO

-- TABLA INTERMEDIA: Mascota_Vacuna
CREATE TABLE Mascota_Vacuna (
    ID_Mascota INT NOT NULL,
    ID_Vacuna INT NOT NULL,
    FechaAplicacion DATE NOT NULL DEFAULT GETDATE(),
    FechaProximaDosis DATE NULL,
    
    PRIMARY KEY (ID_Mascota, ID_Vacuna, FechaAplicacion), -- Nueva PK
    CONSTRAINT FK_MV_Mascota FOREIGN KEY (ID_Mascota)
        REFERENCES Mascota(ID_Mascota)
        ON DELETE CASCADE,
    CONSTRAINT FK_MV_Vacuna FOREIGN KEY (ID_Vacuna)
        REFERENCES Vacuna(ID_Vacuna)
);
GO

-- TABLA: Hospitalizacion
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
GO

-- TABLA: Cirugia
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
GO

-- ==========================================================
-- 4. ÍNDICES DE RENDIMIENTO (Originales + Mejorados)
-- ==========================================================

CREATE INDEX IX_Mascota_Propietario ON Mascota(ID_Propietario);
CREATE INDEX IX_Tratamiento_Mascota ON Tratamiento(ID_Mascota);
CREATE INDEX IX_Cita_Veterinario_Fecha ON Cita(ID_Veterinario, Fecha);
CREATE INDEX IX_Hospitalizacion_Mascota ON Hospitalizacion(ID_Mascota);
CREATE INDEX IX_Propietario_Apellidos_Nombre ON Propietario(Apellidos, Nombre);
CREATE INDEX IX_Mascota_Nombre ON Mascota(Nombre);
CREATE INDEX IX_Cita_Mascota ON Cita(ID_Mascota);
CREATE INDEX IX_Factura_Propietario_Estado ON Factura(ID_Propietario, EstadoPago);
CREATE INDEX IX_FacturaDetalle_Factura ON FacturaDetalle(ID_Factura);
CREATE INDEX IX_Cirugia_Mascota ON Cirugia(ID_Mascota);
CREATE INDEX IX_Mascota_Vacuna_Mascota ON Mascota_Vacuna(ID_Mascota);
GO

PRINT '*** BASE DE DATOS CREADA Y MEJORADA CORRECTAMENTE (V3) ***';
GO