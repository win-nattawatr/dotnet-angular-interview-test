using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Entities;

public class CardEntity : BaseEntity
{
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string ImageContent { get; set; } = null!;
}