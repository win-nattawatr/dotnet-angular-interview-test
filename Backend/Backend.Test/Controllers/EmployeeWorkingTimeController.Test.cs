namespace Backend.Test.Controllers;

using Moq;
using Backend.Services;
using Backend.Controllers;
using Backend.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

public class EmployeeWorkingTimeControllerTest
{
    [Fact]
    public void GetEmployeeWorkScanByLinQ_ShouldReturnResultWith_200()
    {
        var mockEmployeeWorkingTimeService = new Mock<IEmployeeWorkingTimeService>();
        mockEmployeeWorkingTimeService.Setup(service => service.GetEmployeeWorkScanByLinQ()).Returns([]);

        var controller = new EmployeeWorkingTimeController(mockEmployeeWorkingTimeService.Object);

        var result = controller.GetEmployeeWorkScanByLinQ();

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void GetEmployeeWorkScanByLinQ_ShouldReturnErrorWith_500()
    {
        var mockEmployeeWorkingTimeService = new Mock<IEmployeeWorkingTimeService>(MockBehavior.Strict);

        var controller = new EmployeeWorkingTimeController(mockEmployeeWorkingTimeService.Object);

        var result = controller.GetEmployeeWorkScanByLinQ();

        Assert.IsType<ObjectResult>(result);

        var objResult = (ObjectResult)result;
        Assert.Equal(objResult.StatusCode, 500);
    }

    [Fact]
    public void GetEmployeeWorkScanBySQL_ShouldReturnResultWith_200()
    {
        var mockEmployeeWorkingTimeService = new Mock<IEmployeeWorkingTimeService>();
        mockEmployeeWorkingTimeService.Setup(service => service.GetEmployeeWorkScanBySQL()).Returns([]);

        var controller = new EmployeeWorkingTimeController(mockEmployeeWorkingTimeService.Object);

        var result = controller.GetEmployeeWorkScanBySQL();

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void GetEmployeeWorkScanBySQL_ShouldReturnErrorWith_500()
    {
        var mockEmployeeWorkingTimeService = new Mock<IEmployeeWorkingTimeService>(MockBehavior.Strict);

        var controller = new EmployeeWorkingTimeController(mockEmployeeWorkingTimeService.Object);

        var result = controller.GetEmployeeWorkScanBySQL();

        Assert.IsType<ObjectResult>(result);

        var objResult = (ObjectResult)result;
        Assert.Equal(objResult.StatusCode, 500);
    }
}