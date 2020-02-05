using ProjetoAlmoco.Domain.Entities;
using ProjetoAlmoco.Domain.Interfaces.Repository;
using ProjetoAlmoco.Domain.Interfaces.Service;
using System.Web.Http;

namespace ProjetoAlmoco.WebApi.Controllers
{
    public class ClienteController : ApiController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteRepository clienteRepository, IClienteService clienteService)
        {
            _clienteRepository = clienteRepository;
            _clienteService = clienteService;
        }
        public IHttpActionResult Post(Cliente cliente) => Ok(_clienteService.Post(cliente));
        public IHttpActionResult Put(Cliente cliente) => Ok(_clienteService.Put(cliente));
        public IHttpActionResult Delete(int Num_IDCliente)
        {
            _clienteRepository.Delete(Num_IDCliente);
            return Ok();
        }

        public IHttpActionResult Get() => Ok(_clienteRepository.Get());

        public IHttpActionResult GetById(string Nom_Usuario) => Ok(_clienteRepository.GetById(Nom_Usuario));
        [HttpGet, Route(template: "api/cliente/conslogin")]
        public IHttpActionResult ConsLogin(Cliente usuario)
        {
            var retorno = _clienteService.ConsLogin(usuario);

            if (retorno == 0)
            {
                var cliente = _clienteRepository.GetById(usuario.Nom_Usuario);
                cliente.Num_Senha = null;
                return Ok(cliente);
            }
            else if (retorno == 1)
                return Ok("Senha incorreta");
            else
                return Ok("Usuário não encontrado");
        }
    }
}
