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
using RFStorageWebServiceAPI;

namespace RFStorageWebServiceAPI.Controllers
{
    public class OrganisationsController : ApiController
    {
        private RFStorageDataContext db = new RFStorageDataContext();

        // GET: api/Organisations
        public IQueryable<Organisation> GetOrganisation()
        {
            return db.Organisation;
        }

        // GET: api/Organisations/5
        [ResponseType(typeof(Organisation))]
        public IHttpActionResult GetOrganisation(int id)
        {
            Organisation organisation = db.Organisation.Find(id);
            if (organisation == null)
            {
                return NotFound();
            }

            return Ok(organisation);
        }

        // PUT: api/Organisations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrganisation(int id, Organisation organisation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != organisation.OrganisationID)
            {
                return BadRequest();
            }

            db.Entry(organisation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganisationExists(id))
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

        // POST: api/Organisations
        [ResponseType(typeof(Organisation))]
        public IHttpActionResult PostOrganisation(Organisation organisation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Organisation.Add(organisation);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OrganisationExists(organisation.OrganisationID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = organisation.OrganisationID }, organisation);
        }

        // DELETE: api/Organisations/5
        [ResponseType(typeof(Organisation))]
        public IHttpActionResult DeleteOrganisation(int id)
        {
            Organisation organisation = db.Organisation.Find(id);
            if (organisation == null)
            {
                return NotFound();
            }

            db.Organisation.Remove(organisation);
            db.SaveChanges();

            return Ok(organisation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrganisationExists(int id)
        {
            return db.Organisation.Count(e => e.OrganisationID == id) > 0;
        }
    }
}