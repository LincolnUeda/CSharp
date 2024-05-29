using System.ComponentModel.DataAnnotations;

namespace ControleContatos.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage="Informe o Login")]
        public string Login { get; set; }
        [Required(ErrorMessage="Informe a Senha")]
        public string Senha { get; set; }
    }
}
