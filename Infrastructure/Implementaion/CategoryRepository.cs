
using Domain.Entities.CategoryEntity;
using Infrastructure.Common;
using Infrastructure.Context;

namespace Infrastructure.Implementaion;
[ScopedRegistrationAttribute]
public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(MyContext dbContext) : base(dbContext)
    {
    }
}
