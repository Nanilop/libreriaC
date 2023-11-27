USE [libreria]
GO

/****** Object:  StoredProcedure [dbo].[DeleteLibro_Autores]    Script Date: 13/11/2023 04:58:46 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteLibro_Autores]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	update Libro_Autores
	set Estatus=0
	where Id_Libro_Autores=@id
END
GO

