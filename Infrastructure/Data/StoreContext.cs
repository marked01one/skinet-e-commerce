using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
  public class StoreContext : DbContext
  {
    public StoreContext(DbContextOptions<StoreContext> options) : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }
    public DbSet<ProductBrand> ProductBrands { get; set; }

    // Function responsible for creating our migrations
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // Override the migrations to look for our configurations
      base.OnModelCreating(modelBuilder);
      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

      if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
      {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
          //  Get the properties of the entity type that are of type decimal
          var properties = entityType.ClrType.GetProperties().Where(
            p => p.PropertyType == typeof(decimal)
          );

          //  Iterate over the decimal properties
          foreach (var property in properties)
          {
            //  Set the property to have a double conversion
            modelBuilder.Entity(entityType.Name).Property(property.Name).HasConversion<double>();
          }
        }
      }
    }
  }
}