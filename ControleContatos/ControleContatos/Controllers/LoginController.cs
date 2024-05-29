using ControleContatos.Helper;
using ControleContatos.Models;
using ControleContatos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUsuarioInterface _usuarioRepository;
        private readonly ISessao _sessao;
        public LoginController(IUsuarioInterface usuario, ISessao sessao){
            _usuarioRepository = usuario;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            if (_sessao.BuscarSessaoUsuario() != null)
            {
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginParm)
        {

            try {
                if (ModelState.IsValid)
                {
                    var usuario = _usuarioRepository.BuscarLogin(loginParm.Login);
                    if (usuario == null) {
                        TempData["MensagemErro"] = "Usuário não Cadastrado. Tente Novamente";
                        return RedirectToAction("Index");
                    }
                    if (usuario.Senhavalida(loginParm.Senha))
                    {
                        _sessao.CriarSessaoUsuario(usuario);
                        return RedirectToAction("Index", "Home");
                    }else { 
                        TempData["MensagemErro"] = "Senha inválida. Tente Novamente";
                    }

                    
                }

                return View("Index");

            }catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops! Não foi possível realizar o login. Erro: {ex.Message}";
                return RedirectToAction("index");
            }
        }
    }
}
