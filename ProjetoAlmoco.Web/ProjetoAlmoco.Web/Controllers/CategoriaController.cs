using ProjetoAlmoco.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoAlmoco.Web.Controllers
{
    public class CategoriaController : Controller
    {
        public ActionResult Index(Categoria categoria)
        {
            //precisa do banco pra fazer o insert
            return RedirectToAction("Index", "Admin");
        }

        public ActionResult Deletar(int id)
        {
            //precisa do banco pra fazer o delete
            return RedirectToAction("Index","Admin");
        }
    }
}