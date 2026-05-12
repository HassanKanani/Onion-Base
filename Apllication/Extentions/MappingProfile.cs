
//using MediatR;
//using System.Reflection;

//namespace Apllication.Extentions;
//public class MappingProfile : Profile
//{
//    private static readonly List<(Type Source, Type Destination)> _mappingsCache = new();

//    public MappingProfile()
//    {
//        if (!_mappingsCache.Any())
//        {
//            LoadMappings();
//        }

//        foreach (var mapping in _mappingsCache)
//        {
//            CreateMap(mapping.Source, mapping.Destination).ReverseMap();
//        }
//    }

//    private static void LoadMappings()
//    {
//        var markerType = typeof(IRequest);

//        var types = AppDomain.CurrentDomain.GetAssemblies()
//            .SelectMany(a =>
//            {
//                try
//                {
//                    return a.GetTypes();
//                }
//                catch (ReflectionTypeLoadException ex)
//                { 
//                    return ex.Types.Where(t => t != null);
//                }
//            })
//            .Where(t => t.IsClass && t.IsPublic && markerType.IsAssignableFrom(t));

//        foreach (var entity in types)
//        {
//            var mapInterface = entity.GetInterfaces()
//                .FirstOrDefault(i =>
//                    i.IsGenericType &&
//                    i.GetGenericTypeDefinition() == typeof(IAutoMapper<>));

//            if (mapInterface == null)
//                continue;

//            var sourceType = mapInterface.GetGenericArguments()[0];
//            var destinationType = entity;

//            _mappingsCache.Add((sourceType, destinationType));
//        }
//    }
//}
