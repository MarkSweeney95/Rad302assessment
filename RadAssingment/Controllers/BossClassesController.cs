using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RadAssingment.Models;

namespace RadAssingment.Controllers
{
    public class BossClassesController : Controller
    {
        private BossContext db = new BossContext();

        // GET: BossClasses
        public ActionResult Index()
        {
            return View(db.Bosses.ToList());
        }

        // GET: BossClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BossClass bossClass = db.Bosses.Find(id);
            if (bossClass == null)
            {
                return HttpNotFound();
            }
            return View(bossClass);
        }

        // GET: BossClasses/Create
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,image,Name,Location,Health,Resistences,Weaknesses,SoulsGiven")] BossClass bossClass)
        {
            if (ModelState.IsValid)
            {
                db.Bosses.Add(bossClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bossClass);
        }

        // GET: BossClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BossClass bossClass = db.Bosses.Find(id);
            if (bossClass == null)
            {
                return HttpNotFound();
            }
            return View(bossClass);
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,image,Name,Location,Health,Resistences,Weaknesses,SoulsGiven")] BossClass bossClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bossClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bossClass);
        }

        // GET: BossClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BossClass bossClass = db.Bosses.Find(id);
            if (bossClass == null)
            {
                return HttpNotFound();
            }
            return View(bossClass);
        }

        // POST: BossClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BossClass bossClass = db.Bosses.Find(id);
            db.Bosses.Remove(bossClass);
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
