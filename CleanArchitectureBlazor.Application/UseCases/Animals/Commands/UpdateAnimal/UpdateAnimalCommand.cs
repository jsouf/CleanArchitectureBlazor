using CleanArchitectureBlazor.Domain.Entities;
using MediatR;

namespace CleanArchitectureBlazor.Application.UseCases.Animals.Commands.UpdateAnimal;

public sealed record UpdateAnimalCommand(int Id, Animal Animal) : IRequest<Animal>
{ }
