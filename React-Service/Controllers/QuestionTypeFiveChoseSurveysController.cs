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
    public class QuestionTypeFiveChoseSurveysController : ApiController
    {
        private SurvayDatabaseEntities2 db = new SurvayDatabaseEntities2();

        // GET: api/QuestionTypeFiveChoseSurveys
        public IQueryable<QuestionTypeFiveChoseSurvey> GetQuestionTypeFiveChoseSurveys()
        {
            return db.QuestionTypeFiveChoseSurvey;
        }

        // GET: api/QuestionTypeFiveChoseSurveys/5
        [ResponseType(typeof(QuestionTypeFiveChoseSurvey))]
        public IHttpActionResult GetQuestionTypeFiveChoseSurvey(int id)
        {
            QuestionTypeFiveChoseSurvey questionTypeFiveChoseSurvey = db.QuestionTypeFiveChoseSurvey.Find(id);
            if (questionTypeFiveChoseSurvey == null)
            {
                return NotFound();
            }

            return Ok(questionTypeFiveChoseSurvey);
        }

        // PUT: api/QuestionTypeFiveChoseSurveys/5 
        [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
        [ResponseType(typeof(QuestionTypeFiveChoseSurvey))]
        public IHttpActionResult PutQuestionTypeFiveChoseSurvey(int id, QuestionTypeFiveChoseSurvey questionTypeFiveChoseSurvey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != questionTypeFiveChoseSurvey.ID)
            {
                return BadRequest();
            }

            db.Entry(questionTypeFiveChoseSurvey).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionTypeFiveChoseSurveyExists(id))
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

        // POST: api/QuestionTypeFiveChoseSurveys
        [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
        [ResponseType(typeof(QuestionTypeFiveChoseSurvey))]
        public IHttpActionResult PostQuestionTypeFiveChoseSurvey(QuestionTypeFiveChoseSurvey questionTypeFiveChoseSurvey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.QuestionTypeFiveChoseSurvey.Add(questionTypeFiveChoseSurvey);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = questionTypeFiveChoseSurvey.ID }, questionTypeFiveChoseSurvey);
        }

        // DELETE: api/QuestionTypeFiveChoseSurveys/5
        [ResponseType(typeof(QuestionTypeFiveChoseSurvey))]
        public IHttpActionResult DeleteQuestionTypeFiveChoseSurvey(int id)
        {
            QuestionTypeFiveChoseSurvey questionTypeFiveChoseSurvey = db.QuestionTypeFiveChoseSurvey.Find(id);
            if (questionTypeFiveChoseSurvey == null)
            {
                return NotFound();
            }

            db.QuestionTypeFiveChoseSurvey.Remove(questionTypeFiveChoseSurvey);
            db.SaveChanges();

            return Ok(questionTypeFiveChoseSurvey);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuestionTypeFiveChoseSurveyExists(int id)
        {
            return db.QuestionTypeFiveChoseSurvey.Count(e => e.ID == id) > 0;
        }
    }
}