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
    public class ExamInfoesController : ApiController
    {
        private SurvayDatabaseEntities2 db = new SurvayDatabaseEntities2();

        // GET: api/ExamInfoes
        public IQueryable<ExamInfo> GetExamInfoes()
        {
            return db.ExamInfo;
        }

        // GET: api/ExamInfoes/5
        [ResponseType(typeof(ExamInfo))]
        public IHttpActionResult GetExamInfo(int id)
        {
            ExamInfo examInfo = db.ExamInfo.Find(id);
            if (examInfo == null)
            {
                return NotFound();
            }

            return Ok(examInfo);
        }

        // PUT: api/ExamInfoes/5
        [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
        [ResponseType(typeof(ExamInfo))]
        public IHttpActionResult PutExamInfo(int id, ExamInfo examInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != examInfo.Id)
            {
                return BadRequest();
            }

            db.Entry(examInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamInfoExists(id))
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

        // POST: api/ExamInfoes
        [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
        [ResponseType(typeof(ExamInfo))]
        public IHttpActionResult PostExamInfo(ExamInfo examInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ExamInfo.Add(examInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = examInfo.Id }, examInfo);
        }

        // DELETE: api/ExamInfoes/5
        [ResponseType(typeof(ExamInfo))]
        public IHttpActionResult DeleteExamInfo(int id)
        {
            ExamInfo examInfo = db.ExamInfo.Find(id);
            if (examInfo == null)
            {
                return NotFound();
            }

            db.ExamInfo.Remove(examInfo);
            db.SaveChanges();

            return Ok(examInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExamInfoExists(int id)
        {
            return db.ExamInfo.Count(e => e.Id == id) > 0;
        }
    }
}