using PerfilInvestidor.Modelos.Enumeradores;
using PerfilInvestidor.Modelos.Usuario;
using System.Collections.Generic;

namespace PerfilInvestidor.Repositorios
{
    public interface IUsuarioRepositorio
    {
        void Adicionar(Usuario usuario);
        IEnumerable<Usuario> Listar();
        void AtualizarTipoPerfil(int usuarioId, TipoPerfil tipoPerfil);
    }
}
