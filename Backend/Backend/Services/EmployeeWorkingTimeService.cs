
using Backend.Models.ViewModels;
using Backend.Repositories;

namespace Backend.Services;

public interface IEmployeeWorkingTimeService
{
    List<EmployeeWorkingTimeViewModel> GetEmployeeWorkScanByLinQ();
    List<EmployeeWorkingTimeViewModel> GetEmployeeWorkScanBySQL();
}

public class EmployeeWorkingTimeService(IEmployeeWorkingTimeRepository employeeWorkingTimeRepository) : IEmployeeWorkingTimeService
{
    private readonly IEmployeeWorkingTimeRepository _employeeWorkingTimeRepository = employeeWorkingTimeRepository;
    public List<EmployeeWorkingTimeViewModel> GetEmployeeWorkScanByLinQ()
    {
        return _employeeWorkingTimeRepository.GetEmployeeWorkScanByLinQ();
    }

    public List<EmployeeWorkingTimeViewModel> GetEmployeeWorkScanBySQL()
    {
        return _employeeWorkingTimeRepository.GetEmployeeWorkScanBySQL();
    }
}