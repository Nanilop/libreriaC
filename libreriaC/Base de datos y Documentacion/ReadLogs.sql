USE [libreria]
GO

/****** Object:  StoredProcedure [dbo].[ReadLogs]    Script Date: 17/11/2023 05:04:09 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ReadLogs] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id_Log]
      ,[Id_Usuario]
      ,[Fecha_Hora]
      ,[Accion]
      ,[Tabla]
      ,[Estatus]
      ,[Id_Nivel]
  FROM [dbo].[Logs]

END
GO

