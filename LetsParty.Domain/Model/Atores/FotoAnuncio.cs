using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsParty.Seedwork;

namespace LetsParty.Domain.Model.Atores
{
    public class FotoAnuncio : EntityBase
    {

        public DateTime Data { get; set; }
        public string Caminho { get; set; }
        public string Thumbnail { get; set; }
        public string Caminho2 { get; set; }
        public string Thumbnail2 { get; set; }
        public string Caminho3 { get; set; }
        public string Thumbnail3 { get; set; } 
        public Guid AnuncioID { get; set; }
        public Anuncio anuncio { get; set; }
        public Guid ServicoID { get; set; }
        public Servico servico { get; set; }
    }
}
