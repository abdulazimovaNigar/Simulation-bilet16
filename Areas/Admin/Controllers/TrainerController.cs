using Bilet16Trainers.Contexts;
using Bilet16Trainers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bilet16Trainers.Areas.Admin.Controllers;
[Area ("Admin")]
public class TrainerController(AppDbContext _context) : Controller
{

    public IActionResult Index()
    {
        var trainers = _context.Trainers.ToList();
        return View(trainers);
    }

    [HttpGet]
    public IActionResult Create() 
    {
        return View();  
    }
    [HttpPost]
    public IActionResult Create(Trainer trainer) 
    {
        if (!ModelState.IsValid) return View(trainer);
        trainer.IsDeleted = false;
        _context.Trainers.Add(trainer);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public IActionResult Delete(int id) 
    {
        var trainer = _context.Trainers.FirstOrDefault(t => t.Id == id);
        if (trainer == null) return NotFound();
        trainer.IsDeleted = true;
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public IActionResult Update(int id) 
    {
        var trainer = _context.Trainers.FirstOrDefault(t => t.Id == id);
        if (trainer == null) return NotFound();
        return View(trainer);
    }
    [HttpPost]
    public IActionResult Update(Trainer trainer) 
    {
        if (!ModelState.IsValid) return View(trainer);
        var existTrainer = _context.Trainers.FirstOrDefault(t => t.Id == trainer.Id);

        if (existTrainer == null) return NotFound();
        existTrainer.Name = trainer.Name;
        existTrainer.Description = trainer.Description;
        existTrainer.Image = trainer.Image;
        existTrainer.CategoryId = trainer.CategoryId;

        _context.Trainers.Update(existTrainer);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
