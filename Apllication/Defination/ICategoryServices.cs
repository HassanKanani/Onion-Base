
using Domain.Entities.CategoryEntity;

namespace Apllication.Defination;

public interface ICategoryServices
{
    Task<bool> Add(Category category, CancellationToken cancellationToken);

}
