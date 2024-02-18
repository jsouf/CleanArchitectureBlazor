using CleanArchitectureBlazor.Domain.Entities;
using MediatR;

namespace CleanArchitectureBlazor.Application.UseCases.Animals.Queries;

public sealed record GetAnimalQuery(int Id) : IRequest<Animal?>
{ }
