USE [libreria]
GO

/****** Object:  StoredProcedure [dbo].[DeleteLibro]    Script Date: 13/11/2023 04:58:35 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteLibro]
	-- Add the parameters for the stored procedure here
	@id varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	update Libro
	set Estatus=0
	where Id_Libro_ISBN=@id
END
GO

