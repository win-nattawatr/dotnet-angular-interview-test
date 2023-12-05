using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeWorkingTimeController(IEmployeeWorkingTimeService employeeWorkingTimeService) : ControllerBase
{
    private readonly IEmployeeWorkingTimeService _employeeWorkingTimeService = employeeWorkingTimeService;

    [HttpGet("GetEmployeeWorkScanByLinQ")]
    public IActionResult GetEmployeeWorkScanByLinQ()
    {
        try
        {
            var result = _employeeWorkingTimeService.GetEmployeeWorkScanByLinQ();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("GetEmployeeWorkScanBySQL")]
    public IActionResult GetEmployeeWorkScanBySQL()
    {
        try
        {
            var result = _employeeWorkingTimeService.GetEmployeeWorkScanBySQL();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
