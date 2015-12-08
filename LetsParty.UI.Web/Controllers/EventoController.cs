using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LetsParty.AppService.Usuarios;
using LetsParty.AppService.Anuncios;
using LetsParty.AppService.Fotos;
using LetsParty.AppService.Servicos;
using LetsParty.AppService.Eventos;
using LetsParty.AppService.Status;
using LetsParty.AppService.Log;
using LetsParty.Domain.Model.Atores;
using LetsParty.Domain.Repository;
using LetsParty.Infra.Data.Repository;
using LetsParty.Infra.Data.Context;
using LetsParty.Domain.ViewModel;
using System.Web.Helpers;

namespace LetsParty.UI.Web.Controllers
{
    public class EventoController : Controller
    {

        private IAnunciosServices AnuncioService { get; set; }
        private IUsuarioAppService UsuarioService { get; set; }
        private IServicoServices ServicoService { get; set; }
        private IEventoService EventosService { get; set; }
        private ILetsPartyContext Context { get; set; }
        private IStatusService StatuService { get; set; }
        private IlogService LogService { get; set; }

        public EventoController(IAnunciosServices anuncioService, IUsuarioAppService usuarioService, IServicoServices servicoService,
                                IEventoService eventoService, ILetsPartyContext context, IStatusService statuService, IlogService logService)
        {
            AnuncioService = anuncioService;
            UsuarioService = usuarioService;
            ServicoService = servicoService;
            EventosService = eventoService;
            StatuService = statuService;
            LogService = logService;
            Context = context;
        }

        public ActionResult CancelamentoEvento(Guid id)
        {
            if (ModelState.IsValid)
            {
                Evento evento = EventosService.BuscaPorId(id);
                evento.EventoAtivo = false;
                EventosService.EditarEvento(evento);
                Context.SaveChanges();
            }

            return RedirectToAction("AdminListaPedido", "Admin");
        }

        [HttpPost]
        public ActionResult CadastroEvento(AnuncioViewModel _anuncio)
        {
            Evento _evento = new Evento();
            Usuario _usuario = new Usuario();
            _usuario = UsuarioService.BuscaUsuarioPorID(UsuarioService.getIDUsuario());
            _evento.UsuarioClienteID = _usuario.Id;
            _evento.UsuarioPrestadorID = _anuncio.UsuarioID;
            _evento.DataEvento = DateTime.Now;
            _evento.AnuncioID = _anuncio.AnuncioID;

            return View(_evento);
        }


        [HttpPost]
        public ActionResult SolicitacaoEvento(Evento _evento)
        {
            _evento.Id = Guid.NewGuid();
            _evento.DataSolicitacao = DateTime.Now;
            _evento.EventoAtivo = true;
            _evento.StatusID = StatuService.ObtemStatusPadrao();
            EventosService.GravaEvento(_evento);
            return RedirectToAction("AdminListaPedido", "Admin");
        }

        [HttpPost]
        public ActionResult AtualizaStatus(EventoViewModel e)
        {
            Evento evento = new Evento();
            LogEventos log = new LogEventos();

            var Status = StatuService.BuscaStatusPorID(e.StatusId);
            evento = EventosService.BuscaPorId(e.EventoID);

            log.Id = Guid.NewGuid();
            log.Data = DateTime.Now;
            log.EventoID = evento.Id;
            log.Origem = StatuService.RetornaStatusAtual(evento.StatusID);
            log.Destino = Status.status;

            evento.StatusID = e.StatusId;

            LogService.GravaLog(log);
            EventosService.UpdateStatus(evento);
            Context.SaveChanges();
            return RedirectToAction("AdminListaSolicitacoes", "Admin", new { Id = evento.AnuncioID });

        }

        [HttpPost]
        public ActionResult AvaliarEvento(EventoViewModel e)
        {

            Evento evento = new Evento();
            evento = EventosService.BuscaPorId(e.EventoID);
            evento.AvaliacaoCliente = e.NotaAnuncio;
            EventosService.UpdateStatus(evento);
            Context.SaveChanges();

            return RedirectToAction("AdminListaPedido", "Admin");

        }

    }
}