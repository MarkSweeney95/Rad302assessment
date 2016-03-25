using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RadAssingment.Models;

namespace Rad302AssingmentAPI.Controllers
{
    public class BossesController : ApiController
    {
        private BossContext db = new BossContext();

        // GET: api/Bosses
        public IQueryable<BossClass> GetBosses()
        {
            return db.Bosses;
        }

        // GET: api/Bosses/5
        [ResponseType(typeof(BossClass))]
        public IHttpActionResult GetBossClass(int id)
        {
            BossClass bossClass = db.Bosses.Find(id);
            if (bossClass == null)
            {
                return NotFound();
            }

            return Ok(bossClass);
        }

        // PUT: api/Bosses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBossClass(int id, BossClass bossClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bossClass.ID)
            {
                return BadRequest();
            }

            db.Entry(bossClass).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BossClassExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Bosses
        [ResponseType(typeof(BossClass))]
        public IHttpActionResult PostBossClass(BossClass bossClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bosses.Add(bossClass);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bossClass.ID }, bossClass);
        }

        // DELETE: api/Bosses/5
        [ResponseType(typeof(BossClass))]
        public IHttpActionResult DeleteBossClass(int id)
        {
            BossClass bossClass = db.Bosses.Find(id);
            if (bossClass == null)
            {
                return NotFound();
            }

            db.Bosses.Remove(bossClass);
            db.SaveChanges();

            return Ok(bossClass);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BossClassExists(int id)
        {
            return db.Bosses.Count(e => e.ID == id) > 0;
        }
    }
}