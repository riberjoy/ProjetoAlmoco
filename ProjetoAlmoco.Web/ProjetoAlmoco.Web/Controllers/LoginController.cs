using ProjetoAlmoco.Application.Applications;
using ProjetoAlmoco.Application.Models;
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
                        return RedirectToAction("Index", "Admin");
                    else
                        return RedirectToAction("Index", "Cliente");
                }
                else { }
                //var userInfo = "Usuario: "+usuario.NomeUsuario+" -- Senha: "+usuario.Senha;
                //ViewBag.selectedUser = userInfo;

                return RedirectToAction("Index","Admin");
                //return View();
            }

            return View(usuario);
        }
    }
}