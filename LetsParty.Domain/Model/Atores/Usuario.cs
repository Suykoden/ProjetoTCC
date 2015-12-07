using LetsParty.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LetsParty.Domain.Model.Atores
{
    public class Usuario : EntityWithName
    {
        [Display(Name = "senha")]
        [Required(ErrorMessage = "Informe a senha", AllowEmptyStrings = false)]
        public string senha { get; set; }

        [Display(Name = "email")]
        [Required(ErrorMessage = "Informe o email", AllowEmptyStrings = false)]
        public string email { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Documento { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Ramo { get; set; }

        [Display(Name = "DataNascimento")]
        [Required(ErrorMessage = "Informe a data inicial", AllowEmptyStrings = false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataNascimento { get; set; }

        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public string Cep { get; set; }
        public string Pais { get; set; }
        public string Ponto_Referencia { get; set; }
        public string Imagem { get; set; }
        public Boolean Ativo { get; set; }
        public Guid? PerfilID { get; set; }
        public virtual Perfil perfil { get; set; }
        public bool? Administrador { get; set; }
    }
}
