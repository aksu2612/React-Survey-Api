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
    public class QuestionTypeYesNoesController : ApiController
    {
        private SurvayDatabaseEntities2 db = new SurvayDatabaseEntities2();

        // GET: api/QuestionTypeYesNoes
        public IQueryable<QuestionTypeYesNo> GetQuestionTypeYesNoes()
        {
            return db.QuestionTypeYesNo;
        }

        // GET: api/QuestionTypeYesNoes/5
        [ResponseType(typeof(QuestionTypeYesNo))]
        public IHttpActionResult GetQuestionTypeYesNo(int id)
        {
            QuestionTypeYesNo questionTypeYesNo = db.QuestionTypeYesNo.Find(id);
            if (questionTypeYesNo == null)
            {
                return NotFound();
            }

            return Ok(questionTypeYesNo);
        }

        // PUT: api/QuestionTypeYesNoes/5

        [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
        [ResponseType(typeof(QuestionTypeYesNo))]
        public IHttpActionResult PutQuestionTypeYesNo(int id, QuestionTypeYesNo questionTypeYesNo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != questionTypeYesNo.ID)
            {
                return BadRequest();
            }

            db.Entry(questionTypeYesNo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionTypeYesNoExists(id))
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

        // POST: api/QuestionTypeYesNoes
        [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
        [ResponseType(typeof(QuestionTypeYesNo))]
        public IHttpActionResult PostQuestionTypeYesNo(QuestionTypeYesNo questionTypeYesNo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.QuestionTypeYesNo.Add(questionTypeYesNo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = questionTypeYesNo.ID }, questionTypeYesNo);
        }

        // DELETE: api/QuestionTypeYesNoes/5
        [ResponseType(typeof(QuestionTypeYesNo))]
        public IHttpActionResult DeleteQuestionTypeYesNo(int id)
        {
            QuestionTypeYesNo questionTypeYesNo = db.QuestionTypeYesNo.Find(id);
            if (questionTypeYesNo == null)
            {
                return NotFound();
            }

            db.QuestionTypeYesNo.Remove(questionTypeYesNo);
            db.SaveChanges();

            return Ok(questionTypeYesNo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuestionTypeYesNoExists(int id)
        {
            return db.QuestionTypeYesNo.Count(e => e.ID == id) > 0;
        }
    }
}