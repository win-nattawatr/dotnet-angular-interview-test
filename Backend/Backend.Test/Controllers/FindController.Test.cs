namespace Backend.Test;

using Moq;
using Backend.Services;
using Backend.Controllers;
using Microsoft.Extensions.Logging;
using Backend.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

public class FindControllerTest
{
    private readonly Mock<ILogger<FindController>> mockLogger = new();

    [Fact]
    public void FindCommonElements_ShouldReturnResultWith_200()
    {
        var mockFindService = new Mock<IFindService>();
        mockFindService.Setup(service => service.FindCommonElements(It.IsIn<int[]>(), It.IsIn<int[]>())).Returns(It.IsIn<int[]>());

        var controller = new FindController(mockLogger.Object, mockFindService.Object);

        var mockBody = new FindCommonElementsViewModel();

        var result = controller.FindCommonElements(mockBody);

        Assert.IsType<OkObjectResult>(result);
    }
}