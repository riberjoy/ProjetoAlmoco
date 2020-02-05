using ProjetoAlmoco.Domain.Entities;
using ProjetoAlmoco.Domain.Interfaces.Repository;
using System.Web.Http;

namespace ProjetoAlmoco.WebApi.Controllers
{
    public class CategoriaController : ApiController
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IHttpActionResult Post(Categoria categoria)
        {
            _categoriaRepository.Post(categoria);
            return Ok();
        }
        public IHttpActionResult Delete(int Num_IDCategoria)
        {
            _categoriaRepository.Delete(Num_IDCategoria);
            return Ok();
        }
        public IHttpActionResult Get() => Ok(_categoriaRepository.Get());
        public IHttpActionResult GetById(int Num_IDCategoria) => Ok(_categoriaRepository.GetById(Num_IDCategoria));
    }
}
