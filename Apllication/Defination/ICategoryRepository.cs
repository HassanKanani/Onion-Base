
namespace Domain.Entities.CategoryEntity;

public interface ICategoryRepository
{
    Task<bool>Add(Category category,CancellationToken cancellationToken);
}
