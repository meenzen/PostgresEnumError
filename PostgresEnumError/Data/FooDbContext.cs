using Microsoft.EntityFrameworkCore;
using PostgresEnumError.Models;

namespace PostgresEnumError.Data;

public class FooDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseNpgsql(
            "Host=localhost;Database=postgres;Username=postgres;Password=postgres;",
            db => { }
        );

    public DbSet<Person> People => Set<Person>();
}
