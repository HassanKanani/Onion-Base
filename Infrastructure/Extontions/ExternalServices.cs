using Apllication.Defination;
using Infrastructure.Common;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
namespace Infrastructure;
public static class ServicesExtensions
{
    public static void ExtenalServicesExtention(this IServiceCollection service, Assembly[] CurrentDomainAssembly)
    {

        #region IOC Container AutoFact
        // service.AddScoped<ICategoryRepository,CategoryRepository>();
        service.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        #endregion
        #region Scoped Registration - Improved

        var scopedRegistration = typeof(ScopedRegistrationAttribute);
        var scopedTypes = CurrentDomainAssembly
            .SelectMany(s => s.GetTypes())
            .Where(p => p.IsDefined(scopedRegistration, true) && !p.IsInterface && !p.IsAbstract);

        foreach (var implementation in scopedTypes)
        {
            var interfaces = implementation.GetInterfaces()
                .Where(i => !i.IsGenericType || !i.IsGenericTypeDefinition) 
                .ToList();

            if (!interfaces.Any())
            {
                service.AddScoped(implementation);
                continue;
            }

            foreach( var serviceInterface in interfaces)
            {
                service.AddScoped(serviceInterface, implementation);
                Console.WriteLine($"✅ Registered: {serviceInterface.Name} -> {implementation.Name}");
            }
        }

        #endregion
        #region AddSingleton
        Type SingletonRegistration = typeof(SingletonRegistrationAttribute);
        var Singletontypes = CurrentDomainAssembly
          .SelectMany(s => s.GetTypes())
          .Where(p => p.IsDefined(SingletonRegistration, true) && !p.IsInterface).Select(s => new
          { Service = s.GetInterface($"I{s.Name}"), Implementation = s }).Where(x => x.Service != null);
        foreach (var type in Singletontypes) { service.AddSingleton(type.Service, type.Implementation); }

        #endregion
        #region TransientRegiste
        Type TransientRegistration = typeof(TransientRegistrationAttribute);
        var Transienttypes = CurrentDomainAssembly
          .SelectMany(s => s.GetTypes())
          .Where(p => p.IsDefined(TransientRegistration, true) && !p.IsInterface).Select(s => new
          { Service = s.GetInterface($"I{s.Name}"), Implementation = s }).Where(x => x.Service != null);
        foreach (var type in Transienttypes) { service.AddSingleton(type.Service, type.Implementation); }


        #endregion


    }

}