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
                new Dog{Id = 1, Nome = "Mel", Raca = new Raca() { Id = 1, Descricao = "Labrador" }},
                new Dog{Id = 2, Nome = "Java", Raca = new Raca() { Id = 2, Descricao = "Sei la" }}
            };

            dogs.ForEach(d => context.Dogs.Add(d));
            context.SaveChanges();
        }
    }
}