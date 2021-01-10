using PerfilInvestidor.Modelos.Carteira;
using System.Collections.Generic;

namespace PerfilInvestidor.Repositorios
{
    public interface ICarteiraRepositorio
    {
        IEnumerable<Carteira> Listar();
    }
}
