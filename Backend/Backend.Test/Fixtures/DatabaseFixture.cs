using Backend.Repositories.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Backend.Test.Fixtures;

public class DatabaseFixture : IDisposable
{
    public EmployeeWorkingTimeDbContext EmployeeWorkingTimeDbContext { get; private set; }
    public CardDbContext CardDbContext { get; private set; }

    public DatabaseFixture()
    {
        var employeeWorkingTimeDbConnectionString = Environment.GetEnvironmentVariable("SQLCONNSTR_EMPLOYEE_WORKING_TIME_DB");
        DbContextOptionsBuilder<EmployeeWorkingTimeDbContext> employeeWorkingTimeDbContextBuilder = new();
        var employeeWorkingTimeDbContextOptions = employeeWorkingTimeDbContextBuilder.UseSqlServer(employeeWorkingTimeDbConnectionString).Options;
        EmployeeWorkingTimeDbContext = new EmployeeWorkingTimeDbContext(employeeWorkingTimeDbContextOptions);

        var cardDbConnectionString = Environment.GetEnvironmentVariable("SQLCONNSTR_CARD_DB");
        DbContextOptionsBuilder<CardDbContext> cardDbContextBuilder = new();
        var cardDbContextOptions = cardDbContextBuilder.UseSqlServer(cardDbConnectionString).Options;
        CardDbContext = new CardDbContext(cardDbContextOptions);
    }

    public void Dispose()
    {
        EmployeeWorkingTimeDbContext.Dispose();
        CardDbContext.Dispose();
        GC.SuppressFinalize(this);
    }
}

[CollectionDefinition("Database collection")]
public class DatabaseCollection : ICollectionFixture<DatabaseFixture> { }