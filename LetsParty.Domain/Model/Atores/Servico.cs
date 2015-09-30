using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsParty.Seedwork;

namespace LetsParty.Domain.Model.Atores
{
   public  class Servico: EntityWithName
    {
       public string NomeServico { get; set; }
        public float Valor { get; set; }
    }
}
