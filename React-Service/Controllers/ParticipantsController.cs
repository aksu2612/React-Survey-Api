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
    public class ParticipantsController : ApiController
    {
        private SurvayDatabaseEntities2 db = new SurvayDatabaseEntities2();

        // GET: api/Participants
        public IQueryable<Participant> GetParticipants()
        {
            return db.Participant;
        }

        // GET: api/Participants/5
        [ResponseType(typeof(Participant))]
        public IHttpActionResult GetParticipant(int id)
        {
            Participant participant = db.Participant.Find(id);
            if (participant == null)
            {
                return NotFound();
            }

            return Ok(participant);
        }

        // PUT: api/Participants/5
        [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
        [ResponseType(typeof(Participant))]
        public IHttpActionResult PutParticipant(int id, Participant participant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != participant.ID)
            {
                return BadRequest();
            }

            db.Entry(participant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantExists(id))
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

        // POST: api/Participants
        [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
        [ResponseType(typeof(Participant))]
        public IHttpActionResult PostParticipant(Participant participant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Participant.Add(participant);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = participant.ID }, participant);
        }

        // DELETE: api/Participants/5
        [ResponseType(typeof(Participant))]
        public IHttpActionResult DeleteParticipant(int id)
        {
            Participant participant = db.Participant.Find(id);
            if (participant == null)
            {
                return NotFound();
            }

            db.Participant.Remove(participant);
            db.SaveChanges();

            return Ok(participant);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParticipantExists(int id)
        {
            return db.Participant.Count(e => e.ID == id) > 0;
        }
    }
}