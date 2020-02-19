using ProjetoAlmoco.Application.Models;
using System.Collections.Generic;
using System.Net.Http;

namespace ProjetoAlmoco.Application.Applications
{
    public class AlimentoApplication
    {
        private Context contexto;
        private string URLBase = "https://localhost:44339/api/alimento";

        public HttpResponseMessage Post(Alimento alimento)
        {
            using (contexto = new Context())
            {
                return contexto.RequestPost(URLBase, alimento);
            }
        }
        public HttpResponseMessage Delete(int Num_IDAlimento)
        {
            using (contexto = new Context())
            {
                string URL = URLBase + "?Num_IDAlimento=" + Num_IDAlimento.ToString();
                return contexto.RequestDelete(URL);
            }
        }
        public HttpResponseMessage SalvarCardapio(IEnumerable<Alimento> alimentos)
        {
            using (contexto = new Context())
            {
                string URL = URLBase + "/salvarcardapio";
                return contexto.RequestPut(URL, alimentos);
            }
        }
        public HttpResponseMessage ZerarCardapio()
        {
            using (contexto = new Context())
            {
                string URL = URLBase + "/zerarcardapio";
                return contexto.RequestGet(URL);
            }
        }
        public HttpResponseMessage EditarCardapio()
        {
            using (contexto = new Context())
            {
                string URL = URLBase + "/salvarcardapio";
                return contexto.RequestGet(URL);
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
    }
}
