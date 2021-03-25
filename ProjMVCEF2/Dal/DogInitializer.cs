using ProjMVCEF2.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjMVCEF2.Dal
{
    public class DogInitializer : DropCreateDatabaseIfModelChanges<DogContext>
    {
        protected override void Seed(DogContext context)
        {

            var characteristics1 = new List<Characteristic>
            {
                new Characteristic { Id = 1, Description = "Late" },
                new Characteristic { Id = 2, Description = "Morde"},
                new Characteristic { Id = 3, Description = "Fofinho"}
            };

            var characteristics2 = new List<Characteristic>
            {
                new Characteristic { Id = 4, Description = "asd" },
                new Characteristic { Id = 5, Description = "qwe"},
                new Characteristic { Id = 6, Description = "fgh"}
            };

            var dogs = new List<Dog>
            {
                new Dog{Id = 1,
                        Name = "Mel",
                        Breed = new Breed() { Id = 1, Description = "Labrador" },
                        Characteristics = characteristics1},

                new Dog{Id = 2, 
                        Name = "Java", 
                        Breed = new Breed() { Id = 2, Description = "Sei la" },
                        Characteristics = characteristics2}
            };

            dogs.ForEach(d => context.Dogs.Add(d));
            context.SaveChanges();
        }
    }
}