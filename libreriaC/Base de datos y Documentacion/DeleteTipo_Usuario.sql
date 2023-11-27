USE [libreria]
GO

/****** Object:  StoredProcedure [dbo].[DeleteTipo_Usuario]    Script Date: 13/11/2023 05:00:27 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteTipo_Usuario]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	update Tipo_Usuario
	set Estatus=0
	where Id_Tipo_Usuario=@id
END
GO

