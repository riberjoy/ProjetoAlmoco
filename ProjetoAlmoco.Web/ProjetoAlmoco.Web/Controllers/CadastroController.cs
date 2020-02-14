using ProjetoAlmoco.Application.Applications;
using ProjetoAlmoco.Application.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjetoAlmoco.Web.Controllers
{
    public class CadastroController : Controller
    {
        private readonly ClienteApplication clienteApp = new ClienteApplication();

        // GET: Cadastro
        public ActionResult Index()
        {
            var cliente = new Cliente();
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Index(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                clienteApp.Post(cliente);
                return RedirectToAction("Index", "Login");
            }
            return View(cliente);
        }

    }
}