using ProjetoAlmoco.Domain.Entities;
using ProjetoAlmoco.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjetoAlmoco.Infra.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private Context contexto;
        SqlCommand cmd;
        public int Post(Cliente cliente)
        {
            using (cmd = new SqlCommand())
            {
                cmd.CommandText = "InsCliente";
                cmd.Parameters.AddWithValue("@Nom_Cliente", cliente.Nom_Cliente);
                cmd.Parameters.AddWithValue("@Nom_Usuario", cliente.Nom_Usuario);
                cmd.Parameters.AddWithValue("@Num_Senha", cliente.Num_Senha);

                using (contexto = new Context())
                {
                    return contexto.ExecutaProcedureRetorno(cmd);
                }
            }
        }
        public int Put(Cliente cliente)
        {
            using (cmd = new SqlCommand())
            {
                cmd.CommandText = "AltCliente";
                cmd.Parameters.AddWithValue("@Num_IDCliente", cliente.Num_IDCliente);
                cmd.Parameters.AddWithValue("@Nom_Cliente", cliente.Nom_Cliente);
                cmd.Parameters.AddWithValue("@Nom_Usuario", cliente.Nom_Usuario);
                cmd.Parameters.AddWithValue("@Num_Senha", cliente.Num_Senha);

                using (contexto = new Context())
                {
                    return contexto.ExecutaProcedureRetorno(cmd);
                }
            }
        }
        public void Delete(int Num_IDCliente)
        {
            using (cmd = new SqlCommand())
            {
                cmd.CommandText = "DelCliente";
                cmd.Parameters.AddWithValue("@Num_Id", Num_IDCliente);

                using (contexto = new Context())
                {
                    contexto.ExecutaComando(cmd);
                }
            }
        }
        public IEnumerable<Cliente> Get()
        {
            using (cmd = new SqlCommand())
            {
                cmd.CommandText = "SelCliente";
                cmd.Parameters.AddWithValue("@Num_Usuario", 0);

                using (contexto = new Context())
                {
                    SqlDataReader dados = contexto.ExecutaComandoRetorno(cmd);

                    var clientes = new List<Cliente>();

                    while (dados.Read())
                    {
                        var cliente = new Cliente
                        {
                            Num_IDCliente = Convert.ToInt32(dados["Num_IDCliente"]),
                            Nom_Cliente = dados["Nom_Cliente"].ToString(),
                            Nom_Usuario = dados["Nom_Usuario"].ToString()
                        };

                        clientes.Add(cliente);
                    }
                    
                    return clientes;
                }
            }
        }
        public Cliente GetById(string Nom_Usuario)
        {
            using (cmd = new SqlCommand())
            {
                cmd.CommandText = "SelCliente";
                cmd.Parameters.AddWithValue("@Num_Usuario", Nom_Usuario);

                using (contexto = new Context())
                {
                    SqlDataReader dados = contexto.ExecutaComandoRetorno(cmd);
                    
                    if (dados.Read())
                    {
                        var cliente = new Cliente
                        {
                            Num_IDCliente = Convert.ToInt32(dados["Num_IDCliente"]),
                            Nom_Cliente = dados["Nom_Cliente"].ToString(),
                            Nom_Usuario = dados["Nom_Usuario"].ToString(),
                            Num_Senha = dados["Num_Senha"].ToString()
                        };
                        return cliente;
                    }
                    return null;
                }
            }
        }
        public Cliente GetById(int Num_IDCliente)
        {
            using (cmd = new SqlCommand())
            {
                cmd.CommandText = "SelClienteId";
                cmd.Parameters.AddWithValue("@Num_IDCliente", Num_IDCliente);

                using (contexto = new Context())
                {
                    SqlDataReader dados = contexto.ExecutaComandoRetorno(cmd);

                    if (dados.Read())
                    {
                        var cliente = new Cliente
                        {
                            Num_IDCliente = Convert.ToInt32(dados["Num_IDCliente"]),
                            Nom_Cliente = dados["Nom_Cliente"].ToString(),
                            Nom_Usuario = dados["Nom_Usuario"].ToString(),
                            Num_Senha = dados["Num_Senha"].ToString()
                        };
                        return cliente;
                    }
                    return null;
                }
            }
        }
    }
}
