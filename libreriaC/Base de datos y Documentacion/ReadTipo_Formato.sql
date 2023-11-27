USE [libreria]
GO

/****** Object:  StoredProcedure [dbo].[ReadTipo_Formato]    Script Date: 17/11/2023 05:05:08 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ReadTipo_Formato] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id_Tipo_Formato]
      ,[Nombre]
      ,[Id_Usuario_Creacion]
      ,[Fecha_Hora_Creacion]
      ,[Id_Usuario_Modificacion]
      ,[Fecha_Hora_Modificacion]
      ,[Estatus]
  FROM [dbo].[Tipo_Formato]
END
GO

