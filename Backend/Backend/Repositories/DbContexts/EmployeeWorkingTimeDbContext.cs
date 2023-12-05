using Backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.DbContexts;

public class EmployeeWorkingTimeDbContext(DbContextOptions<EmployeeWorkingTimeDbContext> options) : DbContext(options)
{
    public DbSet<CardScanEntity> CardScans { get; set; }
    public DbSet<WorkScheduleEntity> WorkSchedules { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        OnCardScanEntityModelCreating(modelBuilder);
        OnWorkScheduleEntityModelCreating(modelBuilder);
    }

    private static void OnCardScanEntityModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CardScanEntity>().HasData(DefaultCardScanEntities);
    }

    private static void OnWorkScheduleEntityModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WorkScheduleEntity>().HasData(DefaultWorkscheduleEntities);
    }

    private static readonly List<CardScanEntity> DefaultCardScanEntities = [
        new CardScanEntity { Id = 1, EmployeeId = "000000001", Clock = DateTime.ParseExact("01/01/2012 07:00:00", "dd/MM/yyyy HH:mm:ss", null) },
        new CardScanEntity { Id = 2, EmployeeId = "000000001", Clock = DateTime.ParseExact("01/01/2012 12:00:00", "dd/MM/yyyy HH:mm:ss", null) },
        new CardScanEntity { Id = 3, EmployeeId = "000000001", Clock = DateTime.ParseExact("01/01/2012 17:30:00", "dd/MM/yyyy HH:mm:ss", null) },
        new CardScanEntity { Id = 4, EmployeeId = "000000002", Clock = DateTime.ParseExact("01/01/2012 08:40:00", "dd/MM/yyyy HH:mm:ss", null) },
        new CardScanEntity { Id = 5, EmployeeId = "000000002", Clock = DateTime.ParseExact("01/01/2012 21:00:00", "dd/MM/yyyy HH:mm:ss", null) },
        new CardScanEntity { Id = 6, EmployeeId = "000000001", Clock = DateTime.ParseExact("02/01/2012 01:00:00", "dd/MM/yyyy HH:mm:ss", null) },
        new CardScanEntity { Id = 7, EmployeeId = "000000001", Clock = DateTime.ParseExact("02/01/2012 05:30:00", "dd/MM/yyyy HH:mm:ss", null) },
        new CardScanEntity { Id = 8, EmployeeId = "000000001", Clock = DateTime.ParseExact("02/01/2012 18:00:00", "dd/MM/yyyy HH:mm:ss", null) },
        new CardScanEntity { Id = 9, EmployeeId = "000000001", Clock = DateTime.ParseExact("02/01/2012 22:30:00", "dd/MM/yyyy HH:mm:ss", null) },
        new CardScanEntity { Id = 10, EmployeeId = "000000002", Clock = DateTime.ParseExact("02/01/2012 04:00:00", "dd/MM/yyyy HH:mm:ss", null) },
        new CardScanEntity { Id = 11, EmployeeId = "000000002", Clock = DateTime.ParseExact("02/01/2012 20:00:00", "dd/MM/yyyy HH:mm:ss", null) }
    ];

    private static readonly List<WorkScheduleEntity> DefaultWorkscheduleEntities = [
        new WorkScheduleEntity {
            Id = 1,
            EmployeeId = "000000001",
            WorkDate = DateTime.ParseExact("01/01/2012", "dd/MM/yyyy", null),
            BeginTime = DateTime.ParseExact("01/01/2012 08:00:00", "dd/MM/yyyy HH:mm:ss", null),
            EndTime = DateTime.ParseExact("01/01/2012 17:00:00", "dd/MM/yyyy HH:mm:ss", null)
        },
        new WorkScheduleEntity {
            Id = 2,
            EmployeeId = "000000001",
            WorkDate = DateTime.ParseExact("02/01/2012", "dd/MM/yyyy", null),
            BeginTime = DateTime.ParseExact("02/01/2012 08:00:00", "dd/MM/yyyy HH:mm:ss", null),
            EndTime = DateTime.ParseExact("02/01/2012 17:00:00", "dd/MM/yyyy HH:mm:ss", null)
        },
        new WorkScheduleEntity {
            Id = 3,
            EmployeeId = "000000002",
            WorkDate = DateTime.ParseExact("01/01/2012", "dd/MM/yyyy", null),
            BeginTime = DateTime.ParseExact("01/01/2012 10:00:00", "dd/MM/yyyy HH:mm:ss", null),
            EndTime = DateTime.ParseExact("01/01/2012 20:00:00", "dd/MM/yyyy HH:mm:ss", null)
        },
        new WorkScheduleEntity {
            Id = 4,
            EmployeeId = "000000002",
            WorkDate = DateTime.ParseExact("02/01/2012", "dd/MM/yyyy", null),
            BeginTime = DateTime.ParseExact("02/01/2012 10:00:00", "dd/MM/yyyy HH:mm:ss", null),
            EndTime = DateTime.ParseExact("02/01/2012 20:00:00", "dd/MM/yyyy HH:mm:ss", null)
        },
    ];
}