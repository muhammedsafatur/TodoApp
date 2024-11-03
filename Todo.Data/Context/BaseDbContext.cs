
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Todo.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace Todo.Repository.Context;

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


    public DbSet<Models.Entities.Task> Tasks { get; set; }

    public DbSet<Category> Categories { get; set; }


}
