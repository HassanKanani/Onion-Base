
using Domain.Entities.CategoryEntity;
using MediatR;
namespace Apllication.CategoryCommand;
public class CreateCategoryCommand : IRequest<Category>
{
    public string Name { get; set; }
}
