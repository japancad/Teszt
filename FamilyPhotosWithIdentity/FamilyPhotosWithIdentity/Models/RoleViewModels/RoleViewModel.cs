using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyPhotosWithIdentity.Models.RoleViewModels
{
    public class RoleViewModel
    {
        public string UrlCode { get; set; }
        [Required]
        public string Name { get; set; }


    }
}
