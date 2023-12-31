USE [master]
GO
/****** Object:  Database [DBAlquiler]    Script Date: 25/10/2022 14:01:40 ******/
CREATE DATABASE [DBAlquiler]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBfarmacia', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DBfarmacia.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DBfarmacia_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DBfarmacia_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DBAlquiler] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBAlquiler].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBAlquiler] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBAlquiler] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBAlquiler] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBAlquiler] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBAlquiler] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBAlquiler] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBAlquiler] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBAlquiler] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBAlquiler] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBAlquiler] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBAlquiler] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBAlquiler] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBAlquiler] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBAlquiler] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBAlquiler] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DBAlquiler] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBAlquiler] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBAlquiler] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBAlquiler] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBAlquiler] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBAlquiler] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBAlquiler] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBAlquiler] SET RECOVERY FULL 
GO
ALTER DATABASE [DBAlquiler] SET  MULTI_USER 
GO
ALTER DATABASE [DBAlquiler] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBAlquiler] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBAlquiler] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBAlquiler] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DBAlquiler] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DBAlquiler] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DBAlquiler', N'ON'
GO
ALTER DATABASE [DBAlquiler] SET QUERY_STORE = OFF
GO
USE [DBAlquiler]
GO
/****** Object:  Table [dbo].[tblAlquiler]    Script Date: 25/10/2022 14:01:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAlquiler](
	[CodigoAlquiler] [int] NOT NULL,
	[DocumentoCliente] [varchar](50) NULL,
	[NombreCliente] [varchar](50) NOT NULL,
	[TipoVehiculo] [varchar](50) NULL,
	[FechaAlquiler] [varchar](50) NOT NULL,
	[DiasAlquiler] [int] NOT NULL,
 CONSTRAINT [PK_tblAlquiler] PRIMARY KEY CLUSTERED 
(
	[CodigoAlquiler] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCliente]    Script Date: 25/10/2022 14:01:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCliente](
	[TipoDoc] [varchar](50) NOT NULL,
	[Documento] [varchar](50) NOT NULL,
	[NombreCliente] [varchar](50) NOT NULL,
	[Telefono] [varchar](50) NULL,
	[Email] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblCliente] PRIMARY KEY CLUSTERED 
(
	[Documento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDevolucion]    Script Date: 25/10/2022 14:01:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDevolucion](
	[CodigoDevolucion] [int] NOT NULL,
	[FechaDevolucion] [varchar](50) NULL,
	[TipoVehiculo] [varchar](50) NULL,
	[DocumentoCliente] [varchar](50) NULL,
	[NombreCliente] [varchar](50) NULL,
 CONSTRAINT [PK_tblDevolucion] PRIMARY KEY CLUSTERED 
(
	[CodigoDevolucion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTipoVehiculo]    Script Date: 25/10/2022 14:01:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTipoVehiculo](
	[IdVehiculo] [int] NOT NULL,
	[MarcaVehiculo] [varchar](50) NOT NULL,
	[Modelo] [int] NOT NULL,
	[Placa] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[tblAlquiler] ([CodigoAlquiler], [DocumentoCliente], [NombreCliente], [TipoVehiculo], [FechaAlquiler], [DiasAlquiler]) VALUES (2412, N'3245', N'asd', N'Ford', N'Oct  1 2022 12:00AM', 35)
INSERT [dbo].[tblAlquiler] ([CodigoAlquiler], [DocumentoCliente], [NombreCliente], [TipoVehiculo], [FechaAlquiler], [DiasAlquiler]) VALUES (45214, N'45841254774112', N'Esteban Perez', N'AKT', N'26/10/2022', 90)
INSERT [dbo].[tblAlquiler] ([CodigoAlquiler], [DocumentoCliente], [NombreCliente], [TipoVehiculo], [FechaAlquiler], [DiasAlquiler]) VALUES (123456, N'103787', N'Diego Mesa', N'AKT', N'25-10-2022', 45)
GO
INSERT [dbo].[tblCliente] ([TipoDoc], [Documento], [NombreCliente], [Telefono], [Email]) VALUES (N'Cédula de ciudadanía', N'10376671111111', N'juan', N'312208300', N'')
INSERT [dbo].[tblCliente] ([TipoDoc], [Documento], [NombreCliente], [Telefono], [Email]) VALUES (N'NIT', N'123121', N'CARL JOHNSON', N'3042104510', N'CARL@gmail.com')
GO
INSERT [dbo].[tblDevolucion] ([CodigoDevolucion], [FechaDevolucion], [TipoVehiculo], [DocumentoCliente], [NombreCliente]) VALUES (1, N'07/10/2022', N'Mazda', N'1152215014', N'Santiago Martinez Londoño')
INSERT [dbo].[tblDevolucion] ([CodigoDevolucion], [FechaDevolucion], [TipoVehiculo], [DocumentoCliente], [NombreCliente]) VALUES (3, N'14/11/2020', N'AKT', N'45621', N'Carlos')
GO
INSERT [dbo].[tblTipoVehiculo] ([IdVehiculo], [MarcaVehiculo], [Modelo], [Placa]) VALUES (1, N'Mazda CX5', 2023, N'DTO696')
INSERT [dbo].[tblTipoVehiculo] ([IdVehiculo], [MarcaVehiculo], [Modelo], [Placa]) VALUES (2, N'Hiunday i10', 2021, N'FVY926')
INSERT [dbo].[tblTipoVehiculo] ([IdVehiculo], [MarcaVehiculo], [Modelo], [Placa]) VALUES (3, N'AKT Flex125', 2019, N'VUE05E')
INSERT [dbo].[tblTipoVehiculo] ([IdVehiculo], [MarcaVehiculo], [Modelo], [Placa]) VALUES (4, N'Ford Fiesta', 2020, N'QWE123')
INSERT [dbo].[tblTipoVehiculo] ([IdVehiculo], [MarcaVehiculo], [Modelo], [Placa]) VALUES (5, N'Chevrolet Equinox', 2022, N'ASD456')
GO
ALTER TABLE [dbo].[tblAlquiler] ADD  CONSTRAINT [DF_tblAlquiler_FechaAlquiler]  DEFAULT ('Oct  1 2022 12:00AM') FOR [FechaAlquiler]
GO
/****** Object:  StoredProcedure [dbo].[SP_Alquiler_LlenarGrid]    Script Date: 25/10/2022 14:01:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Alquiler_LlenarGrid] 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT A.CODIGOALQUILER, A.DOCUMENTOCLIENTE, A.NOMBRECLIENTE,A.TIPOVEHICULO, A.FECHAALQUILER, A.DIASALQUILER
	FROM   dbo.tblALQUILER A 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Cliente_LlenarGrid]    Script Date: 25/10/2022 14:01:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Cliente_LlenarGrid] 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [TipoDoc],[Documento],[NombreCliente],[Telefono],[Email]
FROM   tblCliente
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Devolucion_LlenarGrid]    Script Date: 25/10/2022 14:01:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Devolucion_LlenarGrid] 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT D.CODIGODEVOLUCION, D.FECHADEVOLUCION, D.TIPOVEHICULO, D.DOCUMENTOCLIENTE, D.NOMBRECLIENTE
	FROM   dbo.tblDevolucion D 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TipoVehiculo_LlenarCombo]    Script Date: 25/10/2022 14:01:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_TipoVehiculo_LlenarCombo]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	SELECT MarcaVehiculo as Valor, MarcaVehiculo As Texto
	FROM tblTipoVehiculo
END
GO
USE [master]
GO
ALTER DATABASE [DBAlquiler] SET  READ_WRITE 
GO
