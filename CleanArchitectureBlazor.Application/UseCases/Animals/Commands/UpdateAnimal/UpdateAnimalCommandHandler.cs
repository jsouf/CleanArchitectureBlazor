using CleanArchitectureBlazor.Domain.Entities;
using MediatR;

namespace CleanArchitectureBlazor.Application.UseCases.Animals.Commands.UpdateAnimal;

public sealed class UpdateAnimalComandHandler(IAnimalContext context) : IRequestHandler<UpdateAnimalCommand, Animal>
{
    private readonly IAnimalContext _context = context;

    public async Task<Animal> Handle(UpdateAnimalCommand request, CancellationToken cancellationToken)
    {
        // todo : Fluent Validation
        var animal = await _context.Animals.FindAsync(request.Id);

        if (animal is not null)
        {
            animal.ChangeName(request.Animal.Name);

            await _context.SaveChangesAsync(cancellationToken);
        }

        // throw if animal is null with ApplicationException
        return animal ?? request.Animal;
    }
}
