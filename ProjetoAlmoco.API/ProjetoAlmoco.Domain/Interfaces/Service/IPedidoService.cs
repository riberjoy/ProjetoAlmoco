using ProjetoAlmoco.Domain.Entities;

namespace ProjetoAlmoco.Domain.Interfaces.Service
{
    public interface IPedidoService
    {
        string txtPedido();
        Pedido EditarPedido(Pedido pedido);
    }
}
