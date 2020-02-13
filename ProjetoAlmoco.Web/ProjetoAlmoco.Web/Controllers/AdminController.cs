using ProjetoAlmoco.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProjetoAlmoco.Web.Controllers
{
    public class AdminController : Controller
    {
        public List<Categoria> Categorias;
        public List<Alimento> Alimentos;
        public List<Cliente> Clientes;
        public List<Pedido> Pedidos;
        
        //Cria a index do admin 
        public ActionResult Index()
        {
            ListaCategoria();
            ViewBag.ControleRota = 0;
            return View();
        }

        //Primeira lista de 
        public ActionResult ListarPedidos(string[] id)
        {
            ViewBag.ControleRota = 0;
            ViewBag.IdCliente = 0;
            if (id != null)
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

        public ActionResult PedidoAdd(string[] id)
        {
            string idCliente = id[id.Length-1];
            ViewBag.IdCliente = 0;
            ViewBag.ControleRota = 1;
            //Se já tiver o pedido apaga do banco, se não cria ele
            if (id != null)
            {
                int cont = 1;
                foreach (string idAlimento in id)
                {
                    if(cont != id.Length - 1)
                    {
                        //Int32.Parse(idAlimento))
                        //Cardapio usuario
                    }
                }
                ListaDePedidos();
                return View("_ListarPedidosAdmin");
            }
            ListaDePedidos();
            return View("_ListarPedidos");
        }


        public ActionResult ListarClientes()
        {
            ListaDeClientes();
            return View("_ListarClientes");
        }

        public ActionResult AdcionarPedidos()
        {
            ListaCategoria();

            ViewBag.CriaAlimentos = Alimentos;
            ViewBag.Cliente = "";
            ListaDeClientes();
            return View("_AdcionarPedidos");
        }

        public ActionResult EditarPedidos(string id)
        {
            ListaCategoria();
            ListaDeClientes();

            ViewBag.Cliente = id;

            return View("_AdcionarPedidos");
        }



        public void ListaCategoria()
        {
            Categorias = new List<Categoria>();
            //Categoria = **lista obtida por select do banco
            Categorias.Add(new Categoria { CategoriaID = 1, Nome = "Categoria 1" });
            Categorias.Add(new Categoria { CategoriaID = 2, Nome = "Categoria 2" });
            Categorias.Add(new Categoria { CategoriaID = 3, Nome = "Categoria 3" });
            ViewBag.CriaCategorias = Categorias;

            Alimentos = new List<Alimento>();
            Alimentos.Add(new Alimento { AlimentotID = 1, Nome = "Alimento 1", CategoriaID = 1, Ativo = '1' });
            Alimentos.Add(new Alimento { AlimentotID = 2, Nome = "Alimento 2", CategoriaID = 1, Ativo = '1' });
            Alimentos.Add(new Alimento { AlimentotID = 3, Nome = "Alimento 3", CategoriaID = 2, Ativo = '1' });
            Alimentos.Add(new Alimento { AlimentotID = 4, Nome = "Alimento 4", CategoriaID = 2, Ativo = '1' });
            Alimentos.Add(new Alimento { AlimentotID = 5, Nome = "Alimento 5", CategoriaID = 3, Ativo = '1' });
            Alimentos.Add(new Alimento { AlimentotID = 6, Nome = "Alimento 6", CategoriaID = 3, Ativo = '1' });
            ViewBag.CriaAlimentos = Alimentos;

        }

        public void ListaDeClientes()
        {
            Clientes = new List<Cliente>();
            //Categoria = **lista obtida por select do banco
            Clientes.Add(new Cliente { Nome = "Cliente 1", Usuario = "User 1", Senha = "123" });
            Clientes.Add(new Cliente { Nome = "Cliente 2", Usuario = "User 2", Senha = "123" });
            Clientes.Add(new Cliente { Nome = "Cliente 3", Usuario = "User 2", Senha = "123" });

            ViewBag.BuscaClientes = Clientes;
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

        public ActionResult DeletarPedidoAdm(int id)
        {
            //deletar pedido do banco!
            //string urlAnterior = System.Web.HttpContext.Current.Request.UrlReferrer.ToString();
            //Redirect(urlAnterior);
            //Redireciona pra url anterior.

            return RedirectToAction("ListarPedidos", "Admin");
        }

        public ActionResult MudarCardapio()
        {
            //Deletar cardapio do banco 
            return RedirectToAction("Index", "Admin");
        }

    }
}