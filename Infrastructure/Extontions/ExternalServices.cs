using Domain.Entities.CategoryEntity;
using Infrastructure.Implementaion;
using Microsoft.Extensions.DependencyInjection;
namespace Infrastructure;
public static class ServicesExtensions
{
    public static void ExtenalServicesExtention(this IServiceCollection service)
    {
        #region IOC Container AutoFact
        service.AddScoped<ICategoryRepository,CategoryRepository>();
        #endregion




    }

}