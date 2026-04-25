using Apllication.Defination;
using Domain.Entities.CategoryEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryServices _services;

    public CategoryController(ICategoryServices services)
    {
        _services = services;
    }

    [HttpPost]
    public async Task<bool> AddAsync(string Name,CancellationToken cancellationToken)
    {
        Category category=new Category() { Name=Name };
        return await _services.Add(category, cancellationToken);

    }
}
