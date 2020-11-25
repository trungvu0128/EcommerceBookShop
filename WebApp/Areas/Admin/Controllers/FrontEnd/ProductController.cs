using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Areas.Admin.Data;

namespace WebApp.Areas.Admin.Controllers.FrontEnd
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly DPContext _context;

        public ProductController(DPContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View("../FrontEnd/Index");
        }
        public IActionResult Category()
        {
            return View("../FrontEnd/Category");
        }
    }
}
