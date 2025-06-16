
--Create Database
Create Database Healt_State;

--Use DB
use Healt_State

-- Tabla Roles
CREATE TABLE Roles (
    RolID INT PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL
);

-- Tabla Usuarios
CREATE TABLE Usuarios (
    UsuarioID INT PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Contraseña NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100),
    RolID INT,
    FOREIGN KEY (RolID) REFERENCES Roles(RolID)
);

-- Tabla Estados
CREATE TABLE Estados (
    EstadoID INT PRIMARY KEY,
    Descripcion NVARCHAR(100) NOT NULL
);

-- Tabla Aseguradoras
CREATE TABLE Aseguradoras (
    AseguradoraID INT PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Direccion NVARCHAR(200),
    Telefono NVARCHAR(20),
    Email NVARCHAR(100),
    Contacto NVARCHAR(100)
);

-- Tabla Pacientes
CREATE TABLE Pacientes (
    PacienteID INT PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    FechaNacimiento DATE,
    Sexo CHAR(1),
    Direccion NVARCHAR(200),
    Telefono NVARCHAR(20),
    Email NVARCHAR(100),
    PolizaID INT,
    AseguradoraID INT,
    FOREIGN KEY (AseguradoraID) REFERENCES Aseguradoras(AseguradoraID)
);

-- Tabla Medicos
CREATE TABLE Medicos (
    MedicoID INT PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100),
    Especialidad NVARCHAR(100),
    Telefono NVARCHAR(20),
    Email NVARCHAR(100)
);

-- Tabla Citas
CREATE TABLE Citas (
    CitaID INT PRIMARY KEY,
    PacienteID INT,
    MedicoID INT,
    FechaHora DATETIME,
    MotivoConsulta NVARCHAR(200),
    EstadoID INT,
    FOREIGN KEY (PacienteID) REFERENCES Pacientes(PacienteID),
    FOREIGN KEY (MedicoID) REFERENCES Medicos(MedicoID),
    FOREIGN KEY (EstadoID) REFERENCES Estados(EstadoID)
);

-- Tabla Tratamientos
CREATE TABLE Tratamientos (
    TratamientoID INT PRIMARY KEY,
    CitaID INT,
    Descripcion NVARCHAR(200),
    Fecha DATE,
    Costo DECIMAL(10,2),
    Cubierto BIT,
    FOREIGN KEY (CitaID) REFERENCES Citas(CitaID)
);

-- Tabla Facturas
CREATE TABLE Facturas (
    FacturaID INT PRIMARY KEY,
    PacienteID INT,
    FechaEmision DATE,
    Monto DECIMAL(10,2),
    Pagado BIT,
    FOREIGN KEY (PacienteID) REFERENCES Pacientes(PacienteID)
);

-- Tabla DetalleFacturas
CREATE TABLE DetalleFacturas (
    DetalleID INT PRIMARY KEY,
    FacturaID INT,
    TratamientoID INT,
    Monto DECIMAL(10,2),
    FOREIGN KEY (FacturaID) REFERENCES Facturas(FacturaID),
    FOREIGN KEY (TratamientoID) REFERENCES Tratamientos(TratamientoID)
);

-- Tabla TipoSolicitudes
CREATE TABLE TipoSolicitudes (
    TipoID INT PRIMARY KEY,
    Descripcion NVARCHAR(100)
);

-- Tabla Solicitudes
CREATE TABLE Solicitudes (
    SolicitudID INT PRIMARY KEY,
    Descripcion NVARCHAR(200),
    EstadoID INT,
    TipoID INT,
    MontoTotal DECIMAL(10,2),
    MontoAprobado DECIMAL(10,2),
    PolizaID INT,
    PacienteID INT,
    AseguradoraID INT,
    Observaciones NVARCHAR(200),
    FOREIGN KEY (EstadoID) REFERENCES Estados(EstadoID),
    FOREIGN KEY (TipoID) REFERENCES TipoSolicitudes(TipoID),
    FOREIGN KEY (PacienteID) REFERENCES Pacientes(PacienteID),
    FOREIGN KEY (AseguradoraID) REFERENCES Aseguradoras(AseguradoraID)
);
--Insert Data

-- Roles
INSERT INTO Roles VALUES (1, 'Administrador');
INSERT INTO Roles VALUES (2, 'Recepcionista');
INSERT INTO Roles VALUES (3, 'Doctor');

-- Usuarios
INSERT INTO Usuarios VALUES (1, 'Hansel De Los Santos', 'admin123', 'hansel@email.com', 1);
INSERT INTO Usuarios VALUES (2, 'Lucía Pérez', 'recep2024', 'lucia@email.com', 2);
INSERT INTO Usuarios VALUES (3, 'Dr. Ana Gómez', 'ana456', 'ana@email.com', 3);

-- Estados
INSERT INTO Estados VALUES (1, 'Pendiente');
INSERT INTO Estados VALUES (2, 'Aprobada');
INSERT INTO Estados VALUES (3, 'Rechazada');
INSERT INTO Estados VALUES (4, 'Realizada');
INSERT INTO Estados VALUES (5, 'Cancelada');

-- Aseguradoras
INSERT INTO Aseguradoras VALUES (1, 'ARS SaludPlus', 'Calle 123, Sto Dgo', '809-123-4567', 'contacto@saludplus.com', 'Carlos Ramírez');

-- Pacientes
INSERT INTO Pacientes VALUES (1, 'María Torres', '1990-03-15', 'F', 'Av. Bolívar #45', '809-555-1111', 'maria@email.com', 101, 1);
INSERT INTO Pacientes VALUES (2, 'Juan López', '1985-07-09', 'M', 'C/ Mella #10', '809-444-2222', 'juan@email.com', 102, 1);

-- Médicos
INSERT INTO Medicos VALUES (1, 'Ana', 'Gómez', 'Cardiología', '809-321-0000', 'ana.gomez@clinica.com');
INSERT INTO Medicos VALUES (2, 'Luis', 'Martínez', 'Pediatría', '809-321-0001', 'luis.martinez@clinica.com');

-- Citas
INSERT INTO Citas VALUES (1, 1, 1, '2025-06-10 09:00:00', 'Chequeo general', 4);
INSERT INTO Citas VALUES (2, 2, 2, '2025-06-11 11:30:00', 'Fiebre alta', 1);

-- Tratamientos
INSERT INTO Tratamientos VALUES (1, 1, 'Electrocardiograma', '2025-06-10', 2500.00, 1);
INSERT INTO Tratamientos VALUES (2, 2, 'Análisis de sangre', '2025-06-11', 1500.00, 0);

-- Facturas
INSERT INTO Facturas VALUES (1, 1, '2025-06-10', 2500.00, 1);
INSERT INTO Facturas VALUES (2, 2, '2025-06-11', 1500.00, 0);

-- DetalleFacturas
INSERT INTO DetalleFacturas VALUES (1, 1, 1, 2500.00);
INSERT INTO DetalleFacturas VALUES (2, 2, 2, 1500.00);

-- TipoSolicitudes
INSERT INTO TipoSolicitudes VALUES (1, 'Solicitud de Autorización');
INSERT INTO TipoSolicitudes VALUES (2, 'Reembolso');
INSERT INTO TipoSolicitudes VALUES (3, 'Consulta Previa');

-- Solicitudes
INSERT INTO Solicitudes VALUES (1, 'Autorización para tratamiento', 1, 1, 3000.00, NULL, 101, 1, 1, 'Paciente solicita autorización urgente');
INSERT INTO Solicitudes VALUES (2, 'Solicitud de reembolso', 2, 2, 1500.00, 1500.00, 102, 2, 1, 'Paciente solicita reembolso por consulta');