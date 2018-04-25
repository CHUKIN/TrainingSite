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
    public class StepsController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Steps
        public ActionResult Index()
        {
            var stepsList = db.StepsList.Include(s => s.Test).Include(s => s.Theory).Include(s => s.Video);
            return View(stepsList.ToList());
        }

        // GET: Steps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Step step = db.StepsList.Find(id);
            if (step == null)
            {
                return HttpNotFound();
            }
            return View(step);
        }

        // GET: Steps/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.TestsList, "Id", "Id");
            ViewBag.Id = new SelectList(db.TheoriesList, "Id", "Text");
            ViewBag.Id = new SelectList(db.VideoList, "Id", "Url");
            return View();
        }

        // POST: Steps/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Order,TheoryId,TestId,VideoId")] Step step)
        {
            if (ModelState.IsValid)
            {
                db.StepsList.Add(step);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.TestsList, "Id", "Id", step.Id);
            ViewBag.Id = new SelectList(db.TheoriesList, "Id", "Text", step.Id);
            ViewBag.Id = new SelectList(db.VideoList, "Id", "Url", step.Id);
            return View(step);
        }

        // GET: Steps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Step step = db.StepsList.Find(id);
            if (step == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.TestsList, "Id", "Id", step.Id);
            ViewBag.Id = new SelectList(db.TheoriesList, "Id", "Text", step.Id);
            ViewBag.Id = new SelectList(db.VideoList, "Id", "Url", step.Id);
            return View(step);
        }

        // POST: Steps/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Order,TheoryId,TestId,VideoId")] Step step)
        {
            if (ModelState.IsValid)
            {
                db.Entry(step).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.TestsList, "Id", "Id", step.Id);
            ViewBag.Id = new SelectList(db.TheoriesList, "Id", "Text", step.Id);
            ViewBag.Id = new SelectList(db.VideoList, "Id", "Url", step.Id);
            return View(step);
        }

        // GET: Steps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Step step = db.StepsList.Find(id);
            if (step == null)
            {
                return HttpNotFound();
            }
            return View(step);
        }

        // POST: Steps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Step step = db.StepsList.Find(id);
            db.StepsList.Remove(step);
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
