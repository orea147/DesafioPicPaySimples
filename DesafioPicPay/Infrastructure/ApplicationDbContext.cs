using DesafioPicPay.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioPicPay.Infrastructure;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Carteira> Carteiras { get; set; }
    public DbSet<Transferencia> Transferencias { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Carteira>()
            .HasIndex(c => new { c.CPFCNPJ, c.Email })
            .IsUnique();
        
        modelBuilder.Entity<Carteira>()
            .Property(c => c.Saldo)
            .HasColumnType("decimal(10,2)");

        modelBuilder.Entity<Carteira>()
            .Property(c => c.Tipo)
            .HasConversion<string>();

        modelBuilder.Entity<Transferencia>()
            .HasKey(t => t.TransactionId);

        modelBuilder.Entity<Transferencia>()
            .Property(t => t.Valor)
            .HasColumnType("decimal(10,2)");

        modelBuilder.Entity<Transferencia>()
            .HasOne(t => t.Origem)
            .WithMany()
            .HasForeignKey(t => t.OrigemId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Transferencia_Origem");

        modelBuilder.Entity<Transferencia>()
            .HasOne(t => t.Destino)
            .WithMany()
            .HasForeignKey(t => t.DestinoId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Transferencia_Destino");
    }
}
