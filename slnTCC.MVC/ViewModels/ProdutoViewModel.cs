using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace slnTCC.MVC.ViewModels
{
    public class ProdutoViewModel
    {

        [Key]
        public int ProdutoID { get; set; }

        [Required(ErrorMessage = "Informe o nome do produto")]
        [MaxLength(ErrorMessage = "Tamanho informado inválido ,máximo de {0}")]
        [MinLength(2, ErrorMessage = "Minimo de caracetes {0}")]
        public string Nome { get; set; }

        [DataType(DataType.Currency)]
        [Range(typeof(decimal),"0","9999999999999999999")]
        [Required(ErrorMessage ="Informe o valor")]
        public decimal Valor { get; set; }

        [DisplayName("Disponível?") ]
        public bool Disponivel { get; set; }

        public int ClienteID { get; set; }
       public virtual ClienteViewModel Cliente { get; set; }
    }
}