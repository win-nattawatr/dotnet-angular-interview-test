using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Entities;

public class BaseEmployee : BaseEntity
{
    [Required]
    public string EmployeeId { get; set; } = null!;
}