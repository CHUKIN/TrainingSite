using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrainingSite.Models;

namespace TrainingSite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CompetencesController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Competences
        public ActionResult Index()
        {
            var competencesList = db.CompetencesList.Include(c => c.Course).Include(c => c.Position);
            return View(competencesList.ToList());
        }

        // GET: Competences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competence competence = db.CompetencesList.Find(id);
            if (competence == null)
            {
                return HttpNotFound();
            }
            return View(competence);
        }

        // GET: Competences/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.CoursesList, "Id", "Name");
            ViewBag.PositionId = new SelectList(db.PositionsList, "Id", "Name");
            return View();
        }

        // POST: Competences/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PositionId,CourseId,Description,IsRequired")] Competence competence)
        {
            if (ModelState.IsValid)
            {
                db.CompetencesList.Add(competence);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.CoursesList, "Id", "Name", competence.CourseId);
            ViewBag.PositionId = new SelectList(db.PositionsList, "Id", "Name", competence.PositionId);
            return View(competence);
        }

        // GET: Competences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competence competence = db.CompetencesList.Find(id);
            if (competence == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.CoursesList, "Id", "Name", competence.CourseId);
            ViewBag.PositionId = new SelectList(db.PositionsList, "Id", "Name", competence.PositionId);
            return View(competence);
        }

        // POST: Competences/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PositionId,CourseId,Description,IsRequired")] Competence competence)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competence).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.CoursesList, "Id", "Name", competence.CourseId);
            ViewBag.PositionId = new SelectList(db.PositionsList, "Id", "Name", competence.PositionId);
            return View(competence);
        }

        // GET: Competences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competence competence = db.CompetencesList.Find(id);
            if (competence == null)
            {
                return HttpNotFound();
            }
            return View(competence);
        }

        // POST: Competences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Competence competence = db.CompetencesList.Find(id);
            db.CompetencesList.Remove(competence);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
