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
        private IUsuarioRepository UsuarioRepository { get; set; }
        private IServicoRepository ServicoRepository { get; set; }

        public AnunciosServices(IAnuncioRepository anunciorepository, IFotoRepository fotoRepository, ILetsPartyContext context, IUsuarioRepository usuarioRepository,IServicoRepository servicoRepository)
        {
            AnuncioRepository = anunciorepository;
            LetsPartyContext = context;
            FotoRepository = fotoRepository;
            UsuarioRepository = usuarioRepository;
            ServicoRepository = servicoRepository;

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
            var _Usuario = UsuarioRepository.All();
            var AnuncioFoto = (from a in _Anuncios
                               join f in _Fotos on a.Id equals f.AnuncioID
                               join u in _Usuario on a.UsuarioID equals u.Id
                              where (a.Descricao.ToUpper().Contains(anuncio.Busca.ToUpper()) && a.Ativo == true)
                               select new AnuncioViewModel()
                               {
                                   Descricao = a.Descricao,
                                   Titulo = a.Titulo,
                                   Data = a.Data,
                                   Thumbnail = f.Thumbnail,
                                   Thumbnail2 = f.Thumbnail2,
                                   Thumbnail3 = f.Thumbnail,
                                   Caminho = f.Caminho,
                                   Caminho2 = f.Caminho2,
                                   Caminho3 = f.Caminho3,
                                   Valor = a.Valor,
                                   Endereco = u.Endereco,
                                   Cep = u.Cep,
                                   Numero = u.Numero,
                                   Pais = u.Pais,
                                   Estado = u.Estado,
                                   Bairro = u.Bairro,
                                   Celular = u.Celular,
                                   Telefone = u.Telefone,
                                   Cidade = u.Cidade,
                                   NomeUsuario = u.Nome,
                                   Email = u.email,
                                   UsuarioID = a.UsuarioID,
                                   AnuncioID =  a.Id
                               });

            return AnuncioFoto.ToList();
        }
        public IEnumerable<AnuncioViewModel> PesquisaPorCategoria(String Categoria)
        {
            var _Anuncios = AnuncioRepository.All();
            var _Fotos = FotoRepository.All();
            var _Usuario = UsuarioRepository.All();
            var _Servico = ServicoRepository.All();
            var AnuncioFoto = (from a in _Anuncios
                               join f in _Fotos on a.Id equals f.AnuncioID
                               join u in _Usuario on a.UsuarioID equals u.Id
                                join s in _Servico on f.AnuncioID equals s.Id
                               where (s.Nome.ToUpper().Contains(Categoria.ToUpper()) && a.Ativo == true)
                               select new AnuncioViewModel()
                               {
                                   Descricao = a.Descricao,
                                   Titulo = a.Titulo,
                                   Data = a.Data,
                                   Thumbnail = f.Thumbnail,
                                   Thumbnail2 = f.Thumbnail2,
                                   Thumbnail3 = f.Thumbnail,
                                   Caminho = f.Caminho,
                                   Caminho2 = f.Caminho2,
                                   Caminho3 = f.Caminho3,
                                   Valor = a.Valor,
                                   Endereco = u.Endereco,
                                   Cep = u.Cep,
                                   Numero = u.Numero,
                                   Pais = u.Pais,
                                   Estado = u.Estado,
                                   Bairro = u.Bairro,
                                   Celular = u.Celular,
                                   Telefone = u.Telefone,
                                   Cidade = u.Cidade,
                                   NomeUsuario = u.Nome,
                                   Email = u.email
                               });

            return AnuncioFoto.ToList();
        }
    }
}
