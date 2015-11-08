﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LetsParty.AppService.Usuarios;
using LetsParty.AppService.Anuncios;
using LetsParty.AppService.Fotos;
using LetsParty.AppService.Servicos;
using LetsParty.AppService.Eventos;
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

        public EventoController(IAnunciosServices anuncioService, IUsuarioAppService usuarioService, IServicoServices servicoService, IEventoService eventoService, ILetsPartyContext context)
        {
            AnuncioService = anuncioService;
            UsuarioService = usuarioService;
            ServicoService = servicoService;
            EventosService = eventoService;
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
            EventosService.GravaEvento(_evento);
            return RedirectToAction("AdminListaPedido", "Admin");
        }
         [HttpPost]
        public ActionResult AdminEventoSolicitado(Guid Id)
        {
            if (UsuarioService.ObtemUsuarioLogado() != null)
            {
                var ListaModelo = new EventoViewModel
                {
                    ListaEvento = EventosService.RetornaEventos(Id).ToList()
                };

                return View(ListaModelo);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

    }
}