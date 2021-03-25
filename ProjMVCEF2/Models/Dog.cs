using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjMVCEF2.Models
{
    public class Dog
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Breed Breed { get; set; }

        public virtual ICollection<Characteristic> Characteristics { get; set; }
    }
}