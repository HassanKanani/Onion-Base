
using Domain.Entities.CategoryEntity;
using Infrastructure.Common;
using Infrastructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementaion;
[ScopedRegistrationAttribute]
public class CategoryRepository :Repository<Category>, ICategoryRepository
{
    private readonly MyContext _context;

    public CategoryRepository(DbContext dbContext, IHttpContextAccessor? httpContextAccessor = null) : base(dbContext, httpContextAccessor)
    {
    }


    
}
