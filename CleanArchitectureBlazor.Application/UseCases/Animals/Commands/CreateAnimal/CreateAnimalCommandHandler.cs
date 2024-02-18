using CleanArchitectureBlazor.Domain.Entities;
using MediatR;

namespace CleanArchitectureBlazor.Application.UseCases.Animals.Commands.CreateAnimal;

public sealed class CreateAnimalCommandHandler(IAnimalContext context) : IRequestHandler<CreateAnimalCommand, Animal>
{
    private readonly IAnimalContext _context = context;

    public async Task<Animal> Handle(CreateAnimalCommand request, CancellationToken cancellationToken)
    {
        _context.Animals.Add(request.Animal);
        await _context.SaveChangesAsync(cancellationToken);

        return request.Animal;
    }
}
