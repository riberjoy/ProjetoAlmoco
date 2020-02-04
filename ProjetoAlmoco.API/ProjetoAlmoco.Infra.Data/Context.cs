using System;
using System.Data;
using System.Data.SqlClient;

namespace ProjetoAlmoco.Infra.Data
{
    public class Context:IDisposable
    {
        private SqlConnection minhaConexao;

        public Context()
        {
            string _connectionString = "Data Source=ESTAGIO12\\SQLEXPRESS;Initial Catalog=ProjetoAlmoco;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            minhaConexao = new SqlConnection(_connectionString);
            minhaConexao.Open();
        }

        public void ExecutaComando(SqlCommand cmd)
        {
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = minhaConexao;

            cmd.ExecuteNonQuery();
        }

        public SqlDataReader ExecutaComandoRetorno(SqlCommand cmd)
        {
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = minhaConexao;
            return cmd.ExecuteReader();
        }

        public int ExecutaProcedureRetorno(SqlCommand cmd)
        {
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = minhaConexao;

            var returnParameter = cmd.Parameters.Add("@RetornoProc", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            cmd.ExecuteNonQuery();

            return (int)returnParameter.Value;
        }

        public void Dispose()
        {
            if (minhaConexao.State == System.Data.ConnectionState.Open)
                minhaConexao.Close();
        }
    }
}
