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
using AgendaContato.Models;
using System.Threading.Tasks;

namespace AgendaContato.Controllers
{
    public class ContatoesController : ApiController
    {
        private AgendaContatoEntities db = new AgendaContatoEntities();

        // GET: api/Contatoes
        public IQueryable<contato> GetContato()
        {
            return db.Contato;
        }

        // GET: api/Contatoes/5
        [ResponseType(typeof(contato))]
        public async Task<IHttpActionResult> GetContato(int id)
        {
            contato contato = await db.Contato.FindAsync(id);
            if (contato == null)
            {
                return NotFound();
            }

            return Ok(contato);
        }

        // PUT: api/Contatoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutContato(int id, contato contato)
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
               await db.SaveChangesAsync();
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

        // POST: api/Contatoes
        [ResponseType(typeof(contato))]
        public async Task<IHttpActionResult> PostContato(contato contato)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contato.Add(contato);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = contato.ContatoID }, contato);
        }

        // DELETE: api/Contatoes/5
        [ResponseType(typeof(contato))]
        public async Task<IHttpActionResult> DeleteContato(int id)
        {
            contato contato = db.Contato.Find(id);
            if (contato == null)
            {
                return NotFound();
            }

            db.Contato.Remove(contato);
            await db.SaveChangesAsync();

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