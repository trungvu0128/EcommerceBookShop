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
        }
        
        public IActionResult Index(int? id)
        {
            ViewModel model = new ViewModel();
            if (id == null)
            {
                model.Products = _context.Products.ToList();
                model.Categories = _context.Categories.ToList();
                return View(model);
            }
            model.Products = _context.Products.Where(p=>p.CategoryId == id).ToList();
            model.Categories = _context.Categories.ToList();
            return View(model);
        }
        public IActionResult Detail(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            ViewModel model = new ViewModel();
            model.product = _context.Products.Include(p=>p.Publishing).Include(p=>p.Category).FirstOrDefault(p => p.Id == id);
            model.Categories = _context.Categories.ToList();
            if(model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        
    }
}
