using FamilyPhotos.ViewModel.Validation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyPhotos.ViewModel
{
    public class PhotoViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        
        [StringLength(40)]
        public string Company { get; set; }

        
        [StringLength(40)]
        [Url]
        public string FaceBookProfil { get; set; }

        
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        
        [FromFileLengthValidation]
        [ContentTypeValidation]
        [Display(Name = "Picture")]
        public IFormFile PictureFromBrowser { get; set; }


       
    }
}
