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
Create FUNCTION dbo.GetDiscount
(@email varchar(320))
RETURNS float(2)
AS
Begin
    Declare @discount as float(2)=0;
    Declare @tipo_cobro as char;
    Select @tipo_cobro = (select Tipo_cobro from NUTRICIONISTA where NUTRICIONISTA.Correo=@email)
    if (@tipo_cobro='a')begin
        select @discount=0.0
    end
    if (@tipo_cobro='b')begin
        select @discount=5.0
    end
    if(@tipo_cobro='c')begin
        select @discount=10.0
    end
    return @discount

end
GO
Create FUNCTION dbo.GetAttendedClient
(@email varchar(320))
returns integer
    AS
    begin
        declare @attended As INTEGER;
        Select @attended=Count(*)
        From CLIENTE
        WHERE Correo_nutri=@email;
        return @attended;
    end
GO


Create PROCEDURE dbo.GetPaymentAmount
@email varchar(320)
AS
    Begin
        Create Table #temp(
            correo varchar(320),
            atendidos int,
            pago float

        )
        Declare @discount As Float(2);
        Set @discount =dbo.GetDiscount(@email);
        Declare @atendend as integer=dbo.GetAttendedClient(@email);
        Declare @payment as FLOAT
        set @payment =(100-@discount)* @atendend /100;
        insert into #temp (correo,atendidos,pago)
        values(@email,@atendend,ROUND(@payment,2));
        select * from #temp;
        drop table #temp;
    end
GO

Create PROCEDURE dbo.spAddPlan
@plan_name varchar(128),
@correo_nutri varchar(128)
AS
BEGIN

        declare @element_count as integer;
        select @element_count=count(*) from dbo.PLAN_ALIMENTACION
        where Nombre=@plan_name;
        if(@element_count=0)begin
            insert into dbo.PLAN_ALIMENTACION (Nombre, Correo_nutri)
            values (@plan_name,@correo_nutri)
        end
        select * from PLAN_ALIMENTACION
        where Nombre=@plan_name;
END
GO

Create Procedure dbo.spAddProductToMenu
@plan_name varchar(128),
@menu_name varchar(128),
@codigo varchar(128)
AS
    begin
        insert into MENU_PRODUCTO (nombre_plan_alimentacion, nombre_menu, codigo_barras)
        values (@plan_name,@menu_name,@codigo);
        select * from Producto_public
        where Codigo_barras=@codigo;
    end
Go