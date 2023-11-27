USE [libreria]
GO

/****** Object:  Table [dbo].[Venta]    Script Date: 12/11/2023 02:19:33 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Venta](
	[Id_Venta] [varchar](20) NOT NULL,
	[Id_Tipo_Cliente] [int] NOT NULL,
	[Id_Usuario_Creacion] [int] NOT NULL,
	[Fecha_Hora_Creacion] [datetime] NOT NULL,
	[Id_Usuario_Modificacion] [int] NOT NULL,
	[Fecha_Hora_Modificacion] [datetime] NOT NULL,
	[Estatus] [bit] NOT NULL,
	[Id_Tipo_Pago] [int] NOT NULL,
 CONSTRAINT [PK_Venta] PRIMARY KEY CLUSTERED 
(
	[Id_Venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Tipo_Cliente] FOREIGN KEY([Id_Tipo_Cliente])
REFERENCES [dbo].[Tipo_Cliente] ([Id_Tipo_Cliente])
GO

ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_Tipo_Cliente]
GO

ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Tipo_Pago] FOREIGN KEY([Id_Tipo_Pago])
REFERENCES [dbo].[Tipo_Pago] ([Id_Tipo_Pago])
GO

ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_Tipo_Pago]
GO

ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_UsuarioC] FOREIGN KEY([Id_Usuario_Creacion])
REFERENCES [dbo].[Usuario] ([Id_Usuario])
GO

ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_UsuarioC]
GO

ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_UsuarioM] FOREIGN KEY([Id_Usuario_Modificacion])
REFERENCES [dbo].[Usuario] ([Id_Usuario])
GO

ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_UsuarioM]
GO

