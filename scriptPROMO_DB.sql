use master 
go
create database PROMOS_DB
go
use PROMOS_DB
go

CREATE TABLE [dbo].[CATEGORIAS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_CATEGORIAS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[MARCAS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_MARCAS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[ARTICULOS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](50) NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](150) NULL,
	[IdMarca] [int] NULL,
	[IdCategoria] [int] NULL,
	[Precio] [money] NULL,
 CONSTRAINT [PK_ARTICULOS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ARTICULOS]  WITH CHECK ADD  CONSTRAINT [FK_ARTICULOS_CATEGORIAS] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[CATEGORIAS] ([Id])
GO

ALTER TABLE [dbo].[ARTICULOS] CHECK CONSTRAINT [FK_ARTICULOS_CATEGORIAS]
GO

ALTER TABLE [dbo].[ARTICULOS]  WITH CHECK ADD  CONSTRAINT [FK_ARTICULOS_MARCAS] FOREIGN KEY([IdMarca])
REFERENCES [dbo].[MARCAS] ([Id])
GO

ALTER TABLE [dbo].[ARTICULOS] CHECK CONSTRAINT [FK_ARTICULOS_MARCAS]
GO

CREATE TABLE [dbo].[IMAGENES](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdArticulo] [int] NOT NULL,
	[ImagenUrl] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_IMAGENES] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[IMAGENES]  WITH CHECK ADD  CONSTRAINT [FK_IMAGENES_ARTICULOS] FOREIGN KEY([IdArticulo])
REFERENCES [dbo].[ARTICULOS] ([Id])
GO

ALTER TABLE [dbo].[IMAGENES] CHECK CONSTRAINT [FK_IMAGENES_ARTICULOS]
GO

CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Documento] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Direccion] [varchar](50) NOT NULL,
	[Ciudad] [varchar](50) NOT NULL,
	[CP] [int] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Vouchers](
	[CodigoVoucher] [varchar](50) NOT NULL,
	[IdCliente] [int] NULL,
	[FechaCanje] [date] NULL,
	[IdArticulo] [int] NULL,
 CONSTRAINT [PK_Vouchers] PRIMARY KEY CLUSTERED 
(
	[CodigoVoucher] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Vouchers]  WITH CHECK ADD  CONSTRAINT [FK_Vouchers_ARTICULOS] FOREIGN KEY([IdArticulo])
REFERENCES [dbo].[ARTICULOS] ([Id])
GO

ALTER TABLE [dbo].[Vouchers] CHECK CONSTRAINT [FK_Vouchers_ARTICULOS]
GO

ALTER TABLE [dbo].[Vouchers]  WITH CHECK ADD  CONSTRAINT [FK_Vouchers_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([Id])
GO

ALTER TABLE [dbo].[Vouchers] CHECK CONSTRAINT [FK_Vouchers_Clientes]
GO

insert into MARCAS values ('Wilson'), ('Logitech'), ('Royal Kludge'), ('Huawei'), ('Motorola')
insert into CATEGORIAS values ('Mochilas'),('Periféricos'), ('Accesorios')
insert into ARTICULOS values ('M01', 'Mochila Porta Notebook', 'Esta mochila combina un diseño elegante y profesional con la robustez necesaria para enfrentar el ajetreo urbano y los viajes de negocios.', 1, 1, 49999),
('P03', 'Mouse Gamer Hero G502', 'Sumérgete en el mundo de los videojuegos con el mouse gamer Logitech G Series Hero G502 en color negro', 2, 2, 64999),
('P08', 'Teclado Mecánico 75% Rk M75', 'Este teclado cuenta con un diseño compacto con 81 teclas, por lo que es fácil de transportar y usar en cualquier lugar.', 2, 3, 185000)

insert into imagenes values
(1,'https://http2.mlstatic.com/D_NQ_NP_703368-MLU76300898146_052024-O.webp'),
(1, 'https://http2.mlstatic.com/D_NQ_NP_842545-MLU76300482840_052024-O.webp'),
(1, 'https://http2.mlstatic.com/D_NQ_NP_747302-MLU76300769244_052024-O.webp'),
(2, 'https://http2.mlstatic.com/D_NQ_NP_701613-MLA45464844877_042021-O.webp'),
(2, 'https://http2.mlstatic.com/D_NQ_NP_987670-MLA45464844880_042021-O.webp'),
(2, 'https://http2.mlstatic.com/D_NQ_NP_793119-MLU72761228270_112023-O.webp'),
(3, 'https://http2.mlstatic.com/D_NQ_NP_767460-MLA74282172500_022024-O.webp'),
(3, 'https://http2.mlstatic.com/D_NQ_NP_848157-MLA74517144673_022024-O.webp'),
(3, 'https://http2.mlstatic.com/D_NQ_NP_616027-MLA74397845971_022024-O.webp')


insert into clientes values ('32333222', 'Doug', 'Narinas', 'doug@narinas.com','avenida 123', 'chuletas city', 1234)

insert into vouchers values 
('Codigo01', 1, getdate()-10, 2),
('Codigo02', null, null, null),
('Codigo03', null, null, null),
('Codigo04', null, null, null),
('Codigo05', null, null, null)

