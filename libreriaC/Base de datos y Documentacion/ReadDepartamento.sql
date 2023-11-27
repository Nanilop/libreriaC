USE [libreria]
GO

/****** Object:  StoredProcedure [dbo].[ReadDepartamento]    Script Date: 17/11/2023 05:02:44 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ReadDepartamento] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id_Departamento]
      ,[Departamento]
      ,[Id_Usuario_Creacion]
      ,[Fecha_Hora_Creacion]
      ,[Id_Usuario_Modificacion]
      ,[Fecha_Hora_Modificacion]
      ,[Estatus]
  FROM [dbo].[Departamento]
END
GO

