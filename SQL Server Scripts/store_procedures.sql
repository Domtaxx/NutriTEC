create PROCEDURE dbo.spGetProduct
	@Codigo varchar(128) = '',
	@Desc varchar(128)= 'aasdasasdfasd1234jadfvasd1234nadbfh1'
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
    SET NOCOUNT ON;
    select * from Client_public where Correo_nutri = @email
    return
END
GO

Create PROCEDURE dbo.spGetCliente
    @email varchar(320)
AS
BEGIN
    SET NOCOUNT ON;
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
        SET NOCOUNT ON;
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
        SET NOCOUNT ON;
        declare @element_count as integer;
        select @element_count=count(*) from dbo.PLAN_ALIMENTACION
        where Nombre=@plan_name;
        if(@element_count=0)begin
            insert into dbo.PLAN_ALIMENTACION (Nombre, Correo_nutri)
            values (@plan_name,@correo_nutri)
        end
        select * from PLAN_ALIMENTACION
        where Nombre=@plan_name and Correo_nutri=@correo_nutri;
END
GO

Create Procedure dbo.spAddMenuToPlan
@plan_name varchar(128),
@menu_name varchar(128),
@email varchar(320)
as
    begin
        SET NOCOUNT ON;
        declare @accepted_user as INTEGER;
        select @accepted_user=count(*) from PLAN_ALIMENTACION
        where PLAN_ALIMENTACION.Nombre=@plan_name and PLAN_ALIMENTACION.Correo_nutri=@email;
        if(@accepted_user>0)begin
            declare @not_exist_menu as INTEGER;
            select @not_exist_menu=count(*) from MENU
            where MENU.Nombre=@menu_name and MENU.Nombre_plan_alimentacion=@plan_name;
            if(@not_exist_menu=0)begin
                insert into MENU(nombre_plan_alimentacion, nombre)
                values(@plan_name,@menu_name)

            end
        end
        select MENU.Nombre_plan_alimentacion,MENU.Nombre
        from MENU JOIN PLAN_ALIMENTACION on MENU.Nombre_plan_alimentacion=PLAN_ALIMENTACION.Nombre
        where MENU.Nombre=@menu_name and MENU.Nombre_plan_alimentacion=@plan_name;

    end
GO

Create Procedure dbo.spAddProductToMenu
@plan_name varchar(128),
@menu_name varchar(128),
@codigo varchar(128),
@correo varchar(320)
AS
    begin
        SET NOCOUNT ON;
        declare @acceptedPlanUser as integer;
        select @acceptedPlanUser=count(*) from PLAN_ALIMENTACION
        WHERE Nombre=@plan_name and Correo_nutri=@correo;
        if(@acceptedPlanUser>0)begin
            declare @existingMenu as INTEGER;
            select @existingMenu=count(*) from MENU
            where Nombre_plan_alimentacion=@plan_name and Nombre=@menu_name;
            if(@existingMenu>0)begin
                insert into MENU_PRODUCTO (nombre_plan_alimentacion, nombre_menu, codigo_barras)
                values (@plan_name,@menu_name,@codigo);
            end
        end
        select * from Producto_public
        where Codigo_barras=@codigo;
    end
Go

create procedure dbo.spGetMenuProducts
@plan_name varchar(130),
@menu_name varchar(130)
AS
    Begin
        SET NOCOUNT ON;
        Select * from
        MENU_PRODUCTO join Producto_public on (dbo.MENU_PRODUCTO.Codigo_barras=Producto_public.Codigo_barras)
        where MENU_PRODUCTO.Nombre_plan_alimentacion=@plan_name and MENU_PRODUCTO.Nombre_menu=@menu_name
    end
GO

create procedure dbo.spGetProduct_report
@Client_email varchar(320)
AS
    Begin
        SET NOCOUNT ON;
        select * from Cliente_producto_public where Correo_cliente = @Client_email
    end
GO

create procedure dbo.spGetReceta_report
@Client_email varchar(320)
AS
    Begin
        SET NOCOUNT ON;
        select distinct RP.Correo_cliente,
                        RP.Nombre,
                        RP.Correo_creador,
                        RP.Fecha,
                        RP.Tiempo,
                        RP.Tamano,
                        (select sum(Calcio) from receta_public t1 where t1.Correo_creador = RP.Correo_creador and t1.Correo_cliente = RP.Correo_cliente and t1.Nombre = RP.Nombre)[Calcio],
                        (select sum(Hierro) from receta_public t1 where t1.Correo_creador = RP.Correo_creador and t1.Correo_cliente = RP.Correo_cliente and t1.Nombre = RP.Nombre)[Hierro],
                        (select sum(Energia) from receta_public t1 where t1.Correo_creador = RP.Correo_creador and t1.Correo_cliente = RP.Correo_cliente and t1.Nombre = RP.Nombre)[Energia],
                        (select sum(Sodio) from receta_public t1 where t1.Correo_creador = RP.Correo_creador and t1.Correo_cliente = RP.Correo_cliente and t1.Nombre = RP.Nombre)[Sodio],
                        (select sum(Carbohidratos) from receta_public t1 where t1.Correo_creador = RP.Correo_creador and t1.Correo_cliente = RP.Correo_cliente and t1.Nombre = RP.Nombre)[Carbohidratos],
                        (select sum(Proteina) from receta_public t1 where t1.Correo_creador = RP.Correo_creador and t1.Correo_cliente = RP.Correo_cliente and t1.Nombre = RP.Nombre)[Proteina],
                        (select sum(Vitaminas) from receta_public t1 where t1.Correo_creador = RP.Correo_creador and t1.Correo_cliente = RP.Correo_cliente and t1.Nombre = RP.Nombre)[Vitaminas]
        from receta_public RP where Correo_cliente = @Client_email
    end
GO

alter procedure dbo.spGetRecetas
@email_creator varchar(320),
@name varchar(128)
AS
    Begin
        SET NOCOUNT ON;
	    SELECT * from dbo.RECETA where RECETA.Aprobado = 1 and (Nombre like concat('%',concat(@name,'%')) or @email_creator like concat('%',concat(Correo_creador,'%')))
    end
GO

create procedure dbo.spGetReceta
@email_creator varchar(320),
@name varchar(128)
AS
    Begin
        SET NOCOUNT ON;
	    SELECT * from dbo.RECETA where (Nombre = @name and @email_creator = Correo_creador and RECETA.Aprobado = 1)
    end
GO

create procedure dbo.spGetRecetas_byName
@email_creator varchar(320),
@name varchar(128)
AS
    Begin
        SET NOCOUNT ON;
	    SELECT * from dbo.RECETA where (Nombre like concat('%',concat(@name,'%'))and RECETA.Aprobado = 1 and @email_creator =  Correo_creador)
    end
GO

create procedure  dbo.spAddRecetaToMenu
@plan_name varchar(128),
@menu_name varchar(128),
@nombre_receta varchar(128),
@creador varchar(320),
@nutri varchar(320)
AS
    begin
        SET NOCOUNT ON;
        declare @acceptedPlanUser as integer;
        select @acceptedPlanUser=count(*) from PLAN_ALIMENTACION
        WHERE Nombre=@plan_name and Correo_nutri=@nutri;
        if(@acceptedPlanUser>0)begin
            declare @existingMenu as INTEGER;
            select @existingMenu = count(*) from MENU
            where Nombre_plan_alimentacion=@plan_name and Nombre=@menu_name;
            if(@existingMenu>0)begin
                insert into MENU_RECETA (nombre_plan_alimentacion, nombre_menu, Nombre_receta,Correo_creador)
                values (@plan_name,@menu_name,@nombre_receta,@creador);
            end
        end
    end
Go

create procedure dbo.spGetMedidasReciente
@cliente varchar(320)
as
    begin
        SET NOCOUNT ON;
        select * from REGISTRO_MEDIDAS where (Fecha = (select MAX(t.fecha) from dbo.REGISTRO_MEDIDAS t where t.Correo_cliente = @cliente)) and @cliente = Correo_cliente
    end
GO

create procedure dbo.spGetReportRecetasPeriodo
@Client_email varchar(320),
@Fecha_ini date,
@Fecha_Fi date
as
    begin
        SET NOCOUNT ON;
        select distinct RP.Correo_cliente,
                        RP.Nombre,
                        RP.Correo_creador,
                        RP.Fecha,
                        RP.Tiempo,
                        RP.Tamano,
                        (select sum(Calcio) from receta_public t1 where t1.Correo_creador = RP.Correo_creador and t1.Correo_cliente = RP.Correo_cliente and t1.Nombre = RP.Nombre)[Calcio],
                        (select sum(Hierro) from receta_public t1 where t1.Correo_creador = RP.Correo_creador and t1.Correo_cliente = RP.Correo_cliente and t1.Nombre = RP.Nombre)[Hierro],
                        (select sum(Energia) from receta_public t1 where t1.Correo_creador = RP.Correo_creador and t1.Correo_cliente = RP.Correo_cliente and t1.Nombre = RP.Nombre)[Energia],
                        (select sum(Sodio) from receta_public t1 where t1.Correo_creador = RP.Correo_creador and t1.Correo_cliente = RP.Correo_cliente and t1.Nombre = RP.Nombre)[Sodio],
                        (select sum(Carbohidratos) from receta_public t1 where t1.Correo_creador = RP.Correo_creador and t1.Correo_cliente = RP.Correo_cliente and t1.Nombre = RP.Nombre)[Carbohidratos],
                        (select sum(Proteina) from receta_public t1 where t1.Correo_creador = RP.Correo_creador and t1.Correo_cliente = RP.Correo_cliente and t1.Nombre = RP.Nombre)[Proteina],
                        (select sum(Vitaminas) from receta_public t1 where t1.Correo_creador = RP.Correo_creador and t1.Correo_cliente = RP.Correo_cliente and t1.Nombre = RP.Nombre)[Vitaminas]
        from receta_public RP where Correo_cliente = @Client_email and RP.Fecha >= @Fecha_ini and RP.Fecha<= @Fecha_Fi;
    end
GO

create procedure dbo.spGetReportProductosPeriodo
@Client_email varchar(320),
@Fecha_ini date,
@Fecha_Fi date
as
    begin
        SET NOCOUNT ON;
        select * from Cliente_producto_public where Correo_cliente = @Client_email and Fecha>=@Fecha_ini and Fecha<=@Fecha_Fi
    end
GO

create procedure dbo.spGetMedidaPeriodo
@Client_email varchar(320),
@Fecha_ini date,
@Fecha_Fi date
as
    begin
        SET NOCOUNT ON;
        select * from REGISTRO_MEDIDAS where Correo_cliente = @Client_email and Fecha>=@Fecha_ini and Fecha<=@Fecha_Fi
    end
GO

alter procedure dbo.spLoginAdmin
@email varchar(320),
@contra varchar(128)
as
    begin
        SET NOCOUNT ON;
        select * from ADMINISTRADOR where @email = Correo and @contra = Contra
    end
GO

GetPaymentAmount 'Fernando03@gmail.com'