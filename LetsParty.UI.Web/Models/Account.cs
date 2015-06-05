using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace LetsParty.UI.Web.Models
{
    public class Account
    {

        
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]

        public string Senha { get; set; }
    }
}