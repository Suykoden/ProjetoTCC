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
            : base("BancoTCC") //nome do banco
        {

        }

        public DbSet<Cliente> Clientes { get; set; } //método para criação de tabela a partir da classe do meu dominio 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)  //Método para alterar convenções ou habilitar
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //retira plurarização na geração automática do banco
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); //Desabilita deleção em cascata
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
            .Where(p => p.Name == p.ReflectedType.Name + "Id") //Forço a qualquer palavra que venha a vir com nome e id vire chave primária
            .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar")); //Define string como varchar e não Nvarchar

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100)); //Define um tamanho para minhas strings


        }

        public override int SaveChanges()
        {
            foreach(var entry in ChangeTracker.Entries().Where(entry =>entry.Entity.GetType().GetProperty("DataCadastro") != null)){ //Varro uma mudança e caso seja datacadastro seto como datetime now e se não for adição não ocorre alteração

                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified =false;
                }


            }

           

            return base.SaveChanges();
        }

    }
}
