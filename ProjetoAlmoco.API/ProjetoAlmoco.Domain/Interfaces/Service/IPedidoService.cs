using ProjetoAlmoco.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoAlmoco.Domain.Interfaces.Service
{
    public interface IPedidoService
    {
        string TxtPedidos();
        IEnumerable<Pedido> EditarPedido(int Num_IDCliente);
        IEnumerable<PedidoCliente> SepararPedidos(List<Pedido> pedidos);
    }
}
