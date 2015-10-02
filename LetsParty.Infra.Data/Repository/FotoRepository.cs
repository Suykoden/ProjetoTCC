using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsParty.Domain.Model.Atores;
using LetsParty.Domain.Repository;
using LetsParty.Infra.Data.Context;
namespace LetsParty.Infra.Data.Repository
{
   public class FotoRepository: RepositoryBase<FotoAnuncio>, IFotoRepository
    {
       public FotoRepository(ILetsPartyContext context)
            : base(context)
        {

        }
    }
}
