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
        public IActionResult Index(string queryCategory)
        {
            ViewModel model = new ViewModel();
            if(queryCategory != null)
            {
                model.Products = _context.Products.Where(p => p.Category.ToString() == queryCategory).ToList();
                model.Categories = _context.Categories.ToList();

            }
         
            return View(model);
        }
        
    }
}
