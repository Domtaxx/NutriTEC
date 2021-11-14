create view NUTRICIONISTA_public as select Correo,Codigo,Primer_nom,Seg_nom,Primer_apellido,Seg_apellido,Fecha_nace,foto from dbo.NUTRICIONISTA;
GO
create view Client_public as select Correo, Primer_nom, Seg_nom,Primer_apellido,Seg_apellido,dbo.CLIENTE.Max_calorias,Fecha_nace,Peso,IMC,Correo_nutri from CLIENTE;
GO
create view Medida_public as select Cadera,Porcentaje_musculo,Porcentaje_grasa,Cuello,Cintura,Fecha from REGISTRO_MEDIDAS;
GO
create view Producto_public as select Codigo_barras,Descripcion,Estado,Sodio,Energia,Carbohidratos,Tamano,Vitaminas,Hierro,Calcio,Proteina From PRODUCTO;
GO
alter view receta_public as select CR.Correo_cliente,Nombre,R.Correo_creador,Fecha,Tiempo,(Calcio*cantidad)[Calcio], (cantidad*Hierro)[Hierro],(cantidad*energia)[Energia],(cantidad*Sodio)[Sodio],(cantidad*Carbohidratos)[Carbohidratos],(cantidad*Proteina)[Proteina],(cantidad*Vitaminas)[Vitaminas],Tamano[Tamano] from RECETA R join RECETA_PRODUCTO RP on (R.Nombre = RP.Nombre_receta and R.Correo_creador = RP.Correo_creador) join PRODUCTO P on RP.Codigo_barras = P.Codigo_barras join CLIENTE_RECETA CR on RP.Nombre_receta = CR.Nombre_receta and RP.Correo_creador = CR.Correo_creador;
GO
alter view Cliente_producto_public as select CP.Correo_cliente,CP.Tiempo,CP.Fecha ,CP.Codigo_barras, Sodio, Energia, Carbohidratos, Tamano, Vitaminas, Descripcion, Hierro, Calcio, Proteina from (CLIENTE_PRODUCTO CP join PRODUCTO P on CP.codigo_barras = P.Codigo_barras);
GO

select * from receta_public where Correo_cliente = Correo_cliente;