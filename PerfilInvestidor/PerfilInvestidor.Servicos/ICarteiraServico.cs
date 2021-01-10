using PerfilInvestidor.Modelos.Carteira;
using System.Collections.Generic;

namespace PerfilInvestidor.Servicos
{
    public interface ICarteiraServico
    {
        IEnumerable<Carteira> Listar();
    }
}
