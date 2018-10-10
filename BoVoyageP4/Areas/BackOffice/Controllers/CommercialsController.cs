﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BoVoyageP4.Data;
using BoVoyageP4.Models;

namespace BoVoyageP4.Areas.BackOffice.Controllers
{
    public class CommercialsController : Controller
    {
        private BoVoyageDbContext db = new BoVoyageDbContext();

        // GET: BackOffice/Commercials
        public ActionResult Index()
        {
            return View(db.Commercials.ToList());
        }

        // GET: BackOffice/Commercials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commercial commercial = db.Commercials.Find(id);
            if (commercial == null)
            {
                return HttpNotFound();
            }
            return View(commercial);
        }

        // GET: BackOffice/Commercials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/Commercials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Login,MotDePasse,Civilite,Nom,Prenom,Adresse,Telephone,DateNaissance")] Commercial commercial)
        {
            if (ModelState.IsValid)
            {
                db.Commercials.Add(commercial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(commercial);
        }

        // GET: BackOffice/Commercials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commercial commercial = db.Commercials.Find(id);
            if (commercial == null)
            {
                return HttpNotFound();
            }
            return View(commercial);
        }

        // POST: BackOffice/Commercials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Login,MotDePasse,Civilite,Nom,Prenom,Adresse,Telephone,DateNaissance")] Commercial commercial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commercial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(commercial);
        }

        // GET: BackOffice/Commercials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commercial commercial = db.Commercials.Find(id);
            if (commercial == null)
            {
                return HttpNotFound();
            }
            return View(commercial);
        }

        // POST: BackOffice/Commercials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Commercial commercial = db.Commercials.Find(id);
            db.Commercials.Remove(commercial);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}
