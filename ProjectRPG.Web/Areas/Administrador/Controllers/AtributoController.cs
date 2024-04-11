using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectRPG.DataAccess.Repository.IRepository;
using ProjectRPG.Utilitarios;

namespace ProjectRPG.Web.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    [Authorize(Roles = SD.Role_Administrador)]
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
