﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VIS.Models;
using Microsoft.AspNet.Identity.Owin;

namespace VIS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private ApplicationRoleManager _roleManager;

        public RoleController()
        {
        }

        public RoleController(ApplicationRoleManager roleManager)
        {
            RoleManager = roleManager;
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        // GET: Role
        public ActionResult Index()
        {
            List<RoleViewModel> list = new List<RoleViewModel>();
            foreach (var role in RoleManager.Roles)
                list.Add(new RoleViewModel(role));

            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(RoleViewModel model)
        {
            var role = new ApplicationRole() { Name = model.Name , Description = model.Description};
            await RoleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            return View(new RoleViewModel(role));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(RoleViewModel model)
        {
            var role = await RoleManager.FindByIdAsync(model.Role_ID);
            role.Name = model.Name;
            role.Description = model.Description;
            await RoleManager.UpdateAsync(role);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            return View(new RoleViewModel(role));
        }

        public async Task<ActionResult> Delete(int id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            return View(new RoleViewModel(role));
        }

        [HttpPost]
        public async Task<ActionResult> Delete(RoleViewModel model)
        {
            var role = await RoleManager.FindByIdAsync(model.Role_ID);
            await RoleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }
    }
}