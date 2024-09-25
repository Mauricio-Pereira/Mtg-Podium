using Microsoft.EntityFrameworkCore;
using MtgPodium.Models;
using MtgPodium.Models.Entities;
using MtgPodium.Models.Entities.ValueObjects;

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

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
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
        
        //Dados iniciais para Events
        // modelBuilder.Entity<Event>().HasData(
        //     new Event
        //     {
        //         Id = 1,
        //         Name = "Standard Challenge",
        //         Level = "Easy",
        //         Date = new EventDate(new DateTime(2022, 6, 1)),
        //         FormatId = 1,
        //         Source = ""
        //     }
        //     
        // );

    }
    
    

    //Dados iniciais para Events
    // modelBuilder.Entity<Event>().HasData(
    // );

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuração para Price como Owned Type em Card
        modelBuilder.Entity<Card>().OwnsOne(c => c.Price,
            price => { price.Property(p => p.Amount).HasColumnName("Price").HasColumnType("decimal(18,2)"); });

        // Configuração para Location como Owned Type em Event
        modelBuilder.Entity<Event>().OwnsOne(e => e.Location, loc =>
        {
            loc.Property(l => l.City).HasColumnName("City").HasMaxLength(100);
            loc.Property(l => l.State).HasColumnName("State").HasMaxLength(100);
            loc.Property(l => l.Country).HasColumnName("Country").HasMaxLength(100);
        });

        // Configurações adicionais para chaves estrangeiras e relacionamentos

        // Configuração da relação entre Event e Format
        modelBuilder.Entity<Event>()
            .HasOne(e => e.Format)
            .WithMany()
            .HasForeignKey(e => e.FormatId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configuração da relação entre PlayerDeck e Player
        modelBuilder.Entity<PlayerDeck>()
            .HasOne(pd => pd.Player)
            .WithMany(p => p.PlayerDecks)
            .HasForeignKey(pd => pd.PlayerId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configuração da relação entre PlayerDeck e Event
        // modelBuilder.Entity<PlayerDeck>()
        //     .HasOne(pd => pd.Event)
        //     .WithMany(e => e.PlayerDecks)
        //     .HasForeignKey(pd => pd.EventId)
        //     .OnDelete(DeleteBehavior.Cascade);

        // Configuração da relação entre Ranking e Player
        modelBuilder.Entity<Ranking>()
            .HasOne(r => r.Player)
            .WithMany()
            .HasForeignKey(r => r.PlayerId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configuração da relação entre Ranking e Event
        modelBuilder.Entity<Ranking>()
            .HasOne(r => r.Event)
            .WithMany(e => e.Rankings)
            .HasForeignKey(r => r.EventId)
            .OnDelete(DeleteBehavior.Restrict);

        // Chamada do método Seed para adicionar dados iniciais
        SeedData(modelBuilder);
    }
}