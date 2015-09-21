using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsParty.AppService.Usuarios.DTO;
using LetsParty.Domain.Model.Atores;
using LetsParty.Domain.Repository;


namespace LetsParty.AppService.Fornecedores
{
    public interface IFornecedorServices
    {
       
        void Grava(Fornecedor fornecedor);
    }
}
