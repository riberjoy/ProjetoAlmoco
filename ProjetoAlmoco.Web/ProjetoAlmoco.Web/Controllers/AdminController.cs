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
        private readonly AlimentoApplication alimentoApp = new AlimentoApplication();

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

        public void realizaPedidos() // Mandar para o whatsApp
        {
            string pedidos;
            pedidos = "Pedidos do dia:%0D";

            var clientes = clienteApp.Get().Content.ReadAsAsync<List<Cliente>>().Result;
            ViewBag.BuscaClientes = clientes;

            var pedidosClientes  = pedidoApp.Get().Content.ReadAsAsync<List<Pedido>>().Result;
            foreach(var cl in clientes) {
                pedidos = pedidos + "%0D" + cl.Nom_Cliente + ": ";
                foreach (var pd in pedidosClientes)
                {
                    if(cl.Num_IDCliente == pd.Num_IDCliente)
                    {
                        //pedidos = pedidos +pd.Num_IDAlimento;
                    }
                }
            }
            //https://api.whatsapp.com/send?phone=${5535998368852}&text=@Pedidos
        }

        //------------------------------------------------------------------------------------------------------------

        public ActionResult ListarPedidos(string[] id)
        {
            ViewBag.Cliente = TempData["Cliente"];
            TempData.Keep("Cliente");

            var alimentos = new List<Alimento>();
            var alimento = new Alimento();

            ViewBag.ControleRota = 0;
            ViewBag.IdCliente = 0;
            if (id != null)
            {
                foreach (string idAlimento in id)
                {
                    alimento.Num_IDAlimento = Convert.ToInt32(idAlimento);
                    alimentos.Add(alimento);
                }
                alimentoApp.SalvarCardapio(alimentos);

                ViewBag.ListaPedidos = pedidoApp.Get().Content.ReadAsAsync<List<Pedido>>().Result;
                return View("_ListarPedidosAdmin");
            }
            ViewBag.ListaPedidos = pedidoApp.Get().Content.ReadAsAsync<List<Pedido>>().Result;
            return View("_ListarPedidos");
        }

        public ActionResult PedidoAdd(string[] idAlimentos)
        {
            ViewBag.Cliente = TempData["Cliente"];
            TempData.Keep("Cliente");

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
                ViewBag.ListaPedidos = pedidoApp.Get().Content.ReadAsAsync<List<Pedido>>().Result;
                return View("_ListarPedidosAdmin");
            }
            ViewBag.ListaPedidos = pedidoApp.GetById(idCliente).Content.ReadAsAsync<List<Pedido>>().Result;
            return View("_ListarPedidos");
        }

        //Apenas encaminha para view
        public ActionResult NovoPedido()
        {
            ViewBag.Cliente = TempData["Cliente"];
            TempData.Keep("Cliente");
            ViewBag.CriaAlimentos = Alimentos;

            var clientes = clienteApp.Get().Content.ReadAsAsync<List<Cliente>>().Result;
            ViewBag.BuscaClientes = clientes;

            var categorias = categoriaApp.GetAtivos().Content.ReadAsAsync<List<Categoria>>().Result;
            ViewBag.CriaCategorias = categorias;

            return View("_AdcionarPedidos");
        }

        //Apenas encaminha para view
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
            ViewBag.Cliente = TempData["Cliente"];
            TempData.Keep("Cliente");
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

    }
}