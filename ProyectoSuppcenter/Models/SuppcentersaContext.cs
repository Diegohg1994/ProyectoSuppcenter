using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ProyectoSuppcenter.Models
{
    public partial class SuppcentersaContext : DbContext
    {
        public SuppcentersaContext()
        {
        }

        public SuppcentersaContext(DbContextOptions<SuppcentersaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accione> Acciones { get; set; }
        public virtual DbSet<Audiorium> Audioria { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Fabricante> Fabricantes { get; set; }
        public virtual DbSet<Licencia> Licencias { get; set; }
        public virtual DbSet<Permiso> Permisos { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Suscripcion> Suscripcions { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Suppcentersa;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Accione>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<Audiorium>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.HasOne(d => d.AccionNavigation)
                    .WithMany(p => p.Audioria)
                    .HasForeignKey(d => d.Accion)
                    .HasConstraintName("FK_Audioria_Acciones");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Audioria)
                    .HasForeignKey(d => d.Idusuario)
                    .HasConstraintName("FK_Audioria_Usuarios");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.CodigoEmpresa);

                entity.Property(e => e.CodigoEmpresa)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CedulaJuridica)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("Cedula_Juridica");

                entity.Property(e => e.Contacto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo).IsUnicode(false);

                entity.Property(e => e.IdLicencia)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Id_Licencia");

                entity.Property(e => e.NombreEm)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Em");

                entity.HasOne(d => d.IdLicenciaNavigation)
                    .WithMany(p => p.Empresas)
                    .HasForeignKey(d => d.IdLicencia)
                    .HasConstraintName("FK_Empresas_Licencias");
            });

            modelBuilder.Entity<Fabricante>(entity =>
            {
                entity.ToTable("Fabricante");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Licencia>(entity =>
            {
                entity.HasKey(e => e.CodigoLic);

                entity.Property(e => e.CodigoLic)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Descrpcion).IsUnicode(false);

                entity.Property(e => e.IdFab).HasColumnName("Id_Fab");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioCosto).HasColumnType("money");

                entity.Property(e => e.PrecioVenta).HasColumnType("money");

                entity.HasOne(d => d.IdFabNavigation)
                    .WithMany(p => p.Licencia)
                    .HasForeignKey(d => d.IdFab)
                    .HasConstraintName("FK_Licencias_Fabricante");
            });

            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.EmAg).HasColumnName("Em_ag");

                entity.Property(e => e.EmEl).HasColumnName("Em_El");

                entity.Property(e => e.EmMo).HasColumnName("Em_mo");

                entity.Property(e => e.EmVis).HasColumnName("Em_vis");

                entity.Property(e => e.LicAg).HasColumnName("Lic_ag");

                entity.Property(e => e.LicEl).HasColumnName("Lic_el");

                entity.Property(e => e.LicMo).HasColumnName("Lic_mo");

                entity.Property(e => e.LicVis).HasColumnName("Lic_vis");

                entity.Property(e => e.PorEdit).HasColumnName("Por_edit");

                entity.Property(e => e.PorVis).HasColumnName("Por_vis");

                entity.Property(e => e.SusAg).HasColumnName("Sus_ag");

                entity.Property(e => e.SusEl).HasColumnName("Sus_el");

                entity.Property(e => e.SusMo).HasColumnName("Sus_mo");

                entity.Property(e => e.SusVis).HasColumnName("Sus_vis");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Permiso)
                    .HasForeignKey<Permiso>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Permisos_Usuarios");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Suscripcion>(entity =>
            {
                entity.ToTable("Suscripcion");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CodigoEmpresa)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoLicencia)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaGenerada).HasColumnType("date");

                entity.Property(e => e.Movimiento)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.Suscripcions)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .HasConstraintName("FK_Suscripcion_Empresas");

                entity.HasOne(d => d.CodigoLicenciaNavigation)
                    .WithMany(p => p.Suscripcions)
                    .HasForeignKey(d => d.CodigoLicencia)
                    .HasConstraintName("FK_Suscripcion_Licencias");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo).IsUnicode(false);

                entity.Property(e => e.IdRol).HasColumnName("Id_Rol");

                entity.Property(e => e.Usuario1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Usuario");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK_Usuarios_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
