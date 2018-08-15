using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyPhotosWithIdentity.Models.Github
{

    public class Rootobject
    {
        public Milestone milestone { get; set; }
    }

    public class Milestone
    {
        public string url { get; set; }
        public string html_url { get; set; }
        public string labels_url { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public string node_id { get; set; }
        public int number { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public User creator { get; set; }
    }

    

}