namespace Backend.Test.Controllers;

using Moq;
using Backend.Services;
using Backend.Controllers;
using Backend.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

public class CardControllerTest
{
    [Fact]
    public async void GetCards_ShouldReturnResultWith_200()
    {
        var mockCardService = new Mock<ICardService>();
        mockCardService.Setup(service => service.GetCards(It.IsAny<string>())).ReturnsAsync(It.IsAny<List<CardViewModel>>());

        var controller = new CardController(mockCardService.Object);

        var result = await controller.GetCards(null);

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async void GetCards_ShouldReturnErrorWith_500()
    {
        var mockCardService = new Mock<ICardService>(MockBehavior.Strict);

        var controller = new CardController(mockCardService.Object);

        var result = await controller.GetCards(null);

        Assert.IsType<ObjectResult>(result);

        var objResult = (ObjectResult)result;
        Assert.Equal(objResult.StatusCode, 500);
    }

    [Fact]
    public async void AddCard_ShouldReturnResultWith_200()
    {
        var mockCardService = new Mock<ICardService>();
        mockCardService.Setup(service => service.AddCard(It.IsAny<CardViewModel>())).ReturnsAsync(It.IsAny<CardViewModel>());

        var controller = new CardController(mockCardService.Object);

        var result = await controller.AddCard(new CardViewModel());

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async void AddCard_ShouldReturnErrorWith_500()
    {
        var mockCardService = new Mock<ICardService>(MockBehavior.Strict);

        var controller = new CardController(mockCardService.Object);

        var result = await controller.AddCard(new CardViewModel());

        Assert.IsType<ObjectResult>(result);

        var objResult = (ObjectResult)result;
        Assert.Equal(objResult.StatusCode, 500);
    }
}