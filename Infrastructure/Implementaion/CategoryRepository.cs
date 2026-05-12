
using Domain.Entities.CategoryEntity;
using Infrastructure.Context;

namespace Infrastructure.Implementaion;

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


    public async Task<Category>GetByKey(int Key)
    {
        return await _context.Categories.FindAsync(Key);
    }
    public async Task<string> GetNameByKey(int Key)
    {
        var res= await _context.Categories.FindAsync(Key);
        return res.Name;
    }
    public async Task<bool> Update(Category category, CancellationToken cancellationToken)
    {


        // _context.Update(category);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

}
