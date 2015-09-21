﻿using System;
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
            if (UsuarioAppService.ObtemUsuarioLogado() != null)
            {

                ViewBag.Logado = true;
            }
            return View();
        }


        public ActionResult SelecaoTipoUsuario()
        {
            return View("SelecaoTipoUsuario");
        }
        public ActionResult CadastroFornecedor()
        {
            return View("CadastroFornecedor");
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



        public ActionResult Anuncio(Usuario usuario)
        {
            if (UsuarioAppService.ObtemUsuarioLogado() != null)
            {

                return View("Administrativo");
            }
            else
            {
                return View("Login");
            }

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

                UsuarioAppService.AutenticarUsuario(usuario);
                return View("Anuncio");///Todo após logado definir para qual página o usuario será enviado.

            }
            return View("Login");
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

      
       
       
        public ActionResult Deslogar()
        {


            if (ModelState.IsValid)
            {

                UsuarioAppService.Deslogar();
                

            }
            return RedirectToAction("Index","Home");
        }





    }
}
