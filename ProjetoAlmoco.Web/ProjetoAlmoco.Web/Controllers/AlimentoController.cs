using ProjetoAlmoco.Web.Models;
using System.Web.Mvc;

namespace ProjetoAlmoco.Web.Controllers
{
    public class AlimentoController : Controller
    {
        public ActionResult Index(Alimento alimento)
        {
            //precisa do banco pra fazer o insert
            return RedirectToAction("Index", "Admin");
        }

        // GET: Alimento
        public ActionResult Deletar(int id)
        {
            //precisa do banco pra fazer o delete
            return RedirectToAction("Index", "Admin");
        }
    }
}