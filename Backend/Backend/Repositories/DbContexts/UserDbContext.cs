using Backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.DbContexts;

public class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        OnUserEntityModelCreating(modelBuilder);
    }

    private static void OnUserEntityModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>().HasData(DefaultUsers);
    }

    private static readonly List<UserEntity> DefaultUsers = [
        new UserEntity { Id = 1, HN = "000001", Firstname = "First 1", Lastname = "Last 1", PhoneNumber = "0123456789", Email = "mail1@mail.com" },
        new UserEntity { Id = 2, HN = "000002", Firstname = "First 2", Lastname = "Last 2", PhoneNumber = "0123456789", Email = "mail2@mail.com" },
        new UserEntity { Id = 3, HN = "000003", Firstname = "First 3", Lastname = "Last 3", PhoneNumber = "0123456789", Email = "mail3@mail.com" },
    ];
}