USE [libreria]
GO

/****** Object:  StoredProcedure [dbo].[DeleteAutor]    Script Date: 13/11/2023 04:57:17 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteAutor]
	-- Add the parameters for the stored procedure here
	@id varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	update Autor
	set Estatus=0
	where Id_Autor=@id
END
GO

