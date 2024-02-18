using CleanArchitectureBlazor.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureBlazor.Application;

public interface IAnimalContext
{
    DbSet<Animal> Animals { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
