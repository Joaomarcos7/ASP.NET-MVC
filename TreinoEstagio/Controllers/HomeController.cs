using System.Web.Mvc; //bibliotecas padroes de controladores
using TreinoEstagio.Models;

namespace TreinoEstagio.Controllers //nome do projeto
{
    public class HomeController : Controller //herdando da classe Controller
    {
        public ActionResult Index() //ActionResult é um tipo de retorno geralmente com o metodo View()!
        {
            return View(); //como default ela carrega a view que possui o mesmo nome da Action, no caso é Index
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View("About");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.Nome = "João Marcos";

            return View();
        }

        public ActionResult Form()
        {
            var pessoa = new Pessoa();
            pessoa.Id = 1;
            pessoa.Nome = "João";
            return View(pessoa);
        }

        [HttpPost]
        public ActionResult Lista(Pessoa pessoa)
        {
            return View(pessoa);
        }
    }
}