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
    public class AnuncioRepositorio : RepositoryBase<Anuncio>, IAnuncioRepository
    {
        public AnuncioRepositorio(ILetsPartyContext context)
            : base(context)
        {

        }

    }
}
