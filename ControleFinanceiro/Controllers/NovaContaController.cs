using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleFinanceiro.Controllers
{
    public class NovaContaController : Controller
    {
        
        // GET: NovaConta
        public ActionResult Cadastrar()
        {
            return View();
        }
        public ActionResult Alterar(int? cod)
        {
            if (cod == null || cod == 0)
            {
                return View("Cadastrar");
            }

            
            return View();
        }
        public void Gravar(int? cod, string nome_usuario, string email_usuario, string senha)
        {
            if(nome_usuario.Trim() == "" || email_usuario.Trim() == "" || senha.Trim() == "")
            {
                ViewBag.ret = 0;
            }
           
        }
    }
}