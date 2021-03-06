﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Areas.Admin.Data;
using WebApp.Models;

namespace WebApp.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly DPContext _context;

        public HomeController(DPContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewModel model = new ViewModel();
            model.Slides =  _context.Slide.ToList();
            model.Products =  _context.Products.ToList();
            model.ProductTypes = _context.ProductType.ToList();
            model.Categories = _context.Categories.ToList(); 
            return View(model);
        }
    }
}
