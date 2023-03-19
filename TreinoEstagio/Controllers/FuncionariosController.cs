using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TreinoEstagio.Dados;

namespace TreinoEstagio.Controllers
{
    public class FuncionariosController : Controller
    {
        private DadosEntities db = new DadosEntities();
        
        // GET: Funcionarios
        public ActionResult Index()
        {
            var funcionario = db.Funcionario.Include(f => f.Funcao1);
            if (funcionario.ToList().Count() == 0)
            {
                return View("Indexvazia");
            }
            return View(funcionario.ToList());
        }

        // GET: Funcionarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionario.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // GET: Funcionarios/Create
        public ActionResult Create()
        {
            ViewBag.codfuncao = new SelectList(db.Funcao1, "codfuncao", "tipo");
            return View();
        }

        // POST: Funcionarios/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codfuncionario,nome,datanasc,codfuncao")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Funcionario.Add(funcionario); //adiciona uma nova linha com os dados na tabela de funcionario recebendo como parametro essa instancia
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codfuncao = new SelectList(db.Funcao1, "codfuncao", "tipo", funcionario.codfuncao);
            return View(funcionario);
        }

        // GET: Funcionarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionario.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            ViewBag.codfuncao = new SelectList(db.Funcao1, "codfuncao", "tipo", funcionario.codfuncao);
            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codfuncionario,nome,datanasc,codfuncao")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funcionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codfuncao = new SelectList(db.Funcao1, "codfuncao", "tipo", funcionario.codfuncao);
            return View(funcionario);
        }

        // GET: Funcionarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionario.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Funcionario funcionario = db.Funcionario.Find(id);
            db.Funcionario.Remove(funcionario);
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
