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
    public class QuestionTypeThreesController : ApiController
    {
        private SurvayDatabaseEntities2 db = new SurvayDatabaseEntities2();

        // GET: api/QuestionTypeThrees
        public IQueryable<QuestionTypeThree> GetQuestionTypeThrees()
        {
            return db.QuestionTypeThree;
        }

        // GET: api/QuestionTypeThrees/5
        [ResponseType(typeof(QuestionTypeThree))]
        public IHttpActionResult GetQuestionTypeThree(int id)
        {
            QuestionTypeThree questionTypeThree = db.QuestionTypeThree.Find(id);
            if (questionTypeThree == null)
            {
                return NotFound();
            }

            return Ok(questionTypeThree);
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
        [ResponseType(typeof(QuestionTypeThree))]
        public IHttpActionResult PutQuestionTypeThree(int id, QuestionTypeThree questionTypeThree)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != questionTypeThree.ID)
            {
                return BadRequest();
            }

            db.Entry(questionTypeThree).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionTypeThreeExists(id))
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

        // POST: api/QuestionTypeThrees
        [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
        [ResponseType(typeof(QuestionTypeThree))]
        public IHttpActionResult PostQuestionTypeThree(QuestionTypeThree questionTypeThree)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.QuestionTypeThree.Add(questionTypeThree);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = questionTypeThree.ID }, questionTypeThree);
        }

        // DELETE: api/QuestionTypeThrees/5
        [ResponseType(typeof(QuestionTypeThree))]
        public IHttpActionResult DeleteQuestionTypeThree(int id)
        {
            QuestionTypeThree questionTypeThree = db.QuestionTypeThree.Find(id);
            if (questionTypeThree == null)
            {
                return NotFound();
            }

            db.QuestionTypeThree.Remove(questionTypeThree);
            db.SaveChanges();

            return Ok(questionTypeThree);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuestionTypeThreeExists(int id)
        {
            return db.QuestionTypeThree.Count(e => e.ID == id) > 0;
        }
    }
}