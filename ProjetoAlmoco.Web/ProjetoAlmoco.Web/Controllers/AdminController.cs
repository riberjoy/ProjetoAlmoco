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

            ViewBag.AlimentosAtivos = TempData["Alimentos"];
            TempData.Keep("Alimentos");

            var categorias = categoriaApp.Get().Content.ReadAsAsync<List<Categoria>>().Result;
            ViewBag.CriaCategorias = categorias;
            return View();
        }

        public ActionResult MudarCardapio()
        {
            var categoriasAtivas = categoriaApp.EditarCardapio().Content.ReadAsAsync<List<Categoria>>().Result;
            var alimentos = new List<Alimento>();

            foreach(var cat in categoriasAtivas)
            {
                foreach(var alim in cat.Alimentos)
                {
                    alimentos.Add(alim);
                }
            }

            TempData["Alimentos"] = alimentos;

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

        public ActionResult ListarPedidos(string[] ids)
        {
            ViewBag.Cliente = TempData["Cliente"];
            TempData.Keep("Cliente");

            var alimentos = new List<Alimento>();

            ViewBag.ControleRota = 0;
            ViewBag.Cliente.Num_IDCliente = 0;
            if (ids != null)
            {
                for (int id=0; id < ids.Length; id++)
                {
                    var alimento = new Alimento { 
                        Num_IDAlimento = Convert.ToInt32(ids[id])
                    };
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
            ViewBag.Cliente.Num_IDCliente = 0;
            ViewBag.ControleRota = 1;

            if (idAlimentos != null)
            {

                for (int i=0; i < idAlimentos.Length - 1; i++)
                {
                    var pedido = new Pedido {
                        Num_IDCliente = idCliente,
                        Num_IDAlimento = Convert.ToInt32(idAlimentos[i])
                    };
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
            ViewBag.Cliente = TempData["Cliente"];
            TempData.Keep("Cliente");

            ViewBag.Nom_Cliente = "";

            var categorias = categoriaApp.GetAtivos().Content.ReadAsAsync<List<Categoria>>().Result;
            ViewBag.CriaCategorias = categorias;

            Cliente cliente = clienteApp.GetById(Convert.ToInt32(id)).Content.ReadAsAsync<Cliente>().Result;
            List<Cliente> Cliente = new List<Cliente>();
            Cliente.Add(cliente);
            ViewBag.BuscaClientes = Cliente;

            return View("_AdcionarPedidos");
        }

        public ActionResult DeletarPedidoAdm(int id)
        {
            ViewBag.Cliente = TempData["Cliente"];
            TempData.Keep("Cliente");

            pedidoApp.Delete(id);
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
    }
}