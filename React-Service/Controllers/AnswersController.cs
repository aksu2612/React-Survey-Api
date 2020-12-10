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
    public class AnswersController : ApiController
    {
        private SurvayDatabaseEntities2 db = new SurvayDatabaseEntities2();

        // GET: api/Answers
        public IQueryable<Answer> GetAnswers()
        {
            return db.Answer;
        }

        // GET: api/Answers/5
        [ResponseType(typeof(Answer))]
        public IHttpActionResult GetAnswer(int id)
        {
            Answer answer = db.Answer.Find(id);
            if (answer == null)
            {
                return NotFound();
            }

            return Ok(answer);
        }

        // PUT: api/Answers/5
        [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
        [ResponseType(typeof(Answer))]
        public IHttpActionResult PutAnswer(int id, Answer answer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != answer.ID)
            {
                return BadRequest();
            }

            db.Entry(answer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnswerExists(id))
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

        // POST: api/Answers
        [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs 
        [ResponseType(typeof(Answer))]
        public IHttpActionResult PostAnswer(Answer answer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Answer.Add(answer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = answer.ID }, answer);
        }

        // DELETE: api/Answers/5
        [ResponseType(typeof(Answer))]
        public IHttpActionResult DeleteAnswer(int id)
        {
            Answer answer = db.Answer.Find(id);
            if (answer == null)
            {
                return NotFound();
            }

            db.Answer.Remove(answer);
            db.SaveChanges();

            return Ok(answer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnswerExists(int id)
        {
            return db.Answer.Count(e => e.ID == id) > 0;
        }
    }
}