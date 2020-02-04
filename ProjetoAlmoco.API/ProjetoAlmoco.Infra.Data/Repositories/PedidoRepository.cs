using ProjetoAlmoco.Domain.Entities;
using ProjetoAlmoco.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjetoAlmoco.Infra.Data.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private Context contexto;
        SqlCommand cmd;
        public void Post(Pedido pedido)
        {
            using (cmd = new SqlCommand())
            {
                    cmd.CommandText = "InsPedido";
                    cmd.Parameters.AddWithValue("@Dat_DataPedido", pedido.Dat_DataPedido);
                    cmd.Parameters.AddWithValue("@Num_IDCliente", pedido.Num_IDCliente);
                    cmd.Parameters.AddWithValue("@Num_IDAlimento", pedido.Num_IDAlimento);

                    using (contexto = new Context())
                    {
                        contexto.ExecutaComando(cmd);
                    }
            }
        }
        public void Delete(int Num_IDPedido)
        {
            using (cmd = new SqlCommand())
            {
                cmd.CommandText = "DelPedido";
                cmd.Parameters.AddWithValue("@Num_IDPedido", Num_IDPedido);

                using (contexto = new Context())
                {
                    contexto.ExecutaComando(cmd);
                }
            }
        }
        public IEnumerable<Pedido> Get()
        {
            using (cmd = new SqlCommand())
            {
                cmd.CommandText = "SelPedido";
                cmd.Parameters.AddWithValue("@Num_id", 0);

                using (contexto = new Context())
                {
                    SqlDataReader dados = contexto.ExecutaComandoRetorno(cmd);

                    var pedidos = new List<Pedido>();

                    if (dados.Read())
                    {
                        var pedido = new Pedido
                        {
                            Num_IDPedido = Convert.ToInt32(dados["Num_IDPedido"]),
                            Dat_DataPedido = Convert.ToDateTime(dados["Dat_DataPedido"]),
                            Num_IDCliente = Convert.ToInt32(dados["Num_IDCliente"]),
                            Num_IDAlimento = Convert.ToInt32(dados["Num_IDAlimento"])
                        };

                        pedidos.Add(pedido);
                    }
                    return pedidos;
                }
            }
        }
        public IEnumerable<Pedido> GetById(int Num_IDCliente)
        {
            using (cmd = new SqlCommand())
            {
                cmd.CommandText = "SelPedido";
                cmd.Parameters.AddWithValue("@Num_id", Num_IDCliente);

                using (contexto = new Context())
                {
                    SqlDataReader dados = contexto.ExecutaComandoRetorno(cmd);

                    var pedidos = new List<Pedido>();

                    if (dados.Read())
                    {
                        var pedido = new Pedido
                        {
                            Num_IDPedido = Convert.ToInt32(dados["Num_IDPedido"]),
                            Dat_DataPedido = Convert.ToDateTime(dados["Dat_DataPedido"]),
                            Num_IDCliente = Convert.ToInt32(dados["Num_IDCliente"]),
                            Num_IDAlimento = Convert.ToInt32(dados["Num_IDAlimento"])
                        };

                        pedidos.Add(pedido);
                    }
                    return pedidos;
                }
            }
        }
    }
}
