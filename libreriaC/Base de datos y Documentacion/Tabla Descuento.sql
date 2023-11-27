USE [libreria]
GO

/****** Object:  Table [dbo].[Descuento]    Script Date: 12/11/2023 02:10:23 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Descuento](
	[id_Descuento] [int] IDENTITY(1,1) NOT NULL,
	[Porcentaje] [decimal](3, 2) NOT NULL,
	[Estatus] [bit] NOT NULL,
 CONSTRAINT [PK_Descuento] PRIMARY KEY CLUSTERED 
(
	[id_Descuento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


