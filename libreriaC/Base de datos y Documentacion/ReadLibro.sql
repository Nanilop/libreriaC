USE [libreria]
GO

/****** Object:  StoredProcedure [dbo].[ReadLibro]    Script Date: 17/11/2023 05:03:43 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ReadLibro] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id_Libro_ISBN]
      ,[Titulo]
      ,[Id_Categoria]
      ,[Volumen]
      ,[Id_Tipo_Formato]
      ,[Id_Editorial]
      ,[Fecha_Publicacion]
      ,[Paginas]
      ,[Precio]
      ,[Id_Usuario_Creacion]
      ,[Fecha_Hora_Creacion]
      ,[Id_Usuario_Modificacion]
      ,[Fecha_Hora_Modificacion]
      ,[Id_Rating]
      ,[Estatus]
  FROM [dbo].[Libro]

END
GO

