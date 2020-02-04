namespace ProjetoAlmoco.Domain.Entities
{
    public class Alimento
    {
        public int Num_IDAlimento { get; set; }
        public string Nom_Alimento { get; set; }
        public int Num_IDCategoria { get; set; }
        public bool Ind_Ativo { get; set; }
    }
}