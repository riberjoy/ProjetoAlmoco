using ProjetoAlmoco.Domain.Entidades;

namespace ProjetoAlmoco.Domain.Interfaces.Service
{
    public interface IPedidoService
    {
        string txtPedido();
        Pedido EditarPedido(Pedido pedido);
        Pedido GetPorUsuario(int Num_IDCliente);
    }
}
