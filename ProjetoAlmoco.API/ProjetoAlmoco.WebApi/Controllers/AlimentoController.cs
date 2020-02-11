using ProjetoAlmoco.Domain.Entities;
using ProjetoAlmoco.Domain.Interfaces.Repository;
using ProjetoAlmoco.Domain.Interfaces.Service;
using System.Collections.Generic;
using System.Web.Http;

namespace ProjetoAlmoco.WebApi.Controllers
{
    public class AlimentoController : ApiController
    {
        private readonly IAlimentoRepository _alimentoRepository;
        private readonly IAlimentoService _alimentoService;

        public AlimentoController(IAlimentoRepository alimentoRepository, IAlimentoService alimentoService)
        {
            _alimentoRepository = alimentoRepository;
            _alimentoService = alimentoService;
        }
        public IHttpActionResult Post(Alimento alimento)
        {
            _alimentoRepository.Post(alimento);
            return Ok();
        }
        public IHttpActionResult Delete(int Num_IDAlimento)
        {
            _alimentoRepository.Delete(Num_IDAlimento);
            return Ok();
        }
        [HttpPut, Route(template: "api/alimento/salvarcardapio")]
        public IHttpActionResult SalvarCardapio(IEnumerable<Alimento> alimentos)
        {
            if(alimentos != null)
                _alimentoRepository.Put(alimentos, 0);
            return Ok();
        }
        [HttpGet, Route(template: "api/alimento/editarcardapio")]
        public IHttpActionResult EditarCardapio() => Ok(_alimentoService.EditarCardapio());
    }
}
