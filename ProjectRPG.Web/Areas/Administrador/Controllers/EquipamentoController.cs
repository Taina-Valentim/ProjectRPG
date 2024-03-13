using Microsoft.AspNetCore.Mvc;
using ProjectRPG.DataAccess.Repository.IRepository;

namespace ProjectRPG.Web.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    public class EquipamentoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public EquipamentoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var lista = _unitOfWork.Equipamento.BuscarTodos().ToList();
            return View(lista);
        }
    }
}
