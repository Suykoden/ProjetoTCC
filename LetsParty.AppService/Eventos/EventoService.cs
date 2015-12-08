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
        private IStatusRepository StatusRepository;
        

        public EventoService(ILetsPartyContext context, IEventoRepository eventoRepository, IAnuncioRepository anuncioRepository, IUsuarioRepository usuarioRepository, IStatusRepository statusRepository)
        {
            Context = context;
            EventoRepository = eventoRepository;
            AnuncioRepository = anuncioRepository;
            UsuarioRepository = usuarioRepository;
            StatusRepository = statusRepository;
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
            var _Status = StatusRepository.All();
            var Evento = (from e in _Evento
                          join u in _Usuario on e.UsuarioPrestadorID equals u.Id
                          join a in _Anuncios on e.AnuncioID equals a.Id
                          join s in _Status on e.StatusID equals s.Id
                          where (e.UsuarioClienteID == Id && e.EventoAtivo == true)
                          select new EventoViewModel()
                          {
                              Ativo = e.EventoAtivo,
                              EventoID = e.Id,
                              Titulo = a.Titulo,
                              Fornecedor = u.Nome,
                              Valor = a.Valor,
                              DataEvento = e.DataEvento,
                              DataSolicitacao = e.DataSolicitacao,
                              Status = s.status
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
            var _Status = StatusRepository.All();

            var Evento = (from e in _Evento
                          join u in _Usuario on e.UsuarioClienteID equals u.Id
                          join s in _Status on e.StatusID equals s.Id
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
                              Cidade = e.Cidade,
                              Status = s.status,
                              StatusId = s.Id,
                              FornecedorId = e.UsuarioPrestadorID,

                          });

            return Evento.ToList();
        }

        public void AtualizaStatus(Evento eventoAntigo, Evento eventoAtu)
        {
            EventoRepository.UpdateSet(eventoAntigo, eventoAtu);
        }

        public void UpdateStatus(Evento evento)
        {
            EventoRepository.Update(evento);
        }

        public bool SolicitaAvaliacao(Guid Id)
        {
            var Evento = EventoRepository.GetById(Id);

            if (Evento.DataEvento < DateTime.Now && Evento.AvaliacaoCliente == null)
            {
                return true;
            }
            {
                return false;
            }
        }

        public EventoViewModel ObtemNota(Guid AnuncioId)
        {
            var _Evento = EventoRepository.All().Where(e => e.AnuncioID == AnuncioId)
                .GroupBy(e => e.AnuncioID)
                .Select(g => new
                {
                    Total = g.Sum(e => e.AvaliacaoCliente),
                    Contagem = g.Count(),
                });

            EventoViewModel eventoViewModel = new EventoViewModel();
            foreach (var e in _Evento)
            {
                if (e.Contagem != 0) // evitar divisão por zero
                {
                    eventoViewModel.NotalTotal = Convert.ToDecimal(e.Total / e.Contagem);
                    eventoViewModel.TotalUsuarios = e.Contagem;
                }
            }
            return eventoViewModel;
        }


        public List<EventoViewModel> RetornaQualificacaoEventos(string Order, DateTime? DataIni, DateTime? DataFin)
        {
            var _Anuncios = AnuncioRepository.All();
            var _Usuario = UsuarioRepository.All();
            var _Evento = EventoRepository.All();
            var Evento = (from e in _Evento
                          join u in _Usuario on e.UsuarioPrestadorID equals u.Id
                          join a in _Anuncios on e.AnuncioID equals a.Id
                          where ((DataIni == null && DataFin == null) ? e.EventoAtivo == true : e.EventoAtivo == true && a.Data.Day >= DataIni.Value.Day && a.Data.Month >= DataIni.Value.Month &&
                          a.Data.Year >= DataIni.Value.Year && a.Data.Day <= DataFin.Value.Day && a.Data.Month <= DataFin.Value.Month && a.Data.Year <= DataFin.Value.Year)
                          group new { e, u, a } by new
                          {
                              e.AnuncioID,
                              a.Titulo,
                              u.Nome,
                              a.Data
                          } into g

                          select new
                  {
                      g.Key.AnuncioID,
                      g.Key.Titulo,
                      g.Key.Nome,
                      g.Key.Data,
                      Total = g.Sum(t => t.e.AvaliacaoCliente / g.Count()),

                  });

            List<EventoViewModel> ev = new List<EventoViewModel>();

            foreach (var e in Evento)
            {
                ev.Add(new EventoViewModel() { NotalTotal = e.Total, Titulo = e.Titulo, Fornecedor = e.Nome, Data = e.Data });
            }

            switch (Order)
            {
                case "name_desc":
                    ev = ev.OrderByDescending(e => e.Titulo).ToList();
                    break;
                case "Forn_desc":
                    ev = ev.OrderByDescending(e => e.Fornecedor).ToList();
                    break;
                case "Forn":
                    ev = ev.OrderBy(e => e.Fornecedor).ToList();
                    break;
                case "Nota_desc":
                    ev = ev.OrderByDescending(e => e.NotalTotal).ToList();
                    break;
                case "Nota":
                    ev = ev.OrderBy(e => e.NotalTotal).ToList();
                    break;
                case "date_desc":
                    ev = ev.OrderByDescending(e => e.Data).ToList();
                    break;
                case "Date":
                    ev = ev.OrderBy(e => e.Data).ToList();
                    break;

                default:
                    ev = ev.OrderBy(e => e.Titulo).ToList();
                    break;
            }

            return ev;
        }
    }
}
