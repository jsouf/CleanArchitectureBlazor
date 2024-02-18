using System.Reflection;
using CleanArchitectureBlazor.Application;
using CleanArchitectureBlazor.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureBlazor.Infrastructure.Context;

public class AnimalContext : DbContext, IAnimalContext
{
    public AnimalContext(DbContextOptions<AnimalContext> options)
        : base(options)
    { }

    public DbSet<Animal> Animals { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
