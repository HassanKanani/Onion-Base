using Apllication.CategoryCommand;
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
    public async Task<ActionResult<bool>> AddAsync(CreateCategoryCommand command)
    {
        var userId = await _mediator.Send(command);
        return Ok(userId);
    }
    [HttpGet]
    public  Task Get()
    {
        throw new NotImplementedException();
    }
}
