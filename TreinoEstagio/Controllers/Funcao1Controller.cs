using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TreinoEstagio.Dados;

namespace TreinoEstagio.Controllers
{
    public class Funcao1Controller : Controller
    {
        private DadosEntities db = new DadosEntities();

        // GET: Funcao1
        public ActionResult Index()
        {
            return View(db.Funcao1.ToList());
        }

        // GET: Funcao1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcao1 funcao1 = db.Funcao1.Find(id);
            if (funcao1 == null)
            {
                return HttpNotFound();
            }
            return View(funcao1);
        }

        // GET: Funcao1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Funcao1/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codfuncao,tipo,salario")] Funcao1 funcao1)
        {
            if (ModelState.IsValid)
            {
                db.Funcao1.Add(funcao1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(funcao1);
        }

        // GET: Funcao1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcao1 funcao1 = db.Funcao1.Find(id);
            if (funcao1 == null)
            {
                return HttpNotFound();
            }
            return View(funcao1);
        }

        // POST: Funcao1/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codfuncao,tipo,salario")] Funcao1 funcao1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funcao1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(funcao1);
        }

        // GET: Funcao1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcao1 funcao1 = db.Funcao1.Find(id);
            if (funcao1 == null)
            {
                return HttpNotFound();
            }
            return View(funcao1);
        }

        // POST: Funcao1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Funcao1 funcao1 = db.Funcao1.Find(id);
            db.Funcao1.Remove(funcao1);
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
