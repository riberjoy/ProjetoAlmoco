using ProjetoAlmoco.Domain.Entities;
using ProjetoAlmoco.Domain.Interfaces.Repository;
using ProjetoAlmoco.Domain.Interfaces.Service;
using System.Web.Http;

namespace ProjetoAlmoco.WebApi.Controllers
{
    public class CategoriaController : ApiController
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaRepository categoriaRepository, ICategoriaService categoriaService)
        {
            _categoriaRepository = categoriaRepository;
            _categoriaService = categoriaService;
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
        public IHttpActionResult Get() => Ok(_categoriaService.SepararTodosAlimentos());
        [HttpGet, Route(template: "api/categoria/getativos")]
        public IHttpActionResult GetAtivos() => Ok(_categoriaService.SepararAlimentosAtivos());
        public IHttpActionResult GetById(int Num_IDCategoria) => Ok(_categoriaRepository.GetById(Num_IDCategoria));
    }
}
