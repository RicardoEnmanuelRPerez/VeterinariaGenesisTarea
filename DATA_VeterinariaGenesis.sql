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
