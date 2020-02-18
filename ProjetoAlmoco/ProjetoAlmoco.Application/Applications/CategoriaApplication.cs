using ProjetoAlmoco.Application.Models;
using System.Net.Http;

namespace ProjetoAlmoco.Application.Applications
{
    public class CategoriaApplication
    {
        private Context contexto;
        private string URLBase = "https://localhost:44339/api/categoria";
        public HttpResponseMessage Post(Categoria categoria)
        {
            using (contexto = new Context())
            {
                return contexto.RequestPost(URLBase, categoria);
            }
        }
        public HttpResponseMessage Delete(int Num_IDCategoria)
        {
            using (contexto = new Context())
            {
                string URL = URLBase + "?Num_IDCategoria=" + Num_IDCategoria.ToString();
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
        public HttpResponseMessage GetAtivos()
        {
            using (contexto = new Context())
            {
                string URL = URLBase + "/getativos";
                return contexto.RequestGet(URL);
            }
        }
        public HttpResponseMessage GetById(int Num_IDCategoria)
        {
            using (contexto = new Context())
            {
                string URL = URLBase + "?Num_IDCategoria=" + Num_IDCategoria.ToString();
                return contexto.RequestGet(URL);
            }
        }
        public HttpResponseMessage EditarCardapio()
        {
            using (contexto = new Context())
            {
                string URL = URLBase + "/editarcardapio";
                return contexto.RequestGet(URL);
            }
        }
    }
}
