
using Apllication.Defination;
using Domain.Entities.CategoryEntity;

namespace Apllication.Implementaions;

public class CategoryServices : ICategoryServices
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryServices(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<bool> Add(Category category, CancellationToken cancellationToken)
    {
        return await _categoryRepository.Add(category, cancellationToken);
    }
}
