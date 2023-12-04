using Backend.Models.ViewModels;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FindController(IFindService findService) : ControllerBase
{
    private readonly IFindService _findService = findService;

    [HttpPost("FindCommonElements")]
    public IActionResult FindCommonElements(FindCommonElementsViewModel body)
    {
        try
        {
            var result = _findService.FindCommonElements(body.FirstArray, body.SecondArray);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
