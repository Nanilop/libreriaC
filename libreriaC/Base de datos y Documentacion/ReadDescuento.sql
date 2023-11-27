USE [libreria]
GO

/****** Object:  StoredProcedure [dbo].[ReadDescuento]    Script Date: 17/11/2023 05:02:57 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ReadDescuento] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [id_Descuento]
      ,[Porcentaje]
      ,[Estatus]
  FROM [dbo].[Descuento]

END
GO

