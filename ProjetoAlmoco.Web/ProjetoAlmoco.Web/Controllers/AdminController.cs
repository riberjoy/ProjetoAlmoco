using ProjetoAlmoco.Web.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjetoAlmoco.Web.Controllers
{
    public class AdminController : Controller
    {
        public List<Categoria> Categorias = new List<Categoria>();
        public List<Alimento> Alimentos = new List<Alimento>();
        public List<Cliente> Clientes = new List<Cliente>();

        // GET: Admin
        public ActionResult Index()
        {
            Categorias = new List<Categoria>();
            //Categoria = **lista obtida por select do banco
            Categorias.Add(new Categoria { CategoriaID = 1, Nome = "Categoria 1" });
            Categorias.Add(new Categoria { CategoriaID = 2, Nome = "Categoria 2" });
            Categorias.Add(new Categoria { CategoriaID = 3, Nome = "Categoria 3" });

            ViewBag.CriaCategorias = Categorias;

            Alimentos = new List<Alimento>();

            Alimentos.Add(new Alimento { AlimentotID = 1, Nome = "Alimento 1", CategoriaID = 1, Ativo = '1' });
            Alimentos.Add(new Alimento { AlimentotID = 2, Nome = "Alimento 2", CategoriaID = 1, Ativo = '1' });

            Alimentos.Add(new Alimento { AlimentotID = 3, Nome = "Alimento 3", CategoriaID = 2, Ativo = '1' });
            Alimentos.Add(new Alimento { AlimentotID = 4, Nome = "Alimento 4", CategoriaID = 2, Ativo = '1' });

            Alimentos.Add(new Alimento { AlimentotID = 5, Nome = "Alimento 5", CategoriaID = 3, Ativo = '1' });
            Alimentos.Add(new Alimento { AlimentotID = 6, Nome = "Alimento 6", CategoriaID = 3, Ativo = '1' });

            ViewBag.CriaAlimentos = Alimentos;

            return View();
        }
        
        public ActionResult LiberarCardapio(string[] id)
        {
            foreach(string idAlimento in id)
            {
                //Int32.Parse(idAlimento))
                //Alterar estes alimntos no banco como ativos
            }
            return RedirectToAction("Index", "Admin");
        }
    }
}