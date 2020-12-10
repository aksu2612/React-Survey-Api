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
    public class SurveyInfoesController : ApiController
    {
        private SurvayDatabaseEntities2 db = new SurvayDatabaseEntities2();

        // GET: api/SurveyInfoes
        public IQueryable<SurveyInfo> GetSurveyInfoes()
        {
            return db.SurveyInfo;
        }

        // GET: api/SurveyInfoes/5
        [ResponseType(typeof(SurveyInfo))]
        public IHttpActionResult GetSurveyInfo(int id)
        {
            SurveyInfo surveyInfo = db.SurveyInfo.Find(id);
            if (surveyInfo == null)
            {
                return NotFound();
            }

            return Ok(surveyInfo);
        }

        // PUT: api/SurveyInfoes/5
    
        public IHttpActionResult PutSurveyInfo(int id, SurveyInfo surveyInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != surveyInfo.ID)
            {
                return BadRequest();
            }

            db.Entry(surveyInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SurveyInfoExists(id))
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

        // POST: api/SurveyInfoes
        [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
        [ResponseType(typeof(SurveyInfo))]
        public IHttpActionResult PostSurveyInfo(SurveyInfo surveyInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SurveyInfo.Add(surveyInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = surveyInfo.ID }, surveyInfo);
        }

        // DELETE: api/SurveyInfoes/5
        [ResponseType(typeof(SurveyInfo))]
        public IHttpActionResult DeleteSurveyInfo(int id)
        {
            SurveyInfo surveyInfo = db.SurveyInfo.Find(id);
            if (surveyInfo == null)
            {
                return NotFound();
            }

            db.SurveyInfo.Remove(surveyInfo);
            db.SaveChanges();

            return Ok(surveyInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SurveyInfoExists(int id)
        {
            return db.SurveyInfo.Count(e => e.ID == id) > 0;
        }
    }
}