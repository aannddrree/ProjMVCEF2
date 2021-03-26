using System.ComponentModel.DataAnnotations.Schema;

namespace ProjMVCEF2.Models
{
    public class Characteristic
    {
        public int Id { get; set; }
        public string Description { get; set; }

        [NotMapped]
        public bool Assigned { get; set; }
    }
}