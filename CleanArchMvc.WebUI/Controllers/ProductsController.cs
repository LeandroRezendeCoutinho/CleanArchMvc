using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArchMvc.WebUI.Controllers;

public class ProductsController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly IWebHostEnvironment _environment;
    
    public ProductsController(IProductService productService, ICategoryService categoryService,
        IWebHostEnvironment environment)
    {
        _productService = productService;
        _categoryService = categoryService;
        _environment = environment;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetProducts();
        return View(products);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.CategoryId = new SelectList(await _categoryService.GetCategories(), "Id", "Name");
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Create(ProductDTO product)
    {
        if (ModelState.IsValid)
        {
            await _productService.Add(product);
            return RedirectToAction(nameof(Index));
        }

        return View(product);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var productDto = await _productService.GetById(id);

        if (productDto == null) return NotFound();

        ViewBag.CategoryId = new SelectList(await _categoryService.GetCategories(), "Id", "Name");
        return View(productDto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProductDTO productDto)
    {
        if (ModelState.IsValid)
        {
            await _productService.Update(productDto);
            return RedirectToAction(nameof(Index));
        }

        return View(productDto);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var productDto = await _productService.GetById(id);

        return View(productDto);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfitmed(int? id)
    {
        if (id == null) return NotFound();

        await _productService.Delete(id);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        
        var productDto = await _productService.GetById(id);

        if (productDto == null) return NotFound();

        var wwwroot = _environment.WebRootPath;
        var image = Path.Combine(wwwroot, "images\\" + productDto.Image);
        var exists = System.IO.File.Exists(image);
        ViewBag.ImageExist = exists;
        
        return View(productDto);
    }
}
