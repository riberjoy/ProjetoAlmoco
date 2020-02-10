using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoAlmoco.Web.Controllers
{
    public class PedidoController : Controller
    {
        [HttpPost]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Selecionar(string op)
        {
            return View();
        }

        [HttpDelete]
        public ActionResult Deletar(int id)
        {
            return View();
        }
    }
}