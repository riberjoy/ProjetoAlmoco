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

        public ActionResult realizaPedidos() // Mandar para o whatsApp
        {
            string pedidosTxt = "Pedidos do dia:%0A%0A" + pedidoApp.TxtPedidos().Content.ReadAsStringAsync().Result;
            alimentoApp.ZerarCardapio();

            string url = "https://api.whatsapp.com/send?phone=${5535998901582}&text=" + pedidosTxt;
            return Redirect(url);
        }

        //------------------------------------------------------------------------------------------------------------

        public ActionResult ListarPedidos(string[] ids)
        {
            ViewBag.Cliente = TempData["Cliente"];
            TempData.Keep("Cliente");

            var alimentos = new List<Alimento>();

            ViewBag.ControleRota = 1;
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

        public ActionResult PedidoAdd(string[] idAlimentos, int Num_IDCliente)
        {
            ViewBag.Cliente = TempData["Cliente"];
            TempData.Keep("Cliente");

            int idCliente = Num_IDCliente;
            ViewBag.ControleRota = 1;

            if (idAlimentos != null)
            {

                for (int i=0; i < idAlimentos.Length; i++)
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

            ViewBag.ControleRota = 1;

            var categorias = categoriaApp.GetAtivos().Content.ReadAsAsync<List<Categoria>>().Result;
            ViewBag.CriaCategorias = categorias;

            if (categorias.Count > 0)
            {
                ViewBag.ControleCardapio = true;
                ViewBag.CriaCategorias = categorias;
            }
            else
            {
                ViewBag.ControleCardapio = false;
            }

            return View("_AdcionarPedidos");
        }

        //Apenas encaminha para view
        public ActionResult EditarPedidos(string id)
        {
            ViewBag.Cliente = TempData["Cliente"];
            TempData.Keep("Cliente");

            ViewBag.Nom_Cliente = "";

            ViewBag.ControleRota = 1;

            ViewBag.ControleCardapio = true;

            var categorias = categoriaApp.GetAtivos().Content.ReadAsAsync<List<Categoria>>().Result;
            ViewBag.CriaCategorias = categorias;

            var cliente = clienteApp.GetById(Convert.ToInt32(id)).Content.ReadAsAsync<Cliente>().Result;
            List<Cliente> Cliente = new List<Cliente> {cliente};

            var pedido = new Pedido { Num_IDCliente = Convert.ToInt32(id) };
            var pedidos = pedidoApp.Put(pedido).Content.ReadAsAsync<List<Pedido>>().Result;
            ViewBag.Pedido = pedidos[0];

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
            if(Convert.ToInt32(id) != 3)
            clienteApp.Delete(Convert.ToInt32(id));
             return RedirectToAction("ListarClientes", "Admin");
        }

        public ActionResult AlterarClienteAdm(ProjetoAlmoco.Web.Models.Cliente cliente)
        {
            var Cliente = new Cliente
            {
                Num_IDCliente = cliente.Id,
                Nom_Cliente = cliente.Nome,
                Nom_Usuario = cliente.Usuario
            };
            clienteApp.Put(Cliente);
            return RedirectToAction("ListarClientes", "Admin");
        }
    }
}