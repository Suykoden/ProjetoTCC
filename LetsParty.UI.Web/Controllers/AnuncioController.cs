using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LetsParty.AppService.Anuncios;
using LetsParty.AppService.Fornecedores;
using LetsParty.Domain.Model.Atores;
using LetsParty.Domain.Repository;
using LetsParty.Infra.Data.Repository;
using LetsParty.Infra.Data.Context;

namespace LetsParty.UI.Web.Controllers
{
    public class AnuncioController : Controller
    {
        private IAnunciosServices AnunciosServices { get; set; }
        private IFornecedorServices FornecedorServices { get; set; }

        public AnuncioController(IAnunciosServices anunciosservices, IFornecedorServices fornecedoresServices)
        {
            AnunciosServices = anunciosservices;
            FornecedorServices = fornecedoresServices;
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
                anuncio.FornecedorID = FornecedorServices.getIDFornecedor();
                AnunciosServices.Grava(anuncio);

            }

            ViewBag.Cadastro = "Sucesso";
            return RedirectToAction("Anuncio", "Usuario");
        }
    }
}