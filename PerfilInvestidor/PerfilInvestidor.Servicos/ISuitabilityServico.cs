using PerfilInvestidor.Modelos.Suitability;
using System.Collections.Generic;

namespace PerfilInvestidor.Servicos
{
    public interface ISuitabilityServico
    {
        Suitability Selecionar();
        void SalvarRelacaoUsuarioResposta(int usuarioId, ICollection<int> respostaIds);
        void LimparRelacionamentoUsuarioResposta(int usuarioId);
        IEnumerable<UsuarioResposta> ListarRespostasPorUsuario(int usuarioId);
    }
}
