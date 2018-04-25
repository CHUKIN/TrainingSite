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
    public class UsersController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Users
        public ActionResult Index()
        {
            var usersList = db.UsersList.Include(u => u.Group).Include(u => u.Position);
            return View(usersList.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.UsersList.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.GroupId = new SelectList(db.GroupsList, "Id", "Name");
            ViewBag.PositionId = new SelectList(db.PositionsList, "Id", "Name");
            return View();
        }

        // POST: Users/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Surname,Patronymic,Login,Password,DateOfBirthday,EmploymentDate,GroupId,PositionId")] User user)
        {
            if (ModelState.IsValid)
            {
                db.UsersList.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupId = new SelectList(db.GroupsList, "Id", "Name", user.GroupId);
            ViewBag.PositionId = new SelectList(db.PositionsList, "Id", "Name", user.PositionId);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.UsersList.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupId = new SelectList(db.GroupsList, "Id", "Name", user.GroupId);
            ViewBag.PositionId = new SelectList(db.PositionsList, "Id", "Name", user.PositionId);
            return View(user);
        }

        // POST: Users/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Surname,Patronymic,Login,Password,DateOfBirthday,EmploymentDate,GroupId,PositionId")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupId = new SelectList(db.GroupsList, "Id", "Name", user.GroupId);
            ViewBag.PositionId = new SelectList(db.PositionsList, "Id", "Name", user.PositionId);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.UsersList.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.UsersList.Find(id);
            db.UsersList.Remove(user);
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
