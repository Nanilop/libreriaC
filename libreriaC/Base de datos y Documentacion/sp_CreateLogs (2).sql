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
CREATE PROCEDURE CreateLogs
	
	@Id_Usuario int,
	@Fecha_Hora datetime,
	@Accion varchar(50),
	@Tabla varchar(50),
	@Estatus bit,
	@Id_Nivel int
AS
BEGIN
	
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Logs]
           (
[Id_Usuario]
		   ,[Fecha_Hora]
		   ,[Accion]
           ,[Tabla]
           ,[Estatus]
		   ,[Id_Nivel])
     VALUES
           (@Id_Usuario
		   ,@Fecha_Hora
		   ,@Accion
           ,@Tabla
           ,@Estatus
		   ,@Id_Nivel)

END
GO