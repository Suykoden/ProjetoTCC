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

            HasKey(P => P.ProdutoID);  ///Define chave primárioa 

            Property(p => p.Nome)   ///torna campo obrigatório  e com tamanho máximo de 250
                .IsRequired()
                .HasMaxLength(250);


            Property(p => p.Valor)
                .IsRequired();

            HasRequired(p => p.Cliente)
                .WithMany()
                .HasForeignKey(p => p.ClienteID);




        }

    }
}
