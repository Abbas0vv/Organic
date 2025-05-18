using Microsoft.AspNetCore.Mvc;
using Organic.Database.Interfaces;
namespace Organic.Controllers;

public class HomeController : Controller
{
    private readonly IProductRepository _productRepository;

    public HomeController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public IActionResult Index()
    {
        var products = _productRepository.GetSome(5);
        return View(products);
    }
}
