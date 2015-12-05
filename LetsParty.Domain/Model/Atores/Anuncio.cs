using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsParty.Seedwork;


namespace LetsParty.Domain.Model.Atores
{
    public class Anuncio : EntityBase
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public decimal? Valor { get; set; }
        public DateTime Data { get; set; }
        public Guid UsuarioID { get; set; }
        public Usuario usuario { get; set; }
        public Guid ServicoID { get; set; }
        public Servico servico { get; set; }
        public Boolean Ativo { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public string Cep { get; set; }
        public string Pais { get; set; }
    }
}
