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


namespace LetsParty.UI.Web.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IUsuarioRepository _UsuarioRepositorio = null;
        LetsPartyContext context = new LetsPartyContext();

        public UsuarioController(IUsuarioRepository usuarioRepositorio)
        {
            _UsuarioRepositorio = usuarioRepositorio;
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
                _UsuarioRepositorio.Insert(usuario);
                return View("Cadastro");
                // RedirectToAction("Cadastro", "Home");

            }
            //return RedirectToAction("Cadastro", "Home");
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
