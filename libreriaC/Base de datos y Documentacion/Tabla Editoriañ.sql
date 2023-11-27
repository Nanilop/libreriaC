USE [libreria]
GO

/****** Object:  Table [dbo].[Editorial]    Script Date: 12/11/2023 02:17:50 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Editorial](
	[Id_Editorial] [varchar](3) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Id_Ciudad] [int] NOT NULL,
	[Año_Inauguracion] [varchar](4) NULL,
	[Id_Usuario_Creacion] [int] NOT NULL,
	[Fecha_Hora_Creacion] [datetime] NOT NULL,
	[Id_Usuario_Modificacion] [int] NOT NULL,
	[Fecha_Hora_Modificacion] [datetime] NOT NULL,
	[Estatus] [bit] NOT NULL,
 CONSTRAINT [PK_Editorial] PRIMARY KEY CLUSTERED 
(
	[Id_Editorial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Editorial]  WITH CHECK ADD  CONSTRAINT [FK_Editorial_Ciudad] FOREIGN KEY([Id_Ciudad])
REFERENCES [dbo].[Ciudad] ([Id_Ciudad])
GO

ALTER TABLE [dbo].[Editorial] CHECK CONSTRAINT [FK_Editorial_Ciudad]
GO

ALTER TABLE [dbo].[Editorial]  WITH CHECK ADD  CONSTRAINT [FK_Editorial_UsuarioC] FOREIGN KEY([Id_Usuario_Creacion])
REFERENCES [dbo].[Usuario] ([Id_Usuario])
GO

ALTER TABLE [dbo].[Editorial] CHECK CONSTRAINT [FK_Editorial_UsuarioC]
GO

ALTER TABLE [dbo].[Editorial]  WITH CHECK ADD  CONSTRAINT [FK_Editorial_UsuarioM] FOREIGN KEY([Id_Usuario_Modificacion])
REFERENCES [dbo].[Usuario] ([Id_Usuario])
GO

ALTER TABLE [dbo].[Editorial] CHECK CONSTRAINT [FK_Editorial_UsuarioM]
GO


