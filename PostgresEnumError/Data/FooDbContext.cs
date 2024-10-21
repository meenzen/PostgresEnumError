using Microsoft.EntityFrameworkCore;
using PostgresEnumError.Models;

namespace PostgresEnumError.Data;

public class FooDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseNpgsql(
            "Host=localhost;Database=postgres;Username=postgres;Password=postgres;",
            db => db.MapEnum<MarriageStatus>("marriage_status")
        );

    public DbSet<Person> People => Set<Person>();
}
