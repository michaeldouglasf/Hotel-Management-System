using Hotel_Management_System.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_System.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Quarto> Quartos { get; set; }

        public DbSet<Hospede> Hospedes { get; set; }

        public DbSet<Reserva> Reservas { get; set; }

        public DbSet<Estadia> Estadias { get; set; }

        public DbSet<Pagamento> Pagamentos { get; set; }

        public DbSet<Fatura> Faturas { get; set; }

        public DbSet<ServicoExtra> ServicosExtras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Quarto>()
                .Property(q => q.PrecoPorNoite)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Reserva>()
                .Property(r => r.ValorTotal)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Estadia>()
                .Property(e => e.ValorTotal)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Pagamento>()
                .Property(p => p.Valor)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Fatura>()
                .Property(f => f.ValorTotal)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ServicoExtra>()
                .Property(s => s.Preco)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Hospede>()
                .HasIndex(h => h.DocumentoIdentificacao)
                .IsUnique();

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Quarto)
                .WithMany(q => q.Reservas)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Hospede)
                .WithMany(h => h.Reservas)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Estadia)
                .WithOne(e => e.Reserva)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Fatura)
                .WithOne(f => f.Reserva)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pagamento>()
                .HasOne(p => p.Reserva)
                .WithMany(r => r.Pagamentos)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}