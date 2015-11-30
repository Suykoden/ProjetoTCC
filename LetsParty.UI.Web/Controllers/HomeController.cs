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
        

        public ActionResult Index()
        {
            if (UsuarioAppService.ObtemUsuarioLogado() != null) //Define se o botão na tela index será entrar ou sair
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
