﻿insert into NUTRICIONISTA
	(Correo,Contra,Codigo,Primer_nom,Seg_nom,Primer_apellido,Seg_apellido,Num_tarjeta,Fecha_nace,Tipo_cobro,Direccion,IMC,Peso,foto)
values('Lau01@gmail.com','58907c27b5ac1ad7289a6a56657b9e90','3996404838','Laura','Susana','Torres','Acosta','1862698798741876','1983-06-05','a','Casa #180 Residencial Casas Bonitas,Cartago, Cartago',21,68,'‪D:\NutriTEC_images\Lau01@gmail.com.png');
insert into NUTRICIONISTA
	(Correo,Contra,Codigo,Primer_nom,Seg_nom,Primer_apellido,Seg_apellido,Num_tarjeta,Fecha_nace,Tipo_cobro,Direccion,IMC,Peso,foto)
values('Pablo02@gmail.com','2e6edb52fa0ea8167a5a621d31937c41','3996404839','Pablo','Felipe','Mendez','Quesada','1962698798694876','1982-06-09','a','Casa #181 Residencial Casas Bonitas,Cartago, Cartago',21.5,78,'‪D:\NutriTEC_images\Pablo02@gmail.com.png');
insert into NUTRICIONISTA
	(Correo,Contra,Codigo,Primer_nom,Seg_nom,Primer_apellido,Seg_apellido,Num_tarjeta,Fecha_nace,Tipo_cobro,Direccion,IMC,Peso,foto)
values('Fernando03@gmail.com','24dc248af86c07e84209fd75f2dfa091','2396403836','Fernando','Felipe','Quesada','Arce','1962693168694876','1972-02-01','b','Casa #182 Residencial Casas Bonitas,Cartago, Cartago',19.7,68,'‪D:\NutriTEC_images\Fernando03@gmail.com.png');

insert into ADMINISTRADOR(Correo,Contra)values('Admin1@gmail.com','e64b78fc3bc91bcbc7dc232ba8ec59e0');
insert into ADMINISTRADOR(Correo,Contra)values('Admin2@gmail.com','e64b78fc3bc91bcbc7dc232ba8ec59e0');
insert into ADMINISTRADOR(Correo,Contra)values('Admin3@gmail.com','e64b78fc3bc91bcbc7dc232ba8ec59e0');

insert into CLIENTE
	(Correo,Contra,Direccion,Primer_nom,Seg_nom,Primer_apellido,Seg_apellido,Max_calorias,Fecha_nace,Peso,IMC,Correo_nutri)
values('mangel12412@gmail.com','59bc0dd33d4a37452c1b5bf19196aeef','Casa #160 Residencial Casas Bonitas,Cartago, Cartago','Miguel','Angel','Calderon','Torres',4500,'2000-03-05',78,21.8,'Lau01@gmail.com');
insert into CLIENTE
	(Correo,Contra,Direccion,Primer_nom,Seg_nom,Primer_apellido,Seg_apellido,Max_calorias,Fecha_nace,Peso,IMC,Correo_nutri)
values('manuel0123@gmail.com','8fc1d6a987a35725bc67e42a45b46d81','Casa #161 Residencial Casas Bonitas,Cartago, Cartago','Manuel','','Arce','Quesada',3000,'1990-05-09',88,24,'Pablo02@gmail.com');
insert into CLIENTE
	(Correo,Contra,Direccion,Primer_nom,Seg_nom,Primer_apellido,Seg_apellido,Max_calorias,Fecha_nace,Peso,IMC,Correo_nutri)
values('Antonio40123@gmail.com','bcb7e9e73ce1771a23777b05bd8d3ea9','Casa #162 Residencial Casas Bonitas,Cartago, Cartago','Antonio','Manuel','Castro','Medina',3000,'1998-09-08',98,24.5,'Fernando03@gmail.com');

insert into PRODUCTO
	(Codigo_barras,Sodio,Energia,Carbohidratos,Tamano,Vitaminas,Descripcion,Estado,Hierro,Calcio,Proteina,Correo_admin)
values('7501000608249',2.5,100,70.8,1024,4,'GALLETA SALADITA GAMESA 1024GR','Disponible',2,3.1,0.4,'Admin1@gmail.com');
insert into PRODUCTO
	(Codigo_barras,Sodio,Energia,Carbohidratos,Tamano,Vitaminas,Descripcion,Estado,Hierro,Calcio,Proteina,Correo_admin)
values('7501000608058',2.5,100,70.8,450,4,'GALLETA SALADITA GAMESA 450GR','Disponible',2,3.1,0.4,'Admin2@gmail.com');
insert into PRODUCTO
	(Codigo_barras,Sodio,Energia,Carbohidratos,Tamano,Vitaminas,Descripcion,Estado,Hierro,Calcio,Proteina,Correo_admin)
values('7501000664221',2.5,100,70.8,186,4,'GALLETA SALADITA GAMESA 186GR','Agotado',2,3.1,0.4,'Admin1@gmail.com');

insert into RECETA(Nombre,Correo_admin)values('Galletas Sabrosas','Admin1@gmail.com');
insert into RECETA(Nombre,Correo_admin)values('Galletas Exquisitas','Admin2@gmail.com');
insert into RECETA(Nombre,Correo_admin)values('Galletas Increibles','Admin1@gmail.com');

insert into REGISTRO_MEDIDAS(Correo_cliente,Cadera,Porcentaje_grasa,Porcentaje_musculo,Cuello,Cintura,Fecha)
values('mangel12412@gmail.com',60,19,40,35,63,'2020-05-07');
insert into REGISTRO_MEDIDAS(Correo_cliente,Cadera,Porcentaje_grasa,Porcentaje_musculo,Cuello,Cintura,Fecha)
values('Antonio40123@gmail.com',72,23,44,38,75,'2020-08-10');
insert into REGISTRO_MEDIDAS(Correo_cliente,Cadera,Porcentaje_grasa,Porcentaje_musculo,Cuello,Cintura,Fecha)
values('manuel0123@gmail.com',62,20,42,36,67,'2020-04-12');

insert into PLAN_ALIMENTACION(Nombre,Correo_nutri)values('Plan de alimentacion Antonio','Fernando03@gmail.com');
insert into PLAN_ALIMENTACION(Nombre,Correo_nutri)values('Plan de alimentacion Manuel','Pablo02@gmail.com');
insert into PLAN_ALIMENTACION(Nombre,Correo_nutri)values('Plan de alimentacion Miguel','Lau01@gmail.com');

insert into MENU(Nombre_plan_alimentacion,Nombre,Correo_nutri)values('Plan de alimentacion Antonio','Menu#1 Antonio','Fernando03@gmail.com');
insert into MENU(Nombre_plan_alimentacion,Correo_nutri,Nombre)values('Plan de alimentacion Manuel','Pablo02@gmail.com','Menu#1 Manuel');
insert into MENU(Nombre_plan_alimentacion,Correo_nutri,Nombre)values('Plan de alimentacion Miguel','Lau01@gmail.com','Menu#1 Miguel');

insert into MENU_PRODUCTO(Nombre_plan_alimentacion,Nombre_menu,Codigo_barras)
values('Plan de alimentacion Antonio','Menu#1 Antonio','7501000608249');
insert into MENU_PRODUCTO(Nombre_plan_alimentacion,Nombre_menu,Codigo_barras)
values('Plan de alimentacion Antonio','Menu#1 Antonio','7501000608058');
insert into MENU_PRODUCTO(Nombre_plan_alimentacion,Nombre_menu,Codigo_barras)
values('Plan de alimentacion Manuel','Menu#1 Manuel','7501000664221');
insert into MENU_PRODUCTO(Nombre_plan_alimentacion,Nombre_menu,Codigo_barras)
values('Plan de alimentacion Manuel','Menu#1 Manuel','7501000608058');
insert into MENU_PRODUCTO(Nombre_plan_alimentacion,Nombre_menu,Codigo_barras)
values('Plan de alimentacion Miguel','Menu#1 Miguel','7501000608249');
insert into MENU_PRODUCTO(Nombre_plan_alimentacion,Nombre_menu,Codigo_barras)
values('Plan de alimentacion Miguel','Menu#1 Miguel','7501000664221');

insert into MENU_RECETA(Nombre_plan_alimentacion,Nombre_menu,Nombre_receta)values('Plan de alimentacion Antonio','Menu#1 Antonio','Galletas Sabrosas');
insert into MENU_RECETA(Nombre_plan_alimentacion,Nombre_menu,Nombre_receta)values('Plan de alimentacion Manuel','Menu#1 Manuel','Galletas Sabrosas');
insert into MENU_RECETA(Nombre_plan_alimentacion,Nombre_menu,Nombre_receta)values('Plan de alimentacion Manuel','Menu#1 Manuel','Galletas Exquisitas');
insert into MENU_RECETA(Nombre_plan_alimentacion,Nombre_menu,Nombre_receta)values('Plan de alimentacion Miguel','Menu#1 Miguel','Galletas Increibles');

insert into CLIENTE_PLAN(Nombre_plan,Correo_cliente,Inicio,Final)values('Plan de alimentacion Antonio','Antonio40123@gmail.com','2021-03-10','2021-12-10');
insert into CLIENTE_PLAN(Nombre_plan,Correo_cliente,Inicio,Final)values('Plan de alimentacion Manuel','manuel0123@gmail.com','2021-04-10','2022-01-10');
insert into CLIENTE_PLAN(Nombre_plan,Correo_cliente,Inicio,Final)values('Plan de alimentacion Miguel','mangel12412@gmail.com','2021-01-10','2021-12-10');

insert into CLIENTE_PRODUCTO(Codigo_barras,Correo_cliente,Fecha,Tiempo)values('7501000608249','Antonio40123@gmail.com','2021-11-09','Desayuno');
insert into CLIENTE_PRODUCTO(Codigo_barras,Correo_cliente,Fecha,Tiempo)values('7501000608058','Antonio40123@gmail.com','2021-11-09','Desayuno');
insert into CLIENTE_PRODUCTO(Codigo_barras,Correo_cliente,Fecha,Tiempo)values('7501000664221','manuel0123@gmail.com','2021-11-09','Desayuno');
insert into CLIENTE_PRODUCTO(Codigo_barras,Correo_cliente,Fecha,Tiempo)values('7501000608058','manuel0123@gmail.com','2021-11-09','Desayuno');
insert into CLIENTE_PRODUCTO(Codigo_barras,Correo_cliente,Fecha,Tiempo)values('7501000608249','mangel12412@gmail.com','2021-11-09','Desayuno');
insert into CLIENTE_PRODUCTO(Codigo_barras,Correo_cliente,Fecha,Tiempo)values('7501000664221','mangel12412@gmail.com','2021-11-09','Desayuno');

insert into CLIENTE_RECETA(Nombre_receta,Correo_cliente,Fecha,Tiempo)values('Galletas Exquisitas','manuel0123@gmail.com','2021-11-09','Desayuno');
insert into CLIENTE_RECETA(Nombre_receta,Correo_cliente,Fecha,Tiempo)values('Galletas Sabrosas','Antonio40123@gmail.com','2021-11-09','Desayuno');
insert into CLIENTE_RECETA(Nombre_receta,Correo_cliente,Fecha,Tiempo)values('Galletas Increibles','mangel12412@gmail.com','2021-11-09','Desayuno');