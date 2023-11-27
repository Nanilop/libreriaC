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
CREATE PROCEDURE[dbo].[UpdateUsuario]
	-- Add the parameters for the stored procedure here
	   @Id_Usuario int
      ,@Nombre_Usuario varchar(30)
      ,@Contraseña varchar(50)
      ,@Nombre varchar(30)
      ,@Apellido_Paterno varchar(50)
      ,@Apellido_Materno varchar(50)
      ,@Email varchar(200)
      ,@Telefono varchar(50)
      ,@Id_Puesto int
      ,@Id_Departamento int
      ,@Id_Usuario_Creacion int
      ,@Fecha_Hora_Creacion datetime
      ,@Id_Usuario_Modificacion int
      ,@Fecha_Hora_Modificacion datetime
      ,@Id_Tipo_Usuario int
      ,@Estatus bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
UPDATE [dbo].[Usuario]
   SET [Nombre_Usuario] = @Nombre_Usuario
      ,[Contraseña] = @Contraseña
      ,[Nombre] = @Nombre
      ,[Apellido_Paterno] = @Apellido_Paterno
      ,[Apellido_Materno] = @Apellido_Materno
      ,[Email] = @Email
      ,[Telefono] = @Telefono
      ,[Id_Puesto] = @Id_Puesto
      ,[Id_Departamento] = @Id_Departamento
      ,[Id_Usuario_Creacion] = @Id_Usuario_Creacion
      ,[Fecha_Hora_Creacion] = @Fecha_Hora_Creacion
      ,[Id_Usuario_Modificacion] = @Id_Usuario_Modificacion
      ,[Fecha_Hora_Modificacion] = @Fecha_Hora_Modificacion
      ,[Id_Tipo_Usuario] = @Id_Tipo_Usuario
      ,[Estatus] = @Estatus
 WHERE [Id_Usuario] = @Id_Usuario
END
GO