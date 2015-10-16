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

        public AnuncioController(IAnunciosServices anunciosservices, IUsuarioAppService usuarioService, IFotoService fotoService, IServicoServices servicoServices, ILetsPartyContext context)
        {
            AnunciosServices = anunciosservices;
            UsuarioService = usuarioService;
            FotoService = fotoService;
            ServicoService = servicoServices;
            Context = context;
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
                _Anuncio.Titulo = anuncio.Titulo;
                _Anuncio.Descricao = anuncio.Descricao;
                _Anuncio.Ativo = true;

                if (file != null)
                {

                    String[] strName = file.FileName.Split('.');
                    String strExt = strName[strName.Count() - 1];

                    string pathSave = String.Format("{0}{1}.{2}", Server.MapPath("~/ImagensAnuncio/"), _Anuncio.Id, strExt);
                    String pathBase = String.Format("/ImagensAnuncio/{0}.{1}", _Anuncio.Id, strExt);


                    WebImage _WebImagem = new WebImage(file.InputStream);


                    _WebImagem.Resize(150, 150, false, true);
                    _WebImagem.Save(pathSave);

                    // file.SaveAs(pathSave);
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
            return RedirectToAction("Anuncio");
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


        public ActionResult PaginaProduto()
        {
            return View("PaginaProduto");
        }


        public ActionResult ThumbNail(int largura, int altura)
        {
            WebImage webImagem = new WebImage(@"C:\imagem.png")
                .Resize(largura, altura, false, false);

            return File(webImagem.GetBytes(), "image/png");
        }

    }
}