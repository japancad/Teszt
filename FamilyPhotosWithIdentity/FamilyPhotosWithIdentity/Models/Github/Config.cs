﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyPhotosWithIdentity.Models.Github
{
    public class Config
    {
        
        public int id { get; set; }
        public string content_type { get; set; }
        public string insecure_ssl { get; set; }
        public string url { get; set; }
    }
}
