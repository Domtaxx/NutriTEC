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
	Fecha date
	primary key(Correo_cliente,Fecha)
);
Create table [CLIENTE](
	Correo varchar(320),
	Contra varchar(128),
	Direccion varchar(Max),
	Primer_nom varchar(64),
	Seg_nom varchar(64),
	Primer_apellido varchar(64),
	Seg_apellido varchar(64),
	Max_calorias float,
	Fecha_nace date,
	Peso float,
	IMC float,
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
	Tipo_cobro char,
	Direccion varchar(Max),
	IMC float,
	Peso float,
	foto varchar(260),
	primary key(Correo)
);
Create Table [PLAN_ALIMENTACION](
	Nombre varchar(128),
	Correo_nutri varchar(320),
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

Alter Table [MENU]
Add Constraint Correo_nutri_MENU
Foreign key(Correo_nutri) References NUTRICIONISTA(Correo);

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
