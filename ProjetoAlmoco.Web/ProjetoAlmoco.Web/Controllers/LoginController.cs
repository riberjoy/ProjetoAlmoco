using ProjetoAlmoco.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoAlmoco.Web.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                /*var userInfo = "Usuario: "+usuario.NomeUsuario+" -- Senha: "+usuario.Senha;
                ViewBag.selectedUser = userInfo;*/
                return View();
            }

            return View(usuario);
        }
    }
}