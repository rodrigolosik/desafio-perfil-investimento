using PerfilInvestidor.Modelos.Carteira;
using PerfilInvestidor.Repositorios;
using System.Collections.Generic;

namespace PerfilInvestidor.Servicos
{
    public class CarteiraServico : ICarteiraServico
    {
        private readonly ICarteiraRepositorio _repo = new CarteiraRepositorio();

        public IEnumerable<Carteira> Listar()
        {
            return _repo.Listar();
        }
    }
}
