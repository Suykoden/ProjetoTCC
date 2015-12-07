using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LetsParty.Infra.Data.Repository;
using LetsParty.Infra.Data.Context;
using System.Data.Entity;
using LetsParty.Domain.Model.Atores;
using LetsParty.Domain.Repository;
using Ninject.Activation;
using LetsParty.AppService.Usuarios;
using LetsParty.AppService.Servicos;
using LetsParty.AppService.Anuncios;


namespace LetsParty.UI.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuarioAppService UsuarioAppService { get; set; }
        private IServicoServices ServicoService { get; set; }
        private ILetsPartyContext Context { get; set; }
        private IAnunciosServices AnunciosServices { get; set; }

        public UsuarioController(IUsuarioAppService usuarioApp, IServicoServices servicoServices, ILetsPartyContext context, IAnunciosServices anunciosServices)
        {
            UsuarioAppService = usuarioApp;
            ServicoService = servicoServices;
            Context = context;
            AnunciosServices = anunciosServices;
        }
        // GET: Usuario
        public ActionResult Index()
        {
            if (UsuarioAppService.ObtemUsuarioLogado() != null)
            {

                ViewBag.Logado = true;
            }
            return View();
        }

        public ActionResult Cadastro()
        {
            return View("Cadastro");
        }

        public ActionResult Login()
        {
            return View("Login");
        }



        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Id = Guid.NewGuid();
                usuario.DataCadastro = DateTime.Now;
                usuario.DataNascimento = DateTime.Now;
                usuario.Ativo = true;
                UsuarioAppService.Grava(usuario);
                // return View();

            }

            ViewBag.Cadastro = "Sucesso";
            return View("Cadastro");
        }

        public ActionResult Logon()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Logon(Usuario usuario)
        {
            if (ModelState.IsValid)
            {

                if (UsuarioAppService.AutenticarUsuario(usuario) == false)
                {
                    ViewBag.Erro = "Senha ou Login inválidos"; ///Todo após logado definir para qual página o usuario será enviado.
                    return View("Login");
                }

            }
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public ActionResult EditarUsuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                UsuarioAppService.EditarUsuario(usuario);
                Context.SaveChanges();
            }
            return RedirectToAction("AdminListaUsuario", "Admin");
        }
        public ActionResult ExclusaoUsuario(Guid id)
        {
            var _Usuario = UsuarioAppService.BuscaUsuarioPorID(id);
            if (ModelState.IsValid)
            {
                _Usuario.Ativo = false;
                UsuarioAppService.EditarUsuario(_Usuario);
                var ListaAnuncio = AnunciosServices.RetornaAnuncios(_Usuario.Id);
                foreach (var anuncios in ListaAnuncio)
                {
                    anuncios.Ativo = false;
                    AnunciosServices.EditarAnuncio(anuncios);
                   
                }
            }
            Context.SaveChanges();
            return RedirectToAction("Deslogar");
        }

        public ActionResult ExclusaoUsuarioAdmin(Guid id)
        {
            var _Usuario = UsuarioAppService.BuscaUsuarioPorID(id);
            if (ModelState.IsValid)
            {
                _Usuario.Ativo = false;
                UsuarioAppService.EditarUsuario(_Usuario);
                var ListaAnuncio = AnunciosServices.RetornaAnuncios(_Usuario.Id);
                foreach (var anuncios in ListaAnuncio)
                {
                    anuncios.Ativo = false;
                    AnunciosServices.EditarAnuncio(anuncios);

                }
            }
            Context.SaveChanges();
            return RedirectToAction("AdminMonitorUsuario","Admin");
        }

        public ActionResult ReativaUsuario(Guid id)
        {
            var _Usuario = UsuarioAppService.BuscaUsuarioPorID(id);
            if (ModelState.IsValid)
            {
                _Usuario.Ativo = true;
                UsuarioAppService.EditarUsuario(_Usuario);
                var ListaAnuncio = AnunciosServices.RetornaAnuncios(_Usuario.Id);
                foreach (var anuncios in ListaAnuncio)
                {
                    anuncios.Ativo = true;
                    AnunciosServices.EditarAnuncio(anuncios);

                }
            }
            Context.SaveChanges();
            return RedirectToAction("AdminMonitorUsuario", "Admin");
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }




        public ActionResult Deslogar()
        {


            if (ModelState.IsValid)
            {

                UsuarioAppService.Deslogar();

                Session.RemoveAll();
            }
            return RedirectToAction("Index", "Home");
        }





    }
}
