using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoAlmoco.Application.Models
{
    public class Usuario
    {
        [Required(ErrorMessage = "Necessário inserir o usuário!")]
        public string Nom_Usuario { get; set; }

        [Required(ErrorMessage = "Necessário inserir a senha!")]
        public string Num_Senha { get; set; }
    }
}