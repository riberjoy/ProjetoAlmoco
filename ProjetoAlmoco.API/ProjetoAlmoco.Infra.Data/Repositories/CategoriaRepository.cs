using ProjetoAlmoco.Domain.Entities;
using ProjetoAlmoco.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjetoAlmoco.Infra.Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private Context contexto;
        SqlCommand cmd;
        public void Post(Categoria categoria)
        {
                using (cmd = new SqlCommand())
                {
                    cmd.CommandText = "InsCategoria";
                    cmd.Parameters.AddWithValue("@Nom_Categoria	", categoria.Nom_Categoria);

                    using (contexto = new Context())
                    {
                        contexto.ExecutaComando(cmd);
                    }
                }
        }
        public void Delete(int Num_IDCategoria)
        {
            using (cmd = new SqlCommand())
            {
                cmd.CommandText = "DelCategoria";
                cmd.Parameters.AddWithValue("@Num_Cat", Num_IDCategoria);

                using (contexto = new Context())
                {
                    contexto.ExecutaComando(cmd);
                }
            }
        }
        public IEnumerable<Categoria> Get()
        {
            using (cmd = new SqlCommand())
            {
                cmd.CommandText = "SelCategoria";
                cmd.Parameters.AddWithValue("@Num_id", 0);

                using (contexto = new Context())
                {
                    SqlDataReader dados = contexto.ExecutaComandoRetorno(cmd);

                    var categorias = new List<Categoria>();

                    if (dados.Read())
                    {
                        var categoria = new Categoria
                        {
                            Num_IDCategoria = Convert.ToInt32(dados["Num_IDCategoria"]),
                            Nom_Categoria = dados["Nom_Categoria"].ToString()
                        };

                        categorias.Add(categoria);
                    }

                    return categorias;
                }
            }
        }
        public Categoria GetById(int Num_IDCategoria)
        {
            using (cmd = new SqlCommand())
            {
                cmd.CommandText = "SelCategoria";
                cmd.Parameters.AddWithValue("@Num_id", Num_IDCategoria);

                using (contexto = new Context())
                {
                    SqlDataReader dados = contexto.ExecutaComandoRetorno(cmd);

                    if (dados.Read())
                    {
                        var categoria = new Categoria
                        {
                            Num_IDCategoria = Convert.ToInt32(dados["Num_IDCategoria"]),
                            Nom_Categoria = dados["Nom_Categoria"].ToString()
                        };
                        return categoria;
                    }
                    return null;
                }
            }
        }
    }
}
