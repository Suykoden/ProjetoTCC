﻿using LetsParty.Infra.Data.DbMapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
 

namespace LetsParty.Infra.Data.Context
{
    public class LetsPartyContext : DbContext, ILetsPartyContext
    {
        public LetsPartyContext() : base("TCCBanco")
        {

        }
        public LetsPartyContext(string connectionString) : base(connectionString)
        {

        }

        public DbContext Context
        {
            get
            {
                return this;
            }
        }

        public void SaveChanges()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UsuarioDbMapping());
            modelBuilder.Configurations.Add(new FornecedorMapping());
            modelBuilder.Configurations.Add(new AnuncioMapping());

        }

        public System.Data.Entity.DbSet<LetsParty.Domain.Model.Atores.Usuario> Usuarios { get; set; }
        public System.Data.Entity.DbSet<LetsParty.Domain.Model.Atores.Fornecedor> Fornecedor { get; set; }
        public System.Data.Entity.DbSet<LetsParty.Domain.Model.Atores.Anuncio> Anuncio { get; set; }

    }
}
