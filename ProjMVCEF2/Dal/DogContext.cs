using ProjMVCEF2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjMVCEF2.Dal
{
    public class DogContext : DbContext
    {
        public DogContext() : base("DogContext")
        {
        }

        public DbSet<Dog> Dogs { set; get; }
        public DbSet<Raca> Raca { set; get; }


    }
}