using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Adicionar()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View("Adicionar");
        }

        public IActionResult Apagar()
        {
            return View();
        }
    }
}
