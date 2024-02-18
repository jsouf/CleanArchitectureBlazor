using CleanArchitectureBlazor.Domain.Entities;
using MediatR;

namespace CleanArchitectureBlazor.Application.UseCases.Animals.Queries;

public sealed record GetAnimalsQuery : IRequest<List<Animal>>
{ }
