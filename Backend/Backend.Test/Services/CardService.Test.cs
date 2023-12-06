namespace Backend.Test.Services;

using Backend.Models.ViewModels;
using Backend.Repositories;
using Backend.Services;
using Moq;

public class CardServiceTest
{
    [Fact]
    public async void GetCards_ShouldReturnResult()
    {
        var mockCardRepository = new Mock<ICardRepository>();
        mockCardRepository
            .Setup(service => service.GetCards(It.IsAny<string>()))
            .ReturnsAsync([]);

        var service = new CardService(mockCardRepository.Object);

        var result = await service.GetCards(null);

        Assert.Equal(result, []);
    }

    [Fact]
    public async void AddCard_ShouldReturnResult()
    {
        var mockResult = new CardViewModel
        {
            Id = 1,
            Name = "Name",
            Base64ImageContent = "Base64-Content"
        };
        var mockCardRepository = new Mock<ICardRepository>();
        mockCardRepository
            .Setup(service => service.AddCard(It.IsAny<CardViewModel>()))
            .ReturnsAsync(mockResult);

        var service = new CardService(mockCardRepository.Object);

        var result = await service.AddCard(mockResult);

        Assert.Equal(result, mockResult);
    }
}