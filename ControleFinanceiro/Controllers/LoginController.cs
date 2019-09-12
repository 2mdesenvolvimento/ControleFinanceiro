using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleFinanceiro.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login(string email_usuario, string senha)
        {
            if (email_usuario.Trim() == "" || senha.Trim() == "")
            {
                ViewBag.ret = 0;
            }
            return View();
        }
    }
}