USE [libreria]
GO

/****** Object:  StoredProcedure [dbo].[DeleteTipo_Cliente]    Script Date: 13/11/2023 05:00:06 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteTipo_Cliente]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	update Tipo_Cliente
	set Estatus=0
	where Id_Tipo_Cliente=@id
END
GO

