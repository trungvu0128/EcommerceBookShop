using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList;
using WebApp.Areas.Admin.Data;
using WebApp.Areas.Admin.Models;
using WebApp.Models;

namespace WebApp.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly DPContext _context;
        public ProductsController(DPContext context)
        {
            _context = context;
        }
        public void _construct()
        {
            LevelProduct level0 = new LevelProduct(0, "Thường");
            LevelProduct level1 = new LevelProduct(1, "Khuyến Mãi");
            LevelProduct level2 = new LevelProduct(2, "Hot");
            List<LevelProduct> ListLevel = new List<LevelProduct>() { level0, level1, level2 };
            Origin or1 = new Origin(1, "Trong nước");
            Origin or2 = new Origin(2, "Nước ngoài");
            List<Origin> ListOrigin = new List<Origin>() { or1, or2 };
            ViewData["Origin"] = new SelectList(ListOrigin, "Id", "Name");
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "Id", "Name");
            ViewData["Level"] = new SelectList(ListLevel, "Id", "Name");
        }
        // GET: Admin/Products
        public async Task<IActionResult> Index(string queryStrings = null, int pageNumber = 1)
        {
            var queryResult = _context.Products.Include(p => p.Publishing).Include(p => p.Category);
            if (queryStrings != null)
            {
                queryResult = (Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Product, Category>)_context.Products.Include(p => p.Publishing).Include(p => p.Category).Where(p => p.Name.Contains(queryStrings));
            }
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "Name");
            return View(await PaginatedList<Product>.CreateAsync(queryResult, pageNumber, 5));
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
            _construct();
            return View();
        }
        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,UnitPrice,Author,PublisherId,CategoryId,ProductTypeId,Img,Description,Level,Origin")] Product product, ICollection<IFormFile> Files)
        {
            if (ModelState.IsValid)
            {
                if (Files == null)
                {
                    return RedirectToAction(nameof(Create));
                }
                _context.Add(product);
                _context.SaveChanges();
                long size = Files.Sum(f => f.Length);
                foreach (var formFile in Files)
                {
                    if (formFile.Length > 0)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img/Pro",product.Id + formFile.FileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                    }
                    product.Img += product.Id + formFile.FileName + ",";
                }
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
            _construct();
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
            _construct();
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,UnitPrice,Author,PublisherId,CategoryId,ProductTypeId,Description,Img,Origin")] Product product,ICollection<IFormFile> Files)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    long size = Files.Sum(f => f.Length);
                    foreach (var formFile in Files)
                    {
                        if (formFile.Length > 0)
                        {
                            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img/Pro", product.Id + formFile.FileName);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await formFile.CopyToAsync(stream);
                            }
                        }
                        product.Img += product.Id + formFile.FileName + ",";
                    }
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
            _construct();
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
