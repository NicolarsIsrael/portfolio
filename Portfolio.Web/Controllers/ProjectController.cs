using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("projects")]
        public IActionResult Index()
        {
            var projects = _context.Project.Where(p => !p.IsDeleted);
            return View(projects);
        }
    }
}
