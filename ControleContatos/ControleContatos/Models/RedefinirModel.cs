using System.ComponentModel.DataAnnotations;

namespace ControleContatos.Models
{
    public class RedefinirModel
    {
        [Required(ErrorMessage = "Informe o Login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Informe o Email")]
        public string Email { get; set; }
    }
}
