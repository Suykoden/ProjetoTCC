using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using slnTCC.Domain.Entities;

namespace slnTCC.Infra.Data.EntityConfig
{
   public class clienteConfiguration : EntityTypeConfiguration<Cliente>  //permite determinar comportamentos exclusivos para a minha tabela cliente  
    {
       public clienteConfiguration()
       {
           HasKey(C => C.ClienteID);   ///Chave primária 

       }

    }
}
