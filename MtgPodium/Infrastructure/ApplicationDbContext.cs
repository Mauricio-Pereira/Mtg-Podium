using Microsoft.EntityFrameworkCore;
using MtgPodium.Models;
using MtgPodium.Models.Entities;

namespace MtgPodium.Infrastructure;

public class ApplicationDbContext : DbContext
{
    //Os DbSet's são propriedades que representam as tabelas do banco de dados
    public DbSet<Format> Formats { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<PlayerDeck> PlayerDecks { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<Ranking> Rankings { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurações para Value Objects como Owned Types
        modelBuilder.Entity<Event>().OwnsOne(e => e.Date);
        modelBuilder.Entity<Event>().OwnsOne(e => e.Location);
        modelBuilder.Entity<Card>().OwnsOne(c => c.Price);
 
        // Configurações adicionais (chaves primárias, relacionamentos, etc.)
 
        // Chamada do método Seed para adicionar dados iniciais
        SeedData(modelBuilder);
    }
 
    private void SeedData(ModelBuilder modelBuilder)
    {
        // Adicionando dados iniciais para Format
        modelBuilder.Entity<Format>().HasData(
            new Format { Id = 1, Name = "Standard" },
            new Format { Id = 2, Name = "Pioneer" },
            new Format { Id = 3, Name = "Modern" },
            new Format { Id = 4, Name = "Legacy" },
            new Format { Id = 5, Name = "Vintage" },
            new Format { Id = 6, Name = "Pauper" },
            new Format { Id = 7, Name = "Commander" }
        );
 
        // Você pode adicionar mais dados iniciais para outras entidades conforme necessário
    }


}