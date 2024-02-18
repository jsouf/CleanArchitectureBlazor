using CleanArchitectureBlazor.Domain.Entities;
using MediatR;

namespace CleanArchitectureBlazor.Application.UseCases.Animals.Commands.CreateAnimal;

public sealed record CreateAnimalCommand(Animal Animal) : IRequest<Animal>
{ }
