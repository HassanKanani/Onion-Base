
using Infrastructure.Extontions;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Context;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ConfigurationDb();
        builder.ApplyConfigurationsEntity();


    }
}