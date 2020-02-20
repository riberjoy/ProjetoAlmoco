using ProjetoAlmoco.Application.Applications;
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
        private readonly CategoriaApplication categoriaApp = new CategoriaApplication();
        public ActionResult Index(Categoria categoria)
        {
            var Categoria = new ProjetoAlmoco.Application.Models.Categoria();

            ViewBag.Cliente = TempData["Cliente"];
            TempData.Keep("Cliente");

            if (categoria != null)
            {
                Categoria.Nom_Categoria = categoria.Nome;
                categoriaApp.Post(Categoria);
            }
            return RedirectToAction("Index", "Admin");
        }

        public ActionResult Deletar(int id)
        {
            categoriaApp.Delete(id);

            return RedirectToAction("Index", "Admin");
        }
    }
}