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


namespace LetsParty.UI.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuarioAppService UsuarioAppService { get; set; }
        public UsuarioController(IUsuarioAppService usuarioApp)
        {
            UsuarioAppService = usuarioApp;
        }
        // GET: Usuario
        public ActionResult Index()
        {
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
        public ActionResult Administrativo()
        {
            return View("Administrativo");
        }
        [Authorize]
        public ActionResult Anuncio()
        {
            return View("Anuncio");
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
                UsuarioAppService.Grava(usuario);
                return View("Cadastro");

            }
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

                UsuarioAppService.AutenticarUsuario(usuario);
                return View("Cadastro");

            }
            return View("Cadastro");
        }



        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
    }
}
