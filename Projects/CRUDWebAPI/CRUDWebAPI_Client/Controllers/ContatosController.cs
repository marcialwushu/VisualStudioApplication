using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUDWebAPI_Client.Models;

namespace CRUDWebAPI_Client.Controllers
{
    public class ContatosController : Controller
    {
        private AgendaContatoEntities db = new AgendaContatoEntities();

        // GET: Contatos
        public ActionResult Index()
        {
            return View(db.Contato.ToList());
        }

        // GET: Contatos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contato contato = db.Contato.Find(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }

        // GET: Contatos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contatos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContatoID,FirstName,LastName,Phone")] Contato contato)
        {
            if (ModelState.IsValid)
            {
                db.Contato.Add(contato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contato);
        }

        // GET: Contatos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contato contato = db.Contato.Find(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }

        // POST: Contatos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContatoID,FirstName,LastName,Phone")] Contato contato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contato);
        }

        // GET: Contatos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contato contato = db.Contato.Find(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }

        // POST: Contatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contato contato = db.Contato.Find(id);
            db.Contato.Remove(contato);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
