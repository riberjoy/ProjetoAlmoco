using ProjetoAlmoco.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoAlmoco.Domain.Interfaces.Service
{
    public interface ICategoriaService
    {
        IEnumerable<Categoria> SepararAlimentosAtivos();
        IEnumerable<Categoria> SepararTodosAlimentos();
    }
}
