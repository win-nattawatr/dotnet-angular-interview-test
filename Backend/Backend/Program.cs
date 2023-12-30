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

builder.Services.AddDbContext<UserDbContext>(option =>
{
    option.UseSqlServer(configurations.GetConnectionString("APP_DB"));
});

builder.Services.AddScoped<IUserManagementService, UserManagementService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.EnsureMigrationDbContext<UserDbContext>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
