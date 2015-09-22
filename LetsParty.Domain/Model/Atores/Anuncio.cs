﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsParty.Seedwork;


namespace LetsParty.Domain.Model.Atores
{
    public class Anuncio : EntityWithCodeAndName
    {
        public string Titulo { get; set; }
        public string Categoria { get; set; }
        public float  Preco { get; set; }
        public string Cep { get; set; }
        public string Telefone { get; set; }
        public string Rua { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public string Numero { get; set; }
        public Guid FornecedorID { get; set; }
        public Fornecedor Fornecedor { get; set; }


    }
}