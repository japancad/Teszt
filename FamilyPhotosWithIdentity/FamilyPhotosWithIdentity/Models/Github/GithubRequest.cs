using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyPhotosWithIdentity.Models.Github
{
    public class GithubRequest
    {
       
        public int id { get; set; }
        public string zen { get; set; }
        public string action { get; set; }
        public int hook_id { get; set; }
        public Hook hook { get; set; }
        public Issue issue { get; set; }
        public Repository repository { get; set; }
        public Sender sender { get; set; }
    }
}
