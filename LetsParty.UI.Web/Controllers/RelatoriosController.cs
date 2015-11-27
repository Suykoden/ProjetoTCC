using System;
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
            ViewBag.DataInicial = DataIni;
            ViewBag.DataFinal = DataFin;

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

        public ActionResult RelatorioLocalidade(string sortOrder, string cidade, string bairro, string estado)
        {
            ViewBag.FornSortParm = String.IsNullOrEmpty(sortOrder) ? "Forn_desc" : "";
            ViewBag.AnuncioSortParm = sortOrder == "Anuncio" ? "Anuncio_desc" : "Anuncio";
            ViewBag.ServSortParm = sortOrder == "Serv" ? "Serv_desc" : "Serv";
            ViewBag.TelSortParm = sortOrder == "Tel" ? "Tel_desc" : "Tel";
            ViewBag.MailSortParm = sortOrder == "Mail" ? "Mail_desc" : "Mail";
            ViewBag.RuaSortParm = sortOrder == "Rua" ? "Rua_desc" : "Rua";
            ViewBag.NumSortParm = sortOrder == "Num" ? "Num_desc" : "Num_";
            ViewBag.BairroSortParm = sortOrder == "Bairro" ? "Bairro_desc" : "Bairro";
            ViewBag.CidadeSortParm = sortOrder == "Cidade" ? "Cidade_desc" : "Cidade";



            if (UsuarioService.ObtemUsuarioLogado() != null)
            {
                var ListaModelo = new AnuncioViewModel
                {
                    ListaViewModel = AnuncioService.RelatorioLocalidade(sortOrder, cidade, bairro, estado)
                };

                return View(ListaModelo);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }
        [HttpPost]
        public ActionResult RelatorioLocalidadeComFiltro(AnuncioViewModel Model)
        {
            return RedirectToAction("RelatorioQualificacao", "Relatorios", new { sortOrder = ViewBag.AnuncioSortParm, cidade = Model.Cidade, bairro = Model.Bairro, estado = Model.Estado });
        }

    }
}