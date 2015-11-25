using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsParty.Domain.Model.Atores;
using LetsParty.Domain.ViewModel;
using System.ComponentModel.DataAnnotations;

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
        public IEnumerable<EventoViewModel> ListaEvento { get; set; }
        public Boolean Ativo { get; set; }
        public string Solicitante { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Status { get; set; }
        public Guid StatusId { get; set; }
        public Guid FornecedorId { get; set; }
        public Guid AnuncioId { get; set; }
        public bool Avaliacao { get; set; }
        public int? NotaAnuncio { get; set; }
        public decimal? NotalTotal { get; set; }
        public int TotalUsuarios { get; set; }
        public string Order { get; set; }
        public DateTime Data { get; set; }

        [Display(Name = "Data inicial")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage="Data em formato inválido")]
        public DateTime? DataInicial { get; set; }

        [Display(Name = "Data final")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime? DataFinal { get; set; }

    }
}
