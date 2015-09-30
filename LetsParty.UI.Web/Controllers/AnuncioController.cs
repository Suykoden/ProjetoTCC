using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LetsParty.AppService.Usuarios;
using LetsParty.AppService.Anuncios;
using LetsParty.Domain.Model.Atores;
using LetsParty.Domain.Repository;
using LetsParty.Infra.Data.Repository;
using LetsParty.Infra.Data.Context;

namespace LetsParty.UI.Web.Controllers
{
    public class AnuncioController : Controller
    {
        private IAnunciosServices AnunciosServices { get; set; }
        private IUsuarioAppService UsuarioService { get; set; }

        public AnuncioController(IAnunciosServices anunciosservices, IUsuarioAppService usuarioService)
        {
            AnunciosServices = anunciosservices;
            UsuarioService = usuarioService;
        }


        public ActionResult Create()
        {
            return View();
        }

        // POST: Fornecedor/Create
        [HttpPost]
        public ActionResult Create(Anuncio anuncio)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));

                // Breakpoint, Log or examine the list with Exceptions.

            }
            if (ModelState.IsValid)
            {
                anuncio.Id = Guid.NewGuid();
                anuncio.UsuarioID = UsuarioService.getIDUsuario();
                anuncio.Data = DateTime.Now;
                AnunciosServices.Grava(anuncio);

            }

            ViewBag.Cadastro = "Sucesso";
            return RedirectToAction("Anuncio", "Usuario");
        }
    }
}