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

        public ActionResult AdminEdicaoAnuncio()
        {
            return View("AdminEdicaoAnuncio");
        }

        public ActionResult AdminListaAnuncio()
        {
            var ListaAnuncio = AnuncioService.RetornaAnuncios(UsuarioService.getIDUsuario()).ToList();
            AnuncioViewModel _AnuncioViewModel = new AnuncioViewModel();
    
            foreach(var anuncios in ListaAnuncio ){

                _AnuncioViewModel.Titulo = anuncios.Titulo;
                _AnuncioViewModel.Descricao = anuncios.Descricao;
                
            }
            return View(_AnuncioViewModel);
        }


    }
}