
using Domain.Entities.CategoryEntity;
using Infrastructure.Common;
using Infrastructure.Context;

namespace Infrastructure.Implementaion;
[ScopedRegistrationAttribute]
public class CategoryRepository : ICategoryRepository
{
    private readonly MyContext _context;

    public CategoryRepository(MyContext context)
    {
        _context = context;
    }

    public async Task<bool> Add(Category category, CancellationToken cancellationToken)
    {


        await _context.AddAsync(category, cancellationToken);
      await  _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
