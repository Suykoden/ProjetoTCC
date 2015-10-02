using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LetsParty.AppService.Usuarios;
using LetsParty.AppService.Anuncios;
using LetsParty.AppService.Fotos;
using LetsParty.Domain.Model.Atores;
using LetsParty.Domain.Repository;
using LetsParty.Infra.Data.Repository;
using LetsParty.Infra.Data.Context;
using LetsParty.Domain.ViewModel;

namespace LetsParty.UI.Web.Controllers
{
    public class AnuncioController : Controller
    {
        private IAnunciosServices AnunciosServices { get; set; }
        private IUsuarioAppService UsuarioService { get; set; }
        private IFotoService FotoService { get; set; }

        public AnuncioController(IAnunciosServices anunciosservices, IUsuarioAppService usuarioService, IFotoService fotoService)
        {
            AnunciosServices = anunciosservices;
            UsuarioService = usuarioService;
            FotoService = fotoService;
        }


        public ActionResult Create()
        {
            return View();
        }

        // POST: Fornecedor/Create
        [HttpPost]
        public ActionResult Create(AnuncioViewModel anuncio, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));

                // Breakpoint, Log or examine the list with Exceptions.

            }
            if (ModelState.IsValid)
            {
                Anuncio _Anuncio = new Anuncio();
                FotoAnuncio foto = new FotoAnuncio();

                _Anuncio.Id = Guid.NewGuid();
                _Anuncio.UsuarioID = UsuarioService.getIDUsuario();
                _Anuncio.Data = DateTime.Now;
                _Anuncio.ServicoID = anuncio.ServicoID;

                if (file != null)
                {
                    String[] strName = file.FileName.Split('.');
                    String strExt = strName[strName.Count() - 1];
                    string pathSave = String.Format("{0}{1}.{2}", Server.MapPath("~/ImagensAnuncio/"), _Anuncio.UsuarioID, strExt);
                    String pathBase = String.Format("/ImagensAnuncio/{0}.{1}", _Anuncio.UsuarioID, strExt);
                    file.SaveAs(pathSave);
                    foto.Caminho = pathBase;
                }
                foto.Id = Guid.NewGuid();
                foto.Data = DateTime.Now;
                foto.AnuncioID = _Anuncio.Id;
                foto.ServicoID = anuncio.ServicoID;

                AnunciosServices.Grava(_Anuncio);
                FotoService.Grava(foto);

            }

            ViewBag.Cadastro = "Sucesso";
            return RedirectToAction("Anuncio", "Usuario");
        }
    }
}