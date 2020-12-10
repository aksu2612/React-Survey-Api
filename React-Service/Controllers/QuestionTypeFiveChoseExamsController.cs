using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using React_Service.Models;

namespace React_Service.Controllers
{

    public class QuestionTypeFiveChoseExamsController : ApiController
    {
        private SurvayDatabaseEntities2 db = new SurvayDatabaseEntities2();

        // GET: api/QuestionTypeFiveChoseExams
        public IQueryable<QuestionTypeFiveChoseExam> GetQuestionTypeFiveChoseExams()
        {
            return db.QuestionTypeFiveChoseExam;
        }

        // GET: api/QuestionTypeFiveChoseExams/5
        [ResponseType(typeof(QuestionTypeFiveChoseExam))]
        public IHttpActionResult GetQuestionTypeFiveChoseExam(int id)
        {

            QuestionTypeFiveChoseExam questionTypeFiveChoseExam = db.QuestionTypeFiveChoseExam.Find(id);
            if (questionTypeFiveChoseExam == null)
            {
                return NotFound();
            }

            return Ok(questionTypeFiveChoseExam);
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQuestionTypeFiveChoseExam(int id, QuestionTypeFiveChoseExam questionTypeFiveChoseExam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != questionTypeFiveChoseExam.Id)
            {
                return BadRequest();
            }

            db.Entry(questionTypeFiveChoseExam).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionTypeFiveChoseExamExists(id))
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

        [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
        [ResponseType(typeof(QuestionTypeFiveChoseExam))]
        public IHttpActionResult PostQuestionTypeFiveChoseExam(QuestionTypeFiveChoseExam questionTypeFiveChoseExam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.QuestionTypeFiveChoseExam.Add(questionTypeFiveChoseExam);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = questionTypeFiveChoseExam.Id }, questionTypeFiveChoseExam);
        }

        // DELETE: api/QuestionTypeFiveChoseExams/5
        [ResponseType(typeof(QuestionTypeFiveChoseExam))]
        public IHttpActionResult DeleteQuestionTypeFiveChoseExam(int id)
        {
            QuestionTypeFiveChoseExam questionTypeFiveChoseExam = db.QuestionTypeFiveChoseExam.Find(id);
            if (questionTypeFiveChoseExam == null)
            {
                return NotFound();
            }

            db.QuestionTypeFiveChoseExam.Remove(questionTypeFiveChoseExam);
            db.SaveChanges();

            return Ok(questionTypeFiveChoseExam);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuestionTypeFiveChoseExamExists(int id)
        {
            return db.QuestionTypeFiveChoseExam.Count(e => e.Id == id) > 0;
        }
    }
}