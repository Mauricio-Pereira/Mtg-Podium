using MtgPodium.Models.Entities;
using MtgPodium.Models.Entities.ValueObjects;

namespace MtgPodium.Models;

public class Card : BaseEntity
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }
 
    public Price Price { get; set; } // Owned Type
}