using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoAlmoco.Web.Controllers
{
    public class PedidoController : Controller
    {

        public ActionResult DeletarPedidoCliente(int id)
        {
            //deletar pedido do banco!
            //string urlAnterior = System.Web.HttpContext.Current.Request.UrlReferrer.ToString();
            //Redirect(urlAnterior);
            //Redireciona pra url anterior.

            return RedirectToAction("Index", "Cliente");
        }



       

        public ActionResult EditarPedidoAdm()
        {
            //Deletar cardapio do banco 
            return RedirectToAction("EditarPedidos", "Admin");
        }

        public ActionResult EditarPedidoCliente()
        {
            return RedirectToAction("Index", "Cliente");
        }

    }
}