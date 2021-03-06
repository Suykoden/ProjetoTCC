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
using LetsParty.AppService.Log;
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
        private ILetsPartyContext Context { get; set; }
        private IlogService LogService { get; set; }

        public AdminController(IAnunciosServices anuncioService, IUsuarioAppService usuarioService,
            IServicoServices servicoService, IEventoService eventoService, IStatusService statusService, ILetsPartyContext context, IlogService logService)
        {
            AnuncioService = anuncioService;
            UsuarioService = usuarioService;
            ServicoService = servicoService;
            EventoService = eventoService;
            StatusService = statusService;
            LogService = logService;
            Context = context;

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
            _AnuncioViewModel.Endereco = anuncio.Endereco;
            _AnuncioViewModel.Numero = anuncio.Numero;
            _AnuncioViewModel.Cep = anuncio.Cep;
            _AnuncioViewModel.Cidade = anuncio.Municipio;
            _AnuncioViewModel.Estado = anuncio.Estado;
            _AnuncioViewModel.Bairro = anuncio.Bairro;
            _AnuncioViewModel.Valor = anuncio.Valor;

            ViewBag.ListaServico = ServicoService.RetornaServicos(false).ToList();
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
                Session["Administrador"] = UsuarioService.VerificaAdministrador(IdUsuario);
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

            if (UsuarioService.ObtemUsuarioLogado() != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        public ActionResult AdminMonitorUsuario()
        {

            if (UsuarioService.ObtemUsuarioLogado() != null)
            {

                var ListaUsuarios = new UsuarioViewModel {
                ListaUsuario =   UsuarioService.ListaUsuarios()

            };
                return View(ListaUsuarios);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }

        }

        [HttpPost]
        public ActionResult AdminMonitorUsuario(string nome)
        {

            if (UsuarioService.ObtemUsuarioLogado() != null)
            {

                var ListaUsuarios = new UsuarioViewModel
                {
                    ListaUsuario = UsuarioService.BuscaUsuarioPorNome(nome)

                };
                return View(ListaUsuarios);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }

        }

        public ActionResult AdminMonitorAnuncios()
        {

            if (UsuarioService.ObtemUsuarioLogado() != null)
            {

                IEnumerable<Anuncio> ListaAnuncios = AnuncioService.ListarTodos();


                return View(ListaAnuncios);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }

        }

        public ActionResult AdminMonitorServicos()
        {
            var Servicos = new ServicoViewModel
            {

                ListaServico = ServicoService.RetornaServicos(true)
            };
            return View(Servicos);

        }

        [HttpPost]
        public ActionResult CadastroServico(ServicoViewModel servico)
        {
            Servico _servico = new Servico();
            _servico.Id = Guid.NewGuid();
            _servico.Nome = servico.Nome;
            _servico.Ativo = true;

            ServicoService.GravaServico(_servico);
            return RedirectToAction("AdminMonitorServicos");
        }


        public ActionResult ExclusaoServico(Guid id, string tipo)
        {
            var _Servico = ServicoService.BuscaPorId(id);

            if (tipo == "D")
            {
                if (ModelState.IsValid)
                {
                    _Servico.Ativo = false;
                    ServicoService.EditarServico(_Servico);
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    _Servico.Ativo = true;
                    ServicoService.EditarServico(_Servico);
                }
            }
            Context.SaveChanges();
            return RedirectToAction("AdminMonitorServicos", "Admin");
        }


        public ActionResult AdminMonitorStatus()
        {
            var Status = new StatusViewModel
            {

                ListaStatus = StatusService.RetornaStatus()
            };
            return View(Status);

        }

        [HttpPost]
        public ActionResult CadastroStatus(ServicoViewModel status)
        {
            StatusEvento _status = new StatusEvento();
            _status.Id = Guid.NewGuid();
            _status.status = status.Nome;


            StatusService.GravaStatus(_status);
            return RedirectToAction("AdminMonitorStatus");
        }

        public ActionResult AdminLogEvento(Guid id)
        {
            var Logs = new LogViewModel
            {
                ListaLogs = LogService.RetornaLog(id)
            };

            return View(Logs);
        }


    }
}