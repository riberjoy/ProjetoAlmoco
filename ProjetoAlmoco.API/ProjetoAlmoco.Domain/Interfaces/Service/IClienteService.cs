using ProjetoAlmoco.Domain.Entities;

namespace ProjetoAlmoco.Domain.Interfaces.Service
{
    public interface IClienteService
    {
        string Post(Cliente cliente);
        string Put(Cliente cliente);
        int ConsLogin(Cliente usuario);
    }
}
