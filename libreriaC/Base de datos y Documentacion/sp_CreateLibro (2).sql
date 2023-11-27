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
CREATE PROCEDURE CreateLibro
	@Id_Libro_ISBN varchar(50),
	@Titulo varchar(max),
	@Id_Categoria int,
	@Volumen varchar (5),
	@Id_Tipo_Formato int,
	@Id_Editorial int,
	@Fecha_Publicacion date,
	@Paginas int,
	@Precio decimal(10,2),
	@Id_Usuario_Creacion int ,
	@Fecha_Hora_Creacion datetime,
	@Id_Usuario_Modificacion int ,
	@Fecha_Hora_Modificacion datetime ,
	@Id_Rating int,
	@Estatus bit 
AS
BEGIN
	
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Libro]
           ([Id_Libro_ISBN]
		   ,[Titulo]
		   ,[Id_Categoria]
		   ,[Volumen]
		   ,[Id_Tipo_Formato]
		   ,[Id_Editorial]
		   ,[Fecha_Publicacion]
		   ,[Paginas]
		   ,[Precio]
           ,[Id_Usuario_Creacion]
           ,[Fecha_Hora_Creacion]
           ,[Id_Usuario_Modificacion]
           ,[Fecha_Hora_Modificacion]
		   ,[Id_Rating]
           ,[Estatus])
     VALUES
           (@Id_Libro_ISBN
		   ,@Titulo
		   ,@Id_Categoria
		   ,@Volumen
		   ,@Id_Tipo_Formato
		   ,@Id_Editorial
		   ,@Fecha_Publicacion
		   ,@Paginas
		   ,@Precio
           ,@Id_Usuario_Creacion
           ,@Fecha_Hora_Creacion
           ,@Id_Usuario_Modificacion
           ,@Fecha_Hora_Modificacion
		   ,@Id_Rating
           ,@Estatus)

END
GO