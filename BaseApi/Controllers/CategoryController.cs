using Apllication.CategoryCommand;
using Apllication.GetByKey;
using Domain.Entities.CategoryEntity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace BaseApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController( IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<ActionResult<bool>> AddAsync(Category command)
    {
        var userId = await _mediator.Send(command);
        return Ok(userId);
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<IReadOnlyList<Category>>> GetAll()
        => Ok( await _mediator.Send(new GetAllQuery<Category>()));
}
