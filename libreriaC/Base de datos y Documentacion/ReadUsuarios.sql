USE [libreria]
GO

/****** Object:  StoredProcedure [dbo].[ReadUsuarios]    Script Date: 17/11/2023 05:06:04 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ReadUsuarios] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id_Usuario]
      ,[Nombre_Usuario]
      ,[Contraseña]
      ,[Nombre]
      ,[Apellido_Paterno]
      ,[Apellido_Materno]
      ,[Email]
      ,[Telefono]
      ,[Id_Puesto]
      ,[Id_Departamento]
      ,[Id_Usuario_Creacion]
      ,[Fecha_Hora_Creacion]
      ,[Id_Usuario_Modificacion]
      ,[Fecha_Hora_Modificacion]
      ,[Id_Tipo_Usuario]
      ,[Estatus]
  FROM [dbo].[Usuario]
END
GO

