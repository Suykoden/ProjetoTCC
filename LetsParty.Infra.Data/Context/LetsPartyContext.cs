using LetsParty.Infra.Data.DbMapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UsuarioDbMapping());
        }

    }
}
