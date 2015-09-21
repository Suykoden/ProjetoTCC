using LetsParty.AppService.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LetsParty.UI.Web.Controllers
{
    public class HomeController : Controller
    {

        private IUsuarioAppService UsuarioAppService { get; set; }
        public HomeController(IUsuarioAppService usuarioApp)
        {
            UsuarioAppService = usuarioApp;
        }
        //public ActionResult Index()
        //{
        //    //Em 30.05.15 rafael damasio
        //    //comentei o retorno da action para alterar para que a action retorne a pagina inicial do projeto.
        //    //Não sei se era importante
        //   // var listaUsuarios = UsuarioAppService.RetornaUsuario().ToList();
        //    // return View(listaUsuarios);

        //    return View();
        //}

        public ActionResult Index()
        {
            if (UsuarioAppService.ObtemUsuarioLogado() != null)
            {

                ViewBag.Logado = true;
            }
            else
            {
                ViewBag.Logado = false;
            }

            return View();
        }

        public ActionResult Cadastro()
        {

            return View();

        }
        public ActionResult Login()
        {

            return View();

        }
        public ActionResult Administrativo()
        {
            return View();
        }
        public ActionResult Anuncio()
        {
            return View();
        }

      
    }
}
