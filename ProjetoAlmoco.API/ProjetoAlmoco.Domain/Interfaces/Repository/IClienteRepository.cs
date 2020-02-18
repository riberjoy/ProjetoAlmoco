using ProjetoAlmoco.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoAlmoco.Domain.Interfaces.Repository
{
    public interface IClienteRepository
    {
        int Post(Cliente cliente);
        int Put(Cliente cliente);
        void Delete(int Num_IDCliente);
        IEnumerable<Cliente> Get();
        Cliente GetById(string Nom_Usuario);
        Cliente GetById(int Num_IDCliente);
    }
}
