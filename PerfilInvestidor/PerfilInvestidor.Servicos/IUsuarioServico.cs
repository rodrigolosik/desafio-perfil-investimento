using PerfilInvestidor.Modelos.Usuario;
using PerfilInvestidor.Modelos.Usuario.ViewModels;
using System.Collections.Generic;

namespace PerfilInvestidor.Servicos
{
    public interface IUsuarioServico
    {
        void Adicionar(CadastroViewModel usuarioViewModel);
        void Alterar(Usuario usuario);
        Usuario Selecionar(int id);
        IEnumerable<Usuario> Listar();
        Usuario ValidarLogin(LoginViewModel loginViewModel);
    }
}
