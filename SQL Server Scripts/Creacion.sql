CREATE Table [PRODUCTO](
	Codigo_barras varchar(128),
	Sodio float,
	Energia float,
	Carbohidratos float,
	Tamano float,
	Vitaminas float,
	Descripcion varchar(128),
	Estado varchar(64),
	Hierro float,
	Calcio float,
	Proteina float,
	Correo_admin varchar(320),
	primary key(Codigo_barras)
);

Create table [ADMINISTRADOR](
	Correo varchar(320),
	Contra varchar(128),
	primary key(Correo)
);
Create table [RECETA](
	Correo_admin varchar(320),
	Nombre varchar(128),
	Correo_creador varchar(320),
	Aprobado bit,
	primary key(Nombre,Correo_creador)
);
Create table [REGISTRO_MEDIDAS](
	Correo_cliente varchar(320),
	Cadera float,
	Porcentaje_musculo float,
	Porcentaje_grasa float,
	Cuello float,
	Cintura float,
	IMC float,
	Peso float,
	Fecha date
	primary key(Correo_cliente,Fecha)
);
Create table [CLIENTE](
	Correo varchar(320),
	Contra varchar(128),
	Direccion varchar(Max),
	Primer_nom varchar(64),
	Seg_nom varchar(64),
	IMC float,
	Primer_apellido varchar(64),
	Seg_apellido varchar(64),
	Max_calorias float,
	Fecha_nace date,
	Correo_nutri varchar(320),
	primary key(Correo)
);
Create table [NUTRICIONISTA](
	Correo varchar(320),
	Contra varchar(128),
	Codigo varchar(Max),
	Primer_nom varchar(64),
	Seg_nom varchar(64),
	Primer_apellido varchar(64),
	Seg_apellido varchar(64),
	Num_tarjeta varchar(16),
	Fecha_nace date,
	Tipo_cobro varchar(32),
	Direccion varchar(Max),
	IMC float,
	Peso float,
	foto varchar(260),
	primary key(Correo)
);
Create Table [PLAN_ALIMENTACION](
	Nombre varchar(128),
	Correo_nutri varchar(320)
	primary key(Nombre)
);
Create Table [MENU](
	Nombre_plan_alimentacion varchar(128),
	Nombre varchar(128),
	primary key(Nombre_plan_alimentacion,Nombre)
);
Create Table [CLIENTE_RECETA](
	Nombre_receta varchar(128),
	Correo_cliente varchar(320),
	Correo_creador varchar(320),
	Fecha date,
    Tiempo varchar(128),
	primary key(Nombre_receta,Correo_creador,Correo_cliente,Fecha,Tiempo)
);
Create Table [CLIENTE_PRODUCTO](
	Codigo_barras varchar(128),
	Correo_cliente varchar(320),
	Fecha date,
    Tiempo varchar(128),
	primary key(Codigo_barras,Correo_cliente,Fecha,Tiempo)
);
Create Table [CLIENTE_PLAN](
	Nombre_plan varchar(128),
	Correo_cliente varchar(320),
	Inicio date,
	Final date,
	primary key(Nombre_plan,Correo_cliente,Inicio,Final)
);
Create Table [MENU_PRODUCTO](
	Nombre_plan_alimentacion varchar(128),
	Nombre_menu varchar(128),
	Codigo_barras varchar(128),
	cantidad int,
	primary key(Nombre_plan_alimentacion, Nombre_menu, Codigo_barras)
);

Create Table [MENU_RECETA](
	Nombre_plan_alimentacion varchar(128),
	Nombre_menu varchar(128),
	Nombre_receta varchar(128),
	Correo_creador varchar(320),
	primary key(Nombre_plan_alimentacion, Nombre_menu, Nombre_receta,Correo_creador)
);

Create Table [RECETA_PRODUCTO](
	Nombre_receta varchar(128),
	Correo_creador varchar(320),
	Codigo_barras varchar(128),
	cantidad int,
	primary key(Nombre_receta,Correo_creador,Codigo_barras)
);

Alter Table [PRODUCTO]
Add Constraint correo_admin_PRODUCTO
Foreign key(Correo_admin) References ADMINISTRADOR(Correo);

Alter Table [RECETA]
Add Constraint correo_admin_RECETA
Foreign key(Correo_admin) REFERENCES ADMINISTRADOR(Correo);

Alter Table [RECETA]
Add Constraint correo_creador_RECETA
Foreign key(Correo_creador) REFERENCES CLIENTE(Correo);

Alter Table [REGISTRO_MEDIDAS]
Add Constraint cliente_correo_REGISTRO_MEDIDAS
Foreign key(Correo_cliente) References CLIENTE(Correo);

Alter Table [CLIENTE]
Add Constraint client_nutri_CLIENT
Foreign key(Correo_nutri) References NUTRICIONISTA(Correo);

Alter Table [PLAN_ALIMENTACION]
Add Constraint correo_nutri_PLAN_ALIMENTACION
Foreign key(Correo_nutri) References NUTRICIONISTA(Correo);

Alter Table [MENU]
Add Constraint nombre_plan_alimentacion_MENU
Foreign key (Nombre_plan_alimentacion) References PLAN_ALIMENTACION(Nombre);

Alter Table [CLIENTE_RECETA]
Add Constraint receta_CLIENTE_RECETA
Foreign key(Nombre_receta,Correo_creador) References RECETA(Nombre,Correo_creador);

Alter Table [CLIENTE_RECETA]
Add Constraint correo_cliente_CLIENTE_RECETA
Foreign key(Correo_cliente) References CLIENTE(Correo);

Alter Table [CLIENTE_PRODUCTO]
Add Constraint codigo_barras_CLIENTE_PRODUCTO
Foreign key(Codigo_barras) References PRODUCTO(Codigo_barras);

Alter Table [CLIENTE_PRODUCTO]
Add Constraint correo_cliente_CLIENTE_PRODUCTO
Foreign key(Correo_cliente) References CLIENTE(Correo);

Alter Table [CLIENTE_PLAN]
Add Constraint nombre_plan_CLIENTE_PLAN
Foreign key(Nombre_plan) References PLAN_ALIMENTACION(Nombre);

Alter Table [CLIENTE_PLAN]
Add Constraint correo_cliente_CLIENTE_PLAN
Foreign key(Correo_cliente) References CLIENTE(Correo);

Alter Table [MENU_PRODUCTO]
Add Constraint menu_MENU_PRODUCTO
Foreign key (Nombre_plan_alimentacion, Nombre_menu) References MENU(Nombre_plan_alimentacion,Nombre);

Alter Table [MENU_PRODUCTO]
Add Constraint codigo_MENU_PRODUCTO
Foreign key(Codigo_barras) References PRODUCTO(Codigo_barras);

Alter Table [MENU_RECETA]
Add Constraint menu_MENU_RECETA
Foreign key (Nombre_plan_alimentacion, Nombre_menu) References MENU(Nombre_plan_alimentacion,Nombre);

Alter Table [MENU_RECETA]
Add Constraint receta_MENU_RECETA
Foreign key(Nombre_receta,Correo_creador) References RECETA(Nombre,Correo_creador);

Alter TABLE [RECETA_PRODUCTO]
Add CONSTRAINT receta_RECETA_PRODUCTO
FOREIGN KEY (Nombre_receta,Correo_creador) REFERENCES RECETA(Nombre,Correo_creador);

Alter TABLE [RECETA_PRODUCTO]
Add CONSTRAINT codigo_barras_RECETA_PRODUCTO
FOREIGN KEY (Codigo_barras) REFERENCES PRODUCTO(Codigo_barras);

create view NUTRICIONISTA_public as select Correo,Codigo,Primer_nom,Seg_nom,Primer_apellido,Seg_apellido,Fecha_nace,foto from dbo.NUTRICIONISTA;
GO
create view Client_public as select Correo, Primer_nom, Seg_nom,Primer_apellido,Seg_apellido,dbo.CLIENTE.Max_calorias,Fecha_nace,IMC,Correo_nutri from CLIENTE;
GO
create view Medida_public as select Cadera,Porcentaje_musculo,Porcentaje_grasa,Cuello,Cintura,Fecha,Peso,IMC from REGISTRO_MEDIDAS;
GO
create view Producto_public as select Codigo_barras,Descripcion,Estado,Sodio,Energia,Carbohidratos,Tamano,Vitaminas,Hierro,Calcio,Proteina From PRODUCTO;
GO
create view receta_public as select CR.Correo_cliente,Nombre,R.Correo_creador,Fecha,Tiempo,(Calcio*cantidad)[Calcio], (cantidad*Hierro)[Hierro],(cantidad*energia)[Energia],(cantidad*Sodio)[Sodio],(cantidad*Carbohidratos)[Carbohidratos],(cantidad*Proteina)[Proteina],(cantidad*Vitaminas)[Vitaminas],Tamano[Tamano] from RECETA R join RECETA_PRODUCTO RP on (R.Nombre = RP.Nombre_receta and R.Correo_creador = RP.Correo_creador) join PRODUCTO P on RP.Codigo_barras = P.Codigo_barras join CLIENTE_RECETA CR on RP.Nombre_receta = CR.Nombre_receta and RP.Correo_creador = CR.Correo_creador;
GO
create view Cliente_producto_public as select CP.Correo_cliente,CP.Tiempo,CP.Fecha ,CP.Codigo_barras, Sodio, Energia, Carbohidratos, Tamano, Vitaminas, Descripcion, Hierro, Calcio, Proteina from (CLIENTE_PRODUCTO CP join PRODUCTO P on CP.codigo_barras = P.Codigo_barras);
GO
create view Reporte_cobro as select RP.Correo_creador[correo],RP.cantidad[atendidos],CAST(RP.cantidad as Float)[pago],CAST(RP.cantidad as Float)[descuento],CAST(RP.Correo_creador as varchar(32))[tipo_cobro] from RECETA_PRODUCTO RP
GO
create view receta_admin_public as select Nombre,Aprobado,R.Correo_creador,(Calcio*cantidad)[Calcio], (cantidad*Hierro)[Hierro],(cantidad*energia)[Energia],(cantidad*Sodio)[Sodio],(cantidad*Carbohidratos)[Carbohidratos],(cantidad*Proteina)[Proteina],(cantidad*Vitaminas)[Vitaminas],Descripcion from RECETA R join RECETA_PRODUCTO RP on (R.Nombre = RP.Nombre_receta and R.Correo_creador = RP.Correo_creador) join PRODUCTO P on RP.Codigo_barras = P.Codigo_barras
Go
--asdasdas
Create Trigger TR_insert_product on PRODUCTO after insert
as
begin
    declare @est varchar(64),
            @C_admin varchar(320),
            @C_barras varchar(128)
    set nocount on;
    select @est = Estado, @C_admin= Correo_admin,@C_barras=Codigo_barras from inserted
    if (@est not like '%Disponible%') or @C_admin = null
    begin
        update PRODUCTO set Estado = 'Inhabilitado',Correo_admin = null where Codigo_barras = @C_barras
    end
end
GO

create trigger TR_delete_plan on PLAN_ALIMENTACION instead of delete
as
    delete from MENU_RECETA where Nombre_plan_alimentacion = (select deleted.Nombre from deleted);
    delete from MENU_PRODUCTO where Nombre_plan_alimentacion = (select deleted.Nombre from deleted);
    delete from MENU where Nombre_plan_alimentacion = (select deleted.Nombre from deleted);
    delete from CLIENTE_PLAN where Nombre_plan =(select deleted.Nombre from deleted);
    Delete from PLAN_ALIMENTACION where Nombre = (select deleted.Nombre from deleted);
GO

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
    Declare @tipo_cobro as varchar(32);
    Select @tipo_cobro = (select Tipo_cobro from NUTRICIONISTA where NUTRICIONISTA.Correo=@email)
    if (@tipo_cobro='Semanal')begin
        select @discount=0.0
    end
    if (@tipo_cobro='Mensual')begin
        select @discount=5.0
    end
    if(@tipo_cobro='Anual')begin
        select @discount=10.0
    end
    return @discount

end
GO

create function dbo.ftipo_cobro
(@email varchar(320))
returns varchar(32)
    AS
    begin

        declare @tipo_cobro As varchar(32);
        Select @tipo_cobro= Tipo_cobro
        From NUTRICIONISTA
        WHERE Correo=@email;
        return @tipo_cobro;
    end
GO
create function dbo.fpagos
(@email varchar(320))
returns float
    AS
    begin
        Declare @discount As Float(2);
        Set @discount =dbo.GetDiscount(@email);
        Declare @atendend as integer=dbo.GetAttendedClient(@email);
        Declare @payment as FLOAT
        set @payment =(100-@discount)* @atendend /100;
        return @payment
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


create PROCEDURE dbo.GetPaymentAmount
@tipo varchar(32)
    AS
    Begin
        SET NOCOUNT ON;
        Create Table #temp(
            correo varchar(320),
            atendidos int,
            pago float,
            descuento float,
            tipo_cobro varchar(32)
        )
        insert into #temp (correo,atendidos,pago,descuento,tipo_cobro) select distinct Correo,dbo.GetAttendedClient(Correo), dbo.fpagos(Correo),dbo.GetDiscount(Correo),dbo.ftipo_cobro(Correo) from NUTRICIONISTA;
        select * from #temp where tipo_cobro = @tipo;
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

create procedure dbo.spGetRecetas
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

create procedure dbo.spLoginAdmin
@email varchar(320),
@contra varchar(128)
as
    begin
        SET NOCOUNT ON;
        select * from ADMINISTRADOR where @email = Correo and @contra = Contra
    end
GO

create procedure dbo.GetRecetaSum
as
    begin
        SET NOCOUNT ON;
        select distinct RP.Nombre,
                        RP.Correo_creador,
                        (select sum(Calcio) from receta_admin_public t1 where t1.Correo_creador = RP.Correo_creador and t1.Nombre = RP.Nombre)[Calcio],
                        (select sum(Hierro) from receta_admin_public t1 where t1.Correo_creador = RP.Correo_creador  and t1.Nombre = RP.Nombre)[Hierro],
                        (select sum(Energia) from receta_admin_public t1 where t1.Correo_creador = RP.Correo_creador  and t1.Nombre = RP.Nombre)[Energia],
                        (select sum(Sodio) from receta_admin_public t1 where t1.Correo_creador = RP.Correo_creador  and t1.Nombre = RP.Nombre)[Sodio],
                        (select sum(Carbohidratos) from receta_admin_public t1 where t1.Correo_creador = RP.Correo_creador  and t1.Nombre = RP.Nombre)[Carbohidratos],
                        (select sum(Proteina) from receta_admin_public t1 where t1.Correo_creador = RP.Correo_creador  and t1.Nombre = RP.Nombre)[Proteina],
                        (select sum(Vitaminas) from receta_admin_public t1 where t1.Correo_creador = RP.Correo_creador  and t1.Nombre = RP.Nombre)[Vitaminas]
        from receta_admin_public RP where RP.Aprobado != 1;
    end
go