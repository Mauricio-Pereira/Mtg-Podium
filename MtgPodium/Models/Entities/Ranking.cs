namespace MtgPodium.Models.Entities;

public class Ranking:BaseEntity
{
    public Player Player { get; set; }
    public Event Event { get; set; }
    public int Position { get; set; }
}