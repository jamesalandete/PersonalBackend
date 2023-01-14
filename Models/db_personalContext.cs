using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace crud.Models
{
    public partial class db_personalContext : DbContext
    {
        public db_personalContext()
        {
        }

        public db_personalContext(DbContextOptions<db_personalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ConfigUsuario> ConfigUsuarios { get; set; } = null!;
        public virtual DbSet<GenPersonas> GenPersonas { get; set; } = null!;
        public virtual DbSet<GenTipoIdentificacion> GenTipoIdentificaciones { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("server=127.0.0.1;database=db_personal;user=sa;password=123456789");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConfigUsuario>(entity =>
            {
                entity.ToTable("config_usuarios");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Pass)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<GenPersonas>(entity =>
            {
                entity.ToTable("gen_personas");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoIndentificacion)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroIdentificacion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipoIdentificacionId)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GenTipoIdentificacion>(entity =>
            {
                entity.ToTable("gen_tipo_identificaciones");

                entity.HasIndex(e => e.Codigo, "CodigoUniqueTipoIdentificacion")
                    .IsUnique();

                entity.Property(e => e.Codigo)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
