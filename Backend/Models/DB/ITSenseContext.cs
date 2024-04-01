using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Backend.Models.DB
{
    public partial class ITSenseContext : DbContext
    {
        public ITSenseContext()
        {
        }

        public ITSenseContext(DbContextOptions<ITSenseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<TipoElaboracion> TipoElaboracions { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=ROOM4; Database=ITSense; Trusted_Connection=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__Estado__FBB0EDC15E83E792");

                entity.ToTable("Estado");

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Producto__09889210710ABECA");

                entity.Property(e => e.Descripcion).HasMaxLength(500);

                entity.Property(e => e.FechaEntrada)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Entrada");

                entity.Property(e => e.FechaSalida)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Salida");

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.Observacion).HasMaxLength(500);

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("FK_Estado");

                entity.HasOne(d => d.IdTipoElabNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdTipoElab)
                    .HasConstraintName("FK_TipoElab");
            });

            modelBuilder.Entity<TipoElaboracion>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("PK__Tipo_Ela__9E3A29A551C07BE4");

                entity.ToTable("Tipo_Elaboracion");

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__5B65BF979E0BD39A");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
