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
    public class TheoriesController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Theories
        public ActionResult Index()
        {
            var theoriesList = db.TheoriesList.Include(t => t.Step);
            return View(theoriesList.ToList());
        }

        // GET: Theories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theory theory = db.TheoriesList.Find(id);
            if (theory == null)
            {
                return HttpNotFound();
            }
            return View(theory);
        }

        // GET: Theories/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.StepsList, "Id", "Name");
            return View();
        }

        // POST: Theories/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Text")] Theory theory)
        {
            if (ModelState.IsValid)
            {
                db.TheoriesList.Add(theory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.StepsList, "Id", "Name", theory.Id);
            return View(theory);
        }

        // GET: Theories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theory theory = db.TheoriesList.Find(id);
            if (theory == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.StepsList, "Id", "Name", theory.Id);
            return View(theory);
        }

        // POST: Theories/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text")] Theory theory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(theory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.StepsList, "Id", "Name", theory.Id);
            return View(theory);
        }

        // GET: Theories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theory theory = db.TheoriesList.Find(id);
            if (theory == null)
            {
                return HttpNotFound();
            }
            return View(theory);
        }

        // POST: Theories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Theory theory = db.TheoriesList.Find(id);
            db.TheoriesList.Remove(theory);
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
