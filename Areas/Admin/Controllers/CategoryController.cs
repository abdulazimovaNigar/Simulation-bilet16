using Bilet16Trainers.Contexts;
using Bilet16Trainers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bilet16Trainers.Areas.Admin.Controllers;

[Area ("Admin")]
[AutoValidateAntiforgeryToken]
public class CategoryController(AppDbContext _context) : Controller
{
    public IActionResult Index()
    {
        var categories = _context.Categories.ToList();
        return View(categories);
    }

    [HttpGet]
    public IActionResult Create() 
    {
        return View(); 
    }
    [HttpPost]
    public IActionResult Create(Category category) 
    {
        if (!ModelState.IsValid) return View(category);

        category.IsDeleted = false;

        _context.Categories.Add(category);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Delete(int id) 
    {
        var category = _context.Categories.FirstOrDefault(c => c.Id == id);
        if (category == null) return NotFound();
        category.IsDeleted = true;

        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Update(int id) 
    {
        var category = _context.Categories.FirstOrDefault(c => c.Id == id);
        if (category == null) NotFound();
        return View(category);
    }
    [HttpPost]
    public IActionResult Update(Category category) 
    {
        if (!ModelState.IsValid) return View(category);

        var existCategory = _context.Categories.FirstOrDefault(c => c.Id == category.Id);
        if (existCategory == null) return NotFound();

        existCategory.Name = category.Name;

        _context.Categories.Update(existCategory);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
