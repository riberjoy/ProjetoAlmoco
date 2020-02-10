using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAlmoco.Web.Models
{
    public class Alimento
    {
        public int AlimentotID { get; set; }
        public string Nome { get; set; }
        public int CategoriaID { get; set; }
        public char Ativo { get; set; }
    }
}