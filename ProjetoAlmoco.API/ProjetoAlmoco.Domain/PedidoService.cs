using ProjetoAlmoco.Domain.Entities;
using ProjetoAlmoco.Domain.Interfaces.Repository;
using ProjetoAlmoco.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoAlmoco.Domain
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }
        public IEnumerable<Pedido> EditarPedido(int Num_IDCliente)
        {
            var pedidos = _pedidoRepository.GetById(Num_IDCliente);
            _pedidoRepository.Delete(Num_IDCliente);
            return pedidos;
        }

        public IEnumerable<PedidoCliente> SepararPedidos(List<Pedido> pedidos)
        {
            var pedidosSeparados = new List<PedidoCliente>();

            var categoriaAlimento = new List<string>();

            var pedidoAux = pedidos[0];

            foreach(Pedido pedido in pedidos)
            {
                if(pedidoAux.Num_IDCliente != pedido.Num_IDCliente)
                {
                    var pedidoCliente = new PedidoCliente
                    {
                        Num_IDCliente = pedidoAux.Num_IDCliente,
                        Nom_Cliente = pedidoAux.Nom_Cliente,
                        CategoriaAlimento = categoriaAlimento
                    };

                    pedidosSeparados.Add(pedidoCliente);

                    categoriaAlimento.Clear();
                }
                
                categoriaAlimento.Add(pedido.Nom_Categoria + ": " + pedido.Nom_Alimento);

                pedidoAux = pedido;
            }

            var pedidocliente = new PedidoCliente
            {
                Num_IDCliente = pedidoAux.Num_IDCliente,
                Nom_Cliente = pedidoAux.Nom_Cliente,
                CategoriaAlimento = categoriaAlimento
            };

            pedidosSeparados.Add(pedidocliente);

            return pedidosSeparados;
        }

        public string TxtPedidos()
        {
            string txtPedidos = "";

            var pedidos = SepararPedidos(_pedidoRepository.Get().ToList());

            foreach(PedidoCliente pedidoCliente in pedidos)
            {
                txtPedidos += pedidoCliente.Nom_Cliente;
                
                foreach(string categoriaAlimento in pedidoCliente.CategoriaAlimento)
                {
                    txtPedidos += string.Format("{0}" + categoriaAlimento, Environment.NewLine);
                }
                txtPedidos += string.Format("{0}{0}", Environment.NewLine); 
            }

            return txtPedidos;
        }
    }
}
