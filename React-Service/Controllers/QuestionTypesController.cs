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
    public class QuestionTypesController : ApiController
    {
        private SurvayDatabaseEntities2 db = new SurvayDatabaseEntities2();

        // GET: api/QuestionTypes
        public IQueryable<QuestionType> GetQuestionTypes()
        {
            return db.QuestionType;
        }

        // GET: api/QuestionTypes/5
        [ResponseType(typeof(QuestionType))]
        public IHttpActionResult GetQuestionType(int id)
        {
            QuestionType questionType = db.QuestionType.Find(id);
            if (questionType == null)
            {
                return NotFound();
            }

            return Ok(questionType);
        }

        // PUT: api/QuestionTypes/5
        [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
        [ResponseType(typeof(QuestionType))]
        public IHttpActionResult PutQuestionType(int id, QuestionType questionType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != questionType.ID)
            {
                return BadRequest();
            }

            db.Entry(questionType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionTypeExists(id))
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

        // POST: api/QuestionTypes
        [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
        [ResponseType(typeof(QuestionType))]
        public IHttpActionResult PostQuestionType(QuestionType questionType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.QuestionType.Add(questionType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = questionType.ID }, questionType);
        }

        // DELETE: api/QuestionTypes/5
        [ResponseType(typeof(QuestionType))]
        public IHttpActionResult DeleteQuestionType(int id)
        {
            QuestionType questionType = db.QuestionType.Find(id);
            if (questionType == null)
            {
                return NotFound();
            }

            db.QuestionType.Remove(questionType);
            db.SaveChanges();

            return Ok(questionType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuestionTypeExists(int id)
        {
            return db.QuestionType.Count(e => e.ID == id) > 0;
        }
    }
}