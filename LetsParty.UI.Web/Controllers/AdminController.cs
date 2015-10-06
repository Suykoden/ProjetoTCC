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

        public AdminController(IAnunciosServices anuncioService, IUsuarioAppService usuarioService)
        {
            AnuncioService = anuncioService;
            UsuarioService = usuarioService;
        }

        public ActionResult Administrativo()
        {

            return View();
        }

        public ActionResult AdminEdicaoAnuncio(Guid id)
        {
            Anuncio anuncio = AnuncioService.BuscaPorId(id);
            AnuncioViewModel _AnuncioViewModel = new AnuncioViewModel();
            _AnuncioViewModel.Titulo = anuncio.Titulo;
            _AnuncioViewModel.Descricao = anuncio.Descricao;
            return View(_AnuncioViewModel);
        }

        public ActionResult AdminListaAnuncio()
        {
           
            var ListaModelo = new AnuncioViewModel
            {
                ListaAnuncio = AnuncioService.RetornaAnuncios(UsuarioService.getIDUsuario()).ToList()
                
            };
           
            return View(ListaModelo);
        }

    }
}