﻿using LetsParty.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsParty.Domain.Model.Atores
{
    public class Usuario : EntityWithName
    {
        public string senha { get; set; }
        public string email { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Documento { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Ramo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Pais { get; set; }
        public string Ponto_Referencia { get; set; }
        public string Imagem { get; set; }
        public string Ativo { get; set; }
        public Guid? PerfilID{ get; set; }
        public virtual Perfil perfil { get; set; }


    }
}
