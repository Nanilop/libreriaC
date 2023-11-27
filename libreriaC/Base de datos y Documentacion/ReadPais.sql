USE [libreria]
GO

/****** Object:  StoredProcedure [dbo].[ReadPais]    Script Date: 17/11/2023 05:04:26 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ReadPais] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id_Pais]
      ,[Nombre]
      ,[Nacionalidad]
      ,[Estatus]
  FROM [dbo].[Pais]
END
GO

