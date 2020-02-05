using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoAlmoco.Web.Models
{
    public class Usuario
    {
        [Required(ErrorMessage = "Necessário inserir o usuário!")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "Necessário inserir a senha!")]
        public string Senha { get; set; }
    }
}