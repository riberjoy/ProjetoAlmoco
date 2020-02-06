using ProjetoAlmoco.Domain.Entities;
using ProjetoAlmoco.Domain.Interfaces.Repository;
using ProjetoAlmoco.Domain.Interfaces.Service;

namespace ProjetoAlmoco.Domain
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public string Post(Cliente cliente)
        {
            if (_clienteRepository.Post(cliente) == 0)
                return "Cliente cadastrado com sucesso";
            else return "Dados incorretos";
        }
        public string Put(Cliente cliente)
        {
            if(_clienteRepository.Put(cliente) == 0)
                return "Dados atualizados com sucesso";
            else return "Dados incorretos";
        }
        public int ConsLogin(Cliente usuario)
        {
            var clientes = _clienteRepository.Get();
            foreach(Cliente cliente in clientes)
            {
                if(cliente.Nom_Usuario == usuario.Nom_Usuario)
                {
                    if (cliente.Num_Senha == usuario.Num_Senha)
                        return 0;
                    else
                        return 1;
                }
            }
            return 2;
        }
    }
}
