using Backend.Models.ViewModels;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserManagementController(IUserManagementService userManagementService) : ControllerBase
{
    private readonly IUserManagementService _userManagementService = userManagementService;

    [HttpGet("GetUsers")]
    public async Task<IActionResult> GetUsers(int? size, int? page)
    {
        try
        {
            if (size.HasValue && size.Value < 0)
            {
                throw new Exception("'size' must be positive integer.");
            }

            if (page.HasValue && page.Value < 0)
            {
                throw new Exception("'page' must be positive integer.");
            }

            var result = await _userManagementService.GetUsers(size, page);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(UserDto userDto)
    {
        try
        {
            var result = await _userManagementService.AddUser(userDto);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("Update/{hn}")]
    public async Task<IActionResult> Update(string hn, UserDto userDto)
    {
        try
        {
            var result = await _userManagementService.UpdateUser(hn, userDto);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("Delete/{hn}")]
    public async Task<IActionResult> Delete(string hn)
    {
        try
        {
            await _userManagementService.DeleteUser(hn);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
