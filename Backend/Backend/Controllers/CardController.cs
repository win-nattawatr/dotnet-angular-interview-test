using Backend.Models.ViewModels;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CardController(ICardService cardService) : ControllerBase
{
    private readonly ICardService _cardService = cardService;

    [HttpGet("GetCards")]
    public async Task<IActionResult> GetCards(string? searchTerm)
    {
        try
        {
            var result = await _cardService.GetCards(searchTerm);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("AddCard")]
    public async Task<IActionResult> AddCard(CardViewModel card)
    {
        try
        {
            var result = await _cardService.AddCard(card);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
