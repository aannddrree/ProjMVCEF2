﻿using ProjMVCEF2.Dal;
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
            ViewBag.RacaList = new SelectList(db.Raca, "Id", "Descricao");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome, Raca")] Dog dog)
        {
            if (ModelState.IsValid)
            {
                dog.Raca = db.Raca.First(r => r.Id == dog.Raca.Id);
                db.Dogs.Add(dog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dog);
        }

        public ActionResult Edit(int id)
        {
            var dog = db.Dogs.First(d => d.Id == id);
            ViewBag.RacaList = new SelectList(db.Raca, "Id", "Descricao", dog.Id);
            return View(dog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Raca")] Dog dog)
        {
            if (ModelState.IsValid)
            {
                Dog dogUpdate = db.Dogs.First(d => d.Id == dog.Id);
                dogUpdate.Nome = dog.Nome;
                dogUpdate.Raca = db.Raca.First(r => r.Id == dog.Raca.Id);
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