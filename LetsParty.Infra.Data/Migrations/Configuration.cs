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
            //Àrea para inserção manual de dados em tabelas

            /*   try
               {
                   var servicoDbSet = context.Set<Servico>();
                   servicoDbSet.Add(new Servico()
                 {
                      Id = Guid.Parse("fd7b53a9-95b5-49c9-a52f-b36ef7bc76d8"),
                      Nome = "Buffet"
                 });

                  servicoDbSet.Add(new Servico()
                  {
                       Id = Guid.Parse("30373dd0-2bce-4a96-a8d4-db1b1a1a9098"),
                       Nome = "Aluguel de espaço"
                   });

                   servicoDbSet.Add(new Servico()
                   {
                       Id = Guid.Parse("d8fd6b90-1a85-4bd7-9732-b7e7ae4c3838"),
                       Nome = "Aluguel de peças"
                   });

                   servicoDbSet.Add(new Servico()
                  {
                      Id = Guid.Parse("ce3643f7-e2f8-4b9c-864c-9056cc961493"),
                      Nome = "Pegue e monte"
                  });

                   context.SaveChanges();
               }
               catch (Exception)
               {


               }*/


            /*   try
               {
                   var servicoDbSet = context.Set<StatusEvento>();

                   servicoDbSet.Add(new StatusEvento()
                   {

                       Id = Guid.Parse("cd0da356 - f054-45a2-85e0-37b0d74da8ff"),
                       status = "Aguardando análise do fornecedor"
                   });

                   servicoDbSet.Add(new StatusEvento()
                   {

                       Id = Guid.Parse("f39e7794-58de-423a-ab07-a2f3957a0855"),
                       status = "Agendado"
                   });

                   servicoDbSet.Add(new StatusEvento()
                   {

                       Id = Guid.Parse("dc50fcc3-7134-45ce-a331-a7c0261a5236"),
                       status = "Solicitação recusada"
                   });

                   servicoDbSet.Add(new StatusEvento()
                   {

                       Id = Guid.Parse("30cbd91b-b4ef-40ad-bd17-d61e3dff7e6c"),
                       status = "Solicitação finalizada"
                   });


                   context.SaveChanges();
               }
               catch (Exception)
               {


               */
        }
    }
}

