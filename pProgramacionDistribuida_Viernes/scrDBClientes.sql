USE [DBClientes]
GO
/****** Object:  Table [dbo].[tblCliente]    Script Date: 9/2/2022 6:20:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCliente](
	[Documento] [varchar](20) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[PrimerApellido] [varchar](50) NOT NULL,
	[SegundoApellido] [varchar](50) NULL,
	[FechaNacimiento] [date] NOT NULL,
	[Email] [varchar](200) NULL,
	[Direccion] [varchar](200) NOT NULL,
	[Telefono] [varchar](20) NOT NULL,
 CONSTRAINT [PK__tblClien__AF73706C63CB3E4C] PRIMARY KEY CLUSTERED 
(
	[Documento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblHabilitacion]    Script Date: 9/2/2022 6:20:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblHabilitacion](
	[DocumentoEstudiante] [varchar](20) NOT NULL,
	[NombreEstudiante] [varchar](100) NOT NULL,
	[Asignatura] [varchar](50) NOT NULL,
	[FechaHabilitacion] [date] NOT NULL,
	[NotaTeorica] [real] NOT NULL,
	[NotaPractica] [real] NOT NULL,
	[NotaCalculada] [real] NOT NULL,
	[NotaDefinitiva] [real] NOT NULL,
 CONSTRAINT [PK_tblHabilitacion] PRIMARY KEY CLUSTERED 
(
	[DocumentoEstudiante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUsuario]    Script Date: 9/2/2022 6:20:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUsuario](
	[Documento] [varchar](20) NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[Clave] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Documento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tblCliente] ([Documento], [Nombre], [PrimerApellido], [SegundoApellido], [FechaNacimiento], [Email], [Direccion], [Telefono]) VALUES (N'112233', N'MARCO', N'GIRALDO', N'SALAZAR', CAST(N'1999-11-02' AS Date), N'marco.giraldo@gmail.com', N'carrea 23', N'2145')
INSERT [dbo].[tblCliente] ([Documento], [Nombre], [PrimerApellido], [SegundoApellido], [FechaNacimiento], [Email], [Direccion], [Telefono]) VALUES (N'123456', N'LUISA', N'VELEZ', N'BOTERO', CAST(N'1980-02-12' AS Date), N'luisa.velez@gmail.com', N'carrera 25 # 23-98', N'3163218976')
INSERT [dbo].[tblCliente] ([Documento], [Nombre], [PrimerApellido], [SegundoApellido], [FechaNacimiento], [Email], [Direccion], [Telefono]) VALUES (N'987654', N'ANDREA', N'JIMENEZ', N'VILLADA', CAST(N'1998-02-12' AS Date), N'andrea.villada@hotmail.com', N'calle 32 # 33-18', N'3007881122')
INSERT [dbo].[tblUsuario] ([Documento], [Usuario], [Clave]) VALUES (N'112233', N'marco', N'123')
INSERT [dbo].[tblUsuario] ([Documento], [Usuario], [Clave]) VALUES (N'123456', N'luisa.velez', N'123')
INSERT [dbo].[tblUsuario] ([Documento], [Usuario], [Clave]) VALUES (N'987654', N'andrea.villada', N'123')
