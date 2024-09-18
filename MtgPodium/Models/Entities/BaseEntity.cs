using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MtgPodium.Models.Entities;

public abstract class BaseEntity

{

    [Key] // Marca como chave primária

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Indica que o ID será gerado automaticamente

    public int Id { get; set; }
 
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

}
