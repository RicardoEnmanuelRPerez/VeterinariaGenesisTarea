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

