----------------------------
-- Insertar datos de prueba
--
----------------------------

USE Barberia_JK;
GO

---------------------------------------------------------
-- CLIENTES (5)
---------------------------------------------------------
INSERT INTO Cliente (Nombre, Telefono) VALUES
('Juan Pérez', '809-434-1431'),
('María López', '829-272-3422'),
('Carlos Gómez', '849-433-8933'),
('Ana Rodríguez', '809-474-4984'),
('Luis Martínez', '829-545-5675');
GO

---------------------------------------------------------
-- EMPLEADOS (5)
---------------------------------------------------------
INSERT INTO Empleado (Nombre, PorcentajeComision) VALUES
('Pedro Barber', 10.00),
('José Estilista', 12.50),
('Manuel Cortador', 15.00),
('Rosa Colorista', 8.00),
('Sofía Hair Artist', 20.00);
GO

---------------------------------------------------------
-- SERVICIOS (5)
---------------------------------------------------------
INSERT INTO Servicio (Nombre, Precio, DuracionMinutos) VALUES
('Corte de cabello', 300.00, 30),
('Barba', 200.00, 20),
('Corte + Barba', 450.00, 45),
('Tinte', 800.00, 60),
('Lavado y Secado', 250.00, 25);
GO

---------------------------------------------------------
-- CITAS (5)
-- Se usan IdCliente 1-5, IdEmpleado 1-5 e IdServicio 1-5
---------------------------------------------------------
INSERT INTO Cita (IdCliente, IdEmpleado, IdServicio, FechaHoraInicio, FechaHoraFin) VALUES
(1, 1, 1, '2025-01-10 09:00', '2025-01-10 09:30'),
(2, 2, 2, '2025-01-10 12:00', '2025-01-10 01:00'),
(3, 3, 3, '2025-01-10 01:00', '2025-01-10 01:30'),
(4, 4, 4, '2025-01-11 04:00', '2025-01-11 04:50'),
(5, 5, 5, '2025-01-11 09:30', '2025-01-11 10:20');
GO

---------------------------------------------------------
-- COMISIONES (5)
---------------------------------------------------------
INSERT INTO Comision (IdEmpleado, IdCita, MontoComision) VALUES
(1, 1, 30.00),
(2, 2, 25.00),
(3, 3, 67.50),
(4, 4, 64.00),
(5, 5, 50.00);
GO
