using System.ComponentModel.DataAnnotations;

namespace MtgPodium.Models.Entities;

public class PlayerDeck : BaseEntity
{
    public string Name { get; set; }
    public string Archetype { get; set; }
 
    public Player Player { get; set; } // Association with Player
    [Required]
    public int PlayerId { get; set; } // Foreign Key
    [Required]
    public int EventId { get; set; } // Foreign Key
    public Event Event { get; set; } // Association with Event
    public List<Card> Cards { get; set; } = new List<Card>();
}