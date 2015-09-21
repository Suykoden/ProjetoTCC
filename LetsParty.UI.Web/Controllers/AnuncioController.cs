using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        public AnuncioController(IAnunciosServices anunciosservices)
        {
            AnunciosServices = anunciosservices;
        }


        public ActionResult Create()
        {
            return View();
        }

        // POST: Fornecedor/Create
        [HttpPost]
        public ActionResult Create(Anuncio anuncio)
        {
            if (ModelState.IsValid)
            {
                anuncio.Id = Guid.NewGuid();
                AnunciosServices.Grava(anuncio);

            }

            ViewBag.Cadastro = "Sucesso";
            return RedirectToAction("Anuncio", "Usuario");
        }
    }
}