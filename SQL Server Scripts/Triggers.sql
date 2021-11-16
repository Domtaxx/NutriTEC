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
