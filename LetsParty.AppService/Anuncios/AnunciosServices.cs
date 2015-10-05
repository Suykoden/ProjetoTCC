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
namespace LetsParty.AppService.Anuncios
{
    public class AnunciosServices : IAnunciosServices
    {
        private IAnuncioRepository AnuncioRepository { get; set; }
        private ILetsPartyContext LetsPartyContext { get; set; }

        public AnunciosServices(IAnuncioRepository anunciorepository, ILetsPartyContext context)
        {
            AnuncioRepository = anunciorepository;
            LetsPartyContext = context;
        }

        public void Grava(Anuncio anuncio)
        {
            AnuncioRepository.Insert(anuncio);
            LetsPartyContext.SaveChanges();
        }

        public IQueryable<Anuncio> RetornaAnuncios(Guid id)
        {
            Anuncio anuncio = new Anuncio();
            return AnuncioRepository.All().Where(a => anuncio.Id == id);
        }


    }
}
