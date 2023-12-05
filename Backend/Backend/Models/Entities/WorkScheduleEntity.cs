using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Entities;

public class WorkScheduleEntity : BaseEntity
{
    [Required]
    public string EmployeeId { get; set; } = null!;
    [Required]
    public DateTime WorkDate { get; set; }
    [Required]
    public DateTime BeginTime { get; set; }
    [Required]
    public DateTime EndTime { get; set; }
}