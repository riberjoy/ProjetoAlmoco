using System.Collections.Generic;

namespace ProjetoAlmoco.Domain.Entities
{
    public class PedidoCliente
    {
        public int Num_IDCliente { get; set; }
        public string Nom_Cliente { get; set; }
        public List<int> Num_IDAlimentos { get; set; }
        public IEnumerable<string> CategoriaAlimento { get; set; }
    }
}
