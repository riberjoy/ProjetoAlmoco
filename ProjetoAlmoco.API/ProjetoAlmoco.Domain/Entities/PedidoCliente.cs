using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAlmoco.Domain.Entities
{
    public class PedidoCliente
    {
        public int Num_IDCliente { get; set; }
        public string Nom_Cliente { get; set; }
        public IEnumerable<string> CategoriaAlimento { get; set; }
    }
}
