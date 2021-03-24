using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjMVCEF2.Models
{
    public class Dog
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public virtual Raca Raca { get; set; }
    }
}