using System.Collections.Generic;

namespace ProjetoAlmoco.Application.Models
{
    public class Categoria
    {
        public int Num_IDCategoria { get; set; }
        public string Nom_Categoria { get; set; }
        public List<Alimento> Alimentos { get; set; }
    }
}