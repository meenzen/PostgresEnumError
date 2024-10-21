using Microsoft.EntityFrameworkCore;
using PostgresEnumError.Data;

FooDbContext dbContext = new();
await dbContext.Database.MigrateAsync();
