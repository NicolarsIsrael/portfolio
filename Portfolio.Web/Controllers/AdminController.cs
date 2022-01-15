using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Core;
using Portfolio.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Web.Controllers
{
    [Authorize(Roles = AppConstant.AdminRole)]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public AdminController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Projects()
        {
            var projects = _dbContext.Project.Where(p => !p.IsDeleted);
            return View(projects);
        }

        public IActionResult Project(int id)
        {
            var project = _dbContext.Project.Find(id);
            return View(project);
        }

        [Route("add-new-project")]
        public IActionResult AddNewProject()
        {
            return View();
        }

        [Route("add-new-project")]
        [HttpPost]
        public async Task<IActionResult> AddNewProject(Project model)
        {
            _dbContext.Add(model);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Projects));
        }

        
    }
}
