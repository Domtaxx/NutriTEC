using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NutriTEC_rest.SQL_Model.Models;

#nullable disable

namespace NutriTEC_rest.DB_Context
{
    public partial class NutriTECContext : DbContext
    {
        public NutriTECContext()
        {
        }

        public NutriTECContext(DbContextOptions<NutriTECContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrador> Administradors { get; set; }
        public virtual DbSet<ClientPublic> ClientPublics { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<ClientePlan> ClientePlans { get; set; }
        public virtual DbSet<ClienteProducto> ClienteProductos { get; set; }
        public virtual DbSet<ClienteProductoPublic> ClienteProductoPublics { get; set; }
        public virtual DbSet<ClienteRecetum> ClienteReceta { get; set; }
        public virtual DbSet<MedidaPublic> MedidaPublics { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuProducto> MenuProductos { get; set; }
        public virtual DbSet<MenuRecetum> MenuReceta { get; set; }
        public virtual DbSet<NutricionistaPublic> NutricionistaPublics { get; set; }
        public virtual DbSet<Nutricionistum> Nutricionista { get; set; }
        public virtual DbSet<PlanAlimentacion> PlanAlimentacions { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<ProductoPublic> ProductoPublics { get; set; }
        public virtual DbSet<RecetaProducto> RecetaProductos { get; set; }
        public virtual DbSet<RecetaPublic> RecetaPublics { get; set; }
        public virtual DbSet<Recetum> Receta { get; set; }
        public virtual DbSet<RegistroMedida> RegistroMedidas { get; set; }
        public virtual DbSet<ReporteCobro> ReporteCobros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:nutritec.database.windows.net,1433;Initial Catalog=NUTRITECSQLDB;Persist Security Info=False;User ID=nutritec_admin;Password=5cFUGb4C;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.HasKey(e => e.Correo)
                    .HasName("PK__ADMINIST__60695A1887541B2A");

                entity.ToTable("ADMINISTRADOR");

                entity.Property(e => e.Correo)
                    .HasMaxLength(320)
                    .IsUnicode(false);

                entity.Property(e => e.Contra)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClientPublic>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Client_public");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(320)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoNutri)
                    .HasMaxLength(320)
                    .IsUnicode(false)
                    .HasColumnName("Correo_nutri");

                entity.Property(e => e.FechaNace)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_nace");

                entity.Property(e => e.Imc).HasColumnName("IMC");

                entity.Property(e => e.MaxCalorias).HasColumnName("Max_calorias");

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("Primer_apellido");

                entity.Property(e => e.PrimerNom)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("Primer_nom");

                entity.Property(e => e.SegApellido)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("Seg_apellido");

                entity.Property(e => e.SegNom)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("Seg_nom");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Correo)
                    .HasName("PK__CLIENTE__60695A1874D0ED21");

                entity.ToTable("CLIENTE");

                entity.Property(e => e.Correo)
                    .HasMaxLength(320)
                    .IsUnicode(false);

                entity.Property(e => e.Contra)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoNutri)
                    .HasMaxLength(320)
                    .IsUnicode(false)
                    .HasColumnName("Correo_nutri");

                entity.Property(e => e.Direccion).IsUnicode(false);

                entity.Property(e => e.FechaNace)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_nace");

                entity.Property(e => e.Imc).HasColumnName("IMC");

                entity.Property(e => e.MaxCalorias).HasColumnName("Max_calorias");

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("Primer_apellido");

                entity.Property(e => e.PrimerNom)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("Primer_nom");

                entity.Property(e => e.SegApellido)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("Seg_apellido");

                entity.Property(e => e.SegNom)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("Seg_nom");

                entity.HasOne(d => d.CorreoNutriNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.CorreoNutri)
                    .HasConstraintName("client_nutri_CLIENT");
            });

            modelBuilder.Entity<ClientePlan>(entity =>
            {
                entity.HasKey(e => new { e.NombrePlan, e.CorreoCliente, e.Inicio, e.Final })
                    .HasName("PK__CLIENTE___C410ED0BF19A191B");

                entity.ToTable("CLIENTE_PLAN");

                entity.Property(e => e.NombrePlan)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_plan");

                entity.Property(e => e.CorreoCliente)
                    .HasMaxLength(320)
                    .IsUnicode(false)
                    .HasColumnName("Correo_cliente");

                entity.Property(e => e.Inicio).HasColumnType("date");

                entity.Property(e => e.Final).HasColumnType("date");

                entity.HasOne(d => d.CorreoClienteNavigation)
                    .WithMany(p => p.ClientePlans)
                    .HasForeignKey(d => d.CorreoCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("correo_cliente_CLIENTE_PLAN");

                entity.HasOne(d => d.NombrePlanNavigation)
                    .WithMany(p => p.ClientePlans)
                    .HasForeignKey(d => d.NombrePlan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nombre_plan_CLIENTE_PLAN");
            });

            modelBuilder.Entity<ClienteProducto>(entity =>
            {
                entity.HasKey(e => new { e.CodigoBarras, e.CorreoCliente, e.Fecha, e.Tiempo })
                    .HasName("PK__CLIENTE___C5F30673053A20DD");

                entity.ToTable("CLIENTE_PRODUCTO");

                entity.Property(e => e.CodigoBarras)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("Codigo_barras");

                entity.Property(e => e.CorreoCliente)
                    .HasMaxLength(320)
                    .IsUnicode(false)
                    .HasColumnName("Correo_cliente");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Tiempo)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoBarrasNavigation)
                    .WithMany(p => p.ClienteProductos)
                    .HasForeignKey(d => d.CodigoBarras)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("codigo_barras_CLIENTE_PRODUCTO");

                entity.HasOne(d => d.CorreoClienteNavigation)
                    .WithMany(p => p.ClienteProductos)
                    .HasForeignKey(d => d.CorreoCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("correo_cliente_CLIENTE_PRODUCTO");
            });

            modelBuilder.Entity<ClienteProductoPublic>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Cliente_producto_public");

                entity.Property(e => e.CodigoBarras)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("Codigo_barras");

                entity.Property(e => e.CorreoCliente)
                    .IsRequired()
                    .HasMaxLength(320)
                    .IsUnicode(false)
                    .HasColumnName("Correo_cliente");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Tiempo)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClienteRecetum>(entity =>
            {
                entity.HasKey(e => new { e.NombreReceta, e.CorreoCreador, e.CorreoCliente, e.Fecha, e.Tiempo })
                    .HasName("PK__CLIENTE___3AD850D4FCC10282");

                entity.ToTable("CLIENTE_RECETA");

                entity.Property(e => e.NombreReceta)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_receta");

                entity.Property(e => e.CorreoCreador)
                    .HasMaxLength(320)
                    .IsUnicode(false)
                    .HasColumnName("Correo_creador");

                entity.Property(e => e.CorreoCliente)
                    .HasMaxLength(320)
                    .IsUnicode(false)
                    .HasColumnName("Correo_cliente");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Tiempo)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.CorreoClienteNavigation)
                    .WithMany(p => p.ClienteReceta)
                    .HasForeignKey(d => d.CorreoCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("correo_cliente_CLIENTE_RECETA");

                entity.HasOne(d => d.Recetum)
                    .WithMany(p => p.ClienteReceta)
                    .HasForeignKey(d => new { d.NombreReceta, d.CorreoCreador })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("receta_CLIENTE_RECETA");
            });

            modelBuilder.Entity<MedidaPublic>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Medida_public");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Imc).HasColumnName("IMC");

                entity.Property(e => e.PorcentajeGrasa).HasColumnName("Porcentaje_grasa");

                entity.Property(e => e.PorcentajeMusculo).HasColumnName("Porcentaje_musculo");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => new { e.NombrePlanAlimentacion, e.Nombre })
                    .HasName("PK__MENU__258DD5E27FBB396F");

                entity.ToTable("MENU");

                entity.Property(e => e.NombrePlanAlimentacion)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_plan_alimentacion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.NombrePlanAlimentacionNavigation)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.NombrePlanAlimentacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nombre_plan_alimentacion_MENU");
            });

            modelBuilder.Entity<MenuProducto>(entity =>
            {
                entity.HasKey(e => new { e.NombrePlanAlimentacion, e.NombreMenu, e.CodigoBarras })
                    .HasName("PK__MENU_PRO__68E68BBB910D1E13");

                entity.ToTable("MENU_PRODUCTO");

                entity.Property(e => e.NombrePlanAlimentacion)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_plan_alimentacion");

                entity.Property(e => e.NombreMenu)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_menu");

                entity.Property(e => e.CodigoBarras)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("Codigo_barras");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.HasOne(d => d.CodigoBarrasNavigation)
                    .WithMany(p => p.MenuProductos)
                    .HasForeignKey(d => d.CodigoBarras)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("codigo_MENU_PRODUCTO");

                entity.HasOne(d => d.Nombre)
                    .WithMany(p => p.MenuProductos)
                    .HasForeignKey(d => new { d.NombrePlanAlimentacion, d.NombreMenu })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("menu_MENU_PRODUCTO");
            });

            modelBuilder.Entity<MenuRecetum>(entity =>
            {
                entity.HasKey(e => new { e.NombrePlanAlimentacion, e.NombreMenu, e.NombreReceta, e.CorreoCreador })
                    .HasName("PK__MENU_REC__81CE461A073641D7");

                entity.ToTable("MENU_RECETA");

                entity.Property(e => e.NombrePlanAlimentacion)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_plan_alimentacion");

                entity.Property(e => e.NombreMenu)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_menu");

                entity.Property(e => e.NombreReceta)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_receta");

                entity.Property(e => e.CorreoCreador)
                    .HasMaxLength(320)
                    .IsUnicode(false)
                    .HasColumnName("Correo_creador");

                entity.HasOne(d => d.Nombre)
                    .WithMany(p => p.MenuReceta)
                    .HasForeignKey(d => new { d.NombrePlanAlimentacion, d.NombreMenu })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("menu_MENU_RECETA");

                entity.HasOne(d => d.Recetum)
                    .WithMany(p => p.MenuReceta)
                    .HasForeignKey(d => new { d.NombreReceta, d.CorreoCreador })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("receta_MENU_RECETA");
            });

            modelBuilder.Entity<NutricionistaPublic>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("NUTRICIONISTA_public");

                entity.Property(e => e.Codigo).IsUnicode(false);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(320)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNace)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_nace");

                entity.Property(e => e.Foto)
                    .HasMaxLength(260)
                    .IsUnicode(false)
                    .HasColumnName("foto");

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("Primer_apellido");

                entity.Property(e => e.PrimerNom)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("Primer_nom");

                entity.Property(e => e.SegApellido)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("Seg_apellido");

                entity.Property(e => e.SegNom)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("Seg_nom");
            });

            modelBuilder.Entity<Nutricionistum>(entity =>
            {
                entity.HasKey(e => e.Correo)
                    .HasName("PK__NUTRICIO__60695A189CC3BB60");

                entity.ToTable("NUTRICIONISTA");

                entity.Property(e => e.Correo)
                    .HasMaxLength(320)
                    .IsUnicode(false);

                entity.Property(e => e.Codigo).IsUnicode(false);

                entity.Property(e => e.Contra)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion).IsUnicode(false);

                entity.Property(e => e.FechaNace)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_nace");

                entity.Property(e => e.Foto)
                    .HasMaxLength(260)
                    .IsUnicode(false)
                    .HasColumnName("foto");

                entity.Property(e => e.Imc).HasColumnName("IMC");

                entity.Property(e => e.NumTarjeta)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("Num_tarjeta");

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("Primer_apellido");

                entity.Property(e => e.PrimerNom)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("Primer_nom");

                entity.Property(e => e.SegApellido)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("Seg_apellido");

                entity.Property(e => e.SegNom)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("Seg_nom");

                entity.Property(e => e.TipoCobro)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Tipo_cobro")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<PlanAlimentacion>(entity =>
            {
                entity.HasKey(e => e.Nombre)
                    .HasName("PK__PLAN_ALI__75E3EFCE28865933");

                entity.ToTable("PLAN_ALIMENTACION");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoNutri)
                    .HasMaxLength(320)
                    .IsUnicode(false)
                    .HasColumnName("Correo_nutri");

                entity.Property(e => e.TiempoFinal)
                    .HasColumnType("date")
                    .HasColumnName("tiempo_final");

                entity.Property(e => e.TiempoInicial)
                    .HasColumnType("date")
                    .HasColumnName("tiempo_inicial");

                entity.HasOne(d => d.CorreoNutriNavigation)
                    .WithMany(p => p.PlanAlimentacions)
                    .HasForeignKey(d => d.CorreoNutri)
                    .HasConstraintName("correo_nutri_PLAN_ALIMENTACION");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.CodigoBarras)
                    .HasName("PK__PRODUCTO__4AE489C63CC11D3D");

                entity.ToTable("PRODUCTO");

                entity.Property(e => e.CodigoBarras)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("Codigo_barras");

                entity.Property(e => e.CorreoAdmin)
                    .HasMaxLength(320)
                    .IsUnicode(false)
                    .HasColumnName("Correo_admin");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasOne(d => d.CorreoAdminNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.CorreoAdmin)
                    .HasConstraintName("correo_admin_PRODUCTO");
            });

            modelBuilder.Entity<ProductoPublic>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Producto_public");

                entity.Property(e => e.CodigoBarras)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("Codigo_barras");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RecetaProducto>(entity =>
            {
                entity.HasKey(e => new { e.NombreReceta, e.CorreoCreador, e.CodigoBarras })
                    .HasName("PK__RECETA_P__A563CCA689D073AA");

                entity.ToTable("RECETA_PRODUCTO");

                entity.Property(e => e.NombreReceta)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_receta");

                entity.Property(e => e.CorreoCreador)
                    .HasMaxLength(320)
                    .IsUnicode(false)
                    .HasColumnName("Correo_creador");

                entity.Property(e => e.CodigoBarras)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("Codigo_barras");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.HasOne(d => d.CodigoBarrasNavigation)
                    .WithMany(p => p.RecetaProductos)
                    .HasForeignKey(d => d.CodigoBarras)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("codigo_barras_RECETA_PRODUCTO");

                entity.HasOne(d => d.Recetum)
                    .WithMany(p => p.RecetaProductos)
                    .HasForeignKey(d => new { d.NombreReceta, d.CorreoCreador })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("receta_RECETA_PRODUCTO");
            });

            modelBuilder.Entity<RecetaPublic>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("receta_public");

                entity.Property(e => e.CorreoCliente)
                    .IsRequired()
                    .HasMaxLength(320)
                    .IsUnicode(false)
                    .HasColumnName("Correo_cliente");

                entity.Property(e => e.CorreoCreador)
                    .IsRequired()
                    .HasMaxLength(320)
                    .IsUnicode(false)
                    .HasColumnName("Correo_creador");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Tiempo)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Recetum>(entity =>
            {
                entity.HasKey(e => new { e.Nombre, e.CorreoCreador })
                    .HasName("PK__RECETA__B62E8A81D1F4F90D");

                entity.ToTable("RECETA");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoCreador)
                    .HasMaxLength(320)
                    .IsUnicode(false)
                    .HasColumnName("Correo_creador");

                entity.Property(e => e.CorreoAdmin)
                    .HasMaxLength(320)
                    .IsUnicode(false)
                    .HasColumnName("Correo_admin");

                entity.HasOne(d => d.CorreoAdminNavigation)
                    .WithMany(p => p.Receta)
                    .HasForeignKey(d => d.CorreoAdmin)
                    .HasConstraintName("correo_admin_RECETA");

                entity.HasOne(d => d.CorreoCreadorNavigation)
                    .WithMany(p => p.Receta)
                    .HasForeignKey(d => d.CorreoCreador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("correo_creador_RECETA");
            });

            modelBuilder.Entity<RegistroMedida>(entity =>
            {
                entity.HasKey(e => new { e.CorreoCliente, e.Fecha })
                    .HasName("PK__REGISTRO__9849BD53B2C69BE9");

                entity.ToTable("REGISTRO_MEDIDAS");

                entity.Property(e => e.CorreoCliente)
                    .HasMaxLength(320)
                    .IsUnicode(false)
                    .HasColumnName("Correo_cliente");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Imc).HasColumnName("IMC");

                entity.Property(e => e.PorcentajeGrasa).HasColumnName("Porcentaje_grasa");

                entity.Property(e => e.PorcentajeMusculo).HasColumnName("Porcentaje_musculo");

                entity.HasOne(d => d.CorreoClienteNavigation)
                    .WithMany(p => p.RegistroMedida)
                    .HasForeignKey(d => d.CorreoCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cliente_correo_REGISTRO_MEDIDAS");
            });

            modelBuilder.Entity<ReporteCobro>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Reporte_cobro");

                entity.Property(e => e.Atendidos).HasColumnName("atendidos");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(320)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Descuento).HasColumnName("descuento");

                entity.Property(e => e.Pago).HasColumnName("pago");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
