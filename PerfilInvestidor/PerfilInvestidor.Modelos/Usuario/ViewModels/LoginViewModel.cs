using System.ComponentModel.DataAnnotations;

namespace PerfilInvestidor.Modelos.Usuario.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

    }
}

