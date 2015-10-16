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
        private IFotoRepository FotoRepository { get; set; }

        public AnunciosServices(IAnuncioRepository anunciorepository, IFotoRepository fotoRepository, ILetsPartyContext context)
        {
            AnuncioRepository = anunciorepository;
            LetsPartyContext = context;
            FotoRepository = fotoRepository;
        }

        public void Grava(Anuncio anuncio)
        {
            AnuncioRepository.Insert(anuncio);
            LetsPartyContext.SaveChanges();
        }

        public IEnumerable<Anuncio> RetornaAnuncios(Guid Id)
        {

            return AnuncioRepository.Listar().Where(a => a.UsuarioID == Id && a.Ativo == true);

        }

        public Anuncio BuscaPorId(Guid Id)
        {
            return AnuncioRepository.GetById(Id);
        }

        public void EditarAnuncio(Anuncio anuncio)
        {
            AnuncioRepository.Update(anuncio);
        }

        public IEnumerable<AnuncioViewModel> PesquisaPorDescricao(AnuncioViewModel anuncio)
        {
            var _Anuncios = AnuncioRepository.All();
            var _Fotos = FotoRepository.All();

            var AnuncioFoto = (from a in _Anuncios
                               join f in _Fotos on a.Id equals f.AnuncioID
                               where (a.Descricao.ToUpper().Contains(anuncio.Descricao.ToUpper()) && a.Ativo == true)
                               select new AnuncioViewModel()
                               {

                                   Descricao = a.Descricao,
                                   Titulo = a.Titulo,
                                   Data = a.Data,
                                   Caminho = f.Caminho
                               });

            return AnuncioFoto.ToList();

            //AnuncioRepository.All().Where(a => a.Descricao.ToUpper().Contains(anuncio.Descricao.ToUpper()) && a.Ativo == true)                                                                                                                                                                                                                                                                       ;

        }

    }
}
