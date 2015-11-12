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
        public string Categoria { get; set; }
        public string Caminho { get; set; }
        public string Thumbnail { get; set; }
        public string Caminho2 { get; set; }
        public string Thumbnail2 { get; set; }
        public string Caminho3 { get; set; }
        public string Thumbnail3 { get; set; }
        public string Busca { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public decimal? Valor { get; set; } 
        public Guid AnuncioID { get; set; }
        public Anuncio anuncio { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Pais { get; set; }
        public string Ponto_Referencia { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public int? NotaAnuncio { get; set; }
        public IEnumerable<Anuncio> ListaAnuncio { get; set; }
        public IEnumerable<AnuncioViewModel> ListaViewModel { get; set; }
       
    }
}
