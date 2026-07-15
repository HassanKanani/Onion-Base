
using Apllication.CategoryCommand;
using Apllication.Common;
using Apllication.Create;
using Apllication.GetByKey;
using Infrastructure;
using Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#region DataBase
builder.Services.AddDbContext<MyContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
#endregion
builder.Services.AddHttpContextAccessor();
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));
builder.Services.ExtenalServicesExtention( AppDomain.CurrentDomain.GetAssemblies());
var entityTypes = typeof(Program).Assembly
    .GetTypes()
    .Where(t => t.IsClass && !t.IsAbstract && t.Namespace?.Contains("Entities") == true);

foreach (var entityType in entityTypes)
{
    // ??? GetAllQuery
    var queryType = typeof(GetAllQuery<>).MakeGenericType(entityType);
    var returnType = typeof(IReadOnlyList<>).MakeGenericType(entityType);
    var handlerType = typeof(GetAllQueryHandler<>).MakeGenericType(entityType);
    var serviceType = typeof(IRequestHandler<,>).MakeGenericType(queryType, returnType);

    builder.Services.AddTransient(serviceType, handlerType);
}

var app = builder.Build();
app.UseCustomErrorHandling();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(option =>
    {
        option.DocumentTitle = "Clean Arch";
        option.DefaultModelsExpandDepth(-1);
    });
}
app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials());

app.UseAuthorization();
app.MapControllers();
app.Run();
