using PerfilInvestidor.Modelos.Usuario;
using System.Collections.Generic;

namespace PerfilInvestidor.Repositorios
{
    public interface IUsuarioRepositorio
    {
        void Adicionar(Usuario usuario);
        void Alterar(Usuario usuario);
        Usuario Selecionar(int id);
        IEnumerable<Usuario> Listar();
    }
}
