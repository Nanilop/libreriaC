USE [libreria]
GO

/****** Object:  Table [dbo].[Departamento]    Script Date: 12/11/2023 02:10:18 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Departamento](
	[Id_Departamento] [int] NOT NULL,
	[Departamento] [varchar](50) NOT NULL,
	[Id_Usuario_Creacion] [int] NOT NULL,
	[Fecha_Hora_Creacion] [datetime] NOT NULL,
	[Id_Usuario_Modificacion] [int] NOT NULL,
	[Fecha_Hora_Modificacion] [datetime] NOT NULL,
	[Estatus] [bit] NOT NULL,
 CONSTRAINT [PK_Departamento] PRIMARY KEY CLUSTERED 
(
	[Id_Departamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Departamento]  WITH CHECK ADD  CONSTRAINT [FK_Departamento_UsuarioC] FOREIGN KEY([Id_Usuario_Creacion])
REFERENCES [dbo].[Usuario] ([Id_Usuario])
GO

ALTER TABLE [dbo].[Departamento] CHECK CONSTRAINT [FK_Departamento_UsuarioC]
GO

ALTER TABLE [dbo].[Departamento]  WITH CHECK ADD  CONSTRAINT [FK_Departamento_UsuarioM] FOREIGN KEY([Id_Usuario_Modificacion])
REFERENCES [dbo].[Usuario] ([Id_Usuario])
GO

ALTER TABLE [dbo].[Departamento] CHECK CONSTRAINT [FK_Departamento_UsuarioM]
GO


