using ProjMVCEF2.Models;
using System;
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
            var dogs = new List<Dog>
            {
                new Dog{Id = 1, Name = "Mel", Breed = new Breed() { Id = 1, Description = "Labrador" }},
                new Dog{Id = 2, Name = "Java", Breed = new Breed() { Id = 2, Description = "Sei la" }}
            };

            dogs.ForEach(d => context.Dogs.Add(d));
            context.SaveChanges();
        }
    }
}