using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LetsParty.UI.Web.Controllers
{
    public class AdminController : Controller
    {

        public ActionResult Administrativo()
        {
            return View("Administrativo");
        }

        public ActionResult AdminEdicaoAnuncio()
        {
            return View("AdminEdicaoAnuncio");
        }

        public ActionResult AdminListaAnuncio()
        {
            return View("AdminListaAnuncio");
        }


    }
}