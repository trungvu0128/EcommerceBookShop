﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Users.Controllers
{
    public class HomeController : Controller
    {
        [Area("Users")]
        public IActionResult Index()
        {
            return View();
        }
    }
}