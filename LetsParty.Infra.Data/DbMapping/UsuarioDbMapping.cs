using LetsParty.Domain.Model.Atores;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace LetsParty.Infra.Data.DbMapping
{
    public class UsuarioDbMapping : EntityTypeConfiguration<Usuario>
    {
        public UsuarioDbMapping()
        {
            HasKey(p => p.Id);
            //Property(u => u.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                        
            ToTable("Usuarios");
        }
    }
}
