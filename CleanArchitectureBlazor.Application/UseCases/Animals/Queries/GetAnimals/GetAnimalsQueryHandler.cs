using CleanArchitectureBlazor.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureBlazor.Application.UseCases.Animals.Queries;

public sealed class GetAnimalsQueryHandler(IAnimalContext context) : IRequestHandler<GetAnimalsQuery, List<Animal>>
{
    private readonly IAnimalContext _context = context;

    public async Task<List<Animal>> Handle(GetAnimalsQuery request, CancellationToken cancellationToken)
    {
        List<Animal> animals = await _context.Animals
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return animals;
    }
}
