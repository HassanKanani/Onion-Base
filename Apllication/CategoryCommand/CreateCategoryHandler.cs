
using Domain.Entities.CategoryEntity;
using MediatR;

namespace Apllication.CategoryCommand;

public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, bool>
{
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<bool> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        return await _categoryRepository.Add(new Category() { Name=request.Name}, cancellationToken);
    }
}
