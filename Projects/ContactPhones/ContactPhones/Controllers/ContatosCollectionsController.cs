using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ContactPhones.Models;

namespace ContactPhones.Controllers
{
    public class ContatosCollectionsController : ApiController
    {
        private AgendaTelefonicaEntities db = new AgendaTelefonicaEntities();

        // GET: api/ContatosCollections
        public IQueryable<ContatosCollection> GetContatosCollection()
        {
            return db.ContatosCollection;
        }

        // GET: api/ContatosCollections/5
        [ResponseType(typeof(ContatosCollection))]
        public IHttpActionResult GetContatosCollection(int id)
        {
            ContatosCollection contatosCollection = db.ContatosCollection.Find(id);
            if (contatosCollection == null)
            {
                return NotFound();
            }

            return Ok(contatosCollection);
        }

        // PUT: api/ContatosCollections/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContatosCollection(int id, ContatosCollection contatosCollection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contatosCollection.idContato)
            {
                return BadRequest();
            }

            db.Entry(contatosCollection).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContatosCollectionExists(id))
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

        // POST: api/ContatosCollections
        [ResponseType(typeof(ContatosCollection))]
        public IHttpActionResult PostContatosCollection(ContatosCollection contatosCollection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ContatosCollection.Add(contatosCollection);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contatosCollection.idContato }, contatosCollection);
        }

        // DELETE: api/ContatosCollections/5
        [ResponseType(typeof(ContatosCollection))]
        public IHttpActionResult DeleteContatosCollection(int id)
        {
            ContatosCollection contatosCollection = db.ContatosCollection.Find(id);
            if (contatosCollection == null)
            {
                return NotFound();
            }

            db.ContatosCollection.Remove(contatosCollection);
            db.SaveChanges();

            return Ok(contatosCollection);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContatosCollectionExists(int id)
        {
            return db.ContatosCollection.Count(e => e.idContato == id) > 0;
        }
    }
}