using Ardalis.Result;
using Frontpoint.Server.Models;
using Frontpoint.UseCases.Individuals.Create;
using Frontpoint.UseCases.Individuals.Delete;
using Frontpoint.UseCases.Individuals.Get;
using Frontpoint.UseCases.Individuals.List;
using Frontpoint.UseCases.Individuals.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Frontpoint.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class IndividualsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<IndividualViewModel>>> GetAll([FromQuery] int? take, [FromQuery] int? skip)
    {
        var result = await _mediator.Send(new ListIndividualsQuery(take, skip));
        if (result.Status == ResultStatus.NotFound) return NotFound();

        var response = result.Value.Select(IndividualViewModel.FromDto);
        return Ok(response);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<IndividualViewModel>> Get([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetIndividualQuery(id));
        if (result.Status == ResultStatus.NotFound) return NotFound();

        var response = IndividualViewModel.FromDto(result.Value);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<IndividualViewModel>> Create([FromBody] IndividualViewModel model)
    {
        
        var result = await _mediator.Send(new CreateIndividualCommand(IndividualViewModel.ToDto(model), GetClientId()));
        if (result.Status != ResultStatus.Ok)
        {
            return Problem(String.Join(',', result.Errors));
        }

        var response = IndividualViewModel.FromDto(result.Value);
        return Ok(response);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<IndividualViewModel>> Update([FromRoute] int id, [FromBody] IndividualViewModel model)
    {
        var result = await _mediator.Send(new UpdateIndividualCommand(id, IndividualViewModel.ToDto(model), GetClientId()));
        if (result.Status == ResultStatus.NotFound) return NotFound();

        var response = IndividualViewModel.FromDto(result.Value);
        return Ok(response);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<IndividualViewModel>> Delete([FromRoute] int id)
    {
        var result = await _mediator.Send(new DeleteIndividualCommand(id, GetClientId()));
        if (result.Status == ResultStatus.NotFound) return NotFound();

        return Ok();
    }

    private string GetClientId()
    {
        return HttpContext.User.Identity?.Name ?? "Mock User";
    }
}
