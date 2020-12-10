using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using React_Service.Models;

namespace React_Service.Controllers
{
    public class BolgesController : ApiController
    {
        private SurvayDatabaseEntities2 db = new SurvayDatabaseEntities2();

        // GET: api/Bolges
        public IQueryable<Bolge> GetBolges()
        {
            return db.Bolge;
        }

        // GET: api/Bolges/5
        [ResponseType(typeof(Bolge))]
        public IHttpActionResult GetBolge(int id)
        {
            Bolge bolge = db.Bolge.Find(id);
            if (bolge == null)
            {
                return NotFound();
            }

            return Ok(bolge);
        }

        // PUT: api/Bolges/5
        [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
        [ResponseType(typeof(Bolge))]
        public IHttpActionResult PutBolge(int id, Bolge bolge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bolge.ID)
            {
                return BadRequest();
            }

            db.Entry(bolge).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BolgeExists(id))
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

        // POST: api/Bolges
        [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs 
        [ResponseType(typeof(Bolge))]
        public IHttpActionResult PostBolge(Bolge bolge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bolge.Add(bolge);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bolge.ID }, bolge);
        }

        // DELETE: api/Bolges/5
        [ResponseType(typeof(Bolge))]
        public IHttpActionResult DeleteBolge(int id)
        {
            Bolge bolge = db.Bolge.Find(id);
            if (bolge == null)
            {
                return NotFound();
            }

            db.Bolge.Remove(bolge);
            db.SaveChanges();

            return Ok(bolge);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BolgeExists(int id)
        {
            return db.Bolge.Count(e => e.ID == id) > 0;
        }
    }
}