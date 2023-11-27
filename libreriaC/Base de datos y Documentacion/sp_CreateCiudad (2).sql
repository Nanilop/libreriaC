USE [libreria]
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE CreateCiudad
	
	@Id_Estado int,
	@Nombre varchar(50) ,
	@Estatus bit 
AS
BEGIN
	
	SET NOCOUNT ON;
	INSERT INTO [dbo].Ciudad
           ([Id_Estado]
		   ,[Nombre]
           ,[Estatus])
     VALUES
           (@Id_Estado
			,@Nombre
           ,@Estatus)

END
GO