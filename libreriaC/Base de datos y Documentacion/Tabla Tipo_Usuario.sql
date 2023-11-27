USE [libreria]
GO

/****** Object:  Table [dbo].[Tipo_Usuario]    Script Date: 12/11/2023 02:19:04 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tipo_Usuario](
	[Id_Tipo_Usuario] [int] NOT NULL,
	[Nombre] [varchar](30) NOT NULL,
	[Id_Usuario_Creacion] [int] NOT NULL,
	[Fecha_Hora_Creacion] [datetime] NOT NULL,
	[Id_Usuario_Modificacion] [int] NOT NULL,
	[Fecha_Hora_Modificacion] [datetime] NOT NULL,
	[Estatus] [bit] NOT NULL,
 CONSTRAINT [PK_Tipo_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id_Tipo_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Tipo_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Tipo_Usuario_UsuarioC] FOREIGN KEY([Id_Usuario_Creacion])
REFERENCES [dbo].[Usuario] ([Id_Usuario])
GO

ALTER TABLE [dbo].[Tipo_Usuario] CHECK CONSTRAINT [FK_Tipo_Usuario_UsuarioC]
GO

ALTER TABLE [dbo].[Tipo_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Tipo_Usuario_UsuarioM] FOREIGN KEY([Id_Usuario_Modificacion])
REFERENCES [dbo].[Usuario] ([Id_Usuario])
GO

ALTER TABLE [dbo].[Tipo_Usuario] CHECK CONSTRAINT [FK_Tipo_Usuario_UsuarioM]
GO


