using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyPhotosWithIdentity.Models.Github
{

    public class Label
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public string node_id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public string color { get; set; }
        public bool _default { get; set; }
    }

}
