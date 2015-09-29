using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsParty.Seedwork;

namespace LetsParty.Domain.Model.Atores
{
    public class LogEventos : EntityBase
    {
        public DateTime Data { get; set; }
        public Guid EventoID { get; set; }
        public Evento evento { get; set; }
        public int Origem { get; set; }
        public int Destino { get; set; }
    }
}
