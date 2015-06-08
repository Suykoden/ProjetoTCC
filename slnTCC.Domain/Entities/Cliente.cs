using System;
using System.Collections.Generic;

namespace slnTCC.Domain.Entities
{
    public class Cliente
    {
        public int ClienteID { get; set; }

        public string Nome { get; set; }

        public string sobrenome { get; set; }

        public string Email { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool ativo { get; set; }

        public virtual IEnumerable<Produto> Produtos { get; set; }


        public bool CLienteEspecial(Cliente cliente)
        {
            return cliente.ativo && DateTime.Now.Year - cliente.DataCadastro.Year >= 5;
        }

    }
}
