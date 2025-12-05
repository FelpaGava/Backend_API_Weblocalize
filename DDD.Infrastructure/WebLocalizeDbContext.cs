using Microsoft.EntityFrameworkCore;
using DDD.Domain.Entities;

namespace DDD.Infrastructure
{
    public class WebLocalizeDbContext : DbContext
    {
        public WebLocalizeDbContext(DbContextOptions<WebLocalizeDbContext> options) : base(options) { }

        public DbSet<Estado> Estados { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Local> Locais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.UFID);
                entity.Property(e => e.UFID).ValueGeneratedOnAdd();
                entity.Property(e => e.UFNOME).HasMaxLength(255);
                entity.Property(e => e.UFSIGLA).HasMaxLength(2);
                entity.Property(e => e.UFSITUACAO).HasColumnType("char(1)");
                entity.Property(e => e.UFDATACRIACAO)
                      .HasColumnType("datetime")
                      .HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.HasKey(c => c.CIDID);
                entity.Property(c => c.CIDID).ValueGeneratedOnAdd();
                entity.Property(c => c.CIDNOME).HasMaxLength(255);
                entity.Property(c => c.CIDSITUACAO).HasColumnType("char(1)");
                entity.Property(c => c.CIDDATACRIACAO)
                      .HasColumnType("datetime")
                      .HasDefaultValueSql("GETDATE()");
                entity.HasOne(c => c.Estado)
                      .WithMany(e => e.Cidades)
                      .HasForeignKey(c => c.CIDUF);
            });

            modelBuilder.Entity<Local>(entity =>
            {
                entity.HasKey(l => l.LOCID);
                entity.Property(l => l.LOCID).ValueGeneratedOnAdd();
                entity.Property(l => l.LOCNOME).HasMaxLength(100);
                entity.Property(l => l.LOCDESCRICAO).HasMaxLength(100);
                entity.Property(l => l.LOCENDERECO).HasMaxLength(100);
                entity.Property(l => l.LOCSITUACAO).HasColumnType("char(1)");
                entity.Property(l => l.LOCDATACRIACAO)
                      .HasColumnType("datetime")
                      .HasDefaultValueSql("GETDATE()");
                entity.HasOne(l => l.Cidade)
                      .WithMany(c => c.Locais)
                      .HasForeignKey(l => l.LOCCID)
                      .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(l => l.Estado)
                      .WithMany(e => e.Locais)
                      .HasForeignKey(l => l.LOCUF)
                      .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
