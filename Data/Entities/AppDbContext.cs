using Microsoft.EntityFrameworkCore;

namespace Data.Entities
{
    public partial class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuthUser> AuthUsers { get; set; } = null!;
        public virtual DbSet<GenPersona> GenPersonas { get; set; } = null!;
        public virtual DbSet<TipoIdentificacion> TipoIdentificaciones { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("server=127.0.0.1;database=DB_doubleV;user=sa;password=123456789");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthUser>(entity =>
            {
                entity.ToTable("auth_users");

                entity.Property(e => e.AddedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Pass).HasMaxLength(20);

                entity.Property(e => e.Usuario).HasMaxLength(20);
            });

            modelBuilder.Entity<GenPersona>(entity =>
            {
                entity.ToTable("gen_personas");

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Apellidos).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Identificacion).HasMaxLength(50);

                entity.Property(e => e.NombreCompleto).HasMaxLength(150);

                entity.Property(e => e.Nombres).HasMaxLength(50);

                entity.Property(e => e.NumeroIdentificacion).HasMaxLength(20);

                entity.HasOne(d => d.TipoIdentificacion)
                .WithMany()
                .HasForeignKey(d => d.TipoIdentificacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_gen_personas_tipo_identificaciones");
            });

            modelBuilder.Entity<TipoIdentificacion>(entity =>
            {
                entity.ToTable("tipo_identificaciones");

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Sigla).HasMaxLength(5);

                entity.Property(e => e.Codigo).HasMaxLength(10);

                entity.Property(e => e.Descripcion).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
