using Backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.DbContexts;

public class EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : DbContext(options)
{
    public DbSet<CardScanEntity> CardScans { get; set; }
    public DbSet<WorkScheduleEntity> WorkSchedules { get; set; }
}