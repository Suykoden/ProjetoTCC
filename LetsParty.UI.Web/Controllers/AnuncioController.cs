using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LetsParty.AppService.Usuarios;
using LetsParty.AppService.Anuncios;
using LetsParty.AppService.Fotos;
using LetsParty.AppService.Servicos;
using LetsParty.AppService.Eventos;
using LetsParty.Domain.Model.Atores;
using LetsParty.Domain.Repository;
using LetsParty.Infra.Data.Repository;
using LetsParty.Infra.Data.Context;
using LetsParty.Domain.ViewModel;
using System.Web.Helpers;

namespace LetsParty.UI.Web.Controllers
{
    public class AnuncioController : Controller
    {
        private IAnunciosServices AnunciosServices { get; set; }
        private IUsuarioAppService UsuarioService { get; set; }
        private IFotoService FotoService { get; set; }
        private IServicoServices ServicoService { get; set; }
        private ILetsPartyContext Context { get; set; }
        private IEventoService EventoService { get; set; }

        public AnuncioController(IAnunciosServices anunciosservices, IUsuarioAppService usuarioService, IFotoService fotoService, IServicoServices servicoServices,
                                 ILetsPartyContext context, IEventoService eventoService)
        {
            AnunciosServices = anunciosservices;
            UsuarioService = usuarioService;
            FotoService = fotoService;
            ServicoService = servicoServices;
            EventoService = eventoService;
            Context = context;
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Fornecedor/Create
        [HttpPost]
        public ActionResult Create(AnuncioViewModel anuncio, HttpPostedFileBase file, HttpPostedFileBase file2, HttpPostedFileBase file3)
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
                _Anuncio.Titulo = anuncio.Titulo;
                _Anuncio.Descricao = anuncio.Descricao;
                _Anuncio.Valor = anuncio.Valor;
                _Anuncio.Ativo = true;

                if (file != null)
                {


                    String[] strName = file.FileName.Split('.');
                    String strExt = strName[strName.Count() - 1];
                    String NomeFoto = strName[0];

                    string Identificador = "Imagem1" + NomeFoto + _Anuncio.Id;

                    string pathSaveThumb = String.Format("{0}{1}.{2}", Server.MapPath("~/ImagensAnuncio/150x150/"), Identificador, strExt);
                    String pathBaseThumb = String.Format("/ImagensAnuncio/150x150/{0}.{1}", Identificador, strExt);

                    string pathSaveBanner = String.Format("{0}{1}.{2}", Server.MapPath("~/ImagensAnuncio/800x300/"), Identificador, strExt);
                    String pathBaseBanner = String.Format("/ImagensAnuncio/800x300/{0}.{1}", Identificador, strExt);


                    file.SaveAs(pathSaveBanner);
                    WebImage WebImagemThumb = new WebImage(file.InputStream);

                    if (WebImagemThumb.Height != 150 || WebImagemThumb.Width != 150)
                    {
                        WebImagemThumb.Resize(150, 150, false, true);

                    }

                    WebImagemThumb.Save(pathSaveThumb);
                    foto.Thumbnail = pathBaseThumb;
                    foto.Caminho = pathBaseBanner;
                }

                if (file2 != null)
                {
                    String[] strName = file2.FileName.Split('.');
                    String strExt = strName[strName.Count() - 1];
                    String NomeFoto = strName[0];

                    string Identificador = "Imagem2" + NomeFoto + _Anuncio.Id;

                    string pathSaveThumb2 = String.Format("{0}{1}.{2}", Server.MapPath("~/ImagensAnuncio/150x150/"), Identificador, strExt);
                    String pathBaseTHumb2 = String.Format("/ImagensAnuncio/150x150/{0}.{1}", Identificador, strExt);

                    string pathSaveBanner2 = String.Format("{0}{1}.{2}", Server.MapPath("~/ImagensAnuncio/800x300/"), Identificador, strExt);
                    String pathBaseBanner2 = String.Format("/ImagensAnuncio/800x300/{0}.{1}", Identificador, strExt);

                    file2.SaveAs(pathSaveBanner2);

                    WebImage WebImagemThumb2 = new WebImage(file2.InputStream);
                    if (WebImagemThumb2.Height != 150 || WebImagemThumb2.Width != 150)
                    {
                        WebImagemThumb2.Resize(150, 150, false, true);
                    }
                    WebImagemThumb2.Save(pathSaveThumb2);
                    foto.Thumbnail2 = pathBaseTHumb2;
                    foto.Caminho2 = pathBaseBanner2;
                }

                if (file3 != null)
                {
                    String[] strName = file3.FileName.Split('.');
                    String strExt = strName[strName.Count() - 1];
                    String NomeFoto = strName[0];

                    string Identificador = "Imagem3" + NomeFoto + _Anuncio.Id;

                    string pathSaveThumb3 = String.Format("{0}{1}.{2}", Server.MapPath("~/ImagensAnuncio/150x150/"), Identificador, strExt);
                    String pathBaseThumb3 = String.Format("/ImagensAnuncio/150x150/{0}.{1}", Identificador, strExt);

                    string pathSaveBanner3 = String.Format("{0}{1}.{2}", Server.MapPath("~/ImagensAnuncio/800x300/"), Identificador, strExt);
                    String pathBaseBanner3 = String.Format("/ImagensAnuncio/800x300/{0}.{1}", Identificador, strExt);

                    file3.SaveAs(pathSaveBanner3);

                    WebImage WebImagemThumb3 = new WebImage(file3.InputStream);
                    if (WebImagemThumb3.Height != 150 || WebImagemThumb3.Width != 150)
                    {
                        WebImagemThumb3.Resize(150, 150, false, true);
                    }
                    WebImagemThumb3.Save(pathSaveThumb3);
                    foto.Thumbnail3 = pathBaseThumb3;
                    foto.Caminho3 = pathBaseBanner3;
                }
                foto.Id = Guid.NewGuid();
                foto.Data = DateTime.Now;
                foto.AnuncioID = _Anuncio.Id;
                foto.ServicoID = anuncio.ServicoID;
                AnunciosServices.Grava(_Anuncio);
                FotoService.Grava(foto);
            }

            return RedirectToAction("AdminListaAnuncio", "Admin");
        }


        public ActionResult Anuncio(Usuario usuario)
        {
            if (UsuarioService.ObtemUsuarioLogado() != null)
            {
                ViewBag.ListaServico = ServicoService.RetornaServicos().ToList();
                return View("Anuncio");
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }

        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditarAnuncio(AnuncioViewModel _AnuncioViewModel)
        {
            if (ModelState.IsValid)
            {
                Anuncio _Anuncio = new Anuncio();
                FotoAnuncio foto = new FotoAnuncio();
                _Anuncio.Titulo = _AnuncioViewModel.Titulo;
                _Anuncio.Descricao = _AnuncioViewModel.Descricao;
                _Anuncio.Id = _AnuncioViewModel.Id;
                _Anuncio.UsuarioID = _AnuncioViewModel.UsuarioID;
                _Anuncio.Data = _AnuncioViewModel.Data;
                _Anuncio.ServicoID = _AnuncioViewModel.ServicoID;
                AnunciosServices.EditarAnuncio(_Anuncio);
                Context.SaveChanges();
            }
            return RedirectToAction("AdminListaAnuncio", "Admin");
        }

        public ActionResult ExclusaoAnuncio(Guid id)
        {
            if (ModelState.IsValid)
            {
                Anuncio anuncio = AnunciosServices.BuscaPorId(id);
                anuncio.Ativo = false;
                AnunciosServices.EditarAnuncio(anuncio);
                Context.SaveChanges();
            }

            return RedirectToAction("AdminListaAnuncio", "Admin");
        }

        public ActionResult ExclusaoAnuncioUsuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var ListaAnuncio = AnunciosServices.RetornaAnuncios(usuario.Id);
                foreach (var anuncios in ListaAnuncio)
                {
                    anuncios.Ativo = false;
                    AnunciosServices.EditarAnuncio(anuncios);
                    Context.SaveChanges();
                }

            }
            return RedirectToAction("Logon", "Usuario");
        }

        public ActionResult PesquisaAnuncio()
        {
            return View("PesquisaAnuncio");
        }

        [HttpPost]
        public ActionResult PesquisaAnuncio(AnuncioViewModel anuncio)
        {

            var ListaModelo = new AnuncioViewModel
            {
                ListaViewModel = AnunciosServices.PesquisaPorDescricao(anuncio).ToList()
            };

            return View(ListaModelo);
        }

        [HttpPost]
        public ActionResult PaginaProduto(AnuncioViewModel _anuncio)
        {
            EventoViewModel _EventoViewModel = EventoService.ObtemNota(_anuncio.AnuncioID);

            var Nota = string.Format("{0:F1}", _EventoViewModel.NotalTotal);

            if (Nota != string.Empty)
            {
                ViewBag.NotaAnuncio = Nota;
                ViewBag.TotalUsers = _EventoViewModel.TotalUsuarios;
            }
            else
            {
                ViewBag.NotaAnuncio = "Sem avaliação";
                ViewBag.TotalUsers = "0";
            }



            return View(_anuncio);
        }

        public ActionResult PesquisaAnuncioCategoria(String Categoria)
        {

            var ListaModelo = new AnuncioViewModel
            {
                ListaViewModel = AnunciosServices.PesquisaPorCategoria(Categoria).ToList()
            };


            return RedirectToAction("PesquisaAnuncio", new { _anuncio = ListaModelo });

        }


    }
}