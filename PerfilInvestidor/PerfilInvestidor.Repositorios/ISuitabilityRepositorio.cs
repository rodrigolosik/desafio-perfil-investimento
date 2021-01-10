using PerfilInvestidor.Modelos.Suitability;
using System.Collections.Generic;

namespace PerfilInvestidor.Repositorios
{
    public interface ISuitabilityRepositorio
    {
        void SalvarRelacaoUsuarioResposta(int usuarioId, int respostaId);
        void LimparRelacionamentoUsuarioResposta(int usuarioId);
        IEnumerable<UsuarioResposta> ListarRespostasPorUsuario(int usuarioId);
    }
}
