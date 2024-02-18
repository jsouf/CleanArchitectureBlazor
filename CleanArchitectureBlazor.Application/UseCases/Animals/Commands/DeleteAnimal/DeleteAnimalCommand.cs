using MediatR;

namespace CleanArchitectureBlazor.Application.UseCases.Animals.Commands.DeleteAnimal;

public sealed record DeleteAnimalCommand(int Id) : IRequest
{ }
