using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Portfolio.Web.Core;
using Portfolio.Web.Data;
using Portfolio.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _dbContext = context;
        }

        public IActionResult Index()
        {
            var model = new IndexModel();
            model.Projects = _dbContext.Project.OrderBy(p=>p.Rank);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
