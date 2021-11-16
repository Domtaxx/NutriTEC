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