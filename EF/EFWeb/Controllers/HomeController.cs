using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFWeb.Models;

namespace EFWeb.Controllers
{
    public class HomeController : Controller
    {
        private BloggingContext _context;

        public HomeController(BloggingContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var blog = _context.Blogs.Single();

            var model = new TestModel
            {
                TestProp = blog.Url
            };

            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
