using System;

namespace ProjetoAlmoco.Domain.Entities
{
    public class Pedido
    {
        public int Num_IDPedido { get; set; }
        public DateTime Dat_DataPedido { get; set; }
        public int Num_IDCliente { get; set; }
        public string Nom_Cliente { get; set; }
        public int Num_IDAlimento { get; set; }
        public string Nom_Alimento { get; set; }
        public string Nom_Categoria { get; set; }
    }
}