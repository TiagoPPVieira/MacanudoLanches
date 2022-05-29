using MacanudoLanches.Models;

namespace MacanudoLanches.ViewModels
{
    public class LancheListViewModel
    {
        public IEnumerable<Lanche> Lanches { get; set; }
        public string CurrentCategory { get; set; }
    }
}
