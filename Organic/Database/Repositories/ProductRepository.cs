using Organic.Database.Interfaces;
using Organic.Database.Models;
using Organic.Database.ViewModels;
using Organic.Helpers.Extentions;

namespace Organic.Database.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly OrganicDbContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private const string FOLDER_NAME = "Uploads/Product";

    public ProductRepository(OrganicDbContext context, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
    }

    public List<Product> GetAll()
    {
        return _context.Products.OrderBy(p => p.Id).ToList();
    }

    public List<Product> GetSome(int value)
    {
        if (GetAll().Count <= value) return GetAll();
        return _context.Products.OrderBy(p => p.Id).Take(value).ToList();
    }

    public Product GetById(int id)
    {
        return _context.Products.FirstOrDefault(p => p.Id == id);
    }

    public void Insert(CreateProductViewModel model)
    {
        var product = new Product()
        {
            Name = model.Name,
            NormalPrice = model.NormalPrice,
            Offer = model.Offer,
            ImageUrl = model.File.CreateFile(_webHostEnvironment.WebRootPath, FOLDER_NAME)
        };

        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void Update(int id, UpdateProductViewModel model)
    {
        var product = GetById(id);

        product.Name = model.Name;
        product.NormalPrice = model.NormalPrice;

        if (model.Offer is not null)
            product.Offer = model.Offer;

        if (model.File is not null)
            product.ImageUrl = model.File.UpdateFile(_webHostEnvironment.WebRootPath, FOLDER_NAME, product.ImageUrl);

        _context.Products.Update(product);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var product = GetById(id);
        _context.Remove(product);
        _context.SaveChanges();
    }
}
