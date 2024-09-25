using System.ComponentModel.DataAnnotations;

namespace MtgPodium.Models.Entities;

public class Player : BaseEntity
{
    [Required]
    public string Name { get; set; }
    public List<PlayerDeck> PlayerDecks { get; set; } = new List<PlayerDeck>();
}