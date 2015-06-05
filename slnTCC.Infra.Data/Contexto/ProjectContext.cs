using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using slnTCC.Domain.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace slnTCC.Infra.Data.Contexto
{
    public class ProjectContext : DbContext
        
    {
        public ProjectContext()
            : base("BancoTCC")
        {

        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
