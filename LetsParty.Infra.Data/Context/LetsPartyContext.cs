using LetsParty.Infra.Data.DbMapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace LetsParty.Infra.Data.Context
{
    public class LetsPartyContext : DbContext, ILetsPartyContext
    {
        public LetsPartyContext()
            : base("TCCBanco")
        {

        }
        public LetsPartyContext(string connectionString)
            : base(connectionString)
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
            modelBuilder.Configurations.Add(new AnuncioMapping());
            modelBuilder.Configurations.Add(new EventoMapping());
            modelBuilder.Configurations.Add(new PermissaoMapping());
            modelBuilder.Configurations.Add(new ServicoMapping());
            modelBuilder.Configurations.Add(new ServicoUsuarioMapping());

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); 

        }

        public System.Data.Entity.DbSet<LetsParty.Domain.Model.Atores.Usuario> Usuarios { get; set; }
        public System.Data.Entity.DbSet<LetsParty.Domain.Model.Atores.Anuncio> Anuncio { get; set; }
        public System.Data.Entity.DbSet<LetsParty.Domain.Model.Atores.Evento> Evento { get; set; }
        public System.Data.Entity.DbSet<LetsParty.Domain.Model.Atores.Permissao> Permissao { get; set; }
        public System.Data.Entity.DbSet<LetsParty.Domain.Model.Atores.Servico> Servico { get; set; }
        public System.Data.Entity.DbSet<LetsParty.Domain.Model.Atores.ServicoUsuario> ServicoUsuario { get; set; }

    }
}
