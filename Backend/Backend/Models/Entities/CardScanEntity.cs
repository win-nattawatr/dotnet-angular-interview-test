using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Entities;

public class CardScanEntity : BaseEmployee
{
    [Required]
    public DateTime Clock { get; set; }
}