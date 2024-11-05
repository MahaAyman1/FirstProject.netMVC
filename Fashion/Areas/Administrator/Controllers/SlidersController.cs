using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fashion.Data;
using Fashion.Models;
using Microsoft.Extensions.Hosting;

namespace Fashion.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class SlidersController : Controller
    {
        private readonly FDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public SlidersController(FDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment; 
        }

        // GET: Administrator/Sliders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sliders.ToListAsync());
        }

        // GET: Administrator/Sliders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slider = await _context.Sliders
                .FirstOrDefaultAsync(m => m.SliderID == id);
            if (slider == null)
            {
                return NotFound();
            }

            return View(slider);
        }

        // GET: Administrator/Sliders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administrator/Sliders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider, IFormFile formFile)
        {
            if (ModelState.IsValid)
            {
                if (formFile != null && formFile.Length > 0)
                {
                    var wwwRootPath = _hostEnvironment.WebRootPath;

                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);

                    var path = Path.Combine(wwwRootPath, "uploads", fileName);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await formFile.CopyToAsync(fileStream);
                    }

                    slider.SliderImg = "/uploads/" + fileName;
                }
                _context.Add(slider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(slider);
        }

        // GET: Administrator/Sliders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slider = await _context.Sliders.FindAsync(id);
            if (slider == null)
            {
                return NotFound();
            }
            return View(slider);
        }

        // POST: Administrator/Sliders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Slider slider , IFormFile? formFile)
        {
            if (id != slider.SliderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (formFile != null && formFile.Length > 0)
                    {
                        var wwwRootPath = _hostEnvironment.WebRootPath;

                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);

                        var path = Path.Combine(wwwRootPath, "uploads", fileName);

                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await formFile.CopyToAsync(fileStream);
                        }


                        slider.SliderImg = "/uploads/" + fileName;
                    }
                    else
                    {

                        _context.Entry(slider).Property(c => c.SliderImg).IsModified = false;
                    }
                    _context.Update(slider);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SliderExists(slider.SliderID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(slider);
        }

     
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slider = await _context.Sliders
                .FirstOrDefaultAsync(m => m.SliderID == id);
            if (slider == null)
            {
                return NotFound();
            }

            return View(slider);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var slider = await _context.Sliders.FindAsync(id);
            if (slider != null)
            {
                _context.Sliders.Remove(slider);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SliderExists(int id)
        {
            return _context.Sliders.Any(e => e.SliderID == id);
        }
    }
}
