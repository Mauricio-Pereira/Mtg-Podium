using System.ComponentModel.DataAnnotations;

namespace MtgPodium.Models.Entities;

public class Ranking:BaseEntity
{   
    [Required]
    public int PlayerId { get; set; }
    public Player Player { get; set; }
    [Required]
    public int EventId { get; set; }
    public Event Event { get; set; }
    public int Position { get; set; }
}