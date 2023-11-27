USE [libreria]
GO

/****** Object:  Table [dbo].[Libro]    Script Date: 12/11/2023 02:18:00 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Libro](
	[Id_Libro_ISBN] [varchar](50) NOT NULL,
	[Titulo] [varchar](max) NOT NULL,
	[Id_Categoria] [int] NOT NULL,
	[Volumen] [varchar](5) NULL,
	[Id_Tipo_Formato] [int] NOT NULL,
	[Id_Editorial] [varchar](3) NOT NULL,
	[Fecha_Publicacion] [date] NULL,
	[Paginas] [int] NULL,
	[Precio] [decimal](10, 2) NOT NULL,
	[Id_Usuario_Creacion] [int] NOT NULL,
	[Fecha_Hora_Creacion] [datetime] NOT NULL,
	[Id_Usuario_Modificacion] [int] NOT NULL,
	[Fecha_Hora_Modificacion] [datetime] NOT NULL,
	[Id_Rating] [int] NOT NULL,
	[Estatus] [bit] NOT NULL,
 CONSTRAINT [PK_Libro] PRIMARY KEY CLUSTERED 
(
	[Id_Libro_ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Libro]  WITH CHECK ADD  CONSTRAINT [FK_Libro_Categoria] FOREIGN KEY([Id_Categoria])
REFERENCES [dbo].[Categoria] ([Id_Categoria])
GO

ALTER TABLE [dbo].[Libro] CHECK CONSTRAINT [FK_Libro_Categoria]
GO

ALTER TABLE [dbo].[Libro]  WITH CHECK ADD  CONSTRAINT [FK_Libro_Editorial] FOREIGN KEY([Id_Editorial])
REFERENCES [dbo].[Editorial] ([Id_Editorial])
GO

ALTER TABLE [dbo].[Libro] CHECK CONSTRAINT [FK_Libro_Editorial]
GO

ALTER TABLE [dbo].[Libro]  WITH CHECK ADD  CONSTRAINT [FK_Libro_Rating] FOREIGN KEY([Id_Rating])
REFERENCES [dbo].[Rating] ([Id_Rating])
GO

ALTER TABLE [dbo].[Libro] CHECK CONSTRAINT [FK_Libro_Rating]
GO

ALTER TABLE [dbo].[Libro]  WITH CHECK ADD  CONSTRAINT [FK_Libro_Tipo_Formato] FOREIGN KEY([Id_Tipo_Formato])
REFERENCES [dbo].[Tipo_Formato] ([Id_Tipo_Formato])
GO

ALTER TABLE [dbo].[Libro] CHECK CONSTRAINT [FK_Libro_Tipo_Formato]
GO

ALTER TABLE [dbo].[Libro]  WITH CHECK ADD  CONSTRAINT [FK_Libro_UsuarioC] FOREIGN KEY([Id_Usuario_Creacion])
REFERENCES [dbo].[Usuario] ([Id_Usuario])
GO

ALTER TABLE [dbo].[Libro] CHECK CONSTRAINT [FK_Libro_UsuarioC]
GO

ALTER TABLE [dbo].[Libro]  WITH CHECK ADD  CONSTRAINT [FK_Libro_UsuarioM] FOREIGN KEY([Id_Usuario_Modificacion])
REFERENCES [dbo].[Usuario] ([Id_Usuario])
GO

ALTER TABLE [dbo].[Libro] CHECK CONSTRAINT [FK_Libro_UsuarioM]
GO


