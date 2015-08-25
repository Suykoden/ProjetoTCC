namespace LetsParty.Infra.Data.Migrations
{
    using LetsParty.Domain.Model.Atores;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LetsParty.Infra.Data.Context.LetsPartyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(LetsParty.Infra.Data.Context.LetsPartyContext context)
        {
            //try
            //{



            //var usuarioDbSet = context.Set<Usuario>();         

            //usuarioDbSet.Add(new Usuario()
            //{
            //    Id = Guid.Parse("fd7b53a9-95b5-49c9-a52f-b36ef7bc76d8"),
            //    Codigo = "1",
            //    Nome = "Rafael Damasio"
            //});

            //usuarioDbSet.Add(new Usuario()
            //{
            //    Id = Guid.Parse("30373dd0-2bce-4a96-a8d4-db1b1a1a9098"),
            //    Codigo = "2",
            //    Nome = "Juan Carlos"
            //});

            //usuarioDbSet.Add(new Usuario()
            //{
            //    Id = Guid.Parse("d8fd6b90-1a85-4bd7-9732-b7e7ae4c3838"),
            //    Codigo = "3",
            //    Nome = "Arthur"
            //});

            //usuarioDbSet.Add(new Usuario()
            //{
            //    Id = Guid.Parse("ce3643f7-e2f8-4b9c-864c-9056cc961493"),
            //    Codigo = "4",
            //    Nome = "Celso"
            //});

            //context.SaveChanges();
            //}
            //    catch (Exception)
            //    {


            //    }
            //}
        }
    }
}
