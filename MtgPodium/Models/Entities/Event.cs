using MtgPodium.Models.Entities.ValueObjects;

namespace MtgPodium.Models.Entities;

public class Event : BaseEntity
{
    public string Name { get; set; }
    public string Level { get; set; }
 
    public EventDate Date { get; set; } // Owned Type
    public bool IsOnline { get; set; }
 
    public Location? Location { get; set; } // Owned Type, nullable for online events
    public int PlayerCount { get; set; }
    public string Source { get; set; }
 
    public Format Format { get; set; } // Association with Format
    public List<Ranking> Rankings { get; set; } = new List<Ranking>();
}