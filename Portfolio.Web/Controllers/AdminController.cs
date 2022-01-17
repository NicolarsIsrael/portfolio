﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult EditProject(int id)
        {
            var project = _dbContext.Project.Find(id);
            return View(project);
        }

        [HttpPost]
        public async Task<IActionResult> EditProject(Project model)
        {
            var project = _dbContext.Project.Find(model.Id);
            project.Title = model.Title;
            project.Description = model.Description;
            project.Participation = model.Participation;
            project.IsDeleted = model.IsDeleted;
            project.HomePage = model.HomePage;
            project.LiveDemoUrl = model.LiveDemoUrl;
            project.CodeUrl = model.CodeUrl;

            _dbContext.Entry(project).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Projects));
        }
        
        public IActionResult Certificates()
        {
            var certificates = _dbContext.Certificate;
            return View(certificates);
        }

        public IActionResult Certificate(int id)
        {
            var certificate = _dbContext.Certificate.Find(id);
            return View(certificate);
        }

        public IActionResult AddCertificate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCertificate(Certificate model)
        {
            _dbContext.Certificate.Add(model);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Certificates));
        }

        public IActionResult EditCertificate(int id)
        {
            var certificate = _dbContext.Certificate.Find(id);
            return View(certificate);
        }

        [HttpPost]
        public async Task<IActionResult> EditCertificate(Certificate model)
        {
            var certificate = _dbContext.Certificate.Find(model.Id);
            certificate.Title = model.Title;
            certificate.Organization = model.Organization;
            certificate.Url = model.Url;
            certificate.Descritption = model.Descritption;
            certificate.DateAwarded = model.DateAwarded;

            _dbContext.Entry(certificate).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Certificates));
        }
    }
}
