using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsParty.Seedwork;

namespace LetsParty.Domain.Model.Atores
{
    public class Evento : EntityBase
    {
        public DateTime DataSolicitacao { get; set; }
        public DateTime DataEvento { get; set; }
        public DateTime? DataCancelamento { get; set; }
        public string MotivoCancelamento { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Pais { get; set; }
        public string Ponto_Referencia { get; set; }
        public string Depoimento { get; set; }
        public int? AvaliacaoCliente { get; set; }
        public int? AvaliacaoFornecedor { get; set; }
        public Guid UsuarioPrestadorID { get; set; }
        public Usuario UsuarioPrestador { get; set; }
        public Guid UsuarioClienteID { get; set; }
        public Usuario UsuarioCliente { get; set; }
        public Boolean EventoAtivo { get; set; }
        public Guid AnuncioID { get; set; }
        public Anuncio Anuncio { get; set; }
    }
}
