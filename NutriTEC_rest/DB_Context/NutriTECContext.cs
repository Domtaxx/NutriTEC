using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NutriTEC_rest.SQL_Model;

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
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<ClientePlan> ClientePlans { get; set; }
        public virtual DbSet<ClienteProducto> ClienteProductos { get; set; }
        public virtual DbSet<ClienteRecetum> ClienteReceta { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuProducto> MenuProductos { get; set; }
        public virtual DbSet<MenuRecetum> MenuReceta { get; set; }
        public virtual DbSet<Nutricionistum> Nutricionista { get; set; }
        public virtual DbSet<PlanAlimentacion> PlanAlimentacions { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Recetum> Receta { get; set; }
        public virtual DbSet<RegistroMedida> RegistroMedidas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database= NutriTEC;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.HasKey(e => e.Correo)
                    .HasName("PK__ADMINIST__60695A184D24C398");

                entity.ToTable("ADMINISTRADOR");

                entity.Property(e => e.Correo)
                    .HasMaxLength(320)
                    .IsUnicode(false);

                entity.Property(e => e.Contra)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Correo)
                    .HasName("PK__CLIENTE__60695A18C794188E");

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
                    .HasName("PK__CLIENTE___C410ED0B4B06BD90");

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
                entity.HasKey(e => new { e.CodigoBarras, e.CorreoCliente, e.Nombre })
                    .HasName("PK__CLIENTE___F2A6FD763D12EC87");

                entity.ToTable("CLIENTE_PRODUCTO");

                entity.Property(e => e.CodigoBarras)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("Codigo_barras");

                entity.Property(e => e.CorreoCliente)
                    .HasMaxLength(320)
                    .IsUnicode(false)
                    .HasColumnName("Correo_cliente");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

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

            modelBuilder.Entity<ClienteRecetum>(entity =>
            {
                entity.HasKey(e => new { e.NombreReceta, e.CorreoCliente, e.Nombre })
                    .HasName("PK__CLIENTE___19A639D0417DA35D");

                entity.ToTable("CLIENTE_RECETA");

                entity.Property(e => e.NombreReceta)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_receta");

                entity.Property(e => e.CorreoCliente)
                    .HasMaxLength(320)
                    .IsUnicode(false)
                    .HasColumnName("Correo_cliente");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.HasOne(d => d.CorreoClienteNavigation)
                    .WithMany(p => p.ClienteReceta)
                    .HasForeignKey(d => d.CorreoCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("correo_cliente_CLIENTE_RECETA");

                entity.HasOne(d => d.NombreRecetaNavigation)
                    .WithMany(p => p.ClienteReceta)
                    .HasForeignKey(d => d.NombreReceta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nombre_receta_CLIENTE_RECETA");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => new { e.NombrePlanAlimentacion, e.Nombre })
                    .HasName("PK__MENU__258DD5E2786ED33E");

                entity.ToTable("MENU");

                entity.Property(e => e.NombrePlanAlimentacion)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_plan_alimentacion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoNutri)
                    .HasMaxLength(320)
                    .IsUnicode(false)
                    .HasColumnName("Correo_nutri");

                entity.HasOne(d => d.CorreoNutriNavigation)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.CorreoNutri)
                    .HasConstraintName("Correo_nutri_MENU");

                entity.HasOne(d => d.NombrePlanAlimentacionNavigation)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.NombrePlanAlimentacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nombre_plan_alimentacion_MENU");
            });

            modelBuilder.Entity<MenuProducto>(entity =>
            {
                entity.HasKey(e => new { e.NombrePlanAlimentacion, e.NombreMenu, e.CodigoBarras })
                    .HasName("PK__MENU_PRO__68E68BBB49383C12");

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
                entity.HasKey(e => new { e.NombrePlanAlimentacion, e.NombreMenu, e.NombreReceta })
                    .HasName("PK__MENU_REC__CE0D8B7FB81F7945");

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

                entity.HasOne(d => d.NombreRecetaNavigation)
                    .WithMany(p => p.MenuReceta)
                    .HasForeignKey(d => d.NombreReceta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nombre_receta_MENU_RECETA");

                entity.HasOne(d => d.Nombre)
                    .WithMany(p => p.MenuReceta)
                    .HasForeignKey(d => new { d.NombrePlanAlimentacion, d.NombreMenu })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("menu_MENU_RECETA");
            });

            modelBuilder.Entity<Nutricionistum>(entity =>
            {
                entity.HasKey(e => e.Correo)
                    .HasName("PK__NUTRICIO__60695A18119A10E4");

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
                    .HasName("PK__PLAN_ALI__75E3EFCE5E8F135A");

                entity.ToTable("PLAN_ALIMENTACION");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoNutri)
                    .HasMaxLength(320)
                    .IsUnicode(false)
                    .HasColumnName("Correo_nutri");

                entity.HasOne(d => d.CorreoNutriNavigation)
                    .WithMany(p => p.PlanAlimentacions)
                    .HasForeignKey(d => d.CorreoNutri)
                    .HasConstraintName("correo_nutri_PLAN_ALIMENTACION");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.CodigoBarras)
                    .HasName("PK__PRODUCTO__4AE489C6E2AF2483");

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

            modelBuilder.Entity<Recetum>(entity =>
            {
                entity.HasKey(e => e.Nombre)
                    .HasName("PK__RECETA__75E3EFCE8AD8E37C");

                entity.ToTable("RECETA");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoAdmin)
                    .HasMaxLength(320)
                    .IsUnicode(false)
                    .HasColumnName("Correo_admin");

                entity.HasOne(d => d.CorreoAdminNavigation)
                    .WithMany(p => p.Receta)
                    .HasForeignKey(d => d.CorreoAdmin)
                    .HasConstraintName("correo_admin_RECETA");
            });

            modelBuilder.Entity<RegistroMedida>(entity =>
            {
                entity.HasKey(e => new { e.CorreoCliente, e.Fecha })
                    .HasName("PK__REGISTRO__9849BD534718E73B");

                entity.ToTable("REGISTRO_MEDIDAS");

                entity.Property(e => e.CorreoCliente)
                    .HasMaxLength(320)
                    .IsUnicode(false)
                    .HasColumnName("Correo_cliente");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.PorcentajeGrasa).HasColumnName("Porcentaje_grasa");

                entity.Property(e => e.PorcentajeMusculo).HasColumnName("Porcentaje_musculo");

                entity.HasOne(d => d.CorreoClienteNavigation)
                    .WithMany(p => p.RegistroMedida)
                    .HasForeignKey(d => d.CorreoCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cliente_correo_REGISTRO_MEDIDAS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
