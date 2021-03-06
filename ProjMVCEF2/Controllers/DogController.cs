using ProjMVCEF2.Dal;
using ProjMVCEF2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjMVCEF2.Controllers
{
    public class DogController : Controller
    {
        private DogContext db = new DogContext();

        // GET: Dog
        public ActionResult Index()
        {
            return View(db.Dogs.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.BreedList = new SelectList(db.Breeds, "Id", "Description");
            ViewBag.CharacteristicList = db.Characteristics.ToList();


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name, Breed")] Dog dog, string[] selectedCharacteristic)
        {

            if (selectedCharacteristic != null)
            {
                dog.Characteristics = new List<Characteristic>();
                foreach (var item in selectedCharacteristic)
                {
                    var characteristicsToAdd = db.Characteristics.Find(int.Parse(item));
                    dog.Characteristics.Add(characteristicsToAdd);
                }
            }

            if (ModelState.IsValid)
            {
                dog.Breed = db.Breeds.First(r => r.Id == dog.Breed.Id);
                db.Dogs.Add(dog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dog);
        }

        public ActionResult Edit(int id)
        {
            var LstCharacteristic = new List<Characteristic>();
            var LstDog = db.Dogs.Find(id);

            foreach (var characteristic in db.Characteristics.ToList())
            {
                LstCharacteristic.Add(new Characteristic()
                {
                    Id = characteristic.Id,
                    Description = characteristic.Description,
                    Assigned = (LstDog.Characteristics.Contains(characteristic)) ? true : false
                });
            }

            ViewBag.CharacteristicList = LstCharacteristic;

            var dog = db.Dogs.First(d => d.Id == id);
            ViewBag.BreedList = new SelectList(db.Breeds, "Id", "Description", dog.Id);
            return View(dog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Breed")] Dog dog, string[] selectedCharacteristic)
        {
            if (selectedCharacteristic != null)
            {
                dog.Characteristics = new List<Characteristic>();
                foreach (var item in selectedCharacteristic)
                {
                    var characteristicsToAdd = db.Characteristics.Find(int.Parse(item));
                    dog.Characteristics.Add(characteristicsToAdd);
                }
            }

            if (ModelState.IsValid)
            {
                Dog dogUpdate = db.Dogs.First(d => d.Id == dog.Id);
                dogUpdate.Name = dog.Name;
                dogUpdate.Breed = db.Breeds.First(r => r.Id == dog.Breed.Id);
                dogUpdate.Characteristics = dog.Characteristics;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dog);
        }

        public ActionResult Details (int id)
        {
            return View(db.Dogs.First(d => d.Id == id));
        }


        public ActionResult Delete(int id)
        {
            return View(db.Dogs.First(d => d.Id == id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            db.Dogs.Remove(db.Dogs.First(d => d.Id == id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}