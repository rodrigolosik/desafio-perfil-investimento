using System.ComponentModel.DataAnnotations;

namespace PerfilInvestidor.Modelos.Usuario
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
