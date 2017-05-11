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
using CRUDWebAPI.Models;

namespace CRUDWebAPI.Controllers
{
    public class ProductController : ApiController
    {
        private AgendaContatoEntities db = new AgendaContatoEntities();

        // GET: api/Product
        public IQueryable<Contato> GetContato()
        {
            return db.Contato;
        }

        // GET: api/Product/5
        [ResponseType(typeof(Contato))]
        public IHttpActionResult GetContato(int id)
        {
            Contato contato = db.Contato.Find(id);
            if (contato == null)
            {
                return NotFound();
            }

            return Ok(contato);
        }

        // PUT: api/Product/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContato(int id, Contato contato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contato.ContatoID)
            {
                return BadRequest();
            }

            db.Entry(contato).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContatoExists(id))
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

        // POST: api/Product
        [ResponseType(typeof(Contato))]
        public IHttpActionResult PostContato(Contato contato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contato.Add(contato);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contato.ContatoID }, contato);
        }

        // DELETE: api/Product/5
        [ResponseType(typeof(Contato))]
        public IHttpActionResult DeleteContato(int id)
        {
            Contato contato = db.Contato.Find(id);
            if (contato == null)
            {
                return NotFound();
            }

            db.Contato.Remove(contato);
            db.SaveChanges();

            return Ok(contato);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContatoExists(int id)
        {
            return db.Contato.Count(e => e.ContatoID == id) > 0;
        }
    }
}