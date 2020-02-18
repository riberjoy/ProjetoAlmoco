using ProjetoAlmoco.Domain.Entities;
using ProjetoAlmoco.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjetoAlmoco.Infra.Data.Repositories
{
    public class AlimentoRepository : IAlimentoRepository
    {
        private Context contexto;
        SqlCommand cmd;
        public void Post(Alimento alimento)
        {
            using (cmd = new SqlCommand())
            {
                cmd.CommandText = "InsAlimento";
                cmd.Parameters.AddWithValue("@Nom_Alimento", alimento.Nom_Alimento);
                cmd.Parameters.AddWithValue("@Num_IDCategoria", alimento.Num_IDCategoria);
                cmd.Parameters.AddWithValue("@Ind_Ativo", 1);

                using (contexto = new Context())
                {
                    contexto.ExecutaComando(cmd);
                }
            }
        }
        public void Put(IEnumerable<Alimento> alimentos, int Ind_Ativo)
        {
            foreach (Alimento alimento in alimentos)
            {
                using (cmd = new SqlCommand())
                {
                    cmd.CommandText = "AltAlimento";
                    cmd.Parameters.AddWithValue("@Num_IDAlimento", alimento.Num_IDAlimento);
                    cmd.Parameters.AddWithValue("@Ind_Ativo", Ind_Ativo);

                    using (contexto = new Context())
                    {
                        contexto.ExecutaComando(cmd);
                    }
                }
            }
        }
        public void Delete(int Num_IDAlimento)
        {
            using (cmd = new SqlCommand())
            {
                cmd.CommandText = "DelAlimento";
                cmd.Parameters.AddWithValue("@Nom_id", Num_IDAlimento);

                using (contexto = new Context())
                {
                    contexto.ExecutaComando(cmd);
                }
            }
        }
        public IEnumerable<Alimento> Get()
        {
            using (cmd = new SqlCommand())
            {
                cmd.CommandText = "SelAlimento";
                cmd.Parameters.AddWithValue("@Num_id", 0);

                using (contexto = new Context())
                {
                    SqlDataReader dados = contexto.ExecutaComandoRetorno(cmd);

                    var alimentos = new List<Alimento>();

                    while (dados.Read())
                    {
                        var alimento = new Alimento
                        {
                            Num_IDAlimento = Convert.ToInt32(dados["Num_IDAlimento"]),
                            Nom_Alimento = dados["Nom_Alimento"].ToString(),
                            Num_IDCategoria = Convert.ToInt32(dados["Num_IDCategoria"])
                        };
                        if (Convert.ToInt32(dados["Ind_Ativo"]) == 0)
                            alimento.Ind_Ativo = true;
                        else alimento.Ind_Ativo = false;

                        alimentos.Add(alimento);
                    }

                    return alimentos;
                }
            }
        }
        public IEnumerable<Alimento> GetAtivos()
        {
            using (cmd = new SqlCommand())
            {
                cmd.CommandText = "SelAlimento";
                cmd.Parameters.AddWithValue("@Num_id", 1);

                using (contexto = new Context())
                {
                    SqlDataReader dados = contexto.ExecutaComandoRetorno(cmd);

                    var alimentos = new List<Alimento>();

                    while (dados.Read())
                    {
                        var alimento = new Alimento
                        {
                            Num_IDAlimento = Convert.ToInt32(dados["Num_IDAlimento"]),
                            Nom_Alimento = dados["Nom_Alimento"].ToString(),
                            Num_IDCategoria = Convert.ToInt32(dados["Num_IDCategoria"]),
                            Ind_Ativo = true
                        };

                        alimentos.Add(alimento);
                    }
                    return alimentos;
                }
            }
        }
    }
}

