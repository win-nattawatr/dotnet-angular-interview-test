namespace Backend.Models.ViewModels;

public class EmployeeWorkingTimeViewModel
{
    public string EmployeeId { get; set; } = null!;
    public DateTime WorkDate { get; set; }
    public DateTime ClockIn { get; set; }
    public DateTime? ClockOut { get; set; }
}