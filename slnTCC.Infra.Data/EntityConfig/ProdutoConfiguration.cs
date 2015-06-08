using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using slnTCC.Domain.Entities;

namespace slnTCC.Infra.Data.EntityConfig
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {

        public ProdutoConfiguration()
        {

            HasKey(P => P.ProdutoID);

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(250);


            Property(p => p.Valor)
                .IsRequired();

        }

    }
}
