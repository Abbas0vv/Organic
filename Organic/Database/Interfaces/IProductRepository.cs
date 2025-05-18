using Organic.Database.Models;
using Organic.Database.ViewModels;

namespace Organic.Database.Interfaces;

public interface IProductRepository
{
    public List<Product> GetAll();
    public List<Product> GetSome(int id);
    public Product GetById(int id);
    public void Insert(CreateProductViewModel model);
    public void Update(int id, UpdateProductViewModel model);
    public void Delete(int id);
}
