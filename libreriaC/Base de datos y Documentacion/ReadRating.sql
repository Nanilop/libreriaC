USE [libreria]
GO

/****** Object:  StoredProcedure [dbo].[ReadRating]    Script Date: 17/11/2023 05:04:44 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ReadRating] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id_Rating]
      ,[Valor]
      ,[Estatus]
  FROM [dbo].[Rating]
END
GO

