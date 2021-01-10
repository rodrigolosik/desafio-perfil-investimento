using PerfilInvestidor.Modelos.Enumeradores;
using PerfilInvestidor.Modelos.Usuario;
using PerfilInvestidor.Modelos.Usuario.ViewModels;
using System.Collections.Generic;

namespace PerfilInvestidor.Servicos
{
    public interface IUsuarioServico
    {
        void Adicionar(CadastroViewModel usuarioViewModel);
        IEnumerable<Usuario> Listar();
        Usuario ValidarLogin(LoginViewModel loginViewModel);
        TipoPerfil ClassificarUsuario(ICollection<int> valores);
        void AtualizarTipoPerfil(int usurioId, ICollection<int> valores);
    }
}
