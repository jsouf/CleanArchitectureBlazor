using CleanArchitectureBlazor.Domain.Entities;
using MediatR;

namespace CleanArchitectureBlazor.Application.UseCases.Animals.Queries;

public sealed class GetAnimalQueryHandler(IAnimalContext context) : IRequestHandler<GetAnimalQuery, Animal?>
{
    private readonly IAnimalContext _context = context;

    public async Task<Animal?> Handle(GetAnimalQuery request, CancellationToken cancellationToken)
    {
        return await _context.Animals.FindAsync(request.Id, cancellationToken);
    }
}
