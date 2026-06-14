
using Domain.Entities.CategoryEntity;
using MediatR;

namespace Apllication.CategoryCommand;

public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, Category>
{
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
     
        return await _categoryRepository.AddAsync(new Category() { Name=request.Name,CreateOn=DateTime.Now,CreateBy="test"}, cancellationToken);
    }
}
