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
using RFStorageWebService;

namespace RFStorageWebService.Controllers
{
    public class OrdresController : ApiController
    {
        private RFStorageContext db = new RFStorageContext();

        // GET: api/Ordres
        public IQueryable<Ordre> GetOrdre()
        {
            return db.Ordre;
        }

        // GET: api/Ordres/5
        [ResponseType(typeof(Ordre))]
        public IHttpActionResult GetOrdre(int id)
        {
            Ordre ordre = db.Ordre.Find(id);
            if (ordre == null)
            {
                return NotFound();
            }

            return Ok(ordre);
        }

        // PUT: api/Ordres/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrdre(int id, Ordre ordre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ordre.OrdreID)
            {
                return BadRequest();
            }

            db.Entry(ordre).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdreExists(id))
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

        // POST: api/Ordres
        [ResponseType(typeof(Ordre))]
        public IHttpActionResult PostOrdre(Ordre ordre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ordre.Add(ordre);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OrdreExists(ordre.OrdreID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ordre.OrdreID }, ordre);
        }

        // DELETE: api/Ordres/5
        [ResponseType(typeof(Ordre))]
        public IHttpActionResult DeleteOrdre(int id)
        {
            Ordre ordre = db.Ordre.Find(id);
            if (ordre == null)
            {
                return NotFound();
            }

            db.Ordre.Remove(ordre);
            db.SaveChanges();

            return Ok(ordre);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrdreExists(int id)
        {
            return db.Ordre.Count(e => e.OrdreID == id) > 0;
        }
    }
}