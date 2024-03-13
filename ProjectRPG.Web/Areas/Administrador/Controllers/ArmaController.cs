using Microsoft.AspNetCore.Mvc;
using ProjectRPG.DataAccess.Repository.IRepository;

namespace ProjectRPG.Web.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
                var lista = _unitOfWork.Arma.BuscarTodos().ToList();
                return View(lista);
            }
    }
}
