using ProjetoAlmoco.Domain.Entidades;
using System.Collections.Generic;

namespace ProjetoAlmoco.Domain.Interfaces.Repository
{
    public interface IPedidoRepository
    {
        void Post(Pedido pedido);
        void Put(Pedido pedido);
        void Delete(int Num_IDPedido);
        IEnumerable<Pedido> Get();
        Pedido GetById(int Num_IDCliente);
    }
}