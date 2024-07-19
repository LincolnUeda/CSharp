using ControleContatos.Enums;
using ControleContatos.Helper;
using System.ComponentModel.DataAnnotations;

namespace ControleContatos.Models
{
    public class UsuarioModel
    {


        public int Id { get; set; }
        [Required(ErrorMessage = "Informe um Nome para Cadastro")]
        public string Nome { get; set; }
        [Required(ErrorMessage ="Informe um Login para Cadastro")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Informe uma Senha para Cadastro")]
        public string Senha { get; set; }
        [EmailAddress(ErrorMessage = "Informe um email válido")]
        public string Email { get; set; }
        public PerfilEnum Perfil { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public bool Senhavalida(string senha)
        {
            return Senha == senha.GerarHash();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }

        public string GeraNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0,8);
            Senha = novaSenha.GerarHash();
            return novaSenha;
        }
    }
}
