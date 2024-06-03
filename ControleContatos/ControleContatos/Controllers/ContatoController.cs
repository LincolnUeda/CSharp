using ControleContatos.Data;
using ControleContatos.Filters;
using ControleContatos.Models;
using ControleContatos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
    [PaginaUsuarioLogado]
    public class ContatoController : Controller
    {
        private readonly IContatoInterface _contatoRepository;
        public ContatoController(IContatoInterface contato) {
            _contatoRepository = contato;
        }
    
        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepository.ListarTodos();
            return View(contatos);
        }


        public IActionResult Adicionar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
           ContatoModel contato = _contatoRepository.ListarPorId(id);
            return View("Adicionar",contato);
        }

        public IActionResult ApagarConfirmacao(int id)
        {

            ContatoModel contato = _contatoRepository.ListarPorId(id);
            return View("Apagar",contato);
        }



        [HttpPost]
        public IActionResult Adicionar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepository.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato adicionado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(contato);


            }catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Não foi possível cadastrar o contato.Erro: {ex.Message}";
                return RedirectToAction("Index");

            }
        }

        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {
            try { 
            if (ModelState.IsValid)
            {
                _contatoRepository.Editar(contato);
                TempData["MensagemSucesso"] = "Contato alterado com sucesso";
                return RedirectToAction("Index");
            }
            return View("Adicionar",contato);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Não foi possível alterar o contato.Erro: {ex.Message}";
                return RedirectToAction("Index");

            }
        }

        
        public IActionResult Apagar(int id) {
            _contatoRepository.Apagar(id);
            return RedirectToAction("Index");

        }
    }
}
