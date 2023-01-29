using Core.Entities;

namespace Core.Interfaces
{
  public interface IProductRepository
  {
    Task<Product> GetProductByIdAsync(int id);
    // Read only list, allows you to be more specific on what to return
    Task<IReadOnlyList<Product>> GetProductsAsync();
    Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
    Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
  }
}