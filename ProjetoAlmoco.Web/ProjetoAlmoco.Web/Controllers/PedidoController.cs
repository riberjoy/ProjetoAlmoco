using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoAlmoco.Web.Controllers
{
    public class PedidoController : Controller
    {
        
        public ActionResult ListarPedidos()
        {
            return View();
        }

        public ActionResult ListaPedido(string op)
        {
            return View();
        }

        public ActionResult Deletar(int id)
        {
            return RedirectToAction("ListarPedidos", "Admin");
        }

        public ActionResult MudarCardapio()
        {
            //Deletar cardapio do banco 
            return RedirectToAction("Index", "Admin");
        }

    }
}