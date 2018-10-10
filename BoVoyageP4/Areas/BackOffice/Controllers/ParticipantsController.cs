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
    public class ParticipantsController : Controller
    {
        private BoVoyageDbContext db = new BoVoyageDbContext();

        // GET: BackOffice/Participants
        public ActionResult Index()
        {
            var participants = db.Participants.Include(p => p.DossierReservation);
            return View(participants.ToList());
        }

        // GET: BackOffice/Participants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participant participant = db.Participants.Find(id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            return View(participant);
        }

        // GET: BackOffice/Participants/Create
        public ActionResult Create()
        {
            ViewBag.IDDossierReservation = new SelectList(db.DossierReservations, "ID", "NumeroCarteBancaire");
            return View();
        }

        // POST: BackOffice/Participants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDDossierReservation,Civilite,Nom,Prenom,Adresse,Telephone,DateNaissance")] Participant participant)
        {
            if (ModelState.IsValid)
            {
                db.Participants.Add(participant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDDossierReservation = new SelectList(db.DossierReservations, "ID", "NumeroCarteBancaire", participant.IDDossierReservation);
            return View(participant);
        }

        // GET: BackOffice/Participants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participant participant = db.Participants.Find(id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDDossierReservation = new SelectList(db.DossierReservations, "ID", "NumeroCarteBancaire", participant.IDDossierReservation);
            return View(participant);
        }

        // POST: BackOffice/Participants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDDossierReservation,Civilite,Nom,Prenom,Adresse,Telephone,DateNaissance")] Participant participant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(participant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDDossierReservation = new SelectList(db.DossierReservations, "ID", "NumeroCarteBancaire", participant.IDDossierReservation);
            return View(participant);
        }

        // GET: BackOffice/Participants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participant participant = db.Participants.Find(id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            return View(participant);
        }

        // POST: BackOffice/Participants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Participant participant = db.Participants.Find(id);
            db.Participants.Remove(participant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
