using LetsParty.AppService.Usuarios;
using LetsParty.AppService.Servicos;
using LetsParty.Domain.ViewModel;
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
        private IServicoServices ServicoService { get; set; }
        public HomeController(IUsuarioAppService usuarioApp, IServicoServices servicoService)
        {
            UsuarioAppService = usuarioApp;
            ServicoService = servicoService;
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
