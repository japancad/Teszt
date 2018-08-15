using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyPhotosWithIdentity.Models.Github
{
    public class Hook
    {
        public string type { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
        public Config config { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime created_at { get; set; }
        public string url { get; set; }
        public string test_url { get; set; }
        public string ping_url { get; set; }
        public Last_Response last_response { get; set; }

        //Ez helyett, mert ilyet az entity framework nem tud
        //public string[] events { get; set; }
        //ezzel az atributummal nem irj ki adatbázisba
        [NotMapped]        
        public string[] events { get; set; }

        public string EventsInDb
        {
            get { return string.Join(",", events); }

            set { events = value.Split(","); }
        }
    }
    

}
