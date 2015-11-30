using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsParty.Domain.Model.Atores;

namespace LetsParty.Domain.ViewModel
{
    public class ServicoViewModel
    {
        public string Nome { get; set; }
        public IEnumerable<Servico> ListaServico { get; set; }
    }
}
