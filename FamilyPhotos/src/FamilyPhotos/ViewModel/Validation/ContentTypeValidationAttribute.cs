using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyPhotos.ViewModel.Validation
{
    public class ContentTypeValidationAttribute : ValidationAttribute
    {
        public List<string> EnableContentType { get; set; }
        

        public ContentTypeValidationAttribute()
             : this(
                   new List<string> { "image/jpeg", "image/png" }
                   , "nem megfeleő formátum : {0}, ezekből lehet feltölteni: {1}."
                   )
        {}

        public ContentTypeValidationAttribute(List<string> enableContentType, string errorMessage)
        {
            EnableContentType = enableContentType;
            ErrorMessage = errorMessage;
        }

        public override bool IsValid(object value)
        {
            var file = value as IFormFile;
            if (file == null)
            {
                return false;
            }
            return EnableContentType.Contains(file.ContentType);
        }
        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessage, name, string.Join(",", EnableContentType));
        }
    }
}
 