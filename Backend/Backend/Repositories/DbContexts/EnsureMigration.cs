using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.DbContexts;

public static class EnsureMigration
{
    public static void EnsureMigrationDbContext<T>(this IApplicationBuilder app) where T : DbContext
    {
        using var scope = app.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<T>();
        context?.Database.Migrate();
        scope.Dispose();
    }
}