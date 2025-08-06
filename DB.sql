USE [HealthState]
GO
/****** Object:  Table [dbo].[Aseguradoras]    Script Date: 26/07/2025 0:39:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aseguradoras](
	[AseguradoraID] [int] IDENTITY(100,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Direccion] [nvarchar](200) NULL,
	[Telefono] [nvarchar](20) NULL,
	[Email] [nvarchar](100) NULL,
	[Contacto] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[AseguradoraID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Citas]    Script Date: 26/07/2025 0:39:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Citas](
	[CitaID] [int] IDENTITY(10000000,1) NOT NULL,
	[PacienteID] [int] NULL,
	[MedicoID] [int] NULL,
	[FechaHora] [datetime] NULL,
	[MotivoConsulta] [nvarchar](200) NULL,
	[EstadoID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CitaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleFacturas]    Script Date: 26/07/2025 0:39:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleFacturas](
	[DetalleID] [int] IDENTITY(10000000,1) NOT NULL,
	[FacturaID] [int] NULL,
	[TratamientoID] [int] NULL,
	[Monto] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[DetalleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estados]    Script Date: 26/07/2025 0:39:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estados](
	[EstadoID] [int] IDENTITY(100,1) NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EstadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facturas]    Script Date: 26/07/2025 0:39:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facturas](
	[FacturaID] [int] IDENTITY(10000000,1) NOT NULL,
	[PacienteID] [int] NULL,
	[FechaEmision] [date] NULL,
	[Monto] [decimal](10, 2) NULL,
	[Pagado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[FacturaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicos]    Script Date: 26/07/2025 0:39:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicos](
	[MedicoID] [int] IDENTITY(10000000,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Apellido] [nvarchar](100) NULL,
	[Especialidad] [nvarchar](100) NULL,
	[Telefono] [nvarchar](20) NULL,
	[Email] [nvarchar](100) NULL,
	[Cedula] [varchar](13) NULL,
PRIMARY KEY CLUSTERED 
(
	[MedicoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pacientes]    Script Date: 26/07/2025 0:39:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pacientes](
	[PacienteID] [int] IDENTITY(10000000,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[FechaNacimiento] [date] NULL,
	[Sexo] [char](1) NULL,
	[Direccion] [nvarchar](200) NULL,
	[Telefono] [nvarchar](20) NULL,
	[Email] [nvarchar](100) NULL,
	[PolizaID] [int] NULL,
	[AseguradoraID] [int] NULL,
	[Cedula] [varchar](13) NULL,
	[Apellido] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PacienteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 26/07/2025 0:39:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RolID] [int] IDENTITY(100,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RolID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Solicitudes]    Script Date: 26/07/2025 0:39:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Solicitudes](
	[SolicitudID] [int] IDENTITY(10000000,1) NOT NULL,
	[Descripcion] [nvarchar](200) NULL,
	[EstadoID] [int] NULL,
	[TipoID] [int] NULL,
	[MontoTotal] [decimal](10, 2) NULL,
	[MontoAprobado] [decimal](10, 2) NULL,
	[PolizaID] [int] NULL,
	[PacienteID] [int] NULL,
	[AseguradoraID] [int] NULL,
	[Observaciones] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[SolicitudID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoSolicitudes]    Script Date: 26/07/2025 0:39:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoSolicitudes](
	[TipoID] [int] IDENTITY(10,1) NOT NULL,
	[Descripcion] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[TipoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tratamientos]    Script Date: 26/07/2025 0:39:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tratamientos](
	[TratamientoID] [int] IDENTITY(10000000,1) NOT NULL,
	[Descripcion] [nvarchar](200) NULL,
	[Costo] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[TratamientoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 26/07/2025 0:39:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[UsuarioID] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [nvarchar](100) NOT NULL,
	[Contrasena] [varchar](100) NOT NULL,
	[RolID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Pacientes] ADD  DEFAULT ('Null') FOR [Apellido]
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD FOREIGN KEY([EstadoID])
REFERENCES [dbo].[Estados] ([EstadoID])
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD FOREIGN KEY([MedicoID])
REFERENCES [dbo].[Medicos] ([MedicoID])
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD FOREIGN KEY([PacienteID])
REFERENCES [dbo].[Pacientes] ([PacienteID])
GO
ALTER TABLE [dbo].[DetalleFacturas]  WITH CHECK ADD FOREIGN KEY([FacturaID])
REFERENCES [dbo].[Facturas] ([FacturaID])
GO
ALTER TABLE [dbo].[DetalleFacturas]  WITH CHECK ADD FOREIGN KEY([TratamientoID])
REFERENCES [dbo].[Tratamientos] ([TratamientoID])
GO
ALTER TABLE [dbo].[Facturas]  WITH CHECK ADD FOREIGN KEY([PacienteID])
REFERENCES [dbo].[Pacientes] ([PacienteID])
GO
ALTER TABLE [dbo].[Pacientes]  WITH CHECK ADD FOREIGN KEY([AseguradoraID])
REFERENCES [dbo].[Aseguradoras] ([AseguradoraID])
GO
ALTER TABLE [dbo].[Solicitudes]  WITH CHECK ADD FOREIGN KEY([AseguradoraID])
REFERENCES [dbo].[Aseguradoras] ([AseguradoraID])
GO
ALTER TABLE [dbo].[Solicitudes]  WITH CHECK ADD FOREIGN KEY([EstadoID])
REFERENCES [dbo].[Estados] ([EstadoID])
GO
ALTER TABLE [dbo].[Solicitudes]  WITH CHECK ADD FOREIGN KEY([PacienteID])
REFERENCES [dbo].[Pacientes] ([PacienteID])
GO
ALTER TABLE [dbo].[Solicitudes]  WITH CHECK ADD FOREIGN KEY([TipoID])
REFERENCES [dbo].[TipoSolicitudes] ([TipoID])
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD FOREIGN KEY([RolID])
REFERENCES [dbo].[Roles] ([RolID])
GO
