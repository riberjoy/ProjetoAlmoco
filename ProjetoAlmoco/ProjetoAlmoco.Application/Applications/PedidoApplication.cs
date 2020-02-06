using ProjetoAlmoco.Application.Models;
using System.Net.Http;

namespace ProjetoAlmoco.Application.Applications
{
    public class PedidoApplication
    {
        private Context contexto;
        private string URLBase = "https://localhost:44339/api/pedido";

        public HttpResponseMessage Post(Pedido pedido)
        {
            using (contexto = new Context())
            {
                return contexto.RequestPost(URLBase, pedido);
            }
        }
        public HttpResponseMessage Put(Pedido pedido)
        {
            using (contexto = new Context())
            {
                return contexto.RequestPut(URLBase, pedido);
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
        public HttpResponseMessage GetById(int Num_IDCliente)
        {
            using (contexto = new Context())
            {
                string URL = URLBase + "?Num_IDCliente=" + Num_IDCliente.ToString();
                return contexto.RequestGet(URL);
            }
        }
        public HttpResponseMessage TxtPedidos()
        {
            using (contexto = new Context())
            {
                string URL = URLBase + "/txtpedidos";
                return contexto.RequestGet(URL);
            }
        }
    }
}
