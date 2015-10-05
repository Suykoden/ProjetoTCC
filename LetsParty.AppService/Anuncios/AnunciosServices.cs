using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsParty.Domain.Model.Atores;
using LetsParty.Domain.ViewModel;
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

        public IEnumerable<Anuncio> RetornaAnuncios()
        {
            var teste = AnuncioRepository.Listar(); 
            return AnuncioRepository.Listar();
            
        }


    }
}
