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
    public class CoursesController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Courses
        public ActionResult Index()
        {
            var coursesList = db.CoursesList.Include(c => c.Creator).Include(c => c.Language);
            return View(coursesList.ToList());
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.CoursesList.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.UsersList, "Id", "Name");
            ViewBag.LanguageId = new SelectList(db.LanguagesList, "Id", "Name");
            return View();
        }

        // POST: Courses/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,UserId,LanguageId")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.CoursesList.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.UsersList, "Id", "Name", course.UserId);
            ViewBag.LanguageId = new SelectList(db.LanguagesList, "Id", "Name", course.LanguageId);
            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.CoursesList.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UsersList, "Id", "Name", course.UserId);
            ViewBag.LanguageId = new SelectList(db.LanguagesList, "Id", "Name", course.LanguageId);
            return View(course);
        }

        // POST: Courses/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,UserId,LanguageId")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.UsersList, "Id", "Name", course.UserId);
            ViewBag.LanguageId = new SelectList(db.LanguagesList, "Id", "Name", course.LanguageId);
            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.CoursesList.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.CoursesList.Find(id);
            db.CoursesList.Remove(course);
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
