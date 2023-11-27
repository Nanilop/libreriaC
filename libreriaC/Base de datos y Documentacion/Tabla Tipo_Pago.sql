USE [libreria]
GO

/****** Object:  Table [dbo].[Tipo_Pago]    Script Date: 12/11/2023 02:18:59 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tipo_Pago](
	[Id_Tipo_Pago] [int] NOT NULL,
	[Nombre] [varchar](30) NOT NULL,
	[Id_Usuario_Creacion] [int] NOT NULL,
	[Fecha_Hora_Creacion] [datetime] NOT NULL,
	[Id_Usuario_Modificacion] [int] NOT NULL,
	[Fecha_Hora_Modificacion] [datetime] NOT NULL,
	[Estatus] [bit] NOT NULL,
 CONSTRAINT [PK_Tipo_Pago] PRIMARY KEY CLUSTERED 
(
	[Id_Tipo_Pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Tipo_Pago]  WITH CHECK ADD  CONSTRAINT [FK_Tipo_Pago_UsuarioC] FOREIGN KEY([Id_Usuario_Creacion])
REFERENCES [dbo].[Usuario] ([Id_Usuario])
GO

ALTER TABLE [dbo].[Tipo_Pago] CHECK CONSTRAINT [FK_Tipo_Pago_UsuarioC]
GO

ALTER TABLE [dbo].[Tipo_Pago]  WITH CHECK ADD  CONSTRAINT [FK_Tipo_Pago_UsuarioM] FOREIGN KEY([Id_Usuario_Modificacion])
REFERENCES [dbo].[Usuario] ([Id_Usuario])
GO

ALTER TABLE [dbo].[Tipo_Pago] CHECK CONSTRAINT [FK_Tipo_Pago_UsuarioM]
GO


