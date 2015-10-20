using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsParty.Seedwork;
using LetsParty.Domain.Model.Atores;


namespace LetsParty.Domain.ViewModel
{
    public class AnuncioViewModel:EntityBase
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
        public string Thumbnail { get; set; }
        public string Caminho2 { get; set; }
        public string Thumbnail2 { get; set; }
        public string Caminho3 { get; set; }
        public string Thumbnail3 { get; set; }
        public string Busca { get; set; }
        public decimal? Valor { get; set; } 
        public Guid AnuncioID { get; set; }
        public Anuncio anuncio { get; set; }
        public IEnumerable<Anuncio> ListaAnuncio { get; set; }
        public IEnumerable<AnuncioViewModel> ListaViewModel { get; set; }
       
    }
}
