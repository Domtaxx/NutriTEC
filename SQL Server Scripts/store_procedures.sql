CREATE PROCEDURE dbo.spGetProduct
	@Codigo varchar(128) = '',
	@Desc varchar(128)= 'a'
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON;

	SELECT * from dbo.PRODUCTO where (Codigo_barras = @Codigo or Descripcion like concat('%',concat(@Desc,'%'))) and (Estado not like '%Pendiente%')
END
GO

CREATE PROCEDURE dbo.spGetAllProducts
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON;
	SELECT * from dbo.PRODUCTO
END
GO

CREATE PROCEDURE dbo.spLoginNutri
	@email varchar(320),
	@pass varchar(128)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON;
	SELECT * from NUTRICIONISTA where Correo = (select Correo from dbo.NUTRICIONISTA where @email = Correo and @pass = Contra)
END
GO

CREATE PROCEDURE dbo.spLoginClient
	@email varchar(320),
	@pass varchar(128)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * from Client_public where Correo = (select Correo from CLIENTE where @email = Correo and @pass = Contra)
	return
END
GO

Create PROCEDURE dbo.spGetClientes
    @email varchar(320)
AS
BEGIN
    select * from Client_public where Correo_nutri = @email
    return
END
GO

Create PROCEDURE dbo.spGetCliente
    @email varchar(320)
AS
BEGIN
    select * from Client_public where Correo = @email
    return
END
GO
