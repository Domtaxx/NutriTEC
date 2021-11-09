

create PROCEDURE dbo.spGetProduct 
	@Codigo varchar(128) = '',
	@Desc varchar(128)= 'a'
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON;

	SELECT * from dbo.PRODUCTO where Codigo_barras = @Codigo or contains(dbo.PRODUCTO.Descripcion,@Desc)
END
GO

create PROCEDURE dbo.spGetProducts
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON;
	SELECT * from dbo.PRODUCTO
END
GO