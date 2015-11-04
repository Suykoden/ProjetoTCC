using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsParty.Domain.Model.Atores;
using LetsParty.Domain.ViewModel;

namespace LetsParty.Domain.ViewModel
{
   public class EventoViewModel
    {
       public Guid EventoID { get; set; }
       public string Titulo { get; set; }
       public DateTime DataSolicitacao { get; set; }
       public decimal? Valor { get; set; }
       public DateTime DataEvento { get; set; }
       public string Fornecedor { get; set; }
       public IEnumerable<EventoViewModel> ListaEvento {get;set;}
       public Boolean Ativo { get; set; }
    }
}
