USE [libreria]
GO

/****** Object:  Table [dbo].[Libro_Autores]    Script Date: 12/11/2023 02:41:28 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Libro_Autores](
	[Id_Libro_Autores] [int] NOT NULL,
	[Id_Libro_ISBN] [varchar](50) NOT NULL,
	[Id_Autor] [varchar](10) NOT NULL,
	[Id_Usuario_Creacion] [int] NOT NULL,
	[Fecha_Hora_Creacion] [datetime] NOT NULL,
	[Id_Usuario_Modificacion] [int] NOT NULL,
	[Fecha_Hora_Modificacion] [datetime] NOT NULL,
	[Estatus] [bit] NOT NULL,
 CONSTRAINT [PK_Libro_Autores] PRIMARY KEY CLUSTERED 
(
	[Id_Libro_Autores] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Libro_Autores]  WITH CHECK ADD  CONSTRAINT [FK_Libro_Autores_Autor] FOREIGN KEY([Id_Autor])
REFERENCES [dbo].[Autor] ([Id_Autor])
GO

ALTER TABLE [dbo].[Libro_Autores] CHECK CONSTRAINT [FK_Libro_Autores_Autor]
GO

ALTER TABLE [dbo].[Libro_Autores]  WITH CHECK ADD  CONSTRAINT [FK_Libro_Autores_Libro] FOREIGN KEY([Id_Libro_ISBN])
REFERENCES [dbo].[Libro] ([Id_Libro_ISBN])
GO

ALTER TABLE [dbo].[Libro_Autores] CHECK CONSTRAINT [FK_Libro_Autores_Libro]
GO

ALTER TABLE [dbo].[Libro_Autores]  WITH CHECK ADD  CONSTRAINT [FK_Libro_Autores_UsuarioC] FOREIGN KEY([Id_Usuario_Creacion])
REFERENCES [dbo].[Usuario] ([Id_Usuario])
GO

ALTER TABLE [dbo].[Libro_Autores] CHECK CONSTRAINT [FK_Libro_Autores_UsuarioC]
GO

ALTER TABLE [dbo].[Libro_Autores]  WITH CHECK ADD  CONSTRAINT [FK_Libro_Autores_UsuarioM] FOREIGN KEY([Id_Usuario_Modificacion])
REFERENCES [dbo].[Usuario] ([Id_Usuario])
GO

ALTER TABLE [dbo].[Libro_Autores] CHECK CONSTRAINT [FK_Libro_Autores_UsuarioM]
GO

