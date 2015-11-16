﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LetsParty.AppService.Usuarios;
using LetsParty.AppService.Anuncios;
using LetsParty.AppService.Eventos;
using LetsParty.AppService.Fotos;
using LetsParty.AppService.Servicos;
using LetsParty.AppService.Status;
using LetsParty.Domain.Model.Atores;
using LetsParty.Domain.Repository;
using LetsParty.Infra.Data.Repository;
using LetsParty.Infra.Data.Context;
using LetsParty.Domain.ViewModel;

namespace LetsParty.UI.Web.Controllers
{
    public class AdminController : Controller
    {

        private IAnunciosServices AnuncioService { get; set; }
        private IUsuarioAppService UsuarioService { get; set; }
        private IServicoServices ServicoService { get; set; }
        private IEventoService EventoService { get; set; }
        private IStatusService StatusService { get; set; }

        public AdminController(IAnunciosServices anuncioService, IUsuarioAppService usuarioService, IServicoServices servicoService, IEventoService eventoService, IStatusService statusService)
        {
            AnuncioService = anuncioService;
            UsuarioService = usuarioService;
            ServicoService = servicoService;
            EventoService = eventoService;
            StatusService = statusService;
        }

        public ActionResult Administrativo()
        {
            if (UsuarioService.ObtemUsuarioLogado() != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        public ActionResult AdminEdicaoAnuncio(Guid id)
        {
            Anuncio anuncio = AnuncioService.BuscaPorId(id);
            AnuncioViewModel _AnuncioViewModel = new AnuncioViewModel();
            _AnuncioViewModel.Titulo = anuncio.Titulo;
            _AnuncioViewModel.Descricao = anuncio.Descricao;
            _AnuncioViewModel.Id = anuncio.Id;
            _AnuncioViewModel.Data = anuncio.Data;
            _AnuncioViewModel.ServicoID = anuncio.ServicoID;
            _AnuncioViewModel.UsuarioID = anuncio.UsuarioID;

            ViewBag.ListaServico = ServicoService.RetornaServicos().ToList();
            return View(_AnuncioViewModel);
        }

        public ActionResult AdminListaAnuncio()
        {
            if (UsuarioService.ObtemUsuarioLogado() != null)
            {
                var ListaModelo = new AnuncioViewModel
                {
                    ListaAnuncio = AnuncioService.RetornaAnuncios(UsuarioService.getIDUsuario()).ToList()

                };

                return View(ListaModelo);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }

        }

        public ActionResult AdminListaUsuario()
        {
            if (UsuarioService.ObtemUsuarioLogado() != null)
            {
                var IdUsuario = UsuarioService.getIDUsuario();
                return View(UsuarioService.BuscaUsuarioPorID(IdUsuario));
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }

        }

        public ActionResult AdminEdicaoUsuario(Guid Id)
        {
            return View(UsuarioService.BuscaUsuarioPorID(Id));
        }

        public ActionResult AdminListaPedido()
        {
            if (UsuarioService.ObtemUsuarioLogado() != null)
            {
                var ListaModelo = new EventoViewModel
                {
                    ListaEvento = EventoService.RetornaEventos(UsuarioService.getIDUsuario()).ToList()
                };

                foreach (var lista in ListaModelo.ListaEvento)
                {
                    if (EventoService.SolicitaAvaliacao(lista.EventoID))
                    {

                        lista.Avaliacao = true;
                    }
                    else
                    {
                        lista.Avaliacao = false;
                    }
                }

                return View(ListaModelo);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }

        }


        public ActionResult AdminListaSolicitacoes(Guid Id)
        {
            if (UsuarioService.ObtemUsuarioLogado() != null)
            {
                var ListaModelo = new EventoViewModel
                {
                    ListaEvento = EventoService.RetornaEventoSolicitado(Id).ToList()
                };

                ViewBag.ListaStatus = StatusService.RetornaStatus();
                return View(ListaModelo);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }


        public ActionResult AdminRelatorios()
        {
            return View();
        }

    }
}