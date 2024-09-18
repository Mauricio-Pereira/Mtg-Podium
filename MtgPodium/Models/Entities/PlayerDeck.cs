namespace MtgPodium.Models.Entities;

public class PlayerDeck : BaseEntity
{
    public string Name { get; set; }
    public string Archetype { get; set; }
 
    public Player Player { get; set; } // Association with Player
    public Event Event { get; set; } // Association with Event
    public List<Card> Cards { get; set; } = new List<Card>();
}