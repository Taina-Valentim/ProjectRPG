using Microsoft.AspNetCore.Mvc;
using ProjectRPG.DataAccess.Repository.IRepository;

namespace ProjectRPG.Web.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    public class ItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ItemController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var lista = _unitOfWork.Item.BuscarTodos().ToList();
            return View(lista);
        }
    }
}
