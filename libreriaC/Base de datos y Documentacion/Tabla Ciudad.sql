USE [libreria]
GO

/****** Object:  Table [dbo].[Ciudad]    Script Date: 12/11/2023 02:10:11 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Ciudad](
	[Id_Ciudad] [int] NOT NULL,
	[Id_Estado] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Estatus] [bit] NOT NULL,
 CONSTRAINT [PK_Ciudad] PRIMARY KEY CLUSTERED 
(
	[Id_Ciudad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Ciudad]  WITH CHECK ADD  CONSTRAINT [FK_Ciudad_Estado] FOREIGN KEY([Id_Estado])
REFERENCES [dbo].[Estado] ([Id_Estado])
GO

ALTER TABLE [dbo].[Ciudad] CHECK CONSTRAINT [FK_Ciudad_Estado]
GO


