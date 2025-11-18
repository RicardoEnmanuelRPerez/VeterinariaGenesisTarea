USE VeterinariaGenesisDB;

GO

-- ====================================================
-- 1. TABLA: Propietario 
-- ====================================================
INSERT INTO Propietario (Nombre, Apellidos, Direccion, Telefono) VALUES
('Carlos', 'Hern�ndez', 'Residencial Los Robles, A-10', '8881-1001'),
('Ana', 'Mart�nez', 'Barrio Monse�or Lezcano, Casa 20', '8881-1002'),
('Luis', 'Garc�a', 'Carretera a Masaya, Km 14', '8881-1003'),
('Mar�a', 'Rodr�guez', 'Altamira D''Este, #45', '8881-1004'),
('Javier', 'L�pez', 'Bello Horizonte, IV Etapa', '8881-1005'),
('Sof�a', 'P�rez', 'Las Colinas, Calle Principal', '8881-1006'),
('Miguel', 'Gonz�lez', 'Villa Fontana, C-5', '8881-1007'),
('Luc�a', 'S�nchez', 'Reparto San Juan, Casa 80', '8881-1008'),
('Diego', 'Ram�rez', 'Planes de Altamira, #12', '8881-1009'),
('Elena', 'Flores', 'Camino de Oriente, Mod C-2', '8881-1010'),
('Pedro', 'D�az', 'Masaya, Barrio San Miguel', '8881-1011'),
('Laura', 'Torres', 'Granada, Calle La Calzada', '8881-1012'),
('Sergio', 'Morales', 'Le�n, Reparto F�tima', '8881-1013'),
('Valeria', 'Cruz', 'Santo Domingo, Km 10', '8881-1014'),
('Andr�s', 'Ortiz', 'Esquipulas, Km 11.5', '8881-1015'),
('Gabriela', 'Reyes', 'Ticuantepe, Lotificaci�n 30', '8881-1016'),
('Fernando', 'Jim�nez', 'Veracruz, Condominio 4', '8881-1017'),
('Paula', 'Moreno', 'Nindir�, Km 20', '8881-1018'),
('Ricardo', 'Alonso', 'Reparto Tiscapa, #5', '8881-1019'),
('Camila', 'Guti�rrez', 'Bolonia, Hotel Mansi�n Teodolinda 2c. al Sur', '8881-1020'),
('Mateo', 'Silva', 'Catarina, Mirador', '8881-1021'),
('Isabela', 'Mendoza', 'Jinotepe, Carazo', '8881-1022'),
('Daniel', 'Castillo', 'Rivas, San Juan del Sur', '8881-1023'),
('Alejandra', 'Navarro', 'Estel�, Barrio Nuevo', '8881-1024'),
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
('Dr. Alejandro Sol�s', 'Cirug�a General'),
('Dra. Beatriz Pe�a', 'Medicina Interna'),
('Dr. Miguel Cifuentes', 'Dermatolog�a'),
('Dra. Laura Campos', 'Animales Ex�ticos'),
('Dr. Roberto Cruz', 'Consulta General'),
('Dra. Sandra Guido', 'Cardiolog�a'),
('Dr. Esteban Lacayo', 'Neurolog�a'),
('Dra. Fabiola T�llez', 'Oncolog�a'),
('Dr. Norman Gait�n', 'Fisioterapia'),
('Dra. Rebeca Arg�ello', 'Medicina Felina'),
('Dr. Arturo Casco', 'Ortopedia'),
('Dra. Melissa Baltodano', 'Consulta General'),
('Dr. Enrique Fonseca', 'Oftalmolog�a'),
('Dra. Victoria Ponce', 'Odontolog�a Veterinaria'),
('Dr. Julio Benda�a', 'Cirug�a Ortop�dica'),
('Dra. Karen Mendieta', 'Medicina Preventiva'),
('Dr. Oscar Valle', 'Consulta General'),
('Dra. Claudia Paguaga', 'Endocrinolog�a'),
('Dr. Luis Felipe Rom�n', 'Anestesiolog�a'),
('Dra. Ana Cecilia Gallo', 'Laboratorio Cl�nico'),
('Dr. Marlon Estrada', 'Cirug�a General'),
('Dra. Gabriela Sol�rzano', 'Medicina Interna'),
('Dr. Ariel D�vila', 'Dermatolog�a'),
('Dra. Patricia Ocampo', 'Animales Ex�ticos'),
('Dr. F�lix Rivas', 'Consulta General'),
('Dra. Marcela Sevilla', 'Cardiolog�a'),
('Dr. Xavier Torres', 'Neurolog�a'),
('Dra. Ingrid Zamora', 'Oncolog�a'),
('Dr. Guillermo Ter�n', 'Fisioterapia'),
('Dra. Carolina Ortega', 'Medicina Felina');

GO

-- ====================================================
-- 3. TABLA: Servicio 
-- ====================================================
INSERT INTO Servicio (Nombre, Descripcion, Costo) VALUES
('Consulta General', 'Revisi�n est�ndar de salud', 35.00),
('Consulta Especializada', 'Consulta con especialista (Cardiolog�a, Dermatolog�a, etc.)', 50.00),
('Vacuna Rabia', 'Dosis anual antirr�bica', 20.00),
('Vacuna M�ltiple (Perro)', 'Refuerzo anual Parvo, Moquillo, Hepatitis, Lepto', 30.00),
('Vacuna Triple (Gato)', 'Refuerzo anual Rino, Calici, Panleuco', 28.00),
('Desparasitaci�n Interna (Perro)', 'Pastilla seg�n peso (precio base)', 15.00),
('Desparasitaci�n Interna (Gato)', 'Pastilla o pipeta (precio base)', 12.00),
('Aplicaci�n Pipeta (Pulgas/Garrapatas)', 'Producto antiparasitario externo (base)', 18.00),
('Examen Heces (Coprol�gico)', 'An�lisis de par�sitos en heces', 22.00),
('Hemograma Completo', 'An�lisis de sangre completo', 40.00),
('Qu�mica Sangu�nea (Panel B�sico)', 'Revisi�n de funci�n renal y hep�tica', 38.00),
('Urian�lisis', 'An�lisis f�sico-qu�mico de orina', 25.00),
('Radiograf�a (Dos Placas)', 'Estudio radiogr�fico est�ndar', 55.00),
('Ultrasonido Abdominal', 'Ecograf�a de �rganos internos', 60.00),
('Ecocardiograma', 'Ultrasonido especializado del coraz�n', 85.00),
('Hospitalizaci�n (D�a)', 'Cuidado intensivo, monitoreo y fluidoterapia (base)', 80.00),
('Hospitalizaci�n (Medio D�a)', 'Monitoreo y tratamiento (menos de 12h)', 45.00),
('Cirug�a Esterilizaci�n (Gato)', 'Ovariohisterectom�a felina', 80.00),
('Cirug�a Esterilizaci�n (Gata)', 'Ovariohisterectom�a felina', 95.00),
('Cirug�a Esterilizaci�n (Perro Macho)', 'Orquiectom�a canina (precio base)', 120.00),
('Cirug�a Esterilizaci�n (Perra)', 'Ovariohisterectom�a canina (precio base)', 150.00),
('Cirug�a Menor (Suturas)', 'Cierre de heridas simples (base)', 65.00),
('Limpieza Dental (Profilaxis)', 'Limpieza con ultrasonido (sin extracciones)', 110.00),
('Extracci�n Dental Simple', 'Extracci�n de pieza dental (por pieza)', 30.00),
('Toma de Presi�n Arterial', 'Medici�n de presi�n en consulta', 15.00),
('Microchip (Implantaci�n)', 'Implantaci�n y registro de microchip', 40.00),
('Certificado de Salud (Viaje)', 'Emisi�n de certificado para viaje nacional', 25.00),
('Ba�o Medicado (Peque�o)', 'Ba�o terap�utico dermatol�gico', 20.00),
('Corte de Pelo (Grooming B�sico)', 'Corte higi�nico y ba�o (base)', 30.00),
('Eutanasia', 'Procedimiento humanitario (incluye sedaci�n)', '60.00');

GO

-- ====================================================
-- 4. TABLA: Medicamento 
-- ====================================================
INSERT INTO Medicamento (Nombre) VALUES
('Amoxicilina + Ac. Clavul�nico'),
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
('Ondansetr�n (Inyectable)'),
('Maropitant (Cerenia)', '10mg (seg�n peso)'),
('Ivermectina'),
('Selamectina (Revolution)', 'Pipeta (seg�n peso)'),
('Fipronil (Frontline)'),
('Praziquantel (Droncit)', 'Pastilla (seg�n peso)'),
('Tilosina'),
('Diazepam'),
('Propofol', '10mg/ml (Anest�sico)'),
('Isoflurano', 'Anest�sico Inhalado'),
('Clorhexidina (Soluci�n)', 'Antis�ptico T�pico 2%'),
('Yodo Povidona', 'Soluci�n Desinfectante'),
('Suero Ringer Lactato'),
('Suero Salino 0.9%'),
('Vitamina K (Inyectable)', 'Ant�doto (warfarina)'),
('Atropina (Inyectable)', 'Pre-anest�sico');

GO

-- ====================================================
-- 5. TABLA: Vacuna 
-- (Nombres espec�ficos y lotes)
-- ====================================================
INSERT INTO Vacuna (Nombre, Dosis) VALUES
('Rabia (Anual) - Lote R100A', '1ml'),
('Rabia (Anual) - Lote R100B', '1ml'),
('Rabia (Refuerzo 3 a�os) - Lote R301A', '1ml'),
('M�ltiple Canina (Cachorro 1) - Lote MC101', '1ml'),
('M�ltiple Canina (Cachorro 2) - Lote MC102', '1ml'),
('M�ltiple Canina (Cachorro 3) - Lote MC103', '1ml'),
('M�ltiple Canina (Refuerzo Anual) - Lote MCA10', '1ml'),
('M�ltiple Canina + Lepto (Anual) - Lote MCL20', '1ml'),
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
('M�ltiple Canina (Puppy DP) - Lote DP01', '1ml'),
('Rabia (Anual) - Lote R100C', '1ml'),
('M�ltiple Canina (Refuerzo Anual) - Lote MCA11', '1ml'),
('Triple Felina (Refuerzo Anual) - Lote TFA2', '1ml'),
('Leucemia Felina (Refuerzo Anual) - Lote LFA3', '0.5ml'),
('KC (Bordetella Oral) - Lote KCO31', '0.5ml'),
('Rabia (Anual) - Lote R100D', '1ml'),
('M�ltiple Canina + Lepto (Anual) - Lote MCL21', '1ml'),
('Triple Felina (Gatito 1) - Lote TF03', '1ml'),
('M�ltiple Canina (Cachorro 1) - Lote MC104', '1ml');

GO

-- ====================================================
-- 6. TABLA: Mascota 
-- ====================================================
INSERT INTO Mascota (Nombre, Especie, Raza, Edad, Sexo, ID_Propietario) VALUES
('Max', 'Perro', 'Labrador', 5, 'Macho', 1),
('Luna', 'Gato', 'Siam�s', 3, 'Hembra', 2),
('Rocky', 'Perro', 'Pastor Alem�n', 7, 'Macho', 1),
('Nala', 'Gato', 'Mestizo', 2, 'Hembra', 3),
('Coco', 'Perro', 'Bulldog Franc�s', 4, 'Macho', 4),
('Simba', 'Gato', 'Persa', 6, 'Macho', 5),
('Lola', 'Perro', 'Pug', 1, 'Hembra', 6),
('Thor', 'Perro', 'Rottweiler', 3, 'Macho', 7),
('M�a', 'Gato', 'Angora', 8, 'Hembra', 8),
('Toby', 'Perro', 'Golden Retriever', 0, 'Macho', 9),
('Kiwi', 'Ave', 'Perico Australiano', 2, 'Macho', 10),
('Bella', 'Perro', 'Chihuahua', 10, 'Hembra', 11),
('Zeus', 'Perro', 'Husky Siberiano', 4, 'Macho', 12),
('Frida', 'Gato', 'Mestizo', 5, 'Hembra', 13),
('Bruno', 'Perro', 'Boxer', 6, 'Macho', 14),
('Oreo', 'Gato', 'Dom�stico Pelo Corto', 2, 'Macho', 15),
('Daisy', 'Perro', 'Beagle', 3, 'Hembra', 16),
('Milo', 'Perro', 'Shih Tzu', 1, 'Macho', 17),
('Cleo', 'Gato', 'Sphynx', 4, 'Hembra', 18),
('Leo', 'Perro', 'Doberman', 2, 'Macho', 19),
('Jack', 'Perro', 'Jack Russell', 9, 'Macho', 20),
('Shadow', 'Gato', 'Maine Coon', 5, 'Macho', 21),
('Molly', 'Perro', 'Cocker Spaniel', 7, 'Hembra', 22),
('Apolo', 'Perro', 'Gran Dan�s', 3, 'Macho', 23),
('Pelusa', 'Conejo', 'Cabeza de Le�n', 1, 'Hembra', 24),
('Pipo', 'Perro', 'Mestizo', 8, 'Macho', 25),
('Nina', 'Gato', 'Ragdoll', 2, 'Hembra', 26),
('Chispa', 'Perro', 'Caniche (Toy)', 4, 'Hembra', 27),
('Buddy', 'Perro', 'Mestizo', 6, 'Macho', 28),
('Misha', 'Gato', 'Azul Ruso', 3, 'Hembra', 29),
('Hachi', 'Perro', 'Akita', 5, 'Macho', 30),
('Pancha', 'Tortuga', 'De Orejas Rojas', 15, 'Hembra', 10),
('Copito', 'H�mster', 'Sirio', 1, 'Macho', 15),
('Felix', 'Gato', 'Dom�stico Pelo Corto', 1, 'Macho', 2),
('Sasha', 'Perro', 'Pastor Belga', 2, 'Hembra', 7);

GO
-- 7. TABLA: HistoriaClinica
-- Se crea una historia cl�nica por cada una de las 35 mascotas insertadas
-- ====================================================
INSERT INTO HistoriaClinica (Observaciones, ID_Mascota) VALUES
-- Mascota 1: Max
('Apertura de HC para chequeo inicial.', 1),
-- Mascota 2: Luna
('Apertura de HC para chequeo inicial.', 2),
-- Mascota 3: Rocky
('Apertura de HC para chequeo inicial.', 3),
-- Mascota 4: Nala
('Apertura de HC para chequeo inicial.', 4),
-- Mascota 5: Coco
('Apertura de HC para chequeo inicial.', 5),
-- Mascota 6: Simba
('Apertura de HC para chequeo inicial.', 6),
-- Mascota 7: Lola
('Apertura de HC para chequeo inicial.', 7),
-- Mascota 8: Thor
('Apertura de HC para chequeo inicial.', 8),
-- Mascota 9: M�a
('Apertura de HC para chequeo inicial.', 9),
-- Mascota 10: Toby
('Apertura de HC para chequeo inicial.', 10),
-- Mascota 11: Kiwi
('Apertura de HC para chequeo inicial.', 11),
-- Mascota 12: Bella
('Apertura de HC para chequeo inicial.', 12),
-- Mascota 13: Zeus
('Apertura de HC para chequeo inicial.', 13),
-- Mascota 14: Frida
('Apertura de HC para chequeo inicial.', 14),
-- Mascota 15: Bruno
('Apertura de HC para chequeo inicial.', 15),
-- Mascota 16: Oreo
('Apertura de HC para chequeo inicial.', 16),
-- Mascota 17: Daisy
('Apertura de HC para chequeo inicial.', 17),
-- Mascota 18: Milo
('Apertura de HC para chequeo inicial.', 18),
-- Mascota 19: Cleo
('Apertura de HC para chequeo inicial.', 19),
-- Mascota 20: Leo
('Apertura de HC para chequeo inicial.', 20),
-- Mascota 21: Jack
('Apertura de HC para chequeo inicial.', 21),
-- Mascota 22: Shadow
('Apertura de HC para chequeo inicial.', 22),
-- Mascota 23: Molly
('Apertura de HC para chequeo inicial.', 23),
-- Mascota 24: Apolo
('Apertura de HC para chequeo inicial.', 24),
-- Mascota 25: Pelusa
('Apertura de HC para chequeo inicial.', 25),
-- Mascota 26: Pipo
('Apertura de HC para chequeo inicial.', 26),
-- Mascota 27: Nina
('Apertura de HC para chequeo inicial.', 27),
-- Mascota 28: Chispa
('Apertura de HC para chequeo inicial.', 28),
-- Mascota 29: Buddy
('Apertura de HC para chequeo inicial.', 29),
-- Mascota 30: Misha
('Apertura de HC para chequeo inicial.', 30),
-- Mascota 31: Hachi
('Apertura de HC para chequeo inicial.', 31),
-- Mascota 32: Pancha
('Apertura de HC para chequeo inicial.', 32),
-- Mascota 33: Copito
('Apertura de HC para chequeo inicial.', 33),
-- Mascota 34: Felix
('Apertura de HC para chequeo inicial.', 34),
GO

-- ====================================================
-- 7. TABLA: Cita
-- (Depende de Mascota, Veterinario, Servicio)
-- ====================================================
INSERT INTO Cita (Fecha, Hora, ID_Mascota, ID_Veterinario, ID_Servicio) VALUES
-- Citas de Consulta General (ID_Servicio = 1)
('2024-01-05', '10:00:00', 1, 5, 1),   -- Max (Labrador) con Dr. Roberto Cruz
('2024-01-05', '10:30:00', 2, 10, 1),  -- Luna (Siam�s) con Dra. Rebeca Arg�ello (Medicina Felina)
('2024-01-05', '11:00:00', 4, 10, 1),  -- Nala (Gato)
('2024-01-06', '09:00:00', 5, 5, 1),   -- Coco (Bulldog Franc�s)
('2024-01-06', '09:30:00', 7, 12, 1),  -- Lola (Pug) con Dra. Melissa Baltodano
('2024-01-06', '10:00:00', 8, 5, 1),   -- Thor (Rottweiler)
('2024-01-07', '14:00:00', 12, 17, 1), -- Bella (Chihuahua) con Dr. Oscar Valle
('2024-01-07', '15:00:00', 16, 25, 1), -- Oreo (Gato) con Dr. F�lix Rivas
('2024-01-08', '11:30:00', 21, 2, 1),  -- Jack (Jack Russell) con Dra. Beatriz Pe�a
('2024-01-08', '12:00:00', 25, 25, 1), -- Pelusa (Conejo)
-- Citas de Vacunaci�n (ID_Servicio: 3 (Rabia), 4 (M�ltiple Canina), 5 (Triple Felina))
('2024-01-10', '08:00:00', 1, 16, 4),  -- Max (Labrador) con Dra. Karen Mendieta (Preventiva)
('2024-01-10', '08:30:00', 2, 16, 5),  -- Luna (Gato)
('2024-01-10', '09:00:00', 10, 16, 4), -- Toby (Golden Retriever)
('2024-01-11', '16:00:00', 14, 16, 5), -- Frida (Gato)
('2024-01-11', '16:30:00', 18, 16, 5), -- Cleo (Gato)
('2024-01-12', '10:00:00', 22, 16, 3), -- Shadow (Maine Coon)
('2024-01-12', '10:30:00', 27, 16, 5), -- Nina (Ragdoll)
('2024-01-12', '11:00:00', 33, 16, 3), -- Copito (Hamster) - Vacunaci�n at�pica o desparasitaci�n
-- Citas Especializadas (ID_Servicio: 2 (Especializada), 13 (Radiograf�a), 14 (Ultrasonido))
('2024-01-15', '14:00:00', 3, 2, 2),   -- Rocky (Pastor Alem�n) con Dra. Beatriz Pe�a (Medicina Interna)
('2024-01-15', '14:30:00', 5, 3, 2),   -- Coco (Bulldog Franc�s) con Dr. Miguel Cifuentes (Dermatolog�a)
('2024-01-16', '10:00:00', 8, 6, 15),  -- Thor (Rottweiler) con Dra. Sandra Guido (Cardiolog�a) - Ecocardiograma
('2024-01-16', '11:00:00', 13, 7, 2),  -- Zeus (Husky) con Dr. Esteban Lacayo (Neurolog�a)
('2024-01-17', '15:00:00', 19, 13, 2), -- Leo (Doberman) con Dr. Enrique Fonseca (Oftalmolog�a)
('2024-01-17', '16:00:00', 29, 23, 2), -- Buddy (Mestizo) con Dr. Ariel D�vila (Dermatolog�a)
('2024-01-18', '09:00:00', 35, 1, 13), -- Sasha (Pastor Belga) con Dr. Alejandro Sol�s (Cirug�a) - Pre-quir�rgica
-- Citas de Control (ID_Servicio: 1 (Consulta), 9 (Heces), 10 (Hemograma))
('2024-01-20', '10:00:00', 1, 5, 10),
('2024-01-20', '10:30:00', 2, 10, 9),
('2024-01-21', '09:00:00', 4, 12, 1),
('2024-01-21', '09:30:00', 6, 17, 1),
('2024-01-22', '14:00:00', 9, 5, 10),
('2024-01-22', '14:30:00', 15, 25, 9),
-- M�s Citas Generales y de Vacunaci�n para superar 100
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
-- M�s Citas Especializadas, Limpieza Dental (23), Desparasitaci�n (6, 7)
('2024-02-12', '15:00:00', 5, 14, 23), -- Coco (Bulldog Franc�s) - Limpieza Dental con Dra. Victoria Ponce
('2024-02-12', '16:00:00', 19, 15, 2), -- Leo (Doberman) - Ortopedia con Dr. Julio Benda�a
('2024-02-13', '10:00:00', 23, 21, 2), -- Apolo (Gran Dan�s) - Cirug�a con Dr. Marlon Estrada (Pre-op)
('2024-02-13', '11:00:00', 3, 22, 2),  -- Rocky (Pastor Alem�n) - Interna con Dra. Gabriela Sol�rzano
('2024-02-14', '08:00:00', 1, 16, 6),  -- Max - Desparasitaci�n Perro
('2024-02-14', '08:30:00', 2, 16, 7),  -- Luna - Desparasitaci�n Gato
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
-- M�s Citas de chequeo general
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
-- M�s citas para desparasitaci�n
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
-- 9. TABLA: Factura 
-- (Usaremos los IDs de Cita para las primeras facturas)
-- (Depende de Servicio, Propietario, Cita)
-- Los costos se toman de la tabla Servicio: 
-- 1 (Consulta General 35.00), 4 (Vacuna M�ltiple 30.00), 5 (Triple Felina 28.00), 15 (Ecocardiograma 85.00), 23 (Limpieza Dental 110.00)
-- ====================================================

INSERT INTO Factura (Fecha, Total, ID_Propietario, ID_Cita, EstadoPago) VALUES
-- Las primeras facturas coinciden con las primeras citas
('2024-01-05', 35.00, 1, 1, 'Pagada'),   -- Max, Consulta General
('2024-01-05', 35.00, 1, 2, 2),   -- Luna, Consulta General
('2024-01-05', 35.00, 1, 3, 3),   -- Nala, Consulta General
('2024-01-06', 35.00, 1, 4, 4),   -- Coco, Consulta General
('2024-01-06', 35.00, 1, 6, 5),   -- Lola, Consulta General
('2024-01-06', 35.00, 1, 7, 6),   -- Thor, Consulta General
('2024-01-07', 35.00, 1, 11, 7),  -- Bella, Consulta General
('2024-01-07', 35.00, 1, 15, 8),  -- Oreo, Consulta General
('2024-01-08', 35.00, 1, 20, 9),  -- Jack, Consulta General
('2024-01-08', 35.00, 1, 25, 10), -- Pelusa, Consulta General
('2024-01-10', 30.00, 4, 1, 11),  -- Max, Vacuna M�ltiple
('2024-01-10', 28.00, 5, 2, 12),  -- Luna, Triple Felina
('2024-01-10', 30.00, 4, 9, 13),  -- Toby, Vacuna M�ltiple
('2024-01-11', 28.00, 5, 13, 14), -- Frida, Triple Felina
('2024-01-11', 28.00, 5, 18, 15), -- Cleo, Triple Felina
('2024-01-12', 20.00, 3, 21, 16), -- Shadow, Vacuna Rabia
('2024-01-12', 28.00, 5, 26, 17), -- Nina, Triple Felina
('2024-01-12', 20.00, 3, 15, 18), -- Copito, Vacuna Rabia (simulado)
('2024-01-15', 50.00, 2, 1, 19),  -- Rocky, Consulta Especializada
('2024-01-15', 50.00, 2, 4, 20),  -- Coco, Consulta Especializada
('2024-01-16', 85.00, 15, 7, 21), -- Thor, Ecocardiograma
('2024-01-16', 50.00, 2, 12, 22), -- Zeus, Consulta Especializada
('2024-01-17', 50.00, 2, 19, 23), -- Leo, Consulta Especializada
('2024-01-17', 50.00, 2, 29, 24), -- Buddy, Consulta Especializada
('2024-01-18', 55.00, 13, 7, 25), -- Sasha, Radiograf�a
('2024-01-20', 40.00, 10, 1, 26), -- Max, Hemograma
('2024-01-20', 22.00, 9, 2, 27),  -- Luna, Examen Heces
('2024-01-21', 35.00, 1, 3, 28),
('2024-01-21', 35.00, 1, 5, 29),
('2024-01-22', 40.00, 10, 8, 30),
('2024-01-22', 22.00, 9, 14, 31),
('2024-01-25', 30.00, 4, 1, 32),
('2024-01-25', 28.00, 5, 3, 33),
('2024-01-26', 35.00, 1, 4, 34),
('2024-01-26', 35.00, 1, 5, 35),
('2024-01-27', 30.00, 4, 6, 36),
('2024-01-27', 35.00, 1, 7, 37),
('2024-01-28', 35.00, 1, 8, 38),
('2024-01-28', 30.00, 4, 9, 39),
('2024-01-29', 35.00, 1, 10, 40),
('2024-01-29', 35.00, 1, 11, 41),
('2024-01-30', 35.00, 1, 12, 42),
('2024-01-30', 28.00, 5, 13, 43),
('2024-01-31', 35.00, 1, 14, 44),
('2024-01-31', 28.00, 5, 15, 45),
('2024-02-01', 35.00, 1, 16, 46),
('2024-02-01', 28.00, 5, 17, 47),
('2024-02-02', 35.00, 1, 18, 48),
('2024-02-02', 30.00, 4, 19, 49),
('2024-02-03', 35.00, 1, 20, 50),
('2024-02-03', 28.00, 5, 21, 51),
('2024-02-04', 35.00, 1, 22, 52),
('2024-02-04', 35.00, 1, 23, 53),
('2024-02-05', 35.00, 1, 24, 54),
('2024-02-05', 35.00, 1, 25, 55),
('2024-02-06', 28.00, 5, 26, 56),
('2024-02-06', 30.00, 4, 27, 57),
('2024-02-07', 35.00, 1, 28, 58),
('2024-02-07', 28.00, 5, 29, 59),
('2024-02-08', 30.00, 4, 30, 60),
('2024-02-08', 35.00, 1, 10, 61),
('2024-02-09', 35.00, 1, 15, 62),
('2024-02-09', 28.00, 5, 2, 63),
('2024-02-10', 35.00, 1, 7, 64),
('2024-02-12', 110.00, 23, 4, 65), 
('2024-02-12', 50.00, 2, 19, 66),
('2024-02-13', 50.00, 2, 23, 67),
('2024-02-13', 50.00, 2, 1, 68),
('2024-02-14', 15.00, 6, 1, 69),  
('2024-02-14', 12.00, 7, 2, 70),  
('2024-02-14', 15.00, 6, 1, 71),
('2024-02-15', 12.00, 7, 3, 72),
('2024-02-15', 15.00, 6, 4, 73),
('2024-02-16', 12.00, 7, 5, 74),
('2024-02-16', 15.00, 6, 6, 75),
('2024-02-17', 15.00, 6, 7, 76),
('2024-02-17', 15.00, 6, 8, 77),
('2024-02-18', 15.00, 6, 9, 78),
('2024-02-18', 15.00, 6, 11, 79),
('2024-02-19', 35.00, 1, 12, 80),
('2024-02-19', 12.00, 7, 13, 81),
('2024-02-20', 35.00, 1, 14, 82),
('2024-02-20', 12.00, 7, 15, 83),
('2024-02-21', 35.00, 1, 16, 84),
('2024-02-21', 12.00, 7, 17, 85),
('2024-02-22', 35.00, 1, 18, 86),
('2024-02-22', 15.00, 6, 19, 87),
('2024-02-23', 35.00, 1, 20, 88),
('2024-02-23', 12.00, 7, 21, 89),
('2024-02-24', 15.00, 6, 22, 90),
('2024-02-24', 35.00, 1, 23, 91),
('2024-02-25', 35.00, 1, 24, 92),
('2024-02-25', 35.00, 1, 25, 93),
('2024-02-26', 12.00, 7, 26, 94),
('2024-02-26', 15.00, 6, 27, 95),
('2024-02-27', 35.00, 1, 28, 96),
('2024-02-27', 12.00, 7, 29, 97),
('2024-02-28', 15.00, 6, 30, 98),
('2024-02-28', 35.00, 1, 10, 99),
('2024-02-29', 35.00, 1, 15, 100),
('2024-02-29', 12.00, 7, 2, 101),
('2024-03-01', 15.00, 6, 7, 102),
('2024-03-02', 35.00, 1, 1, 103),
('2024-03-02', 35.00, 1, 2, 104),
('2024-03-03', 35.00, 1, 1, 105),
('2024-03-03', 35.00, 1, 3, 106),
('2024-03-04', 35.00, 1, 4, 107),
('2024-03-04', 35.00, 1, 5, 108),
('2024-03-05', 35.00, 1, 6, 109),
('2024-03-05', 35.00, 1, 7, 110),
('2024-03-06', 35.00, 1, 8, 111),
('2024-03-06', 35.00, 1, 9, 112),
('2024-03-07', 35.00, 1, 10, 113),
('2024-03-07', 35.00, 1, 11, 114),
('2024-03-08', 35.00, 1, 12, 115),
('2024-03-08', 35.00, 1, 13, 116),
('2024-03-09', 35.00, 1, 14, 117),
('2024-03-09', 35.00, 1, 15, 118),
('2024-03-10', 35.00, 1, 16, 119),
('2024-03-10', 35.00, 1, 17, 120),
('2024-03-11', 35.00, 1, 18, 121),
('2024-03-11', 35.00, 1, 19, 122),
('2024-03-12', 35.00, 1, 20, 123),
('2024-03-12', 35.00, 1, 21, 124),
('2024-03-13', 35.00, 1, 22, 125),
('2024-03-13', 35.00, 1, 23, 126),
('2024-03-14', 35.00, 1, 24, 127),
('2024-03-14', 35.00, 1, 25, 128),
('2024-03-15', 35.00, 1, 26, 129),
('2024-03-15', 35.00, 1, 27, 130),
('2024-03-16', 35.00, 1, 28, 131),
('2024-03-16', 35.00, 1, 29, 132),
('2024-03-17', 35.00, 1, 30, 133),
('2024-03-17', 35.00, 1, 10, 134),
('2024-03-18', 35.00, 1, 15, 135),
('2024-03-18', 35.00, 1, 2, 136),
('2024-03-19', 35.00, 1, 7, 137),
('2024-03-20', 15.00, 6, 1, 138),
('2024-03-20', 12.00, 7, 2, 139),
('2024-03-20', 15.00, 6, 1, 140),
('2024-03-21', 12.00, 7, 3, 141),
('2024-03-21', 15.00, 6, 4, 142),
('2024-03-22', 12.00, 7, 5, 143),
('2024-03-22', 15.00, 6, 6, 144),
('2024-03-23', 15.00, 6, 7, 145),
('2024-03-23', 15.00, 6, 8, 146),
('2024-03-24', 15.00, 6, 9, 147),
('2024-03-24', 35.00, 1, 10, 148),
('2024-03-25', 15.00, 6, 11, 149),
('2024-03-25', 35.00, 1, 12, 150); 
GO

-- ====================================================
-- 10. TABLA: Tratamiento 
-- (Depende de Mascota)
-- Se enfoca en diagnosticos de problemas cr�nicos o infecciones
-- ====================================================
PRINT 'Poblando Tratamiento (110)...';
INSERT INTO Tratamiento (Fecha, Diagnostico, ID_Mascota) VALUES
('2024-01-05', 'Otitis externa aguda. Iniciar antibi�tico t�pico.', 1), -- Max (Perro)
('2024-01-05', 'Gingivitis leve. Se recomienda profilaxis dental.', 2), -- Luna (Gato)
('2024-01-15', 'Enfermedad articular degenerativa. Control de dolor.', 3), -- Rocky (Perro)
('2024-01-15', 'Dermatitis at�pica, brote agudo. Iniciar esteroides.', 5), -- Coco (Perro)
('2024-01-16', 'Soplo cardiaco Grado III. Se requiere ecocardiograma.', 8), -- Thor (Perro)
('2024-01-17', '�lcera corneal superficial. Tratamiento con colirio antibi�tico.', 19), -- Leo (Perro)
('2024-01-20', 'Anaplasmosis canina (resultado positivo). Iniciar Doxiciclina.', 1), -- Max (Perro)
('2024-01-22', 'Infecci�n urinaria. Cultivo en proceso. Iniciar tratamiento emp�rico.', 10), -- Toby (Perro)
('2024-01-26', 'Infecci�n de v�as respiratorias superiores (Gripe felina).', 6), -- Simba (Gato)
('2024-01-28', 'Dermatitis por pulgas. Aplicaci�n de antipulgas y antinflamatorio.', 12), -- Bella (Perro)
('2024-02-02', 'Linfoma cut�neo. Inicio de protocolo de quimioterapia oral.', 20), -- Jack (Perro)
('2024-02-05', 'Insuficiencia renal cr�nica (estadio II). Dieta y manejo de fluidos.', 24), -- Alejandra (Perro)
('2024-02-13', 'Trauma por ca�da. M�ltiples contusiones y hematomas.', 23), -- Apolo (Perro)
('2024-02-14', 'Control de par�sitos. Desparasitaci�n interna de rutina.', 1), -- Max
('2024-02-14', 'Control de par�sitos. Desparasitaci�n interna de rutina.', 2), -- Luna
('2024-02-14', 'Control de par�sitos. Desparasitaci�n interna de rutina.', 3), -- Rocky
('2024-02-15', 'Control de par�sitos. Desparasitaci�n interna de rutina.', 4), -- Nala
('2024-02-15', 'Control de par�sitos. Desparasitaci�n interna de rutina.', 5), -- Coco
('2024-02-16', 'Control de par�sitos. Desparasitaci�n interna de rutina.', 6), -- Simba
('2024-02-16', 'Control de par�sitos. Desparasitaci�n interna de rutina.', 7), -- Lola
('2024-02-17', 'Control de par�sitos. Desparasitaci�n interna de rutina.', 8), -- Thor
('2024-02-17', 'Control de par�sitos. Desparasitaci�n interna de rutina.', 9), -- M�a
('2024-02-18', 'Control de par�sitos. Desparasitaci�n interna de rutina.', 10), -- Toby
('2024-02-18', 'Control de par�sitos. Desparasitaci�n interna de rutina.', 12), -- Bella
('2024-02-19', 'Control de par�sitos. Desparasitaci�n interna de rutina.', 14), -- Frida
('2024-02-20', 'Control de par�sitos. Desparasitaci�n interna de rutina.', 16), -- Oreo
('2024-02-21', 'Control de par�sitos. Desparasitaci�n interna de rutina.', 18), -- Cleo
('2024-02-22', 'Control de par�sitos. Desparasitaci�n interna de rutina.', 20), -- Jack
('2024-02-23', 'Control de par�sitos. Desparasitaci�n interna de rutina.', 22), -- Shadow
('2024-02-24', 'Control de par�sitos. Desparasitaci�n interna de rutina.', 23), -- Apolo
('2024-02-26', 'Control de par�sitos. Desparasitaci�n interna de rutina.', 27), -- Nina
('2024-02-27', 'Control de par�sitos. Desparasitaci�n interna de rutina.', 28), -- Chispa
('2024-02-27', 'Control de par�sitos. Desparasitaci�n interna de rutina.', 29), -- Buddy
('2024-02-28', 'Control de par�sitos. Desparasitaci�n interna de rutina.', 30), -- Misha
('2024-02-29', 'Control de par�sitos. Desparasitaci�n interna de rutina.', 31), -- Hachi
('2024-03-01', 'Control de par�sitos. Desparasitaci�n interna de rutina.', 35), -- Sasha
-- Tratamientos de seguimiento y nuevos casos
('2024-03-02', 'Control de Otitis. Mejor�a, continuar con gotas 5 d�as m�s.', 1),
('2024-03-03', 'Control de Dolor Cr�nico. Ajuste de dosis de Meloxicam.', 3),
('2024-03-04', 'Revisi�n de piel. La dermatitis mejora con tratamiento. Reducir dosis de Prednisona.', 5),
('2024-03-05', 'Revisi�n �lcera Corneal. Curaci�n completa. Suspensi�n de tratamiento.', 19),
('2024-03-06', 'Gastroenteritis aguda. Dieta blanda y antiem�ticos.', 7),
('2024-03-07', 'Mordedura de otro perro. Herida superficial. Sutura simple y antibi�tico.', 29),
('2024-03-08', 'Sospecha de intoxicaci�n por raticida. Administrar Vitamina K.', 10),
('2024-03-09', 'Chequeo geri�trico. Iniciar suplemento articular.', 21),
('2024-03-10', 'Problemas dentales severos. Programar Limpieza Dental y posibles extracciones.', 23),
('2024-03-11', 'Absceso en pata. Drenaje y antibi�tico.', 26),
('2024-03-12', 'Vigilancia de enfermedad cardiaca. Pr�xima revisi�n en 3 meses.', 8),
('2024-03-13', 'Chequeo de mascota ex�tica. Dieta y ambiente �ptimos.', 11),
('2024-03-14', 'Revisi�n de la Leucemia Felina. Par�metros estables.', 14),
('2024-03-15', 'Otitis cr�nica. Mantenimiento con limpiador de o�dos.', 17),
('2024-03-16', 'Revisi�n de ISR (Insuficiencia Renal). Ajuste de fluidos subcut�neos.', 24),
('2024-03-17', 'Problema de comportamiento: Ansiedad por separaci�n. Iniciar terapia conductual y medicaci�n.', 35),
('2024-03-18', 'C�lculos en vejiga (Diagn�stico por ultrasonido). Programar cistotom�a.', 19),
('2024-03-19', 'Tos de perrera. Iniciar Doxiciclina y antitusivo.', 3),
('2024-03-20', 'Infecci�n en herida post-quir�rgica (cirug�a anterior). Lavado y antibi�tico.', 23),
('2024-03-21', 'Control de desparasitaci�n. Sin par�sitos en heces.', 1),
('2024-03-22', 'Control de desparasitaci�n. Sin par�sitos en heces.', 2),
('2024-03-23', 'Control de dolor por osteoartritis. Meloxicam.', 12),
('2024-03-24', 'Deshidrataci�n por v�mitos. Fluidoterapia IV.', 7),
('2024-03-25', 'Sospecha de tumoraci�n abdominal. Cita para TAC.', 8),
('2024-03-26', 'Alergia alimentaria. Cambio a dieta hipoalerg�nica.', 5),
('2024-03-27', 'Eclampsia postparto (emergencia). Calcio IV y monitoreo.', 28),
('2024-03-28', 'Dermatitis f�ngica. Tratamiento con Ketoconazol t�pico.', 10),
('2024-03-29', 'Problemas de motilidad intestinal. Cisaprida.', 13),
('2024-03-30', 'Control de anemia. Suplemento de hierro.', 15),
('2024-03-31', 'Revisi�n de mordedura (control). Herida sana.', 29),
-- M�s seguimientos de tratamientos
('2024-04-01', 'Seguimiento de Anaplasmosis. Control de hemograma.', 1),
('2024-04-02', 'Seguimiento de IRA. Par�metros renales estables.', 24),
('2024-04-03', 'Control de Gastroenteritis. Dieta blanda contin�a.', 7),
('2024-04-04', 'Control de Tos de Perrera. Mejor�a notable.', 3),
('2024-04-05', 'Revisi�n de ansiedad. Dosis de medicaci�n estable.', 35),
('2024-04-06', 'Control de Absceso. Listo para retirar puntos.', 26),
('2024-04-07', 'Control de Linfoma. Quimioterapia tolerada.', 20),
('2024-04-08', 'Revisi�n de Sonda de alimentaci�n (anterior hospitalizaci�n).', 23),
('2024-04-09', 'Dolor en la espalda. Reposo y antiinflamatorio (Meloxicam).', 31),
('2024-04-10', 'Revisi�n de piel por Dermatitis. Cambio de medicaci�n.', 5),
('2024-04-11', 'V�mitos espor�dicos. Anti�cido (Omeprazol) y ayuno.', 14),
('2024-04-12', 'Revisi�n de �lcera corneal (nuevo caso). Aplicaci�n de antibi�tico.', 12),
('2024-04-13', 'Control de Gingivitis. Se programa la profilaxis dental.', 2),
('2024-04-14', 'Infecci�n ocular. Colirio de Tilosina.', 9),
('2024-04-15', 'Tratamiento preventivo para Leishmania (viaje).', 1),
('2024-04-16', 'Dolor por Osteoartritis. Reajuste de dosis de Gabapentina.', 3),
('2024-04-17', 'Revisi�n de masa en cuello. Punci�n (FNA) para citolog�a.', 5),
('2024-04-18', 'Control de hipertiroidismo (nuevo caso). Iniciar Metimazol.', 14),
('2024-04-19', 'Seguimiento de mordedura grave. Curaci�n por segunda intenci�n.', 29),
('2024-04-20', 'Otitis media. Tratamiento con Maropitant y antibi�tico sist�mico.', 8),
('2024-04-21', 'Revisi�n de la alimentaci�n en conejos. Ajuste de heno.', 25),
('2024-04-22', 'Profilaxis dental post-operatoria. Recomendaciones de cepillado.', 23),
('2024-04-23', 'Alergia ambiental. Antihistam�nico.', 7),
('2024-04-24', 'Chequeo pre-quir�rgico para esterilizaci�n.', 28),
('2024-04-25', 'Infecci�n de herida. Limpieza y curaci�n.', 31),
('2024-04-26', 'Control de dolor por fractura antigua. Tramadol.', 19),
('2024-04-27', 'Revisi�n de anemia felina. Transfusi�n de sangre.', 15),
('2024-04-28', 'Diagn�stico de Pi�metra. Cirug�a de emergencia programada.', 28),
('2024-04-29', 'Dolor articular. Carprofeno.', 10),
('2024-04-30', 'Infecci�n en pata. Cefalexina.', 5),
('2024-05-01', 'Revisi�n de Anaplasmosis. Hemograma con mejor�a.', 1),
('2024-05-02', 'Control de tos. Antitusivo.', 3),
('2024-05-03', 'Gastroenteritis (leve). Dieta blanda.', 7),
('2024-05-04', 'Dermatitis. Tratamiento t�pico.', 5),
('2024-05-05', 'Control de ansiedad. Ajuste de dosis.', 35),
('2024-05-06', 'Chequeo de mascota geri�trica. Sin cambios.', 21),
('2024-05-07', 'Dolor por Osteoartritis. Meloxicam.', 12),
('2024-05-08', 'Revisi�n de IRC. Fluidos subcut�neos.', 24),
('2024-05-09', 'Absceso. Drenaje y antibi�tico.', 26),
('2024-05-10', 'Control post-cirug�a dental.', 2),
('2024-05-11', 'Infecci�n ocular. Colirio de Tilosina.', 9),
('2024-05-12', 'Revisi�n de Anemia. Suplemento de hierro.', 15),
('2024-05-13', 'Control de hipertiroidismo. Dosis estable.', 14),
('2024-05-14', 'Dolor abdominal. Radiograf�a y antiinflamatorio.', 10),
('2024-05-15', 'Revisi�n de mordedura (final). Cicatrizaci�n completa.', 29),
('2024-05-16', 'Tos de perrera (reca�da). Doxiciclina y antitusivo.', 3),
('2024-05-17', 'Otitis. Tratamiento t�pico.', 1),
('2024-05-18', 'Control de dolor por fractura antigua. Tramadol.', 19),
('2024-05-19', 'Alergia ambiental. Antihistam�nico.', 7),
('2024-05-20', 'Control de tumoraci�n. Pendiente citolog�a.', 5),
('2024-05-21', 'Chequeo de mascota ex�tica. Sin problemas.', 11),
('2024-05-22', 'Dolor articular. Carprofeno.', 31),
('2024-05-23', 'Revisi�n de Pi�metra (post-cirug�a). Retiro de puntos.', 28),
('2024-05-24', 'Dermatitis f�ngica. Tratamiento t�pico.', 10),
('2024-05-25', 'Problemas de motilidad intestinal. Cisaprida.', 13),
('2024-05-26', 'Control de hipertiroidismo. Reajuste de dosis.', 14),
('2024-05-27', 'Infecci�n en pata. Cefalexina.', 31),
('2024-05-28', 'Revisi�n de �lcera corneal. Curaci�n en proceso.', 12),
('2024-05-29', 'Control de Lymphoma. Pr�xima quimioterapia.', 20),
('2024-05-30', 'Seguimiento de anemia felina. Suplemento de hierro.', 15),
('2024-05-31', 'Otitis cr�nica. Mantenimiento con limpiador.', 17),
('2024-06-01', 'Dolor por Osteoartritis. Meloxicam.', 12),
('2024-06-02', 'Revisi�n de IRC. Dieta renal.', 24);
GO

--- ====================================================
--- 11. TABLA: Tratamiento_Medicamento 
--- (Depende de Tratamiento, Medicamento)
--- Se asocia un medicamento a cada tratamiento
--- ====================================================
INSERT INTO Tratamiento_Medicamento (ID_Tratamiento, ID_Medicamento) VALUES
(1, 2), (1, 10),� �-- Otitis: Amoxi + Meloxicam
(2, 2),� � � � � -- Gingivitis: Propofol (si se requiere sedaci�n para examinar)
(3, 4), (4, 8),� �-- Osteoartritis: Meloxicam + Gabapentina
(4, 23),           -- Dermatitis: Prednisona + Cefalexina (Se elimin� (4, 12) que causaba el error de clave primaria)
(5, 5), (5, 6),� �-- Soplo Cardiaco: Furosemida + Enalapril
(6, 11),� � � � � -- �lcera corneal: Doxiciclina (colirio o sist�mico)
(7, 11),� � � � � -- Anaplasmosis: Doxiciclina
(8, 12), (8, 14), -- Infecci�n urinaria: Cefalexina + Sucralfato (protector)
(9, 11), (9, 16), -- Gripe Felina: Doxiciclina + Maropitant (antivomitivo/n�usea)
(10, 2), (10, 17),-- Dermatitis por pulgas: Prednisona + Ivermectina
(11, 2), (11, 15),-- Linfoma cut�neo: Prednisona + Ondansetr�n
(12, 5), (12, 28),-- IRC: Furosemida + Suero Salino
(13, 3), (13, 27),-- Trauma: Meloxicam + Suero Ringer
(14, 20),� � � � �-- Desparasitaci�n: Praziquantel
(15, 20),
(16, 20),
(17, 20),
(18, 20),
(19, 20),
(20, 20),
(21, 20),
(22, 20),
(23, 20),
(24, 20),
(25, 20),
(26, 20),
(27, 20),
(28, 20),
(29, 20),
(30, 20),
(31, 20),
(32, 20),
(33, 20),
(34, 20),
(35, 20),
(36, 1), (36, 25),-- Control de Otitis: Amoxicilina + Clorhexidina
(37, 3), (37, 8), -- Control de dolor: Meloxicam + Gabapentina
(38, 2), (38, 1), -- Dermatitis: Prednisona + Amoxicilina
(39, 11),� � � � �-- �lcera Corneal: Doxiciclina
(40, 16), (40, 14), -- Gastroenteritis: Maropitant + Sucralfato
(41, 1), (41, 26), -- Mordedura: Amoxicilina + Yodo Povidona
(42, 29), (42, 27), -- Intoxicaci�n: Vitamina K + Suero Ringer
(43, 3),� � � � � �-- Chequeo geri�trico: Meloxicam
(44, 23),� � � � � -- Problemas dentales: Propofol (para examen)
(45, 12), (45, 25), -- Absceso: Cefalexina + Clorhexidina
(46, 5), (46, 6),� �-- Enfermedad cardiaca: Furosemida + Enalapril
(47, 12),� � � � � -- Mascota ex�tica: Cefalexina (preventivo si aplica)
(48, 2),� � � � � �-- Leucemia felina: Prednisona
(49, 1),� � � � � �-- Otitis cr�nica: Amoxicilina
(50, 28),� � � � � -- IRC: Suero Salino
(51, 8), (51, 2),� �-- Ansiedad: Gabapentina + Prednisona
(52, 1), (52, 3),� �-- C�lculos: Amoxicilina + Meloxicam
(53, 11), (53, 9),� -- Tos de perrera: Doxiciclina + Tramadol (antitusivo)
(54, 1), (54, 25),� -- Infecci�n post-quir�rgica: Amoxicilina + Clorhexidina
(55, 20),
(56, 20),
(57, 3), (57, 8),
(58, 16), (58, 27),
(59, 15), (59, 27),
(60, 2), (60, 11),
(61, 28), (61, 27),
(62, 1), (62, 25),
(63, 1), (63, 2),
(64, 11), (64, 16),
(65, 3), (65, 8),
(66, 2),
(67, 1),
(68, 11),
(69, 16),
(70, 2), (70, 17),
(71, 25),
(72, 23),
(73, 2),
(74, 1),
(75, 12), (75, 3),
(76, 9),
(77, 12),
(78, 11), (78, 28),
(79, 1), (79, 3),
(80, 2), (80, 12),
(81, 2), (81, 11),
(82, 3), (82, 8),
(83, 1), (83, 27),
(84, 1), (84, 25),
(85, 3), (85, 8),
(86, 1), (86, 12),
(87, 2),
(88, 11), (88, 16),
(89, 2), (89, 27),
(90, 1), (90, 3),
(91, 11),
(92, 12),
(93, 2),
(94, 3),
(95, 1), (95, 11),
(96, 14), (96, 16),
(97, 1), (97, 2),
(98, 3), (98, 8),
(99, 11),
(100, 27), (100, 28),
(101, 1),
(102, 3), (102, 8),
(103, 16), (103, 14),
(104, 2),
(105, 11),
(106, 2), (106, 17),
(107, 12), (107, 3),
(108, 9),
(109, 12),
(110, 2);
GO

-- ====================================================
-- 12. TABLA: Hospitalizacion (30 Registros)
-- (Depende de Mascota ID 1-35)
-- ====================================================
INSERT INTO Hospitalizacion (FechaIngreso, FechaSalida, Observaciones, ID_Mascota) VALUES
('2024-01-25', '2024-01-28', 'Diagn�stico de Pancreatitis. Fluidoterapia IV y control de dolor. Estuvo 3 d�as.', 7), -- Lola
('2024-01-27', '2024-01-27', 'Observaci�n por post-quir�rgico de tumor. Alta el mismo d�a.', 1), -- Max
('2024-02-13', '2024-02-15', 'Trauma grave por atropello. Monitoreo constante, sonda de alimentaci�n. 2 d�as.', 23), -- Apolo
('2024-02-20', NULL, 'Insuficiencia Renal Aguda, requiere fluidos de por vida. Hospitalizaci�n inicial 5 d�as.', 24), -- Alejandra
('2024-02-20', '2024-02-25', 'Insuficiencia Renal Aguda, requiere fluidos de por vida. Hospitalizaci�n inicial 5 d�as.', 24), -- Alejandra (se corrige el anterior con la fecha de salida)
('2024-03-08', '2024-03-09', 'Sospecha de intoxicaci�n. Lavado g�strico y fluidoterapia. 1 d�a.', 10), -- Toby
('2024-03-27', '2024-03-28', 'Eclampsia (convulsiones postparto). Calcio IV y estabilizaci�n. 1 d�a.', 28), -- Chispa
('2024-04-27', '2024-04-27', 'Anemia Felina grave. Transfusi�n de sangre. Monitoreo intensivo de 6 horas. (Se registra como 1 d�a).', 15), -- Oreo
('2024-04-28', '2024-05-01', 'Pi�metra. Cirug�a de emergencia (Ovariohisterectom�a). Postoperatorio 3 d�as.', 28), -- Chispa
('2024-05-18', '2024-05-20', 'Deshidrataci�n severa por gastroenteritis. Fluidoterapia y reposo. 2 d�as.', 7), -- Lola
('2024-05-25', '2024-05-26', 'Crisis de hipertiroidismo felino. Monitoreo cardiaco. 1 d�a.', 14), -- Frida
('2024-06-05', '2024-06-06', 'Dificultad respiratoria. Terapia con ox�geno y nebulizaci�n. 1 d�a.', 3), -- Rocky
('2024-06-15', '2024-06-17', 'V�mitos incoercibles. Hospitalizaci�n para diagn�stico y tratamiento. 2 d�as.', 5), -- Coco
('2024-06-25', '2024-06-25', 'Pre-quir�rgico de Cirug�a Ortop�dica. Observaci�n.', 19), -- Leo
('2024-07-01', '2024-07-03', 'Fiebre de origen desconocido. Hemocultivos. 2 d�as.', 1), -- Max
('2024-07-10', '2024-07-11', 'Trauma ocular. Tratamiento intensivo con colirios. 1 d�a.', 12), -- Bella
('2024-07-20', '2024-07-21', 'Anorexia felina. Sonda de alimentaci�n. 1 d�a.', 2), -- Luna
('2024-08-01', '2024-08-03', 'Hemorragia gastrointestinal. Transfusi�n y monitoreo. 2 d�as.', 10), -- Toby
('2024-08-10', '2024-08-12', 'Neumon�a. Antibi�tico IV y nebulizaciones. 2 d�as.', 35), -- Sasha
('2024-08-20', '2024-08-22', 'Postoperatorio de extracci�n dental compleja. 2 d�as.', 23), -- Apolo
('2024-09-01', '2024-09-04', 'Parvovirus canino (cachorro). 3 d�as.', 30), -- Misha
('2024-09-10', '2024-09-11', 'Crisis asm�tica. Terapia inhalada. 1 d�a.', 4), -- Nala
('2024-09-20', '2024-09-22', 'Diabetes descompensada. Ajuste de insulina. 2 d�as.', 8), -- Thor
('2024-10-01', '2024-10-05', 'Infecci�n abdominal grave. 4 d�as.', 7), -- Lola
('2024-10-10', '2024-10-10', 'Intoxicaci�n leve. Observaci�n y fluidos. 6 horas (1 d�a).', 1), -- Max
('2024-10-20', '2024-10-22', 'Control de dolor por c�ncer. 2 d�as.', 20), -- Jack
('2024-11-01', '2024-11-01', 'Pre-quir�rgico de Cirug�a de Tumor. Observaci�n.', 5), -- Coco
('2024-11-10', '2024-11-12', 'Hepatitis aguda. Tratamiento de soporte. 2 d�as.', 31), -- Hachi
('2024-12-01', '2024-12-03', 'Fractura de pata (Post-cirug�a). Cuidado post-ortopedia. 2 d�as.', 19), -- Leo
('2024-12-10', '2024-12-14', 'Fallo Renal Cr�nico (descompensaci�n). Fluidoterapia. 4 d�as.', 24); -- Alejandra
GO

-- ====================================================
-- 13. TABLA: Cirugia (20 Registros)
-- ====================================================
INSERT INTO Cirugia (Fecha, Tipo, Descripcion, ID_Mascota, ID_Veterinario) VALUES
('2024-01-27', 'Excisi�n de masa', 'Extracci�n de tumor cut�neo en hombro. Margen limpio.', 1, 1), -- Max con Dr. Sol�s (Cirug�a General)
('2024-02-12', 'Profilaxis Dental', 'Limpieza dental con ultrasonido. Sin extracciones.', 5, 14), -- Coco con Dra. Ponce (Odontolog�a)
('2024-02-28', 'Esterilizaci�n (OVH)', 'Ovariohisterectom�a canina de rutina.', 28, 21), -- Chispa con Dr. Estrada (Cirug�a General)
('2024-03-18', 'Cistotom�a', 'Extracci�n de c�lculos vesicales. Env�o a patolog�a.', 19, 1), -- Leo con Dr. Sol�s (Cirug�a General)
('2024-04-28', 'OVH de emergencia', 'Ovariohisterectom�a por Pi�metra (Infecci�n uterina).', 28, 21), -- Chispa con Dr. Estrada (Cirug�a General)
('2024-05-05', 'Esterilizaci�n (Castraci�n)', 'Orquiectom�a canina (castraci�n).', 10, 1), -- Toby con Dr. Sol�s
('2024-05-10', 'Extracciones Dentales', 'Profilaxis dental y extracci�n de 4 premolares.', 2, 14), -- Luna con Dra. Ponce
('2024-06-26', 'Cirug�a Ortop�dica', 'Reparaci�n de fractura de tibia con placa y tornillos.', 19, 15), -- Leo con Dr. Benda�a (Ortop�dica)
('2024-07-05', 'Extirpaci�n de tumor', 'Mastectom�a unilateral simple. Env�o a patolog�a.', 12, 21), -- Bella con Dr. Estrada
('2024-08-05', 'Correcci�n de entropi�n', 'Cirug�a palpebral para corregir p�rpado invertido.', 13, 13), -- Zeus con Dr. Fonseca (Oftalmolog�a)
('2024-09-05', 'Laparotom�a Exploratoria', 'Abdomen agudo, se encontr� cuerpo extra�o en intestino. Remoci�n.', 7, 1), -- Lola con Dr. Sol�s
('2024-10-01', 'Cirug�a de Tumor (Masa abdominal)', 'Excisi�n de masa en bazo. Esplenectom�a.', 8, 8), -- Thor con Dra. T�llez (Oncolog�a)
('2024-11-02', 'Biopsia incisional', 'Toma de muestra de tumoraci�n mamaria.', 5, 21), -- Coco con Dr. Estrada
('2024-12-05', 'Grooming Quir�rgico', 'Corte de pelo y limpieza profunda en sedaci�n.', 33, 4), -- Copito (H�mster) con Dra. Campos (Ex�ticos)
('2024-12-15', 'Extracci�n de dientes', 'Extracci�n dental en perro geri�trico.', 21, 14), -- Jack con Dra. Ponce
('2025-01-05', 'Esterilizaci�n (Gata)', 'OVH felina.', 30, 21), -- Misha
('2025-01-15', 'Cirug�a Ortop�dica', 'Fijaci�n externa de fractura de f�mur.', 31, 15), -- Hachi
('2025-02-05', 'Excisi�n de Lipoma', 'Remoci�n de tumoraci�n benigna de grasa.', 1, 1), -- Max
('2025-03-05', 'Correcci�n de hernia umbilical', 'Herniorrafia de rutina.', 10, 21), -- Toby
('2025-04-05', 'Amputaci�n de cola', 'Amputaci�n por lesi�n cr�nica.', 29, 1); -- Buddy
GO

--- ====================================================
---14. TABLA: Mascota_Vacuna 
--- ====================================================
INSERT INTO Mascota_Vacuna (ID_Mascota, ID_Vacuna) VALUES
-- Mascota 1 (Max - Perro)
(1, 3), (1, 7), (1, 23), (1, 4), (1, 8),
-- Mascota 2 (Luna - Gato)
(2, 11), (2, 13), (2, 24),(2,18),(2,9),
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
-- Mascota 9 (M�a - Gato)
(9, 11), (9, 13), (9, 24), (9, 18), (9, 14),
-- Mascota 10 (Toby - Perro) - Cachorro
(10, 4), (10, 5), (10, 6), (10, 7), (10, 1),
-- Mascota 11 (Kiwi - Ave)
(11, 1), (11, 3), (11,5),(11,8),
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
-- Mascota 33 (Copito - H�mster)
(33, 1), (33, 3),
-- Mascota 34 (Felix - Gato)
(34, 11), (34, 13),
-- Mascota 35 (Sasha - Perro)
(35, 7), (35, 1), (35, 23);
GO

-- NOTA: La tabla DetalleHistoria no existe en el esquema, se omite esta sección
-- ====================================================
-- 15. TABLA: FacturaDetalle (NUEVA SECCIÓN)
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
-- 16. TABLA: Pago (continuación)
-- ====================================================
-- NOTA: DetalleHistoria eliminado - tabla no existe en el esquema
GO

-- ====================================================
-- 16. TABLA: Pago
(2, 'Tratamiento', 2, '2024-01-05'),
(3, 'Tratamiento', 3, '2024-01-15'),
(5, 'Tratamiento', 4, '2024-01-15'),
(8, 'Tratamiento', 5, '2024-01-16'),
(19, 'Tratamiento', 6, '2024-01-17'),
(1, 'Tratamiento', 7, '2024-01-20'),
(10, 'Tratamiento', 8, '2024-01-22'),
(6, 'Tratamiento', 9, '2024-01-26'),
(12, 'Tratamiento', 10, '2024-01-28'),
(20, 'Tratamiento', 11, '2024-02-02'),
(24, 'Tratamiento', 12, '2024-02-05'),
(23, 'Tratamiento', 13, '2024-02-13'),
-- Eventos de Cirug�a
(1, 'Cirugia', 1, '2024-01-27'),   -- Excisi�n de masa (Max)
(5, 'Cirugia', 2, '2024-02-12'),   -- Profilaxis Dental (Coco)
(28, 'Cirugia', 3, '2024-02-28'),  -- Esterilizaci�n (Chispa)
(19, 'Cirugia', 4, '2024-03-18'),  -- Cistotom�a (Leo)
(28, 'Cirugia', 5, '2024-04-28'),  -- OVH de emergencia (Chispa)
(10, 'Cirugia', 6, '2024-05-05'), -- Castraci�n (Toby)
(2, 'Cirugia', 7, '2024-05-10'),   -- Extracciones Dentales (Luna)
(19, 'Cirugia', 8, '2024-06-26'),  -- Ortop�dica (Leo)
(12, 'Cirugia', 9, '2024-07-05'),  -- Extirpaci�n de tumor (Bella)
(13, 'Cirugia', 10, '2024-08-05'), -- Entropi�n (Zeus)
(7, 'Cirugia', 11, '2024-09-05'),  -- Laparotom�a (Lola)
(8, 'Cirugia', 12, '2024-10-01'),  -- Tumor (Thor)
(5, 'Cirugia', 13, '2024-11-02'),  -- Biopsia (Coco)
-- Eventos de Hospitalizaci�n
(7, 'Hospitalizacion', 1, '2024-01-25'), -- Pancreatitis (Lola)
(1, 'Hospitalizacion', 2, '2024-01-27'), -- Post-quir�rgico (Max)
(23, 'Hospitalizacion', 3, '2024-02-13'),-- Trauma (Apolo)
(24, 'Hospitalizacion', 5, '2024-02-20'),-- IRA (Alejandra)
(10, 'Hospitalizacion', 6, '2024-03-08'),-- Intoxicaci�n (Toby)
(28, 'Hospitalizacion', 7, '2024-03-27'),-- Eclampsia (Chispa)
(15, 'Hospitalizacion', 8, '2024-04-27'),-- Anemia (Oreo)
(28, 'Hospitalizacion', 9, '2024-04-28'),-- Pi�metra (Chispa)
(7, 'Hospitalizacion', 10, '2024-05-18'),-- Gastroenteritis (Lola)
(14, 'Hospitalizacion', 11, '2024-05-25'),-- Hipertiroidismo (Frida)
(3, 'Hospitalizacion', 12, '2024-06-05'),-- Respiratoria (Rocky)
-- Eventos de Vacuna (se usa el ID del registro en Mascota_Vacuna, se toma de 1 en adelante)
(1, 'Vacuna', 2, '2024-01-10'),   -- Rabia (Mascota_Vacuna ID 2)
(2, 'Vacuna', 12, '2024-01-10'),  -- Triple Felina (Mascota_Vacuna ID 12)
(10, 'Vacuna', 38, '2024-01-10'), -- M�ltiple Canina (Mascota_Vacuna ID 38)
(14, 'Vacuna', 55, '2024-01-11'), -- Triple Felina (Mascota_Vacuna ID 55)
(18, 'Vacuna', 68, '2024-01-11'), -- Triple Felina (Mascota_Vacuna ID 68)
(22, 'Vacuna', 77, '2024-01-12'), -- Rabia (Mascota_Vacuna ID 77)
(27, 'Vacuna', 98, '2024-01-12'), -- Triple Felina (Mascota_Vacuna ID 98)
(33, 'Vacuna', 105, '2024-01-12'),-- Rabia (Mascota_Vacuna ID 105)
(1, 'Vacuna', 1, '2024-01-25'),
(3, 'Vacuna', 2, '2024-01-25'),
(7, 'Vacuna', 10, '2024-01-27'),
(9, 'Vacuna', 11, '2024-01-28'),
(12, 'Vacuna', 13, '2024-02-06'),
-- Se completan con Tratamientos (IDs 14-110)
(1, 'Tratamiento', 14, '2024-02-14'),
(2, 'Tratamiento', 15, '2024-02-14'),
(3, 'Tratamiento', 16, '2024-02-14'),
(4, 'Tratamiento', 17, '2024-02-15'),
(5, 'Tratamiento', 18, '2024-02-15'),
(6, 'Tratamiento', 19, '2024-02-16'),
(7, 'Tratamiento', 20, '2024-02-16'),
(8, 'Tratamiento', 21, '2024-02-17'),
(9, 'Tratamiento', 22, '2024-02-17'),
(10, 'Tratamiento', 23, '2024-02-18'),
(12, 'Tratamiento', 24, '2024-02-18'),
(14, 'Tratamiento', 25, '2024-02-19'),
(16, 'Tratamiento', 26, '2024-02-20'),
(18, 'Tratamiento', 27, '2024-02-21'),
(20, 'Tratamiento', 28, '2024-02-22'),
(22, 'Tratamiento', 29, '2024-02-23'),
(23, 'Tratamiento', 30, '2024-02-24'),
(27, 'Tratamiento', 31, '2024-02-26'),
(28, 'Tratamiento', 32, '2024-02-27'),
(29, 'Tratamiento', 33, '2024-02-27'),
(30, 'Tratamiento', 34, '2024-02-28'),
(31, 'Tratamiento', 35, '2024-02-29'),
(35, 'Tratamiento', 36, '2024-03-01'),
(1, 'Tratamiento', 37, '2024-03-02'),
(3, 'Tratamiento', 38, '2024-03-03'),
(5, 'Tratamiento', 39, '2024-03-04'),
(19, 'Tratamiento', 40, '2024-03-05'),
(7, 'Tratamiento', 41, '2024-03-06'),
(29, 'Tratamiento', 42, '2024-03-07'),
(10, 'Tratamiento', 43, '2024-03-08'),
(21, 'Tratamiento', 44, '2024-03-09'),
(23, 'Tratamiento', 45, '2024-03-10'),
(26, 'Tratamiento', 46, '2024-03-11'),
(8, 'Tratamiento', 47, '2024-03-12'),
(11, 'Tratamiento', 48, '2024-03-13'),
(14, 'Tratamiento', 49, '2024-03-14'),
(17, 'Tratamiento', 50, '2024-03-15'),
(24, 'Tratamiento', 51, '2024-03-16'),
(35, 'Tratamiento', 52, '2024-03-17'),
(19, 'Tratamiento', 53, '2024-03-18'),
(3, 'Tratamiento', 54, '2024-03-19'),
(23, 'Tratamiento', 55, '2024-03-20'),
(1, 'Tratamiento', 56, '2024-03-21'),
(2, 'Tratamiento', 57, '2024-03-22'),
(12, 'Tratamiento', 58, '2024-03-23'),
(7, 'Tratamiento', 59, '2024-03-24'),
(8, 'Tratamiento', 60, '2024-03-25'),
(5, 'Tratamiento', 61, '2024-03-26'),
(28, 'Tratamiento', 62, '2024-03-27'),
(10, 'Tratamiento', 63, '2024-03-28'),
(13, 'Tratamiento', 64, '2024-03-29'),
(15, 'Tratamiento', 65, '2024-03-30'),
(29, 'Tratamiento', 66, '2024-03-31'),
(1, 'Tratamiento', 67, '2024-04-01'),
(24, 'Tratamiento', 68, '2024-04-02'),
(7, 'Tratamiento', 69, '2024-04-03'),
(3, 'Tratamiento', 70, '2024-04-04'),
(35, 'Tratamiento', 71, '2024-04-05'),
(26, 'Tratamiento', 72, '2024-04-06'),
(20, 'Tratamiento', 73, '2024-04-07'),
(23, 'Tratamiento', 74, '2024-04-08'),
(31, 'Tratamiento', 75, '2024-04-09'),
(5, 'Tratamiento', 76, '2024-04-10'),
(14, 'Tratamiento', 77, '2024-04-11'),
(12, 'Tratamiento', 78, '2024-04-12'),
(2, 'Tratamiento', 79, '2024-04-13'),
(9, 'Tratamiento', 80, '2024-04-14'),
(1, 'Tratamiento', 81, '2024-04-15'),
(3, 'Tratamiento', 82, '2024-04-16'),
(5, 'Tratamiento', 83, '2024-04-17'),
(14, 'Tratamiento', 84, '2024-04-18'),
(29, 'Tratamiento', 85, '2024-04-19'),
(8, 'Tratamiento', 86, '2024-04-20'),
(25, 'Tratamiento', 87, '2024-04-21'),
(23, 'Tratamiento', 88, '2024-04-22'),
(7, 'Tratamiento', 89, '2024-04-23'),
(28, 'Tratamiento', 90, '2024-04-24'),
(31, 'Tratamiento', 91, '2024-04-25'),
(19, 'Tratamiento', 92, '2024-04-26'),
(15, 'Tratamiento', 93, '2024-04-27'),
(28, 'Tratamiento', 94, '2024-04-28'),
(10, 'Tratamiento', 95, '2024-04-29'),
(5, 'Tratamiento', 96, '2024-04-30'),
(1, 'Tratamiento', 97, '2024-05-01'),
(3, 'Tratamiento', 98, '2024-05-02'),
(7, 'Tratamiento', 99, '2024-05-03'),
(5, 'Tratamiento', 100, '2024-05-04'),
(35, 'Tratamiento', 101, '2024-05-05'),
(21, 'Tratamiento', 102, '2024-05-06'),
(12, 'Tratamiento', 103, '2024-05-07'),
(24, 'Tratamiento', 104, '2024-05-08'),
(26, 'Tratamiento', 105, '2024-05-09'),
(2, 'Tratamiento', 106, '2024-05-10'),
(9, 'Tratamiento', 107, '2024-05-11'),
(15, 'Tratamiento', 108, '2024-05-12'),
(14, 'Tratamiento', 109, '2024-05-13'),
(10, 'Tratamiento', 110, '2024-05-14');
GO

-- ====================================================
-- 16. TABLA: Pago 
-- (Depende de Factura)
-- El Monto debe ser igual al Total de la factura.
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
-- Facturas 31-60
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
-- Facturas 61-90
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
-- Facturas 91-120
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
-- Facturas 121-150
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

