using ProjetoAlmoco.Application.Models;
using System.Net.Http;

namespace ProjetoAlmoco.Application.Applications
{
    public class ClienteApplication
    {
        private Context contexto;
        private string URLBase = "https://localhost:44339/api/cliente";
        public HttpResponseMessage Post(Cliente cliente)
        {
            using (contexto = new Context())
            {
                return contexto.RequestPost(URLBase, cliente);
            }
        }
        public HttpResponseMessage Put(Cliente cliente)
        {
            using (contexto = new Context())
            {
                return contexto.RequestPut(URLBase, cliente);
            }
        }
        public HttpResponseMessage Delete(int Num_IDCliente)
        {
            using (contexto = new Context())
            {
                string URL = URLBase + "?Num_IDCliente=" + Num_IDCliente.ToString();
                return contexto.RequestDelete(URL);
            }
        }
        public HttpResponseMessage Get()
        {
            using (contexto = new Context())
            {
                string URL = URLBase;
                return contexto.RequestGet(URL);
            }
        }
        public HttpResponseMessage GetById(string Nom_Usuario)
        {
            using (contexto = new Context())
            {
                string URL = URLBase + "?Nom_Usuario=" + Nom_Usuario.ToString();
                return contexto.RequestGet(URL);
            }
        }
        public HttpResponseMessage ConsLogin(Cliente usuario)
        {
            using (contexto = new Context())
            {
                string URL = URLBase + "/conslogin";
                return contexto.RequestPost(URL, usuario);
            }
        }
    }
}
