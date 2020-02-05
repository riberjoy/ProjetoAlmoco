using ProjetoAlmoco.Domain.Entities;
using ProjetoAlmoco.Domain.Interfaces.Repository;
using ProjetoAlmoco.Domain.Interfaces.Service;
using System.Collections.Generic;

namespace ProjetoAlmoco.Domain
{
    public class AlimentoService : IAlimentoService
    {
        private readonly IAlimentoRepository _alimentoRepository;

        public AlimentoService(IAlimentoRepository alimentoRepository)
        {
            _alimentoRepository = alimentoRepository;
        }
        public IEnumerable<Alimento> EditarCardapio()
        {
            var alimentosAtivos = _alimentoRepository.GetAtivos();
            if (alimentosAtivos != null)
                _alimentoRepository.Put(alimentosAtivos, 1);

            return alimentosAtivos;
        }
    }
}
