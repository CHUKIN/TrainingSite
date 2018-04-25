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
    public class StoriesController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Stories
        public ActionResult Index()
        {
            var storiesList = db.StoriesList.Include(s => s.Step).Include(s => s.User);
            return View(storiesList.ToList());
        }

        // GET: Stories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = db.StoriesList.Find(id);
            if (story == null)
            {
                return HttpNotFound();
            }
            return View(story);
        }

        // GET: Stories/Create
        public ActionResult Create()
        {
            ViewBag.StepId = new SelectList(db.StepsList, "Id", "Name");
            ViewBag.UserId = new SelectList(db.UsersList, "Id", "Name");
            return View();
        }

        // POST: Stories/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,StepId,IsOpen,IsSuccessful,IsWrong")] Story story)
        {
            if (ModelState.IsValid)
            {
                db.StoriesList.Add(story);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StepId = new SelectList(db.StepsList, "Id", "Name", story.StepId);
            ViewBag.UserId = new SelectList(db.UsersList, "Id", "Name", story.UserId);
            return View(story);
        }

        // GET: Stories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = db.StoriesList.Find(id);
            if (story == null)
            {
                return HttpNotFound();
            }
            ViewBag.StepId = new SelectList(db.StepsList, "Id", "Name", story.StepId);
            ViewBag.UserId = new SelectList(db.UsersList, "Id", "Name", story.UserId);
            return View(story);
        }

        // POST: Stories/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,StepId,IsOpen,IsSuccessful,IsWrong")] Story story)
        {
            if (ModelState.IsValid)
            {
                db.Entry(story).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StepId = new SelectList(db.StepsList, "Id", "Name", story.StepId);
            ViewBag.UserId = new SelectList(db.UsersList, "Id", "Name", story.UserId);
            return View(story);
        }

        // GET: Stories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = db.StoriesList.Find(id);
            if (story == null)
            {
                return HttpNotFound();
            }
            return View(story);
        }

        // POST: Stories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Story story = db.StoriesList.Find(id);
            db.StoriesList.Remove(story);
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
