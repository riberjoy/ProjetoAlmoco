using ProjetoAlmoco.Web.Models;
using System.Web.Mvc;

namespace ProjetoAlmoco.Web.Controllers
{
    public class LoginController : Controller
    {
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
                //var userInfo = "Usuario: "+usuario.NomeUsuario+" -- Senha: "+usuario.Senha;
                //ViewBag.selectedUser = userInfo;
                return RedirectToAction("Index","Admin");
                //return View();
            }

            return View(usuario);
        }
    }
}