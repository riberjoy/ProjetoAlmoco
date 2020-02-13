using ProjetoAlmoco.Domain.Entities;
using ProjetoAlmoco.Domain.Interfaces.Repository;
using ProjetoAlmoco.Domain.Interfaces.Service;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoAlmoco.Domain
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IAlimentoRepository _alimentoRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository, IAlimentoRepository alimentoRepository)
        {
            _categoriaRepository = categoriaRepository;
            _alimentoRepository = alimentoRepository;
        }

        public IEnumerable<Categoria> SepararAlimentosAtivos() 
        {
            var categoriasValidas = new List<Categoria>();
            var categorias = _categoriaRepository.Get().ToList();
            var alimentos = _alimentoRepository.GetAtivos();

            if (alimentos != null)
            {
                for (int i = 0; i < categorias.Count; i++)
                {
                    categorias[i].Alimentos = new List<Alimento>();

                    foreach (Alimento alimento in alimentos)
                        if (alimento.Num_IDCategoria == categorias[i].Num_IDCategoria)
                            categorias[i].Alimentos.Add(alimento);
                }
            }
            foreach (Categoria categoria in categorias)
                if (categoria.Alimentos.Count > 0)
                    categoriasValidas.Add(categoria);

            return categoriasValidas;
        }
        public IEnumerable<Categoria> SepararTodosAlimentos()
        {
            var categorias = _categoriaRepository.Get().ToList();
            var alimentos = _alimentoRepository.Get();

            for (int i = 0; i < categorias.Count; i++)
            {
                categorias[i].Alimentos = new List<Alimento>();

                foreach (Alimento alimento in alimentos)
                    if (alimento.Num_IDCategoria == categorias[i].Num_IDCategoria)
                        categorias[i].Alimentos.Add(alimento);
            }
            
            return categorias;
        }
    }
}
