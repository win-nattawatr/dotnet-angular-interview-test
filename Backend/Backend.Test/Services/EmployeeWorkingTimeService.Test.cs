namespace Backend.Test.Services;

using Backend.Repositories;
using Backend.Services;
using Moq;

public class EmployeeWorkingTimeServiceTest
{
    [Fact]
    public void GetEmployeeWorkScanByLinQ_ShouldReturnResult()
    {
        var mockEmployeeWorkingTimeRepository = new Mock<IEmployeeWorkingTimeRepository>();
        mockEmployeeWorkingTimeRepository
            .Setup(service => service.GetEmployeeWorkScanByLinQ())
            .Returns([]);

        var service = new EmployeeWorkingTimeService(mockEmployeeWorkingTimeRepository.Object);

        var result = service.GetEmployeeWorkScanByLinQ();

        Assert.Equal(result, []);
    }

    [Fact]
    public void GetEmployeeWorkScanBySQL_ShouldReturnResult()
    {
        var mockEmployeeWorkingTimeRepository = new Mock<IEmployeeWorkingTimeRepository>();
        mockEmployeeWorkingTimeRepository
            .Setup(service => service.GetEmployeeWorkScanBySQL())
            .Returns([]);

        var service = new EmployeeWorkingTimeService(mockEmployeeWorkingTimeRepository.Object);

        var result = service.GetEmployeeWorkScanBySQL();

        Assert.Equal(result, []);
    }
}