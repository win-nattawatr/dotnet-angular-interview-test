using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Entities;

public class CardScanEntity : BaseEntity
{
    [Required]
    public string EmployeeId { get; set; } = null!;
    [Required]
    public DateTime Clock { get; set; }
}