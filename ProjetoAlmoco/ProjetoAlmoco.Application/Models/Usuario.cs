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
        [MaxLength(15, ErrorMessage = "Máximo de 15 caracteres")]
        [MinLength(5, ErrorMessage = "Mínimo de 5 caracteres")]
        public string Nom_Usuario { get; set; }

        [Required(ErrorMessage = "Necessário inserir a senha!")]
        [MaxLength(15, ErrorMessage = "Máximo de 15 caracteres")]
        [MinLength(5, ErrorMessage = "Mínimo de 5 caracteres")]
        public string Num_Senha { get; set; }
    }
}