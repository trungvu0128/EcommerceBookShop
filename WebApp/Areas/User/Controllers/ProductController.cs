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
        public IActionResult Index()
        {
            ViewModel model = new ViewModel
            {
                Products = _context.Products.ToList(),
                Categories = _context.Categories.ToList()
            };
            return View(model);
        }
        
    }
}
