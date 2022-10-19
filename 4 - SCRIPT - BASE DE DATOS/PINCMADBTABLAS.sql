USE [db_a6dce2_pincma]
GO
/****** Object:  Table [dbo].[Billetera]    Script Date: 19/10/2022 16:05:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Billetera](
	[idBilletera] [int] IDENTITY(1,1) NOT NULL,
	[idCuenta] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idBilletera] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Crypto]    Script Date: 19/10/2022 16:05:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Crypto](
	[idCrypto] [int] IDENTITY(1,1) NOT NULL,
	[nombreCrypto] [varchar](200) NOT NULL,
	[idEstado] [int] NOT NULL,
	[nombreCorto] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[idCrypto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CryptoXBilletera]    Script Date: 19/10/2022 16:05:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CryptoXBilletera](
	[idBilletera] [int] NOT NULL,
	[idCrypto] [int] NOT NULL,
	[cantidad] [int] NULL,
 CONSTRAINT [pk_CXB] PRIMARY KEY CLUSTERED 
(
	[idBilletera] ASC,
	[idCrypto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuenta]    Script Date: 19/10/2022 16:05:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuenta](
	[idCuenta] [int] IDENTITY(1,1) NOT NULL,
	[mail] [varchar](250) NOT NULL,
	[telefono] [varchar](20) NOT NULL,
	[cuentaValidada] [bit] NULL,
	[hashRecuperacion] [varchar](max) NULL,
	[idEstado] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Domicilio]    Script Date: 19/10/2022 16:05:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Domicilio](
	[idDomicilio] [int] IDENTITY(1,1) NOT NULL,
	[idLocalidad] [int] NOT NULL,
	[calle] [varchar](150) NOT NULL,
	[altura] [varchar](150) NOT NULL,
	[mail] [varchar](250) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idDomicilio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 19/10/2022 16:05:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado](
	[idEstado] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](80) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idEstado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Localidad]    Script Date: 19/10/2022 16:05:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Localidad](
	[idLocalidad] [int] IDENTITY(1,1) NOT NULL,
	[idProvincia] [int] NOT NULL,
	[nombreLocalidad] [varchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idLocalidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logs]    Script Date: 19/10/2022 16:05:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[idLog] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](max) NULL,
	[fechaRegistro] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idLog] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ofertas]    Script Date: 19/10/2022 16:05:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ofertas](
	[idOferta] [int] IDENTITY(1,1) NOT NULL,
	[idBilletera] [int] NOT NULL,
	[idCrypto] [int] NOT NULL,
	[nombreCrypto] [varchar](200) NOT NULL,
	[nombreUsuario] [varchar](80) NOT NULL,
	[cantidad] [int] NOT NULL,
	[precioU] [decimal](14, 2) NULL,
	[precioP] [decimal](14, 2) NULL,
	[idEstado] [int] NOT NULL,
 CONSTRAINT [PK__Ofertas__05A1245E0FF3D97A] PRIMARY KEY CLUSTERED 
(
	[idOferta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Operacion]    Script Date: 19/10/2022 16:05:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operacion](
	[idOperacion] [int] IDENTITY(1,1) NOT NULL,
	[fechaOperacion] [datetime] NULL,
	[idTipoOperacion] [int] NOT NULL,
	[idEstado] [int] NOT NULL,
	[idBilleteraOrigen] [int] NOT NULL,
	[idBilleteraDestino] [int] NULL,
	[idCrypto] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[precio] [decimal](10, 2) NOT NULL,
	[operacionFinalizada] [bit] NULL,
 CONSTRAINT [PK__Operacio__E7EB69887C5815F1] PRIMARY KEY CLUSTERED 
(
	[idOperacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pais]    Script Date: 19/10/2022 16:05:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pais](
	[idPais] [int] IDENTITY(1,1) NOT NULL,
	[nombrePais] [varchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idPais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PrecioCompra]    Script Date: 19/10/2022 16:05:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrecioCompra](
	[idPrecioCompra] [int] IDENTITY(1,1) NOT NULL,
	[idCrypto] [int] NOT NULL,
	[precio] [decimal](10, 2) NOT NULL,
	[fecha] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idPrecioCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PrecioVenta]    Script Date: 19/10/2022 16:05:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrecioVenta](
	[idPrecioVenta] [int] IDENTITY(1,1) NOT NULL,
	[idCrypto] [int] NOT NULL,
	[precio] [decimal](10, 2) NOT NULL,
	[fecha] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idPrecioVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provincia]    Script Date: 19/10/2022 16:05:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincia](
	[idProvincia] [int] IDENTITY(1,1) NOT NULL,
	[idPais] [int] NOT NULL,
	[nombreProvincia] [varchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idProvincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegistroIngresos]    Script Date: 19/10/2022 16:05:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegistroIngresos](
	[idIngreso] [int] IDENTITY(1,1) NOT NULL,
	[fechaIngreso] [datetime] NOT NULL,
	[idCuenta] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idIngreso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoDocumento]    Script Date: 19/10/2022 16:05:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoDocumento](
	[idTipoDocumento] [int] IDENTITY(1,1) NOT NULL,
	[nombreTipoDocumento] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idTipoDocumento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoOperacion]    Script Date: 19/10/2022 16:05:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoOperacion](
	[idTipoOperacion] [int] IDENTITY(1,1) NOT NULL,
	[nombreTipoOperacion] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idTipoOperacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 19/10/2022 16:05:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[mail] [varchar](250) NOT NULL,
	[clave] [varchar](250) NOT NULL,
	[nombre] [varchar](80) NOT NULL,
	[apellido] [varchar](80) NOT NULL,
	[documento] [varchar](20) NOT NULL,
	[idEstado] [int] NOT NULL,
	[fechaCreacion] [datetime] NULL,
	[idTipoDocumento] [int] NULL,
 CONSTRAINT [pk_Usuario] PRIMARY KEY CLUSTERED 
(
	[mail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cuenta] ADD  DEFAULT ((0)) FOR [cuentaValidada]
GO
ALTER TABLE [dbo].[Logs] ADD  DEFAULT (getdate()) FOR [fechaRegistro]
GO
ALTER TABLE [dbo].[Operacion] ADD  CONSTRAINT [DF__Operacion__fecha__68487DD7]  DEFAULT (getdate()) FOR [fechaOperacion]
GO
ALTER TABLE [dbo].[PrecioCompra] ADD  DEFAULT (getdate()) FOR [fecha]
GO
ALTER TABLE [dbo].[PrecioVenta] ADD  DEFAULT (getdate()) FOR [fecha]
GO
ALTER TABLE [dbo].[RegistroIngresos] ADD  DEFAULT (getdate()) FOR [fechaIngreso]
GO
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF__Usuario__fechaCr__4222D4EF]  DEFAULT (getdate()) FOR [fechaCreacion]
GO
ALTER TABLE [dbo].[Billetera]  WITH CHECK ADD  CONSTRAINT [FK_Billetera_Cuenta] FOREIGN KEY([idCuenta])
REFERENCES [dbo].[Cuenta] ([idCuenta])
GO
ALTER TABLE [dbo].[Billetera] CHECK CONSTRAINT [FK_Billetera_Cuenta]
GO
ALTER TABLE [dbo].[Crypto]  WITH CHECK ADD  CONSTRAINT [fk_CryptoEstado] FOREIGN KEY([idEstado])
REFERENCES [dbo].[Estado] ([idEstado])
GO
ALTER TABLE [dbo].[Crypto] CHECK CONSTRAINT [fk_CryptoEstado]
GO
ALTER TABLE [dbo].[CryptoXBilletera]  WITH CHECK ADD  CONSTRAINT [fk_BilleteraCrypto] FOREIGN KEY([idBilletera])
REFERENCES [dbo].[Billetera] ([idBilletera])
GO
ALTER TABLE [dbo].[CryptoXBilletera] CHECK CONSTRAINT [fk_BilleteraCrypto]
GO
ALTER TABLE [dbo].[CryptoXBilletera]  WITH CHECK ADD  CONSTRAINT [fk_CryptoBilletera] FOREIGN KEY([idCrypto])
REFERENCES [dbo].[Crypto] ([idCrypto])
GO
ALTER TABLE [dbo].[CryptoXBilletera] CHECK CONSTRAINT [fk_CryptoBilletera]
GO
ALTER TABLE [dbo].[Cuenta]  WITH CHECK ADD  CONSTRAINT [fk_EstadoCuenta] FOREIGN KEY([idEstado])
REFERENCES [dbo].[Estado] ([idEstado])
GO
ALTER TABLE [dbo].[Cuenta] CHECK CONSTRAINT [fk_EstadoCuenta]
GO
ALTER TABLE [dbo].[Cuenta]  WITH CHECK ADD  CONSTRAINT [fk_UsuarioCuenta] FOREIGN KEY([mail])
REFERENCES [dbo].[Usuario] ([mail])
GO
ALTER TABLE [dbo].[Cuenta] CHECK CONSTRAINT [fk_UsuarioCuenta]
GO
ALTER TABLE [dbo].[Domicilio]  WITH CHECK ADD  CONSTRAINT [fk_localidad] FOREIGN KEY([idLocalidad])
REFERENCES [dbo].[Localidad] ([idLocalidad])
GO
ALTER TABLE [dbo].[Domicilio] CHECK CONSTRAINT [fk_localidad]
GO
ALTER TABLE [dbo].[Domicilio]  WITH CHECK ADD  CONSTRAINT [fk_UsuarioDomicilio] FOREIGN KEY([mail])
REFERENCES [dbo].[Usuario] ([mail])
GO
ALTER TABLE [dbo].[Domicilio] CHECK CONSTRAINT [fk_UsuarioDomicilio]
GO
ALTER TABLE [dbo].[Localidad]  WITH CHECK ADD  CONSTRAINT [fk_provincia] FOREIGN KEY([idProvincia])
REFERENCES [dbo].[Provincia] ([idProvincia])
GO
ALTER TABLE [dbo].[Localidad] CHECK CONSTRAINT [fk_provincia]
GO
ALTER TABLE [dbo].[Ofertas]  WITH CHECK ADD  CONSTRAINT [fk_Bille] FOREIGN KEY([idBilletera])
REFERENCES [dbo].[Billetera] ([idBilletera])
GO
ALTER TABLE [dbo].[Ofertas] CHECK CONSTRAINT [fk_Bille]
GO
ALTER TABLE [dbo].[Ofertas]  WITH CHECK ADD  CONSTRAINT [fk_Cryp] FOREIGN KEY([idCrypto])
REFERENCES [dbo].[Crypto] ([idCrypto])
GO
ALTER TABLE [dbo].[Ofertas] CHECK CONSTRAINT [fk_Cryp]
GO
ALTER TABLE [dbo].[Ofertas]  WITH CHECK ADD  CONSTRAINT [FK_Ofertas_Estado] FOREIGN KEY([idEstado])
REFERENCES [dbo].[Estado] ([idEstado])
GO
ALTER TABLE [dbo].[Ofertas] CHECK CONSTRAINT [FK_Ofertas_Estado]
GO
ALTER TABLE [dbo].[Operacion]  WITH CHECK ADD  CONSTRAINT [FK_Operacion_Billetera] FOREIGN KEY([idBilleteraOrigen])
REFERENCES [dbo].[Billetera] ([idBilletera])
GO
ALTER TABLE [dbo].[Operacion] CHECK CONSTRAINT [FK_Operacion_Billetera]
GO
ALTER TABLE [dbo].[Operacion]  WITH CHECK ADD  CONSTRAINT [FK_Operacion_Billetera1] FOREIGN KEY([idBilleteraDestino])
REFERENCES [dbo].[Billetera] ([idBilletera])
GO
ALTER TABLE [dbo].[Operacion] CHECK CONSTRAINT [FK_Operacion_Billetera1]
GO
ALTER TABLE [dbo].[Operacion]  WITH CHECK ADD  CONSTRAINT [fk_OperacionCrypto] FOREIGN KEY([idCrypto])
REFERENCES [dbo].[Crypto] ([idCrypto])
GO
ALTER TABLE [dbo].[Operacion] CHECK CONSTRAINT [fk_OperacionCrypto]
GO
ALTER TABLE [dbo].[Operacion]  WITH CHECK ADD  CONSTRAINT [fk_OperacionEstado] FOREIGN KEY([idEstado])
REFERENCES [dbo].[Estado] ([idEstado])
GO
ALTER TABLE [dbo].[Operacion] CHECK CONSTRAINT [fk_OperacionEstado]
GO
ALTER TABLE [dbo].[Operacion]  WITH CHECK ADD  CONSTRAINT [fk_OperacionTipoOperacion] FOREIGN KEY([idTipoOperacion])
REFERENCES [dbo].[TipoOperacion] ([idTipoOperacion])
GO
ALTER TABLE [dbo].[Operacion] CHECK CONSTRAINT [fk_OperacionTipoOperacion]
GO
ALTER TABLE [dbo].[PrecioCompra]  WITH CHECK ADD  CONSTRAINT [fk_CryptoCompra] FOREIGN KEY([idCrypto])
REFERENCES [dbo].[Crypto] ([idCrypto])
GO
ALTER TABLE [dbo].[PrecioCompra] CHECK CONSTRAINT [fk_CryptoCompra]
GO
ALTER TABLE [dbo].[PrecioVenta]  WITH CHECK ADD  CONSTRAINT [fk_CryptoVenta] FOREIGN KEY([idCrypto])
REFERENCES [dbo].[Crypto] ([idCrypto])
GO
ALTER TABLE [dbo].[PrecioVenta] CHECK CONSTRAINT [fk_CryptoVenta]
GO
ALTER TABLE [dbo].[Provincia]  WITH CHECK ADD  CONSTRAINT [fk_pais] FOREIGN KEY([idPais])
REFERENCES [dbo].[Pais] ([idPais])
GO
ALTER TABLE [dbo].[Provincia] CHECK CONSTRAINT [fk_pais]
GO
ALTER TABLE [dbo].[RegistroIngresos]  WITH CHECK ADD  CONSTRAINT [FK_RegistroIngresos_Cuenta] FOREIGN KEY([idCuenta])
REFERENCES [dbo].[Cuenta] ([idCuenta])
GO
ALTER TABLE [dbo].[RegistroIngresos] CHECK CONSTRAINT [FK_RegistroIngresos_Cuenta]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [fk_EstadoUsuario] FOREIGN KEY([idEstado])
REFERENCES [dbo].[Estado] ([idEstado])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [fk_EstadoUsuario]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_TipoDocumento] FOREIGN KEY([idTipoDocumento])
REFERENCES [dbo].[TipoDocumento] ([idTipoDocumento])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_TipoDocumento]
GO
