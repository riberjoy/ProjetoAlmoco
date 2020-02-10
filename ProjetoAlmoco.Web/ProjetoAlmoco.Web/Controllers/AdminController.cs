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
        public List<Categoria> Categorias = new List<Categoria>();
        public List<Alimento> Alimentos = new List<Alimento>();
        public List<Cliente> Clientes = new List<Cliente>();

        // GET: Admin
        public ActionResult Index()
        {
            
            Categorias = new List<Categoria>();
            //Categoria = **lista obtida por select do banco
            Categorias.Add(new Categoria{ CategoriaID=1, Nome = "Categoria 1"});
            Categorias.Add(new Categoria { CategoriaID = 2, Nome = "Categoria 2" });
            Categorias.Add(new Categoria { CategoriaID = 3, Nome = "Categoria 3" });

            ViewBag.CriaCategorias = Categorias;


            Alimentos = new List<Alimento>();

            Alimentos.Add(new Alimento { AlimentotID = 1, Nome = "Alimento 1", CategoriaID = 1, Ativo = '1'});
            Alimentos.Add(new Alimento { AlimentotID = 2, Nome = "Alimento 2", CategoriaID = 1, Ativo = '1'});

            Alimentos.Add(new Alimento { AlimentotID = 3, Nome = "Alimento 3", CategoriaID = 2, Ativo = '1'});
            Alimentos.Add(new Alimento { AlimentotID = 4, Nome = "Alimento 4", CategoriaID = 2, Ativo = '1'});

            Alimentos.Add(new Alimento { AlimentotID = 5, Nome = "Alimento 5", CategoriaID = 3, Ativo = '1'});
            Alimentos.Add(new Alimento { AlimentotID = 6, Nome = "Alimento 6", CategoriaID = 3, Ativo = '1'});

            

            ViewBag.CriaAlimentos = Alimentos;
            ViewBag.AvisoCategoria = "Esta categoria será apagada incluindo todos seus pratos cadastrados.";
            ViewBag.AvisoAlimento = Alimentos;
            ViewBag.CriaAlimentos = Alimentos;

            return View();
        }

        public ActionResult Deletar(string op, int id)
        {
            if (op.Equals("Alimento"))
            {
                //Deleta categoria do db
            }else if (op.Equals("Alimento"))
            {
                //Deleta alimento do db
            }
            else if(op.Equals("Cliente"))
            {
                //Deleta cliente do db
            }
            return RedirectToAction("Index");
        }
    }
}