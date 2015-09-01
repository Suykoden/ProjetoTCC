using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsParty.Domain.Model.Atores;
using System.Data.Entity.ModelConfiguration;

namespace LetsParty.Infra.Data.DbMapping
{
    public  class FornecedorMapping : EntityTypeConfiguration<Fornecedor>
    {
        public FornecedorMapping()
        {
            HasKey(p => p.Id);

            ToTable("Fornecedor");

        }
    }
}
