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
    public class QuestionTypeImagesController : ApiController
    {
        private SurvayDatabaseEntities2 db = new SurvayDatabaseEntities2();

        // GET: api/QuestionTypeImages
        public IQueryable<QuestionTypeImage> GetQuestionTypeImages()
        {
            return db.QuestionTypeImage;
        }

        // GET: api/QuestionTypeImages/5
        [ResponseType(typeof(QuestionTypeImage))]
        public IHttpActionResult GetQuestionTypeImage(int id)
        {
            QuestionTypeImage questionTypeImage = db.QuestionTypeImage.Find(id);
            if (questionTypeImage == null)
            {
                return NotFound();
            }

            return Ok(questionTypeImage);
        }

        // PUT: api/QuestionTypeImages/5


        public IHttpActionResult PutQuestionTypeImage(int id, QuestionTypeImage questionTypeImage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != questionTypeImage.ID)
            {
                return BadRequest();
            }

            db.Entry(questionTypeImage).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionTypeImageExists(id))
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

        // POST: api/QuestionTypeImages
 
        [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
        [ResponseType(typeof(QuestionTypeImage))]
        public IHttpActionResult PostQuestionTypeImage(QuestionTypeImage questionTypeImage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.QuestionTypeImage.Add(questionTypeImage);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = questionTypeImage.ID }, questionTypeImage);
        }

        // DELETE: api/QuestionTypeImages/5
        [ResponseType(typeof(QuestionTypeImage))]
        public IHttpActionResult DeleteQuestionTypeImage(int id)
        {
            QuestionTypeImage questionTypeImage = db.QuestionTypeImage.Find(id);
            if (questionTypeImage == null)
            {
                return NotFound();
            }

            db.QuestionTypeImage.Remove(questionTypeImage);
            db.SaveChanges();

            return Ok(questionTypeImage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuestionTypeImageExists(int id)
        {
            return db.QuestionTypeImage.Count(e => e.ID == id) > 0;
        }
    }
}