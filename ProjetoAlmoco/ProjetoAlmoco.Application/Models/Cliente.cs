using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ProjetoAlmoco.Application.Models
{
    public class Cliente
    {
        public int Num_IDCliente { get; set; }
        [Required(ErrorMessage = "Necessário inserir o nome do cliente!")]
        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres")]
        [MinLength(5, ErrorMessage = "Mínimo de 5 caracteres")]
        public string Nom_Cliente { get; set; }
        [Required(ErrorMessage = "Necessário inserir um nome de usuário válido!")]
        [MaxLength(15, ErrorMessage = "Máximo de 15 caracteres")]
        [MinLength(5, ErrorMessage = "Mínimo de 5 caracteres")]
        [Remote("LoginUnico", "Login", ErrorMessage = "Nome de usuário já existe")]
        public string Nom_Usuario { get; set; }
        [Required(ErrorMessage = "Necessário inserir a senha!")]
        [MaxLength(15, ErrorMessage = "Máximo de 15 caracteres")]
        [MinLength(5, ErrorMessage = "Mínimo de 5 caracteres")]
        public string Num_Senha { get; set; }
        [System.ComponentModel.DataAnnotations.Compare(nameof(Num_Senha), ErrorMessage = "Senhas não coincidem!")]
        [MaxLength(15, ErrorMessage = "Máximo de 15 caracteres")]
        [MinLength(5, ErrorMessage = "Mínimo de 5 caracteres")]
        public string ConfirmaSenha { get; set; }
    }
}
