using ProjetoAlmoco.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoAlmoco.Web.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            List<string> Categorias = new List<string>();
            Categorias.Add("item1");
            Categorias.Add("item2");
            ViewBag.CriaCategorias = Categorias;

            List<string> Alimentos = new List<string>();
            Alimentos.Add("Alimento 1 ");
            Alimentos.Add("Alimento 2");
            ViewBag.CriaAlimentos = Alimentos;

            return View();
        }

        [HttpPost]
        public ActionResult Index(Categoria categoria)
        {
            return RedirectToAction("Index");
        }
    }
}