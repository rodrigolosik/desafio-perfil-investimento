using System.ComponentModel.DataAnnotations;

namespace PerfilInvestidor.Modelos.Usuario.ViewModels
{
    public class CadastroViewModel
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Senha",ErrorMessage = "As senhas informadas devem coincidir.")]
        [Display(Name = "Confirmar Senha")]
        public string ConfirmarSenha { get; set; }
    }
}
