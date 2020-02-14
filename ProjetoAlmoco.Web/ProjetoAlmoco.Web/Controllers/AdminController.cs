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

        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.Cliente = TempData["Cliente"];
            TempData.Keep("Cliente");

            var categorias = categoriaApp.Get().Content.ReadAsAsync<List<Categoria>>().Result;

            ViewBag.CriaCategorias = categorias;
            return View();
        }


        public ActionResult ListarPedidos(string[] id)
        {
            if(id != null)
            {
                foreach(string idAlimento in id)
                {
                    //Int32.Parse(idAlimento))
                    //Alterar estes alimntos no banco como ativos
                }
                ListaDePedidos();
                return View("_ListarPedidosAdmin");
            }
            ListaDePedidos();
            return View("_ListarPedidos");
        }
            
        public void ListaDePedidos()
        {
            Pedidos = new List<Pedido>();
            List<string> list;
            list = new List<string>() { "Arroz: Branco", "Feijão: Caldo", "Carne: Frango assado" };
            Pedidos.Add(new Pedido { Num_IDCliente = 1, CategoriaAlimento = list.AsEnumerable(), Nom_Cliente ="Cliente 1", });

            list = new List<string>() { "Arroz: Branco", "Feijão: Preto", "Carne: Frango assado" };
            Pedidos.Add(new Pedido { Num_IDCliente = 2, CategoriaAlimento = list.AsEnumerable(), Nom_Cliente = "Cliente 2", });

            list = new List<string>() { "Arroz: Branco", "Feijão: Tropeiro", "Carne: Frango assado" };
            Pedidos.Add(new Pedido { Num_IDCliente = 3, CategoriaAlimento = list.AsEnumerable(), Nom_Cliente = "Cliente 3", });

            ViewBag.ListaPedidos = Pedidos;
        }

        public ActionResult ListarClientes()
        {
            ListaDeClientes();
            return View("_ListarClientes");
        }

        public ActionResult AdcionarPedidos()
        {
            ListaDeClientes();
            return View("_AdcionarPedidos");
        }

        public void ListaDeClientes()
        {
            //Clientes = new List<Cliente>();
            ////Categoria = **lista obtida por select do banco
            //Clientes.Add(new Cliente { Nome = "Cliente 1", Usuario = "User 1", Senha = "123" });
            //Clientes.Add(new Cliente { Nome = "Cliente 2", Usuario = "User 2", Senha = "123" });
            //Clientes.Add(new Cliente { Nome = "Cliente 3", Usuario = "User 2", Senha = "123" });

            ViewBag.BuscaClientes = Clientes;
        }
    }
}