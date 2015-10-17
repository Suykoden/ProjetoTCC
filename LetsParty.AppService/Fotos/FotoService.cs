using LetsParty.Domain.Repository;
using LetsParty.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsParty.Domain.Model.Atores;
using LetsParty.AppService.Usuarios.DTO;
using System.Web.Security;
using System.Web;
using System.Security.Cryptography;
using System.IO;
using System.Net;

namespace LetsParty.AppService.Fotos
{
    public class FotoService : IFotoService
    {
        private IFotoRepository FotoRepository { get; set; }
        private ILetsPartyContext LetsPartyContext { get; set; }

        public FotoService(IFotoRepository fotoRepository, ILetsPartyContext lestPartyContext)
        {
            FotoRepository = fotoRepository;
            LetsPartyContext = lestPartyContext;
        }

        public void Grava(FotoAnuncio foto)
        {
            FotoRepository.Insert(foto);
            LetsPartyContext.SaveChanges();
        }

        

    }

}
