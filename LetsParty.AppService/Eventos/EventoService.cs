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



namespace LetsParty.AppService.Eventos
{
    public class EventoService : IEventoService
    {
        private ILetsPartyContext Context;
        private IEventoRepository EventoRepository;
        private IAnuncioRepository AnuncioRepository;
        private IUsuarioRepository UsuarioRepository;

        public EventoService(ILetsPartyContext context, IEventoRepository eventoRepository, IAnuncioRepository anuncioRepository, IUsuarioRepository usuarioRepository)
        {
            Context = context;
            EventoRepository = eventoRepository;
            AnuncioRepository = anuncioRepository;
            UsuarioRepository = usuarioRepository;
        }

        public void GravaEvento(Evento evento)
        {
            EventoRepository.Insert(evento);
            Context.SaveChanges();
        }

        public IEnumerable<EventoViewModel> RetornaEventos(Guid Id)
        {
            var _Anuncios = AnuncioRepository.All();
            var _Usuario = UsuarioRepository.All();
            var _Evento = EventoRepository.All();
            var Evento = (from e in _Evento
                          join u in _Usuario on e.UsuarioPrestadorID equals u.Id
                          join a in _Anuncios on e.AnuncioID equals a.Id
                          where (e.UsuarioClienteID == Id && e.EventoAtivo == true)
                          select new EventoViewModel()
                          {
                              Ativo = e.EventoAtivo,
                              EventoID = e.Id,
                              Titulo = a.Titulo,
                              Fornecedor = u.Nome,
                              Valor = a.Valor,
                              DataEvento = e.DataEvento,
                              DataSolicitacao = e.DataSolicitacao
                          });

            return Evento.ToList();
        }
        public void EditarEvento(Evento evento)
        {
            EventoRepository.Update(evento);
        }

        public Evento BuscaPorId(Guid Id)
        {
            return EventoRepository.GetById(Id);
        }

        public IEnumerable<EventoViewModel> RetornaEventoSolicitado(Guid Id)
        {
             var _Evento = EventoRepository.All();
             var _Usuario = UsuarioRepository.All();

            var Evento = (from e in _Evento
                          join u in _Usuario on e.UsuarioClienteID equals u.Id
                          where (e.AnuncioID == Id && e.EventoAtivo == true)
                          select new EventoViewModel()
                          {
                              EventoID = e.Id,
                              DataEvento = e.DataEvento,
                              DataSolicitacao = e.DataSolicitacao,
                              Solicitante = u.Nome,
                              Endereco = e.Endereco,
                              Numero = e.Numero,
                              Bairro = e.Bairro,
                              Cidade = e.Cidade
                          });

            return Evento.ToList();
        }
    }
}
