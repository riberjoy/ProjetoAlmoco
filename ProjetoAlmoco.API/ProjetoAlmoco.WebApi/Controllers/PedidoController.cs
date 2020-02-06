using ProjetoAlmoco.Domain.Entities;
using ProjetoAlmoco.Domain.Interfaces.Repository;
using ProjetoAlmoco.Domain.Interfaces.Service;
using System.Linq;
using System.Web.Http;

namespace ProjetoAlmoco.WebApi.Controllers
{
    public class PedidoController : ApiController
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoRepository pedidoRepository, IPedidoService pedidoService)
        {
            _pedidoRepository = pedidoRepository;
            _pedidoService = pedidoService;
        }
        public IHttpActionResult Post(Pedido pedido)
        {
            _pedidoRepository.Post(pedido);
            return Ok();
        }
        public IHttpActionResult Put(Pedido pedido) => Ok(_pedidoService.EditarPedido(pedido.Num_IDCliente));
        public IHttpActionResult Delete(int Num_IDCliente)
        {
            _pedidoRepository.Delete(Num_IDCliente);
            return Ok();
        }
        public IHttpActionResult Get() => Ok(_pedidoService.SepararPedidos(_pedidoRepository.Get().ToList()));
        public IHttpActionResult GetById(int Num_IDCliente) => Ok(_pedidoService.SepararPedidos(_pedidoRepository.GetById(Num_IDCliente).ToList()));
        [HttpGet, Route(template: "api/pedido/txtpedidos")]
        public IHttpActionResult TxtPedidos() => Ok(_pedidoService.TxtPedidos());
    }
}
