using ControleContatos.Models;
using Newtonsoft.Json;

namespace ControleContatos.Helper
{
    public class Sessao : ISessao
    {

        private readonly IHttpContextAccessor _httpContext;
        public Sessao(IHttpContextAccessor acessor)
        {
            _httpContext = acessor;
        }

        public UsuarioModel BuscarSessaoUsuario()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("usuario");
            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
        }

        public void CriarSessaoUsuario(UsuarioModel usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);
            _httpContext.HttpContext.Session.SetString("usuario",valor);
        }

        public void RemoverSessaoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("usuario");
        }
    }
}
