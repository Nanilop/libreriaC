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
CREATE PROCEDURE CreateVenta
	@Id_Tipo_Cliente int,
	@Id_Usuario_Creacion int ,
	@Fecha_Hora_Creacion datetime,
	@Id_Usuario_Modificacion int ,
	@Fecha_Hora_Modificacion datetime ,
	@Estatus bit,
	@Id_Tipo_Pago int
AS
BEGIN
	
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Venta]
           ([Id_Tipo_Cliente]
           ,[Id_Usuario_Creacion]
           ,[Fecha_Hora_Creacion]
           ,[Id_Usuario_Modificacion]
           ,[Fecha_Hora_Modificacion]
           ,[Estatus]
		   ,[Id_Tipo_Pago])

     VALUES
           (@Id_Tipo_Cliente
           ,@Id_Usuario_Creacion
           ,@Fecha_Hora_Creacion
           ,@Id_Usuario_Modificacion
           ,@Fecha_Hora_Modificacion
           ,@Estatus
		   ,@Id_Tipo_Pago)

END
GO