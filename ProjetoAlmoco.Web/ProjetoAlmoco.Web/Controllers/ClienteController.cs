using ProjetoAlmoco.Application.Applications;
using ProjetoAlmoco.Application.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace ProjetoAlmoco.Web.Controllers
{
    public class ClienteController : Controller
    {
        public List<Categoria> Categorias = new List<Categoria>();
        public List<Alimento> Alimentos = new List<Alimento>();
        public List<Cliente> Pedido = new List<Cliente>();

        private readonly CategoriaApplication categoriaApp = new CategoriaApplication();
        private readonly PedidoApplication pedidoApp = new PedidoApplication();

        public ActionResult Index()
        {
            ViewBag.Cliente = TempData["Cliente"];
            TempData.Keep("Cliente");

            var categorias = categoriaApp.GetAtivos().Content.ReadAsAsync<List<Categoria>>().Result;
            if (categorias.Count> 0)
            {
                ViewBag.ControleCardapio = true;
                ViewBag.CriaCategorias = categorias;
            }
            else
            {
                ViewBag.ControleCardapio = false;
            }
            return View();
        }

        public ActionResult EnviarPedido(string[] idAlimentos)
        {
            ViewBag.Cliente = TempData["Cliente"];
            TempData.Keep("Cliente");
            int idCliente = ViewBag.Cliente.Num_IDCliente;

            Pedido pedido = new Pedido();
            pedido.Num_IDCliente = idCliente;

            if (idAlimentos != null)
            {
                foreach (string idAlimento in idAlimentos)
                {
                    pedido.Num_IDAlimento = Int32.Parse(idAlimento);
                    pedidoApp.Post(pedido);
                }
                ViewBag.ListaPedidos = pedidoApp.GetById(idCliente).Content.ReadAsAsync<List<Pedido>>().Result;
                return View("PedidoCliente");
            }
            return View("Pedido");
        }

        public ActionResult Deletar(int idCliente)
        {
            ViewBag.Cliente = TempData["Cliente"];
            TempData.Keep("Cliente");
            return View();
        }
    }
}