using CleanArchitectureBlazor.Application.UseCases.Animals.Commands.CreateAnimal;
using CleanArchitectureBlazor.Application.UseCases.Animals.Commands.DeleteAnimal;
using CleanArchitectureBlazor.Application.UseCases.Animals.Commands.UpdateAnimal;
using CleanArchitectureBlazor.Application.UseCases.Animals.Queries;
using CleanArchitectureBlazor.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureBlazor.WebApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalsController : ControllerBase
{
    private readonly ISender _sender;

    public AnimalsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult<List<Animal>>> GetAsync()
    {
        // todo : use Dto instead of DomainEntity
        List<Animal> result = await _sender.Send(new GetAnimalsQuery());

        // todo : return PaginatedList
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Animal>> GetAsync(int id)
    {
        // todo : Result class to handle every return
        var result = await _sender.Send(new GetAnimalQuery(id));

        if (result == null)
        {
            return NotFound("Animal not found");
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        await _sender.Send(new DeleteAnimalCommand(id));

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Animal>> UpdateAsync(int id, Animal updatedAnimal)
    {
        var animal = await _sender.Send(new UpdateAnimalCommand(id, updatedAnimal));

        return Ok(animal);
    }

    [HttpPost]
    public async Task<ActionResult<Animal>> AddAnimalAsync(Animal newAnimal)
    {
        var animal = await _sender.Send(new CreateAnimalCommand(newAnimal));

        return animal ?? newAnimal;
    }
}
