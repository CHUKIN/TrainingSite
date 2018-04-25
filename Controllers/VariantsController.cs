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
    public class VariantsController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Variants
        public ActionResult Index()
        {
            var variantsList = db.VariantsList.Include(v => v.Test);
            return View(variantsList.ToList());
        }

        // GET: Variants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Variant variant = db.VariantsList.Find(id);
            if (variant == null)
            {
                return HttpNotFound();
            }
            return View(variant);
        }

        // GET: Variants/Create
        public ActionResult Create()
        {
            ViewBag.TestId = new SelectList(db.TestsList, "Id", "Id");
            return View();
        }

        // POST: Variants/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Text,IsCorrected,TestId")] Variant variant)
        {
            if (ModelState.IsValid)
            {
                db.VariantsList.Add(variant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TestId = new SelectList(db.TestsList, "Id", "Id", variant.TestId);
            return View(variant);
        }

        // GET: Variants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Variant variant = db.VariantsList.Find(id);
            if (variant == null)
            {
                return HttpNotFound();
            }
            ViewBag.TestId = new SelectList(db.TestsList, "Id", "Id", variant.TestId);
            return View(variant);
        }

        // POST: Variants/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text,IsCorrected,TestId")] Variant variant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(variant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TestId = new SelectList(db.TestsList, "Id", "Id", variant.TestId);
            return View(variant);
        }

        // GET: Variants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Variant variant = db.VariantsList.Find(id);
            if (variant == null)
            {
                return HttpNotFound();
            }
            return View(variant);
        }

        // POST: Variants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Variant variant = db.VariantsList.Find(id);
            db.VariantsList.Remove(variant);
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
