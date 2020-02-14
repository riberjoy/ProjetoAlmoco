using ProjetoAlmoco.Application.Applications;
using ProjetoAlmoco.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;

namespace ProjetoAlmoco.Web.Controllers
{
    public class AdminController : Controller
    {
        public List<Categoria> Categorias;
        public List<Alimento> Alimentos;
        public List<Cliente> Clientes;
        public List<Pedido> Pedidos;

        private readonly CategoriaApplication categoriaApp = new CategoriaApplication();
        private readonly ClienteApplication clienteApp = new ClienteApplication();
        private readonly PedidoApplication pedidoApp = new PedidoApplication();

        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.Cliente = TempData["Cliente"];

            TempData.Keep("Cliente");

            var categorias = categoriaApp.Get().Content.ReadAsAsync<List<Categoria>>().Result;
            ViewBag.CriaCategorias = categorias;
            return View();
        }

        public ActionResult MudarCardapio()
        {
            //Deleta cardapio disponivel 
            return RedirectToAction("Index", "Admin");
        }

        //------------------------------------------------------------------------------------------------------------

        public ActionResult ListarPedidos(string[] id)
        {
            ViewBag.ControleRota = 0;
            ViewBag.IdCliente = 0;
            if (id != null)
            {
                foreach (string idAlimento in id)
                {
                    //Int32.Parse(idAlimento))
                    //Alterar estes alimntos no banco como ativos
                }
                //Retornar todos clientes!
                ViewBag.ListaPedidos = pedidoApp.Get().Content.ReadAsAsync<List<Pedido>>().Result;
                return View("_ListarPedidosAdmin");
            }
            //Retornar todos clientes!
            ViewBag.ListaPedidos = pedidoApp.Get().Content.ReadAsAsync<List<Pedido>>().Result;
            return View("_ListarPedidos");
        }

        public ActionResult PedidoAdd(string[] idAlimentos)
        {
            int idCliente = Int32.Parse(idAlimentos[idAlimentos.Length - 1]);
            ViewBag.IdCliente = 0;
            ViewBag.ControleRota = 1;

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
                return View("_ListarPedidosAdmin");
            }
            ViewBag.ListaPedidos = pedidoApp.GetById(idCliente).Content.ReadAsAsync<List<Pedido>>().Result;
            return View("_ListarPedidos");
        }

        public ActionResult NovoPedido()
        {
            ViewBag.CriaAlimentos = Alimentos;
            ViewBag.Cliente = "";

            var clientes = clienteApp.Get().Content.ReadAsAsync<List<Cliente>>().Result;
            ViewBag.BuscaClientes = clientes;

            var categorias = categoriaApp.Get().Content.ReadAsAsync<List<Categoria>>().Result;
            ViewBag.CriaCategorias = categorias;

            return View("_AdcionarPedidos");
        }

        public ActionResult EditarPedidos(string id)
        {
            var categorias = categoriaApp.Get().Content.ReadAsAsync<List<Categoria>>().Result;
            ViewBag.CriaCategorias = categorias;

            var clientes = clienteApp.Get().Content.ReadAsAsync<List<Cliente>>().Result;
            ViewBag.BuscaClientes = clientes;

            ViewBag.Cliente = id;
            return View("_AdcionarPedidos");
        }

        public ActionResult DeletarPedidoAdm(int id)
        {
            //Apaga pedido do banco!
            return RedirectToAction("ListarPedidos", "Admin");
        }


        //----------------------------------------------------------------------------------------------------------------

        public ActionResult ListarClientes()
        {
            var clientes = clienteApp.Get().Content.ReadAsAsync<List<Cliente>>().Result;
            ViewBag.BuscaClientes = clientes;
            return View("_ListarClientes");
        }

        public ActionResult DeletarClienteAdm(string id)
        {
            //Apaga cliente do banco!
             return RedirectToAction("ListarClientes", "Admin");
        }

        public ActionResult AlterarClienteAdm(Cliente cliente)
        {
            //Alterar o cliente no banco!
            return RedirectToAction("ListarClientes", "Admin");
        }
    }
}