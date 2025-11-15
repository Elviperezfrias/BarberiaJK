-- =============================================
--  BASE DE DATOS BARBERIA JK
--  ELVI PEREZ FRIAS – 20240292
-- =============================================

-- Crear BD
DROP DATABASE IF EXISTS Barberia_JK;
GO
CREATE DATABASE Barberia_JK;
GO

USE Barberia_JK;
GO

-- =============================================
--  TABLA: Cliente
-- =============================================
CREATE TABLE Cliente (
    IdCliente INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Telefono NVARCHAR(20) NULL
);
GO

CREATE INDEX IX_Cliente_Nombre ON Cliente(Nombre);
GO

-- =============================================
--  TABLA: Empleado
-- =============================================
CREATE TABLE Empleado (
    IdEmpleado INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    PorcentajeComision DECIMAL(5,2) NOT NULL
);
GO

CREATE INDEX IX_Empleado_Nombre ON Empleado(Nombre);
GO

-- =============================================
--  TABLA: Servicio
-- =============================================
CREATE TABLE Servicio (
    IdServicio INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    DuracionMinutos INT NOT NULL
);
GO

CREATE INDEX IX_Servicio_Nombre ON Servicio(Nombre);
GO

-- =============================================
--  TABLA: Cita
-- =============================================
CREATE TABLE Cita (
    IdCita INT IDENTITY(1,1) PRIMARY KEY,
    IdCliente INT NOT NULL,
    IdEmpleado INT NOT NULL,
    IdServicio INT NOT NULL,
    FechaHoraInicio DATETIME NOT NULL,
    FechaHoraFin DATETIME NOT NULL,

    CONSTRAINT FK_Cita_Cliente 
        FOREIGN KEY (IdCliente) 
        REFERENCES Cliente(IdCliente)
        ON DELETE CASCADE,  -- Si un cliente se elimina, sus citas también

    CONSTRAINT FK_Cita_Empleado 
        FOREIGN KEY (IdEmpleado) 
        REFERENCES Empleado(IdEmpleado)
        ON DELETE NO ACTION,  -- No dejar borrar si tiene citas

    CONSTRAINT FK_Cita_Servicio 
        FOREIGN KEY (IdServicio) 
        REFERENCES Servicio(IdServicio)
        ON DELETE NO ACTION   -- No dejar borrar si tiene citas
);
GO

CREATE INDEX IX_Cita_IdCliente ON Cita(IdCliente);
CREATE INDEX IX_Cita_IdEmpleado ON Cita(IdEmpleado);
CREATE INDEX IX_Cita_IdServicio ON Cita(IdServicio);
GO

-- =============================================
--  TABLA: Comision
-- =============================================
CREATE TABLE Comision (
    IdComision INT IDENTITY(1,1) PRIMARY KEY,
    IdEmpleado INT NOT NULL,
    IdCita INT NOT NULL,
    MontoComision DECIMAL(10,2) NOT NULL,

    CONSTRAINT FK_Comision_Empleado 
        FOREIGN KEY (IdEmpleado) 
        REFERENCES Empleado(IdEmpleado)
        ON DELETE CASCADE,

    CONSTRAINT FK_Comision_Cita 
        FOREIGN KEY (IdCita) 
        REFERENCES Cita(IdCita)
        ON DELETE CASCADE
);
GO

CREATE INDEX IX_Comision_IdEmpleado ON Comision(IdEmpleado);
CREATE INDEX IX_Comision_IdCita ON Comision(IdCita);
GO
