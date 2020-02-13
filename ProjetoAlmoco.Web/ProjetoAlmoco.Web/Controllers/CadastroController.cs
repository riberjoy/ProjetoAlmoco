using ProjetoAlmoco.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjetoAlmoco.Web.Controllers
{
    public class CadastroController : Controller
    {
        

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
                return RedirectToAction("Index", "Login");
            }

            return View(cliente);
        }

    }
}