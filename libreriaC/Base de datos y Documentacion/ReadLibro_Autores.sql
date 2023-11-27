USE [libreria]
GO

/****** Object:  StoredProcedure [dbo].[ReadLibro_Autores]    Script Date: 17/11/2023 05:03:56 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ReadLibro_Autores] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id_Libro_Autores]
      ,[Id_Libro_ISBN]
      ,[Id_Autor]
      ,[Id_Usuario_Creacion]
      ,[Fecha_Hora_Creacion]
      ,[Id_Usuario_Modificacion]
      ,[Fecha_Hora_Modificacion]
      ,[Estatus]
  FROM [dbo].[Libro_Autores]

END
GO

