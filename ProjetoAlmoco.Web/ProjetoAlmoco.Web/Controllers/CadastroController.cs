using ProjetoAlmoco.Application.Applications;
using ProjetoAlmoco.Application.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        //public ActionResult Login(string Nom_Usuario)
        //{
        //    var clientes = clienteApp.Get().Content.ReadAsAsync<List<Cliente>>().Result;
        //    var Nom_Usuarios = new List<string>();
        //    foreach(string usuario in Nom_Usuarios)
        //    {
        //        Nom_Usuarios.Add(usuario);
        //    }
        //    return Json(Nom_Usuarios.All(x => x.ToLower() != Nom_Usuario.ToLower()), JsonRequestBehavior.AllowGet);
        //}
    }
}