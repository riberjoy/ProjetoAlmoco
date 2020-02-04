using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoAlmoco.Web.Models
{
    public class Cliente
    {
        [Required(ErrorMessage ="Necessário inserir o nome do cliente!")]
        public string NomeCliente { get; set; }

        [Required(ErrorMessage = "Necessário inserir um nome de usuario válido!")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Necessário inserir a senha!")]
        public string Senha { get; set; }

        public string ConfirmaSenha { get; set; }

    }
}