
using MediatR;

namespace Apllication.CategoryCommand;


public class CreateCategoryCommand : IRequest<bool>
{
    public string Name { get; set; }
}
