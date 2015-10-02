using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsParty.Seedwork;
using LetsParty.Domain.Model.Atores;


namespace LetsParty.Domain.ViewModel
{
    public class AnuncioViewModel
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public Guid UsuarioID { get; set; }
        public Usuario usuario { get; set; }
        public Guid ServicoID { get; set; }
        public Servico servico { get; set; }
        public DateTime DataFoto { get; set; }
        public string Caminho { get; set; }
        public Guid AnuncioID { get; set; }
        public Anuncio anuncio { get; set; }
       
    }
}
