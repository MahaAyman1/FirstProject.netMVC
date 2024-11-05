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
    public class ProductsController : Controller
    {
        private readonly FDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public ProductsController(FDbContext context , IWebHostEnvironment hostEnvironment)   
        {
            _context = context;
            _hostEnvironment = hostEnvironment; 
        }

        // GET: Administrator/Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        // GET: Administrator/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Product product , IFormFile formFile)
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

                   product.ProductImg = "/uploads/" + fileName;
                }

                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

    
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Product product , IFormFile? formFile)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingproduct = await _context.Products.FindAsync(id);

                    if (existingproduct == null)
                    {
                        return NotFound();
                    }

                    if (formFile != null && formFile.Length > 0)
                    {
                        var wwwRootPath = _hostEnvironment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);
                        var path = Path.Combine(wwwRootPath, "uploads", fileName);

                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await formFile.CopyToAsync(fileStream);
                        }

                       product.ProductImg= "/uploads/" + fileName;
                    }
                    else
                    {
                        // Retain the existing image if no new image is uploaded
                        product.ProductImg = existingproduct.ProductImg;
                    }
                    // Save the changes to the database
                    _context.Entry(existingproduct).CurrentValues.SetValues(product);
                    await _context.SaveChangesAsync();
                }
                 
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
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
            return View(product);
        }

        // GET: Administrator/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Administrator/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
