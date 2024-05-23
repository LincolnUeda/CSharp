using System.ComponentModel.DataAnnotations;

namespace ListaTarefas.Models
{
    public class CategoriaModel
    {
        [Key]
        public int CategoriaId { get; set; }
        public string CategoriaNome { get; set; }
    }
}
