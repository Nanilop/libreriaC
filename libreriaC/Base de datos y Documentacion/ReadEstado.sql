USE [libreria]
GO

/****** Object:  StoredProcedure [dbo].[ReadEstado]    Script Date: 17/11/2023 05:03:35 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ReadEstado] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id_Estado]
      ,[Id_Pais]
      ,[Nombre]
      ,[Estatus]
  FROM [dbo].[Estado]

END
GO

