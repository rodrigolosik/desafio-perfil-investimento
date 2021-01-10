using PerfilInvestidor.Modelos.Enumeradores;
using PerfilInvestidor.Modelos.Usuario;
using PerfilInvestidor.Modelos.Usuario.ViewModels;
using System.Collections.Generic;
using System.Web;

namespace PerfilInvestidor.Servicos
{
    public interface IUsuarioServico
    {
        void Adicionar(CadastroViewModel usuarioViewModel);
        Usuario Pegar(int id);
        IEnumerable<Usuario> Listar();
        Usuario ValidarLogin(LoginViewModel loginViewModel);
        TipoPerfil ClassificarUsuario(ICollection<int> valores);
        void AtualizarTipoPerfil(int usurioId, ICollection<int> valores);
        HttpCookie GerarUsuarioCookie(Usuario usuario);
        HttpCookie AtualizarUsuarioCookie(Usuario usuario, HttpCookie cookie);
        Usuario PegarUsuarioCookie(HttpCookie cookie);
    }
}
