namespace Backend.Test.Services;

using Backend.Models.ViewModels;
using Backend.Repositories;
using Backend.Test.Fixtures;

[Collection("Database collection")]
public class EmployeeWorkingTimeRepositoryTest(DatabaseFixture fixture)
{
    private readonly DatabaseFixture _fixture = fixture;

    [Fact]
    public void GetEmployeeWorkScanByLinQ_ShouldReturnValidResult()
    {
        int[] arg1 = [1, 2, 3, 4, 5];
        int[] arg2 = [3, 4, 5, 6, 7];
        var repository = new EmployeeWorkingTimeRepository(_fixture.EmployeeWorkingTimeDbContext);

        var result = repository.GetEmployeeWorkScanByLinQ();

        Assert.All(result, (item, i) =>
        {
            Assert.Equal(item.EmployeeId, GetEmployeeWorkScanExpectedResult[i].EmployeeId);
            Assert.Equal(item.WorkDate, GetEmployeeWorkScanExpectedResult[i].WorkDate);
            Assert.Equal(item.ClockIn, GetEmployeeWorkScanExpectedResult[i].ClockIn);
            Assert.Equal(item.ClockOut, GetEmployeeWorkScanExpectedResult[i].ClockOut);
        });
    }

    [Fact]
    public void GetEmployeeWorkScanBySQL_ShouldReturnValidResult()
    {
        int[] arg1 = [1, 2, 3, 4, 5];
        int[] arg2 = [3, 4, 5, 6, 7];
        var repository = new EmployeeWorkingTimeRepository(_fixture.EmployeeWorkingTimeDbContext);

        var result = repository.GetEmployeeWorkScanBySQL();

        Assert.All(result, (item, i) =>
        {
            Assert.Equal(item.EmployeeId, GetEmployeeWorkScanExpectedResult[i].EmployeeId);
            Assert.Equal(item.WorkDate, GetEmployeeWorkScanExpectedResult[i].WorkDate);
            Assert.Equal(item.ClockIn, GetEmployeeWorkScanExpectedResult[i].ClockIn);
            Assert.Equal(item.ClockOut, GetEmployeeWorkScanExpectedResult[i].ClockOut);
        });
    }

    private static readonly List<EmployeeWorkingTimeViewModel> GetEmployeeWorkScanExpectedResult = [
        new() {
            EmployeeId= "000000001",
            WorkDate = DateTime.ParseExact("01/01/2012 00:00:00", "dd/MM/yyyy HH:mm:ss", null),
            ClockIn = DateTime.ParseExact("01/01/2012 07:00:00", "dd/MM/yyyy HH:mm:ss", null),
            ClockOut = DateTime.ParseExact("01/01/2012 17:30:00", "dd/MM/yyyy HH:mm:ss", null),
        },
        new() {
            EmployeeId= "000000002",
            WorkDate = DateTime.ParseExact("01/01/2012 00:00:00", "dd/MM/yyyy HH:mm:ss", null),
            ClockIn = DateTime.ParseExact("01/01/2012 08:40:00", "dd/MM/yyyy HH:mm:ss", null),
            ClockOut = DateTime.ParseExact("01/01/2012 21:00:00", "dd/MM/yyyy HH:mm:ss", null),
        },
        new() {
            EmployeeId= "000000001",
            WorkDate = DateTime.ParseExact("02/01/2012 00:00:00", "dd/MM/yyyy HH:mm:ss", null),
            ClockIn = DateTime.ParseExact("02/01/2012 05:30:00", "dd/MM/yyyy HH:mm:ss", null),
            ClockOut = DateTime.ParseExact("02/01/2012 18:00:00", "dd/MM/yyyy HH:mm:ss", null),
        },
        new() {
            EmployeeId= "000000002",
            WorkDate = DateTime.ParseExact("02/01/2012 00:00:00", "dd/MM/yyyy HH:mm:ss", null),
            ClockIn = DateTime.ParseExact("02/01/2012 20:00:00", "dd/MM/yyyy HH:mm:ss", null),
            ClockOut = null,
        }
    ];
}