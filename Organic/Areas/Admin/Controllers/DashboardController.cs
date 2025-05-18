using Microsoft.AspNetCore.Mvc;
using Organic.Database.Interfaces;
using Organic.Database.ViewModels;

namespace Organic.Areas.Admin.Controllers;

[Area("Admin")]
public class DashboardController : Controller
{
    private readonly IProductRepository _productRepository;

    public DashboardController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var products = _productRepository.GetAll();
        return View(products);
    }

    [HttpGet] 
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(CreateProductViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        _productRepository.Insert(model);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        var product = _productRepository.GetById(id);
        var model = new CreateProductViewModel()
        {
            Name = product.Name,
            NormalPrice = product.NormalPrice,
            Offer = product.Offer
        };
        return View(model);
    }

    [HttpPost]
    public IActionResult Update(int id, UpdateProductViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        _productRepository.Update(id, model);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        _productRepository.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}
