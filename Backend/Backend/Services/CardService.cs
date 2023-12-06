
using Backend.Models.ViewModels;
using Backend.Repositories;

namespace Backend.Services;

public interface ICardService
{
    Task<List<CardViewModel>> GetCards(string? searchTerm);
    Task<CardViewModel> AddCard(CardViewModel card);
}

public class CardService(ICardRepository cardRepository) : ICardService
{
    private readonly ICardRepository _cardRepository = cardRepository;

    public async Task<CardViewModel> AddCard(CardViewModel card)
    {
        return await _cardRepository.AddCard(card);
    }

    public async Task<List<CardViewModel>> GetCards(string? searchTerm)
    {
        return await _cardRepository.GetCards(searchTerm);
    }
}