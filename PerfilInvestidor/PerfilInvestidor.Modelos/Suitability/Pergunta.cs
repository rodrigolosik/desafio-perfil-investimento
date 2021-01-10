using System.Collections.Generic;

namespace PerfilInvestidor.Modelos.Suitability
{
    public class Pergunta
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public ICollection<Resposta> Respostas { get; set; } = new List<Resposta>();
    }
}
