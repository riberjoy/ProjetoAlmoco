using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ProjetoAlmoco.Application.Models
{
    public class Cliente
    {
        public int Num_IDCliente { get; set; }
        [Required(ErrorMessage = "Necessário inserir o nome do cliente!")]
        public string Nom_Cliente { get; set; }
        [Required(ErrorMessage = "Necessário inserir um nome de usuário válido!")]
        [MaxLength(10, ErrorMessage = "Máximo de 20 caracteres")]
        [MinLength(5, ErrorMessage = "Mínimo de 5 caracteres")]
        [Remote("LoginUnico", "Login", ErrorMessage = "Nome de usuário já existe")]
        public string Nom_Usuario { get; set; }
        [Required(ErrorMessage = "Necessário inserir a senha!")]
        [MaxLength(20, ErrorMessage = "Máximo de 20 caracteres")]
        [MinLength(5, ErrorMessage = "Mínimo de 5 caracteres")]
        public string Num_Senha { get; set; }
        [System.ComponentModel.DataAnnotations.Compare(nameof(Num_Senha), ErrorMessage = "Senhas não coincidem!")]
        public string ConfirmaSenha { get; set; }
    }
}
