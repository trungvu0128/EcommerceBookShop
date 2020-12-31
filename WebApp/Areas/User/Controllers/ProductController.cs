using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Areas.Admin.Data;
using WebApp.Models;

namespace WebApp.Areas.Admin.Controllers.FrontEnd
{
    [Area("User")]
    public class ProductController : Controller
    {
        private readonly DPContext _context;

        public ProductController(DPContext context)
        {
            _context = context;
            ViewModel model = new ViewModel();
            model.ProductTypes = _context.ProductType.ToList();
            model.Categories = _context.Categories.ToList();
        }
        
        public async Task <IActionResult> Index(int? id)
        {
            ViewModel model = new ViewModel();
            if (id == null)
            {
                model.Products = await _context.Products.ToListAsync();
                model.Categories =await _context.Categories.ToListAsync();
                model.ProductTypes = _context.ProductType.ToList();
                model.Categories = _context.Categories.ToList();
                return View(model);
            }
            model.ProductTypes = _context.ProductType.ToList();
            model.Categories = _context.Categories.ToList();
            model.Products = await _context.Products.Where(p=>p.CategoryId == id).ToListAsync();
            model.Categories = await _context.Categories.ToListAsync();

            return View(model);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            ViewModel model = new ViewModel();
            model.product = await _context.Products.Include(p=>p.Publishing).Include(p=>p.Category).FirstOrDefaultAsync(p => p.Id == id);
            model.Categories = await _context.Categories.ToListAsync();
            model.ProductTypes = await _context.ProductType.ToListAsync();
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        
    }
}
    