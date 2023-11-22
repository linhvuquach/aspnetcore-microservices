using Catalog.API.Entities;

namespace Catalog.API.Repositories.Interfaces;

// TODO:
// BASE repository
public interface IProductRepository
{
  Task<IEnumerable<Product>> GetProducts();
  Task<Product> GetProduct(string id);

  Task CreateProduct(Product product);
  Task<bool> UpdateProduct(Product product);
  Task<bool> DeleteProduct(string id);
}
