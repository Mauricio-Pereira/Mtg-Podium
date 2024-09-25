using System.ComponentModel.DataAnnotations;

namespace MtgPodium.Models.Entities;

public class Format: BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
}