namespace MtgPodium.Models.Entities;

public class Player : BaseEntity
{
    public string Name { get; set; }
    public List<PlayerDeck> PlayerDecks { get; set; } = new List<PlayerDeck>();
}