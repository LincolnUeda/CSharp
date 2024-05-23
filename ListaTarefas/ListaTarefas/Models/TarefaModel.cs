using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ListaTarefas.Models
{
    public class TarefaModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Informe a Descrição")]
        public string Descricao { get; set; }
        [Required(ErrorMessage ="Informe a data de vencimento")]
        public DateTime? DataVencimento { get; set; }
        [Required(ErrorMessage ="Informe uma categoria")]
        public int CategoriaId { get; set; }
        [ValidateNever]
        public CategoriaModel Categoria { get; set; }
        [Required(ErrorMessage ="Informe um status")]
        public int StatusId { get; set; }
        [ValidateNever]
        public StatusModel Status { get; set; }
        public bool Atrasado => StatusId == 1 && DataVencimento < DateTime.Today;
    }
}
