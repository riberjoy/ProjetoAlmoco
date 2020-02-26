using ProjetoAlmoco.Application.Applications;
using ProjetoAlmoco.Application.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;

namespace ProjetoAlmoco.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ClienteApplication clienteApp = new ClienteApplication();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Index","Login");
        }

        [HttpPost]
        public ActionResult Index(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var cliente = clienteApp.ConsLogin(usuario).Content.ReadAsAsync<Cliente>().Result;
                if (cliente != null)
                {
                    TempData["Cliente"] = cliente;
                    if (cliente.Num_IDCliente == 3)
                        return RedirectToAction("ListarPedidos", "Admin");
                    else
                        return RedirectToAction("Index", "Cliente");
                }
                return RedirectToAction("Index","Login");
            }

            return View(usuario);
        }
        public ActionResult LoginUnico(string Nom_Usuario)
        {
            var clientes = clienteApp.Get().Content.ReadAsAsync<List<Cliente>>().Result;
            var clientesString = new Collection<string>();
            foreach(Cliente cliente in clientes)
            {
                clientesString.Add(cliente.Nom_Usuario);
            };
            return Json(clientesString.All(x => x.ToLower() != Nom_Usuario.ToLower()), JsonRequestBehavior.AllowGet);
        }
    }
}