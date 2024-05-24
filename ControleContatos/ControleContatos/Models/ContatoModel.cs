﻿using System.ComponentModel.DataAnnotations;

namespace ControleContatos.Models
{
    public class ContatoModel
    {

        public int Id {  get; set; }
        [Required(ErrorMessage="informe o nome do contato")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "informe o email do contato")]
        [EmailAddress(ErrorMessage ="O email informado não é válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "informe o celular do contato")]
        [Phone(ErrorMessage ="O celular informado não é válido")]
        public string Celular { get; set; }

    }
}
