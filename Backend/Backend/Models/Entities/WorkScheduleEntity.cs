using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Entities;

public class WorkScheduleEntity : BaseEmployee
{
    [Required]
    public DateTime WorkDate { get; set; }
    [Required]
    public DateTime BeginTime { get; set; }
    [Required]
    public DateTime EndTime { get; set; }
}