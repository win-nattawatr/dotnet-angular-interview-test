using Backend.Repositories;
using Backend.Repositories.DbContexts;
using Backend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configurations = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EmployeeWorkingTimeDbContext>(option =>
{
    option.UseSqlServer(configurations.GetConnectionString("EMPLOYEE_WORKING_TIME_DB"));
});

builder.Services.AddDbContext<CardDbContext>(option =>
{
    option.UseSqlServer(configurations.GetConnectionString("CARD_DB"));
});

builder.Services.AddSingleton<IFindService, FindService>();
builder.Services.AddScoped<IEmployeeWorkingTimeService, EmployeeWorkingTimeService>();

builder.Services.AddScoped<IEmployeeWorkingTimeRepository, EmployeeWorkingTimeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.EnsureMigrationDbContext<EmployeeWorkingTimeDbContext>();
app.EnsureMigrationDbContext<CardDbContext>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
