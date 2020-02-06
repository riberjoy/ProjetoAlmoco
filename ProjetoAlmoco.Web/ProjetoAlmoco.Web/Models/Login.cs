using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAlmoco.Web.Models
{
    public class Login
    {
        public int Idusuario { get; set; }
        public string NomeUsuario { get; set; }
        public bool Ativo { get; set; }
    }
}