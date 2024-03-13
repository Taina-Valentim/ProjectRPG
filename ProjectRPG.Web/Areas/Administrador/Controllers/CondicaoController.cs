using Microsoft.AspNetCore.Mvc;
using ProjectRPG.DataAccess.Repository.IRepository;

namespace ProjectRPG.Web.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    public class CondicaoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CondicaoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var lista = _unitOfWork.Condicao.BuscarTodos().ToList();
            return View(lista);
        }
    }
}
