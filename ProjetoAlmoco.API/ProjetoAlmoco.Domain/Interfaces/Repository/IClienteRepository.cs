using ProjetoAlmoco.Domain.Entidades;
using System.Collections.Generic;

namespace ProjetoAlmoco.Domain.Interfaces.Repository
{
    public interface IClienteRepository
    {
        int Post(Cliente cliente);
        int Put(Cliente cliente);
        void Delete(string Nom_Usuario);
        IEnumerable<Cliente> Get();
        Cliente GetById(string Nom_Usuario);
    }
}
