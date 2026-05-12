
namespace Domain.Entities.CategoryEntity;

public interface ICategoryRepository
{
    Task<bool>Add(Category category,CancellationToken cancellationToken);
    Task<Category> GetByKey(int Key);
    Task<string> GetNameByKey(int Key);
    Task<bool> Update(Category category, CancellationToken cancellationToken);
}
