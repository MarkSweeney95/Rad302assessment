using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rad302Assingment.Models;

namespace Rad302Assingment.Controllers
{
    public class BossesController : Controller
    {
        private BossContext db = new BossContext();

        // GET: Bosses
        public ActionResult Index()
        {
            return View(db.Bosses.ToList());
        }

        // GET: Bosses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bosses bosses = db.Bosses.Find(id);
            if (bosses == null)
            {
                return HttpNotFound();
            }
            return View(bosses);
        }

        // GET: Bosses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bosses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,name,location,weakness,health,resistences,imageURL")] Bosses bosses)
        {
            if (ModelState.IsValid)
            {
                db.Bosses.Add(bosses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bosses);
        }

        // GET: Bosses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bosses bosses = db.Bosses.Find(id);
            if (bosses == null)
            {
                return HttpNotFound();
            }
            return View(bosses);
        }

        // POST: Bosses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,name,location,weakness,health,resistences,imageURL")] Bosses bosses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bosses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bosses);
        }

        // GET: Bosses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bosses bosses = db.Bosses.Find(id);
            if (bosses == null)
            {
                return HttpNotFound();
            }
            return View(bosses);
        }

        // POST: Bosses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bosses bosses = db.Bosses.Find(id);
            db.Bosses.Remove(bosses);
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
