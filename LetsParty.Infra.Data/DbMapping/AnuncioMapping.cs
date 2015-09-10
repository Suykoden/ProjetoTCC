﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using LetsParty.Domain.Model.Servicos;
using LetsParty.Domain.Model.Atores;

namespace LetsParty.Infra.Data.DbMapping
{
    public class AnuncioMapping: EntityTypeConfiguration<Anuncio>
    {
        public AnuncioMapping()
        {
            HasKey(p => p.Id);
                                  
            ToTable("Anuncio");
        } 
        
    }
}
