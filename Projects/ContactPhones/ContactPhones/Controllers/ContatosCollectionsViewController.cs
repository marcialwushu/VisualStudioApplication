using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContactPhones.Models;

namespace ContactPhones.Controllers
{
    public class ContatosCollectionsViewController : Controller
    {
        private AgendaTelefonicaEntities db = new AgendaTelefonicaEntities();

        // GET: ContatosCollectionsView
        public ActionResult Index()
        {
            return View(db.ContatosCollection.ToList());
        }

        // GET: ContatosCollectionsView/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContatosCollection contatosCollection = db.ContatosCollection.Find(id);
            if (contatosCollection == null)
            {
                return HttpNotFound();
            }
            return View(contatosCollection);
        }

        // GET: ContatosCollectionsView/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContatosCollectionsView/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idContato,Nome,Sobrenome,Telefone")] ContatosCollection contatosCollection)
        {
            if (ModelState.IsValid)
            {
                db.ContatosCollection.Add(contatosCollection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contatosCollection);
        }

        // GET: ContatosCollectionsView/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContatosCollection contatosCollection = db.ContatosCollection.Find(id);
            if (contatosCollection == null)
            {
                return HttpNotFound();
            }
            return View(contatosCollection);
        }

        // POST: ContatosCollectionsView/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idContato,Nome,Sobrenome,Telefone")] ContatosCollection contatosCollection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contatosCollection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contatosCollection);
        }

        // GET: ContatosCollectionsView/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContatosCollection contatosCollection = db.ContatosCollection.Find(id);
            if (contatosCollection == null)
            {
                return HttpNotFound();
            }
            return View(contatosCollection);
        }

        // POST: ContatosCollectionsView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContatosCollection contatosCollection = db.ContatosCollection.Find(id);
            db.ContatosCollection.Remove(contatosCollection);
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
