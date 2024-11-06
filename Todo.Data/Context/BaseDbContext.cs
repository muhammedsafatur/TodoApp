using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System.Reflection;

namespace Repository.Context;

public class BaseDbContext : IdentityDbContext<User, IdentityRole, string>
{
    public BaseDbContext(DbContextOptions opt) : base(opt)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Your_Connection_String_Here", // appsettings.json'dan almanız önerilir.
                options => options.MigrationsAssembly("Repository"));
        }
    }

    public DbSet<Todo> Todos { get; set; }
    public DbSet<Category> Categories { get; set; }
}
