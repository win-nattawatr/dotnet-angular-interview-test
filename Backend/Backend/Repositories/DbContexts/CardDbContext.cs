using Backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.DbContexts;

public class CardDbContext(DbContextOptions<CardDbContext> options) : DbContext(options)
{
    public DbSet<CardEntity> Cards { get; set; }
}