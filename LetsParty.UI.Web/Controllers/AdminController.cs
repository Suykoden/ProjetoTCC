using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LetsParty.AppService.Usuarios;
using LetsParty.AppService.Anuncios;
using LetsParty.AppService.Fotos;
using LetsParty.AppService.Servicos;
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

        public AdminController(IAnunciosServices anuncioService, IUsuarioAppService usuarioService, IServicoServices servicoService)
        {
            AnuncioService = anuncioService;
            UsuarioService = usuarioService;
            ServicoService = servicoService;
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

    }
}