using FamilyPhotos.ViewModel.Validation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyPhotos.Models
{
    public class PhotoModel
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

        
        public string Description { get; set; }

        public byte[] Picture { get; set; }
      
        public string ContentType { get; set; }
    }
}
