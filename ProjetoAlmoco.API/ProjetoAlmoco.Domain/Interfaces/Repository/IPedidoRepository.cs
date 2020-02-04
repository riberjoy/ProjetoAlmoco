using ProjetoAlmoco.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoAlmoco.Domain.Interfaces.Repository
{
    public interface IPedidoRepository
    {
        void Post(Pedido pedido);
        void Delete(int Num_IDPedido);
        IEnumerable<Pedido> Get();
        IEnumerable<Pedido> GetById(int Num_IDCliente);
    }
}