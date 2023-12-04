namespace Backend.Test.Controllers;

using Moq;
using Backend.Services;
using Backend.Controllers;
using Backend.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

public class FindControllerTest
{
    [Fact]
    public void FindCommonElements_ShouldReturnResultWith_200()
    {
        var mockFindService = new Mock<IFindService>();
        mockFindService.Setup(service => service.FindCommonElements(It.IsIn<int[]>(), It.IsIn<int[]>())).Returns(It.IsIn<int[]>());

        var controller = new FindController(mockFindService.Object);

        var mockBody = new FindCommonElementsViewModel();

        var result = controller.FindCommonElements(mockBody);

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void FindCommonElements_ShouldReturnErrorWith_500()
    {
        var mockFindService = new Mock<IFindService>(MockBehavior.Strict);

        var controller = new FindController(mockFindService.Object);

        var mockBody = new FindCommonElementsViewModel();

        var result = controller.FindCommonElements(mockBody);

        Assert.IsType<ObjectResult>(result);

        var objResult = (ObjectResult)result;
        Assert.Equal(objResult.StatusCode, 500);
    }
}