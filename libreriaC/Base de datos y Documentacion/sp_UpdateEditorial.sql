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
CREATE PROCEDURE [dbo].[UpdateEditorial]
	-- Add the parameters for the stored procedure here
	@Id_Editorial int
	,@Nombre varchar(50)
	,@Id_Ciudad int
	,@Año_Inauguracion VARCHAR (4)
	,@Id_Usuario_Creacion int
    ,@Fecha_Hora_Creacion datetime
    ,@Id_Usuario_Modificacion int
    ,@Fecha_Hora_Modificacion datetime
    ,@Estatus bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here


UPDATE [dbo].[Editorial]
   SET [Nombre] = @Nombre
      ,[Id_Ciudad] = @Id_Ciudad
      ,[Año_Inauguracion] = @Año_Inauguracion
      ,[Id_Usuario_Creacion] = @Id_Usuario_Creacion
      ,[Fecha_Hora_Creacion] = @Fecha_Hora_Creacion
      ,[Id_Usuario_Modificacion] = @Id_Usuario_Modificacion
      ,[Fecha_Hora_Modificacion] = @Fecha_Hora_Modificacion
      ,[Estatus] = @Estatus
 WHERE Id_Editorial = @Id_Editorial
 END
GO
