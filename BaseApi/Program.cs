
using Apllication.CategoryCommand;
using Apllication.Common;
using Infrastructure;
using Infrastructure.Context;
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
builder.Services.AddMediatR(cfg =>cfg.RegisterServicesFromAssembly(typeof(CreateCategoryCommand).Assembly));
    
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
