using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace slnTCC.MVC.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public int ClienteID { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome")]
        [MaxLength(150,ErrorMessage ="Máximo de caracteres {0}")]
        [MinLength(2,ErrorMessage = "Minimo de caracetes {0}"  )]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Preencha o campo Sobrenome")]
        [MaxLength(100, ErrorMessage = "Máximo de caracteres {0}")]
        [MinLength(2, ErrorMessage = "Minimo de caracetes {0}")]
        public string sobrenome { get; set; }


        [Required(ErrorMessage = "Preencha o campo Email")]
        [MaxLength(150, ErrorMessage = "Máximo de caracteres {0}")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        public bool ativo { get; set; }

        public virtual IEnumerable<ProdutoViewModel> Produtos { get; set; }
    }
}