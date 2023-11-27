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
USE [libreria]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateLogs]
	-- Add the parameters for the stored procedure here
	@Id_Log int,
	@Id_Usuario int,
	@Fecha_Hora datetime,
	@Accion varchar(50),
	@Tabla varchar (50),
	@Estatus bit,
	@Id_Nivel int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
UPDATE [dbo].[Logs]
   SET [Id_Usuario] = @Id_Usuario
      ,[Fecha_Hora] = @Fecha_Hora
      ,[Accion] = @Accion
      ,[Tabla] = @Tabla
      ,[Estatus] = @Estatus
      ,[Id_Nivel] = @Id_Nivel
 WHERE Id_Log = Id_Log
END
GO
