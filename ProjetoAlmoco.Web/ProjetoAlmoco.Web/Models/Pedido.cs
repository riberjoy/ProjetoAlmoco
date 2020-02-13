using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAlmoco.Web.Models
{
    public class Pedido
    {
        public int Num_IDCliente { get; set; }
        public string Nom_Cliente { get; set; }
        public IEnumerable<string> CategoriaAlimento { get; set; }

    }
}