using ProjetoAlmoco.Domain.Entidades;
using System.Collections.Generic;

namespace ProjetoAlmoco.Domain.Interfaces.Repository
{
    public interface ICategoriaRepository
    {
        void Post(Categoria categoria);
        void Delete(int Num_IDCategoria);
        IEnumerable<Categoria> GetById(int Num_IDCategoria);
    }
}
