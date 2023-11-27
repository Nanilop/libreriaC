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
CREATE PROCEDURE CreateAutor
	@Id_Autor varchar(10),
	@Nombre varchar(50) ,
	@Apellido varchar(50) ,
	@Fecha_Nacimiento date ,
	@Id_Pais int ,
	@Id_Usuario_Creacion int ,
	@Fecha_Hora_Creacion datetime,
	@Id_Usuario_Modificacion int ,
	@Fecha_Hora_Modificacion datetime ,
	@Estatus bit 
AS
BEGIN
	
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Autor]
           ([Id_Autor]
		   ,[Nombre]
           ,[Apellido]
           ,[Fecha_Nacimiento]
           ,[Id_Pais]
           ,[Id_Usuario_Creacion]
           ,[Fecha_Hora_Creacion]
           ,[Id_Usuario_Modificacion]
           ,[Fecha_Hora_Modificacion]
           ,[Estatus])
     VALUES
           (@Id_Autor
		   ,@Nombre
           ,@Apellido
           ,@Fecha_Nacimiento
           ,@Id_Pais
           ,@Id_Usuario_Creacion
           ,@Fecha_Hora_Creacion
           ,@Id_Usuario_Modificacion
           ,@Fecha_Hora_Modificacion
           ,@Estatus)

END
GO