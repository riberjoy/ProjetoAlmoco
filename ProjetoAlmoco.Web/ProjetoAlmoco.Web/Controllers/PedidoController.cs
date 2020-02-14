using ProjetoAlmoco.Application.Applications;
using ProjetoAlmoco.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ProjetoAlmoco.Web.Controllers
{
    public class PedidoController : Controller
    {
        private readonly PedidoApplication pedidoApp = new PedidoApplication();
        public ActionResult DeletarPedidoCliente(int id)
        {
            pedidoApp.Delete(id);
            TempData["Pedido"] = null;
            ViewBag.Pedido = TempData["Pedido"];

            return RedirectToAction("Index", "Cliente");
        }

        public ActionResult EditarPedidoAdm()
        {
            //Reencaminha para outra action
            return RedirectToAction("EditarPedidos", "Admin");
        }

        public ActionResult EditarPedidoCliente(int id)
        {
            Pedido pedido = new Pedido();
            pedido.Num_IDCliente = id;

            var pedidos = pedidoApp.Put(pedido).Content.ReadAsAsync<List<Pedido>>().Result;
            TempData["Pedido"] = pedidos[0];
            ViewBag.Pedido = TempData["Pedido"];
            TempData.Keep("Pedido");

            return RedirectToAction("Index", "Cliente");
        }

    }
}