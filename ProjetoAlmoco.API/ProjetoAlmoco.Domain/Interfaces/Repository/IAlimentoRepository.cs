using ProjetoAlmoco.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ProjetoAlmoco.Domain.Interfaces.Repository
{
    public interface IAlimentoRepository
    {
        void Post(Alimento alimento);
        void Put(IEnumerable<Alimento> alimentos, DateTime Ind_Ativo);
        void Delete(int Num_IDAlimento);
        IEnumerable<Alimento> Get();
        IEnumerable<Alimento> GetAtivos();
    }
}
