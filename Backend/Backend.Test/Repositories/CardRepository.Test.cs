namespace Backend.Test.Services;

using System.Threading.Tasks;
using Backend.Models.ViewModels;
using Backend.Repositories;
using Backend.Test.Fixtures;

[Collection("Database collection")]
public class CardRepositoryTest(DatabaseFixture fixture)
{
    private readonly DatabaseFixture _fixture = fixture;

    [Fact]
    public async void AddCard_ShouldReturnInsertedData()
    {
        var repository = new CardRepository(_fixture.CardDbContext);

        var card = new CardViewModel
        {
            Name = "Name 1",
            Base64ImageContent = "Base64-Content"
        };
        var result = await repository.AddCard(card);

        Assert.Equal(card.Name, result.Name);
        Assert.Equal(card.Base64ImageContent, result.Base64ImageContent);
        Assert.True(result.Id > 0);

        var removeCard = _fixture.CardDbContext.Cards.Where(e => e.Id == result.Id).FirstOrDefault();
        if (removeCard != null)
        {
            _fixture.CardDbContext.Remove(removeCard);
            await _fixture.CardDbContext.SaveChangesAsync();
        }
    }

    [Fact]
    public async Task GetCards_ShouldReturnResultAsync()
    {
        var repository = new CardRepository(_fixture.CardDbContext);

        var card = new CardViewModel
        {
            Name = "Name 1",
            Base64ImageContent = "Base64-Content"
        };
        var tempCard = await repository.AddCard(card);

        var result = await repository.GetCards(null);

        Assert.Contains(result, item => item.Id == tempCard.Id);

        result = await repository.GetCards("Test");

        Assert.DoesNotContain(result, item => item.Id == tempCard.Id);

        var removeCard = _fixture.CardDbContext.Cards.Where(e => e.Id == tempCard.Id).FirstOrDefault();
        if (removeCard != null)
        {
            _fixture.CardDbContext.Remove(removeCard);
            await _fixture.CardDbContext.SaveChangesAsync();
        }
    }
}