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
        public List<Pedido> Pedidos = new List<Pedido>();

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
            ListaDePedidos();
            return View("Pedido");
        }

        public ActionResult Deletar(int idCliente)
        {
            ViewBag.Cliente = TempData["Cliente"];
            TempData.Keep("Cliente");
            return View();
        }

        public void ListaDePedidos()
        {
            Pedidos = new List<Pedido>();
            List<string> list;

            list = new List<string>() { "Arroz: Branco", "Feijão: Caldo", "Carne: Frango assado" };
            Pedidos.Add(new Pedido { Num_IDCliente = 1, CategoriaAlimento = list.AsEnumerable(), Nom_Cliente = "Cliente 1", });

            list = new List<string>() { "Arroz: Branco", "Feijão: Preto", "Carne: Frango assado" };
            Pedidos.Add(new Pedido { Num_IDCliente = 2, CategoriaAlimento = list.AsEnumerable(), Nom_Cliente = "Cliente 2", });

            list = new List<string>() { "Arroz: Branco", "Feijão: Tropeiro", "Carne: Frango assado" };
            Pedidos.Add(new Pedido { Num_IDCliente = 3, CategoriaAlimento = list.AsEnumerable(), Nom_Cliente = "Cliente 3", });

            ViewBag.ListaPedidos = Pedidos;
        }

        public ActionResult EditarPedido(int id)
        {
            //busca no banco os elementos marcados previamente
            return View("Pedido");
        }
    }
}