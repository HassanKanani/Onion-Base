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
    [HttpGet]
    public async Task<Category> Get(int Id)
    {
        return await _services.GetByKey(Id);

    }
    [HttpPut]
    public async Task<bool> Update(Category Id,CancellationToken cancellationToken)
    {
        return await _services.Update(Id,cancellationToken);

    }
}
