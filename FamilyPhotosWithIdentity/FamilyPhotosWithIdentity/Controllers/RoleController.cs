using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyPhotosWithIdentity.Helpers;
using FamilyPhotosWithIdentity.Models;
using FamilyPhotosWithIdentity.Models.RoleViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FamilyPhotosWithIdentity.Controllers
{
    //[Authorize(Roles ="Administrator")]   // ez a régi mondszer
    //[Authorize(Policy ="RequiredElevatesdAdminRights")]
    [Authorize("RequiredElevatesdAdminRights")]
    public class RoleController : Controller
    {
        private readonly RoleManager<ApplicationRole> roleManager;

        public RoleController(RoleManager<ApplicationRole> roleManager )
        {
            //TODO: Null ellenörzés
            this.roleManager = roleManager.ThrowIfNull(); ;
        }

        public IActionResult Index()
        {
            //var roles = roleManager.Roles.ToList();  //Api miatt nincs rá szükség
            var vm = new List<RoleViewModel>();

            //TODO: automapper intézni

            //Erre sincs Szukseg Api miatt
            //foreach (var role in roles)
            //{
            //    vm.Add(new RoleViewModel { UrlCode = role.UrlCode, Name = role.Name });
            //}

            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new RoleViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel vm)
        {
            if (!ModelState.IsValid) { return View(vm); }

            var roleToCreate = new ApplicationRole(vm.Name);
            var identityResult = await roleManager.CreateAsync(roleToCreate);
            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(vm);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string urlCode)
        {
            var role = roleManager.Roles
                                  .SingleOrDefault(x=>x.UrlCode == urlCode);
            if (role == null)
            {
                return NotFound(urlCode);
            }

            var vm = new RoleViewModel { UrlCode = urlCode, Name = role.Name };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoleViewModel vm)
        {
            if (!ModelState.IsValid) { return View(vm); }

            var roleToModify = roleManager.Roles
                                  .SingleOrDefault(x => x.UrlCode == vm.UrlCode);
            if (roleToModify == null)
            {
                return NotFound(vm.UrlCode);
            }

            roleToModify.Name = vm.Name;

            var identityResult = await roleManager.UpdateAsync(roleToModify);

            if(!identityResult.Succeeded)
            {            
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(vm);
            }

            return RedirectToAction("Index");

        }
    }
}