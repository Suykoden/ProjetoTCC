using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LetsParty.AppService.Fornecedores;
using LetsParty.Domain.Model.Atores;
using LetsParty.Domain.Repository;
using LetsParty.Infra.Data.Repository;
using LetsParty.Infra.Data.Context;

namespace LetsParty.UI.Web.Controllers
{
    public class FornecedorController : Controller
    {

        private IFornecedorServices FornecedoresServices { get; set; }

        public FornecedorController(IFornecedorServices fornecedoresServices)
        {
            FornecedoresServices = fornecedoresServices;
        }


        public ActionResult Create()
        {
            return View();
        }

        // POST: Fornecedor/Create
        [HttpPost]
        public ActionResult Create(Fornecedor Fornecedor)
        {
            if (ModelState.IsValid)
            {
                Fornecedor.Id = Guid.NewGuid();
                Fornecedor.DataCadastro = DateTime.Now;
                FornecedoresServices.Grava(Fornecedor);
               
            }

            ViewBag.Cadastro = "Sucesso";
            return RedirectToAction("CadastroFornecedor","Usuario");
        }

    }
}