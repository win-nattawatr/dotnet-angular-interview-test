using Backend.Repositories;
using Backend.Repositories.DbContexts;
using Backend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configurations = builder.Configuration;

// Add services to the container.
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
{
    var allowedOriginValue = configurations.GetValue<string>("ALLOWED_ORIGIN");
    var allowedOrigins = allowedOriginValue != null ? allowedOriginValue.Split(',').Select(item => item.Trim()).ToArray() : [];
    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins(allowedOrigins);
}));

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
builder.Services.AddScoped<ICardService, CardService>();

builder.Services.AddScoped<IEmployeeWorkingTimeRepository, EmployeeWorkingTimeRepository>();
builder.Services.AddScoped<ICardRepository, CardRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.EnsureMigrationDbContext<EmployeeWorkingTimeDbContext>();
app.EnsureMigrationDbContext<CardDbContext>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
