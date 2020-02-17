using ProjetoAlmoco.Application.Applications;
using ProjetoAlmoco.Web.Models;
using System.Web.Mvc;

namespace ProjetoAlmoco.Web.Controllers
{
    public class AlimentoController : Controller
    {
        private readonly AlimentoApplication alimentoApp = new AlimentoApplication();
        public ActionResult Index(Alimento alimento)
        {
            var Alimento = new Application.Models.Alimento();
            if(alimento != null)
            {
                Alimento.Nom_Alimento = alimento.Nome;
                Alimento.Num_IDCategoria = alimento.CategoriaID;
                alimentoApp.Post(Alimento);
            }

            return RedirectToAction("Index", "Admin");
        }

        // GET: Alimento
        public ActionResult Deletar(int id)
        {
            ViewBag.Cliente = TempData["Cliente"];
            TempData.Keep("Cliente");

            alimentoApp.Delete(id);
            return RedirectToAction("Index", "Admin");
        }
    }
}