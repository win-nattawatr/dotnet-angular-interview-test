using Backend.Models.Entities;
using Backend.Models.ViewModels;
using Backend.Repositories.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public interface ICardRepository
{
    Task<List<CardViewModel>> GetCards(string? searchTerm);
    Task<CardViewModel> AddCard(CardViewModel card);
}

public class CardRepository(CardDbContext cardDbContext) : ICardRepository
{
    private readonly CardDbContext _cardDbContext = cardDbContext;

    public async Task<CardViewModel> AddCard(CardViewModel card)
    {
        var cardEntity = new CardEntity
        {
            Name = card.Name,
            ImageContent = card.Base64ImageContent
        };

        _cardDbContext.Cards.Add(cardEntity);
        await _cardDbContext.SaveChangesAsync();

        card.Id = cardEntity.Id;

        return card;
    }

    public async Task<List<CardViewModel>> GetCards(string? searchTerm)
    {
        return await _cardDbContext.Cards
            .Where(e => string.IsNullOrEmpty(searchTerm) || e.Name.Contains(searchTerm))
            .Select(e => new CardViewModel
            {
                Id = e.Id,
                Name = e.Name,
                Base64ImageContent = e.ImageContent
            }).ToListAsync();
    }
}