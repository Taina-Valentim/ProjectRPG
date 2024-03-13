using Microsoft.AspNetCore.Mvc;
using ProjectRPG.DataAccess.Repository.IRepository;

namespace ProjectRPG.Web.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    public class AtributoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AtributoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var lista = _unitOfWork.Atributo.BuscarTodos().ToList();
            return View(lista);
        }
    }
}
