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
    public class RelatoriosController : Controller
    {
        private IAnunciosServices AnuncioService { get; set; }
        private IUsuarioAppService UsuarioService { get; set; }
        private IServicoServices ServicoService { get; set; }
        private IEventoService EventoService { get; set; }
        private IStatusService StatusService { get; set; }

        public RelatoriosController(IAnunciosServices anuncioService, IUsuarioAppService usuarioService, IServicoServices servicoService, IEventoService eventoService, IStatusService statusService)
        {
            AnuncioService = anuncioService;
            UsuarioService = usuarioService;
            ServicoService = servicoService;
            EventoService = eventoService;
            StatusService = statusService;
        }



        public ActionResult RelatorioQualificacao(string sortOrder, DateTime? DataIni, DateTime? DataFin)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.FornSortParm = sortOrder == "Forn" ? "Forn_desc" : "Forn";
            ViewBag.NotaSortParm = sortOrder == "Nota" ? "Nota_desc" : "Nota";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (UsuarioService.ObtemUsuarioLogado() != null)
            {
                var ListaModelo = new EventoViewModel
                {
                    ListaEvento = EventoService.RetornaQualificacaoEventos(sortOrder, DataIni, DataFin),
                    DataInicial = DataIni,
                    DataFinal = DataFin
                };

                return View(ListaModelo);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        [HttpPost]
        public ActionResult RelatorioPorData(EventoViewModel Model)
        {
            return RedirectToAction("RelatorioQualificacao", "Relatorios", new { sortOrder = ViewBag.DateSortParm, DataIni = Model.DataInicial, DataFin = Model.DataFinal });
        }
    }
}