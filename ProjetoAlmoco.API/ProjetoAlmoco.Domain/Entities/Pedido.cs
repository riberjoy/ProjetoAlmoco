using System;
using System.Collections.Generic;

namespace ProjetoAlmoco.Domain.Entidades
{
    public class Pedido
    {
        public int Num_IDPedido { get; set; }
        public DateTime Dat_DataPedido { get; set; }
        public int Num_IDCliente { get; set; }
        IEnumerable<Alimento> Alimentos { get; set; }
    }
}