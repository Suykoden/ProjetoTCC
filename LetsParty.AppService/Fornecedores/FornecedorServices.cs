using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsParty.Domain.Model.Atores;
using LetsParty.Domain.Repository;
using LetsParty.Infra.Data.Context;
using System.Web.Security;
using System.Web;


namespace LetsParty.AppService.Fornecedores
{
    public class FornecedorServices : IFornecedorServices
    {
        
        private IFornecedorRepository FornecedorRepository { get; set; }
        private ILetsPartyContext LetsPartyContext { get; set; }

        public FornecedorServices(IFornecedorRepository fornecedorRepository, ILetsPartyContext context)
        {
            FornecedorRepository = fornecedorRepository;
            LetsPartyContext = context;
        }

        public void Grava(Fornecedor fornecedor)
        {
            FornecedorRepository.Insert(fornecedor);
            LetsPartyContext.SaveChanges();
        }


        public Guid getIDFornecedor()
        {


            string Login = HttpContext.Current.User.Identity.Name;

            var IdFornecedor = FornecedorRepository.All().SingleOrDefault(u => u.email == Login).Id;
            return IdFornecedor;


        }

    }
}
