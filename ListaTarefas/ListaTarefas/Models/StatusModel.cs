using System.ComponentModel.DataAnnotations;

namespace ListaTarefas.Models
{
    public class StatusModel
    {
        [Key]
        public int StatusId { get; set; }
        public string StatusName { get; set; }
    }
}
