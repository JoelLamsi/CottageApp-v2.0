using CottageApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CottageApp.Controllers;

public class CottageItemsController : Controller
{
    private readonly CottageContext _context;
    private readonly IWebHostEnvironment _environment;

    public CottageItemsController(CottageContext context, IWebHostEnvironment environment)
    {
        _context = context;
        _environment = environment;
    }

    public async Task<IActionResult> Index()
    {
        return Redirect("/");
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.CottageItems == null)
        {
            return NotFound();
        }

        var cottageItem = await _context.CottageItems.FirstOrDefaultAsync(m => m.Id == id);

        if (cottageItem == null)
        {
            return NotFound();
        }

        return View(cottageItem);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Title,Description,DateAdded,CostPerDay,Rooms,IsElectricity,IsSauna")] CottageItem cottageItem, List<IFormFile> files)
    {
        if (ModelState.IsValid)
        {
            if ((files.FirstOrDefault()?.Length ?? 0) > 0)
            {
                var filePath = Path.Combine(_environment.WebRootPath, "collectionImages", cottageItem.Title + ".jpg");

                using (var stream = System.IO.File.Create(filePath))
                {
                    await files.First().CopyToAsync(stream);
                }

                cottageItem.PictureUrl = $"/collectionImages/{cottageItem}.jpg";
            }

            _context.Add(cottageItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(cottageItem);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.CottageItems == null)
        {
            return NotFound();
        }

        var cottageItem = await _context.CottageItems.FindAsync(id);
        if (cottageItem == null)
        {
            return NotFound();
        }
        return View(cottageItem);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Title,Description,DateAdded,CostPerDay,Rooms,IsElectricity,IsSauna")] CottageItem cottageItem)
    {
        if (id != cottageItem.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(cottageItem);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CottageItemExists(cottageItem.Id))
                {
                    return NotFound();
                }
                else throw;
            }
        }
        return View(cottageItem);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.CottageItems == null)
        {
            return NotFound();
        }

        var cottageItem = await _context.CottageItems
                .FirstOrDefaultAsync(m => m.Id == id);
        if (cottageItem == null)
        {
            return NotFound();
        }

        return View(cottageItem);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.CottageItems == null)
        {
            return Problem("Entity set 'CottageContext.CottageItems'  is null.");
        }
        var cottageItem = await _context.CottageItems.FindAsync(id);
        if (cottageItem != null)
        {
            _context.CottageItems.Remove(cottageItem);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CottageItemExists(int id)
    {
        return (_context.CottageItems?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}