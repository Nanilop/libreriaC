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
CREATE PROCEDURE CreateUsuario
	@Nombre_Usuario varchar(30),
	@Contraseña varchar(50),
	@Nombre varchar(30),
	@Apellido_Paterno varchar(50),
	@Apellido_Materno varchar(50),
	@Email varchar(200),
	@Telefono varchar(50),
	@Id_Puesto int,
	@Id_Departamento int,
	@Id_Usuario_Creacion int ,
	@Fecha_Hora_Creacion datetime,
	@Id_Usuario_Modificacion int ,
	@Fecha_Hora_Modificacion datetime ,
	@Id_Tipo_usuario int,
	@Estatus bit 
AS
BEGIN
	
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Usuario]
           ([Nombre_Usuario]
		   ,[Contraseña]
		   ,[Nombre]
		   ,[Apellido_Paterno]
		   ,[Apellido_Materno]
		   ,[Email]
		   ,[Telefono]
		   ,[Id_Puesto]
		   ,[Id_Departamento]
           ,[Id_Usuario_Creacion]
           ,[Fecha_Hora_Creacion]
           ,[Id_Usuario_Modificacion]
           ,[Fecha_Hora_Modificacion]
		   ,[Id_Tipo_Usuario]
           ,[Estatus])
     VALUES
           (@Nombre_Usuario
		   ,@Contraseña
		   ,@Nombre
		   ,@Apellido_Paterno
		   ,@Apellido_Materno
		   ,@Email
		   ,@Telefono
		   ,@Id_Puesto
		   ,@Id_Departamento
           ,@Id_Usuario_Creacion
           ,@Fecha_Hora_Creacion
           ,@Id_Usuario_Modificacion
           ,@Fecha_Hora_Modificacion
		   ,@Id_Tipo_usuario
           ,@Estatus)

END
GO