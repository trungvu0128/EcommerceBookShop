using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Areas.Admin.Data;
using WebApp.Areas.Admin.Models;
using WebApp.Models;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly DPContext _context;

        public ProductsController(DPContext context)
        {
            _context = context;
        }
        // GET: Admin/Products
        public async Task<IActionResult> Index(string queryStrings = null )
        {
            //var dPContext = _context.Products.Include(p => p.Publishing).Include(p => p.Category);
            //return View(await dPContext.ToListAsync());
            var queryResult = _context.Products.Include(p => p.Publishing).Include(p => p.Category).ToList();
            if (queryStrings != null)
            {
                queryResult = _context.Products.Include(p => p.Publishing).Include(p => p.Category).Where(p => p.Name.Contains(queryStrings)).ToList();
            }
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "Name");
            return View(queryResult);
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Publishing)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            LevelProduct level0 = new LevelProduct(0, "Thường");
            LevelProduct level1 = new LevelProduct(1, "Khuyến Mãi");
            LevelProduct level2 = new LevelProduct(2, "Hot");
            List<LevelProduct> ListLevel = new List<LevelProduct>() {level0,level1,level2};
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["Level"] = new SelectList(ListLevel, "Id", "Name");
            return View();
        }   
        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,UnitPrice,Author,PublisherId,CategoryId,Img,Description,Level")] Product product,IFormFile File)
        {
            if (ModelState.IsValid)
            {
                if(File == null)
                {
                    return RedirectToAction(nameof(Create));
                }
                _context.Add(product);
                _context.SaveChanges();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img/Pro", product.Id + "." + File.FileName.Split(".")[File.FileName.Split(".").Length - 1]);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await File.CopyToAsync(stream);
                }
                product.Img = product.Id + "." + File.FileName.Split(".")[File.FileName.Split(".").Length - 1];
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    _context.RemoveRange(product);
                    throw;
                }
            }
            LevelProduct level0 = new LevelProduct(0, "Thường");
            LevelProduct level1 = new LevelProduct(1, "Khuyến Mãi");
            LevelProduct level2 = new LevelProduct(2, "Hot");
            List<LevelProduct> ListLevel = new List<LevelProduct>() { level0, level1, level2 };
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["Level"] = new SelectList(ListLevel, "Id", "Name");    
            return RedirectToAction(nameof(Index));
        }
        // GET: Admin/Products/Edit/5
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
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "Name", product.PublisherId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,UnitPrice,Author,PublisherId,CategoryId,Img,Description")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "Name", product.PublisherId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Publishing)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

    }
}
