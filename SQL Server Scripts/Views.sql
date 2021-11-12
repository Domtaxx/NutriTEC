create view NUTRICIONISTA_public as select Correo,Codigo,Primer_nom,Seg_nom,Primer_apellido,Seg_apellido,Fecha_nace,foto from dbo.NUTRICIONISTA;
GO
create view Client_public as select Correo, Primer_nom, Seg_nom,Primer_apellido,Seg_apellido,dbo.CLIENTE.Max_calorias,Fecha_nace,Peso,IMC,Correo_nutri from CLIENTE;
GO
create view Medida_public as select Cadera,Porcentaje_musculo,Porcentaje_grasa,Cuello,Cintura,Fecha from REGISTRO_MEDIDAS;
GO
create view Producto_public as select Codigo_barras,Descripcion,Estado,Sodio,Energia,Carbohidratos,Tamano,Vitaminas,Hierro,Calcio,Proteina From PRODUCTO;
GO