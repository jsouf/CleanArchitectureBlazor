using MediatR;

namespace CleanArchitectureBlazor.Application.UseCases.Animals.Commands.DeleteAnimal;

public sealed class DeleteAnimalCommandHandler(IAnimalContext context) : IRequestHandler<DeleteAnimalCommand>
{
    private readonly IAnimalContext _context = context;

    public async Task Handle(DeleteAnimalCommand request, CancellationToken cancellationToken)
    {
        // todo : Fluent Validation
        var animal = await _context.Animals.FindAsync(request.Id);

        if (animal is not null)
        {
            _context.Animals.Remove(animal);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
