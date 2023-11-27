USE [libreria]
GO

/****** Object:  Table [dbo].[Logs]    Script Date: 12/11/2023 02:18:09 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Logs](
	[Id_Log] [int] NOT NULL,
	[Id_Usuario] [int] NOT NULL,
	[Fecha_Hora] [datetime] NOT NULL,
	[Accion] [varchar](50) NOT NULL,
	[Tabla] [varchar](50) NOT NULL,
	[Estatus] [bit] NOT NULL,
	[Id_Nivel] [int] NOT NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[Id_Log] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Logs]  WITH CHECK ADD  CONSTRAINT [FK_Log_Nivel] FOREIGN KEY([Id_Nivel])
REFERENCES [dbo].[Nivel] ([Id_Nivel])
GO

ALTER TABLE [dbo].[Logs] CHECK CONSTRAINT [FK_Log_Nivel]
GO

ALTER TABLE [dbo].[Logs]  WITH CHECK ADD  CONSTRAINT [FK_Log_Usuario] FOREIGN KEY([Id_Usuario])
REFERENCES [dbo].[Usuario] ([Id_Usuario])
GO

ALTER TABLE [dbo].[Logs] CHECK CONSTRAINT [FK_Log_Usuario]
GO


