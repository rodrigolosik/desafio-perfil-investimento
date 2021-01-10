using System.Collections.Generic;

namespace PerfilInvestidor.Modelos.ViewModels
{
    public class SuitabilityViewModel
    {
        public ICollection<int> RespostasIds { get; set; }
        public ICollection<int> RespostasValores { get; set; }
    }
}
