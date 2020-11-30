using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Areas.Admin.Data;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly DPContext _context;

        public AuthController(DPContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View("../Auth/Login");
        }
    }
}
