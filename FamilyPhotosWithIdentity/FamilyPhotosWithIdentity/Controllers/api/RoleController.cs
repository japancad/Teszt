using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using FamilyPhotosWithIdentity.Helpers;
using FamilyPhotosWithIdentity.Models;
using FamilyPhotosWithIdentity.Models.RoleViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FamilyPhotosWithIdentity.Controllers.api
{
    [Produces("application/json")]
    [Route("api/Role")]
    public class RoleController : Controller
    {
        private readonly RoleManager<ApplicationRole> roleManager;

        public RoleController(RoleManager<ApplicationRole> roleManager)
        {
            this.roleManager = roleManager.ThrowIfNull(); ;
        }
        /// <summary>
        /// Lista adatforrása: 
        /// </summary>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Post(IDataTablesRequest request)
        {
            var roles = roleManager.Roles.ToList();  //Api miatt nincs rá szükség
            var vm = new List<RoleViewModel>();

            foreach (var role in roles)
            {
                vm.Add(new RoleViewModel { UrlCode = role.UrlCode, Name = role.Name });
            }


            //search müködés
            var filteredVm = string.IsNullOrWhiteSpace(request?.Search.Value)
                                        ? vm
                                        : vm.Where(x => x.Name.Contains(request.Search.Value))
                                            .ToList();

            var vmPage = filteredVm.Skip(request.Start).Take(request.Length);

            //Elökésület DataTables válaszra
            var response = DataTablesResponse.Create(request, vm.Count, filteredVm.Count, vmPage);
            return new DataTablesJsonResult(response,true);
        }
    }
}