USE [libreria]
GO

/****** Object:  StoredProcedure [dbo].[ReadDetalle_Venta]    Script Date: 17/11/2023 05:03:12 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ReadDetalle_Venta] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id_Detalle]
      ,[Id_Venta]
      ,[Id_Descuento]
      ,[Id_Libro_ISBN]
      ,[Id_Usuario_Creacion]
      ,[Fecha_Hora_Creacion]
      ,[Id_Usuario_Modificacion]
      ,[Fecha_Hora_Modificacion]
      ,[Estatus]
  FROM [dbo].[Detalle_Venta]

END
GO

