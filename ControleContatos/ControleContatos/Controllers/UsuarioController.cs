using ControleContatos.Data;
using ControleContatos.Filters;
using ControleContatos.Models;
using ControleContatos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
    [PaginaRestritaAdmin]
    public class UsuarioController : Controller
    {

        private readonly IUsuarioInterface _usuarioRepository;
        public UsuarioController(IUsuarioInterface usuario) {
            _usuarioRepository = usuario;

        }

        public IActionResult Index()
        {
            List<UsuarioModel> usuario = _usuarioRepository.ListarTodos();
            return View(usuario);
        }


        public IActionResult Adicionar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepository.ListarPorId(id);
            return View("Adicionar", usuario);
        }

        public IActionResult ApagarConfirmacao(int id)
        {

            UsuarioModel usuario = _usuarioRepository.ListarPorId(id);
            return View("Apagar", usuario);
        }



        [HttpPost]
        public IActionResult Adicionar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepository.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Contato adicionado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(usuario);


            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Não foi possível cadastrar o usuário.Erro: {ex.Message}";
                return RedirectToAction("Index");

            }
        }

        [HttpPost]
        public IActionResult Editar(UsuarioDTO usuarioDTO)
        {
            try
            {
                UsuarioModel usuario = null;

                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = usuarioDTO.Id,
                        Nome = usuarioDTO.Nome,
                        Login = usuarioDTO.Login,
                        Email = usuarioDTO.Email,
                        Perfil = usuarioDTO.Perfil,
                    };
                    _usuarioRepository.Editar(usuario);
                    TempData["MensagemSucesso"] = "Usuário alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Adicionar", usuario);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Não foi possível alterar o usuário.Erro: {ex.Message}";
                return RedirectToAction("Index");

            }
        }


        public IActionResult Apagar(int id)
        {
            _usuarioRepository.Apagar(id);
            return RedirectToAction("Index");

        }
    }
}
